// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
// ReSharper disable ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
namespace Atc.Rest.Extended.Options;

/// <summary>
/// Post-configures JWT Bearer authentication and authorization options based on <see cref="RestApiExtendedOptions"/>.
/// Handles issuer signing key retrieval from OpenID Connect configuration and token validation setup.
/// </summary>
public class ConfigureAuthorizationOptions :
    IPostConfigureOptions<JwtBearerOptions>,
    IPostConfigureOptions<AuthenticationOptions>
{
    private const string WellKnownOpenidConfiguration = ".well-known/openid-configuration";
    private static readonly TimeSpan SigningKeyFetchTimeout = TimeSpan.FromSeconds(30);
    private readonly IWebHostEnvironment? environment;
    private readonly RestApiExtendedOptions apiOptions;
    private readonly ILogger<ConfigureAuthorizationOptions>? logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigureAuthorizationOptions"/> class.
    /// </summary>
    /// <param name="options">The REST API extended options containing authorization configuration.</param>
    /// <param name="environment">The web host environment for checking development mode.</param>
    /// <param name="logger">Optional logger for diagnostics during signing-key resolution.</param>
    public ConfigureAuthorizationOptions(
        RestApiExtendedOptions options,
        IWebHostEnvironment? environment,
        ILogger<ConfigureAuthorizationOptions>? logger = null)
    {
        this.environment = environment;
        this.logger = logger;
        apiOptions = options ?? throw new ArgumentNullException(nameof(options));
    }

    /// <summary>
    /// Post-configures JWT Bearer options with token validation parameters and issuer signing keys.
    /// </summary>
    /// <param name="name">The name of the options instance being configured.</param>
    /// <param name="options">The <see cref="JwtBearerOptions"/> to configure.</param>
    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
    [SuppressMessage("Design", "CA5404:Do not disable token validation checks", Justification = "OK.")]
    public void PostConfigure(
        string? name,
        JwtBearerOptions options)
    {
        if (apiOptions.Authorization is not null &&
            !apiOptions.Authorization.IsSecurityEnabled())
        {
            if (apiOptions.Authorization.ValidIssuers is null ||
                apiOptions.Authorization.Issuer is null)
            {
                options.TokenValidationParameters.ValidateIssuer = false;
            }

            if (apiOptions.Authorization.ValidAudiences is null ||
                apiOptions.Authorization.Audience is null)
            {
                options.TokenValidationParameters.ValidateAudience = false;
            }

            return;
        }

        if (apiOptions.AllowAnonymousAccessForDevelopment && environment?.IsDevelopment() == true)
        {
            return;
        }

        if (apiOptions.Authorization is null)
        {
            options.TokenValidationParameters.ValidateIssuer = false;
            options.TokenValidationParameters.ValidateAudience = false;
            return;
        }

        SanityCheck(options);

        if (apiOptions.Authorization.ValidAudiences?.Any() == false)
        {
            apiOptions.Authorization.ValidAudiences = new List<string>
            {
                apiOptions.Authorization.ClientId,
                $"api://{apiOptions.Authorization.ClientId}",
            };
        }

        if (!string.IsNullOrEmpty(apiOptions.Authorization.Instance) &&
            !string.IsNullOrEmpty(apiOptions.Authorization.TenantId))
        {
            options.Authority = $"{apiOptions.Authorization.Instance}/{apiOptions.Authorization.TenantId}/";
        }

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidAudience = apiOptions.Authorization.Audience,
            ValidAudiences = apiOptions.Authorization.ValidAudiences,
            ValidateIssuer = !string.IsNullOrWhiteSpace(apiOptions.Authorization.Issuer) ||
                             apiOptions.Authorization.ValidIssuers?.Any() == true,
        };

        if (!options.TokenValidationParameters.ValidateIssuer)
        {
            return;
        }

        options.TokenValidationParameters.ValidIssuer = apiOptions.Authorization.Issuer;
        options.TokenValidationParameters.ValidIssuers = apiOptions.Authorization.ValidIssuers ?? new List<string>();

        // Run the async fetch on a thread-pool thread with a hard timeout so we cannot deadlock
        // on a captured sync-context and cannot hang application startup indefinitely if an
        // identity provider is unreachable.
        var fetchTask = Task.Run(() => GetIssuerSigningKeysAsync(options));
        if (!fetchTask.Wait(SigningKeyFetchTimeout))
        {
            logger?.LogWarning(
                "Timed out fetching issuer signing keys after {TimeoutSeconds}s. Token validation will fall back to empty key set; signing-key validation disabled.",
                SigningKeyFetchTimeout.TotalSeconds);
            options.TokenValidationParameters.IssuerSigningKeys = Array.Empty<SecurityKey>();
            options.TokenValidationParameters.ValidateIssuerSigningKey = false;
            return;
        }

        options.TokenValidationParameters.IssuerSigningKeys = fetchTask.Result;
        options.TokenValidationParameters.ValidateIssuerSigningKey = options.TokenValidationParameters.IssuerSigningKeys.Any();
    }

    /// <summary>
    /// Post-configures authentication options to use JWT Bearer as the default authentication scheme.
    /// </summary>
    /// <param name="name">The name of the options instance being configured.</param>
    /// <param name="options">The <see cref="AuthenticationOptions"/> to configure.</param>
    public void PostConfigure(
        string? name,
        AuthenticationOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }

    /// <summary>
    /// Retrieves issuer signing keys from the OpenID Connect configuration endpoint.
    /// </summary>
    /// <param name="issuer">The issuer URL.</param>
    /// <returns>
    /// A collection of security keys for token validation, or an empty array if retrieval failed
    /// (the failure is logged via the configured <see cref="ILogger"/>; callers should treat an
    /// empty result as "signing keys unavailable").
    /// </returns>
    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "Failure to fetch keys must not abort startup; we log and return empty so the caller decides.")]
    private async Task<IEnumerable<SecurityKey>> GetIssuerSigningKeysAsync(
        string issuer)
    {
        try
        {
            var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                $"{issuer}/{WellKnownOpenidConfiguration}",
                new OpenIdConnectConfigurationRetriever());

            var configuration = await configurationManager.GetConfigurationAsync();
            return configuration.SigningKeys;
        }
        catch (Exception e)
        {
            logger?.LogWarning(
                e,
                "Failed to retrieve OpenID Connect signing keys from {Issuer}. Token validation will fall back to an empty key set for this issuer.",
                issuer);
            return Array.Empty<SecurityKey>();
        }
    }

    private async Task<IEnumerable<SecurityKey>> GetIssuerSigningKeysAsync(
        JwtBearerOptions options)
    {
        var issuerSigningKeys = new List<SecurityKey>();

        if (!string.IsNullOrEmpty(options.Authority))
        {
            issuerSigningKeys.AddRange(
                await GetIssuerSigningKeysAsync(
                    options.Authority));
        }

        if (apiOptions.Authorization is not null &&
            !string.IsNullOrWhiteSpace(apiOptions.Authorization.Issuer))
        {
            issuerSigningKeys.AddRange(
                await GetIssuerSigningKeysAsync(
                    apiOptions.Authorization.Issuer));
        }

        foreach (var issuer in options.TokenValidationParameters.ValidIssuers)
        {
            issuerSigningKeys.AddRange(
                await GetIssuerSigningKeysAsync(
                    issuer));
        }

        return issuerSigningKeys;
    }

    private void SanityCheck(JwtBearerOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        if (apiOptions.Authorization is null ||
            (string.IsNullOrEmpty(apiOptions.Authorization.ClientId) &&
            string.IsNullOrEmpty(apiOptions.Authorization.Audience)))
        {
            throw new InvalidOperationException($"Missing ClientId and Audience. Please verify the {Atc.Rest.Options.AuthorizationOptions.ConfigurationSectionName} section in appSettings and ensure that the ClientId or Audience is specified");
        }
    }
}