using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Atc.Rest.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace Atc.Rest.Extended.Options
{
    public class ConfigureAuthorizationOptions :
        IPostConfigureOptions<JwtBearerOptions>,
        IPostConfigureOptions<AuthenticationOptions>
    {
        private const string WellKnownOpenidConfiguration = ".well-known/openid-configuration";
        private readonly IWebHostEnvironment environment;
        private readonly RestApiExtendedOptions apiOptions;

        public ConfigureAuthorizationOptions(
            RestApiExtendedOptions options,
            IWebHostEnvironment environment)
        {
            this.environment = environment;
            apiOptions = options ?? throw new ArgumentNullException(nameof(options));
        }

        public void PostConfigure(string name, JwtBearerOptions options)
        {
            if (apiOptions.AllowAnonymousAccessForDevelopment && environment?.IsDevelopment() == true)
            {
                return;
            }

            SanityCheck(options);

            if (apiOptions.Authorization.ValidAudiences?.Any() == false)
            {
                apiOptions.Authorization.ValidAudiences = new List<string>
                {
                    apiOptions.Authorization.ClientId,
                    $"api://{apiOptions.Authorization.ClientId}"
                };
            }

            options.Authority = $"{apiOptions.Authorization.Instance}/{apiOptions.Authorization.TenantId}/";
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudience = apiOptions.Authorization.Audience,
                ValidAudiences = apiOptions.Authorization.ValidAudiences,
            };

            options.TokenValidationParameters.ValidateIssuer =
                !string.IsNullOrWhiteSpace(apiOptions.Authorization.Issuer) ||
                apiOptions.Authorization.ValidIssuers?.Any() == true;

            if (!options.TokenValidationParameters.ValidateIssuer)
            {
                return;
            }

            options.TokenValidationParameters.ValidIssuer = apiOptions.Authorization.Issuer;
            options.TokenValidationParameters.ValidIssuers =
                apiOptions.Authorization.ValidIssuers ?? new List<string>();

            var issuerSigningKeys = new List<SecurityKey>();

            if (!string.IsNullOrEmpty(apiOptions.Authorization.Instance) &&
                !string.IsNullOrEmpty(apiOptions.Authorization.TenantId))
            {
                issuerSigningKeys.AddRange(
                    GetIssuerSigningKeys(options.Authority)
                        .GetAwaiter()
                        .GetResult());
            }

            if (!string.IsNullOrWhiteSpace(apiOptions.Authorization.Issuer))
            {
                issuerSigningKeys.AddRange(
                    GetIssuerSigningKeys(apiOptions.Authorization.Issuer)
                        .GetAwaiter()
                        .GetResult());
            }

            foreach (var issuer in options.TokenValidationParameters.ValidIssuers)
            {
                issuerSigningKeys.AddRange(
                    GetIssuerSigningKeys(issuer)
                        .GetAwaiter()
                        .GetResult());
            }

            options.TokenValidationParameters.ValidateIssuerSigningKey = true;
            options.TokenValidationParameters.IssuerSigningKeys = issuerSigningKeys;
            options.RequireHttpsMetadata = false;
        }

        public void PostConfigure(string name, AuthenticationOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }

        [SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "Not all issuers are used as the base URL for the well known OpenID configuration")]
        private static async Task<IEnumerable<SecurityKey>> GetIssuerSigningKeys(string issuer)
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

        private void SanityCheck(JwtBearerOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (string.IsNullOrEmpty(apiOptions.Authorization.Instance) &&
                string.IsNullOrEmpty(apiOptions.Authorization.TenantId))
            {
                throw new InvalidOperationException(
                    $"Missing Instance and TenantId. Please verify the {AuthorizationOptions.ConfigurationSectionName} section in appsettings");
            }

            if (string.IsNullOrEmpty(apiOptions.Authorization.ClientId) &&
                string.IsNullOrEmpty(apiOptions.Authorization.Audience))
            {
                throw new InvalidOperationException(
                    $"Missing ClientId and Audience. Please verify the {AuthorizationOptions.ConfigurationSectionName} section in appsettings and ensure that the ClientId or Audience is specified");
            }
        }
    }
}