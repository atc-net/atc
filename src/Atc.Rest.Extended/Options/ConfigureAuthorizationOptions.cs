// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
// ReSharper disable ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
namespace Atc.Rest.Extended.Options;

public class ConfigureAuthorizationOptions :
    IPostConfigureOptions<JwtBearerOptions>,
    IPostConfigureOptions<AuthenticationOptions>
{
    private const string WellKnownOpenidConfiguration = ".well-known/openid-configuration";
    private readonly IWebHostEnvironment? environment;
    private readonly RestApiExtendedOptions apiOptions;

    public ConfigureAuthorizationOptions(
        RestApiExtendedOptions options,
        IWebHostEnvironment? environment)
    {
        this.environment = environment;
        apiOptions = options ?? throw new ArgumentNullException(nameof(options));
    }

    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
    [SuppressMessage("Design", "CA5404:Do not disable token validation checks", Justification = "OK.")]
    [SuppressMessage("Usage", "VSTHRD002:Avoid problematic synchronous waits", Justification = "OK.")]
    public void PostConfigure(string name, JwtBearerOptions options)
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

        options.TokenValidationParameters.IssuerSigningKeys = GetIssuerSigningKeysAsync(options).GetAwaiter().GetResult();
        options.TokenValidationParameters.ValidateIssuerSigningKey = options.TokenValidationParameters.IssuerSigningKeys.Any();
    }

    public void PostConfigure(string name, AuthenticationOptions options)
    {
        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }

    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    private static async Task<IEnumerable<SecurityKey>> GetIssuerSigningKeysAsync(string issuer)
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
            Debug.WriteLine(e);
            return Array.Empty<SecurityKey>();
        }
    }

    private async Task<IEnumerable<SecurityKey>> GetIssuerSigningKeysAsync(JwtBearerOptions options)
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