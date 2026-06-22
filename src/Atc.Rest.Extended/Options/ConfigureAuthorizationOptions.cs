// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
// ReSharper disable ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
namespace Atc.Rest.Extended.Options;

/// <summary>
/// Post-configures JWT Bearer authentication and authorization options based on <see cref="RestApiExtendedOptions"/>.
/// Signing-key discovery is delegated to JwtBearer's built-in <see cref="Microsoft.IdentityModel.Protocols.ConfigurationManager{T}"/>,
/// which fetches and caches the OIDC discovery document on the first authentication request using the <see cref="JwtBearerOptions.Authority"/> set here.
/// </summary>
public class ConfigureAuthorizationOptions :
    IPostConfigureOptions<JwtBearerOptions>,
    IPostConfigureOptions<AuthenticationOptions>
{
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
    /// Post-configures JWT Bearer options with token validation parameters.
    /// Signing keys are not pre-fetched; JwtBearer's built-in <see cref="Microsoft.IdentityModel.Protocols.ConfigurationManager{T}"/>
    /// discovers and caches them from the OIDC discovery endpoint on the first authentication request.
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

            // Always validate the token signature (fail-closed). This is never relaxed below,
            // so a transient key-fetch failure can never cause unverified tokens to be accepted.
            ValidateIssuerSigningKey = true,
        };

        if (!options.TokenValidationParameters.ValidateIssuer)
        {
            return;
        }

        options.TokenValidationParameters.ValidIssuer = apiOptions.Authorization.Issuer;
        options.TokenValidationParameters.ValidIssuers = apiOptions.Authorization.ValidIssuers ?? new List<string>();

        // Signing keys are discovered lazily by JwtBearer's built-in ConfigurationManager via options.Authority.
        // Pre-fetching here blocked application startup for up to 30 s and duplicated JwtBearer's own mechanism.
        logger?.LogInformation(
            "JWT signing-key discovery deferred: keys will be fetched from {Authority} on the first authentication request.",
            options.Authority);
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