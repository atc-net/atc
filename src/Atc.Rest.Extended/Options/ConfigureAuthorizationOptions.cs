using System;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Atc.Rest.Extended.Options
{
    public class ConfigureAuthorizationOptions :
        IPostConfigureOptions<JwtBearerOptions>,
        IPostConfigureOptions<AuthenticationOptions>
    {
        private readonly RestApiExtendedOptions apiOptions;

        public ConfigureAuthorizationOptions(
            RestApiExtendedOptions options)
        {
            apiOptions = options ?? throw new ArgumentNullException(nameof(options));
        }

        public void PostConfigure(string name, JwtBearerOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (string.IsNullOrEmpty(apiOptions.Authorization.TenantId))
            {
                throw new InvalidOperationException("Missing TenantId. Please verify the AzureAd section in appsettings");
            }

            if (string.IsNullOrEmpty(apiOptions.Authorization.ClientId))
            {
                throw new InvalidOperationException("Missing ClientId. Please verify the AzureAd section in appsettings");
            }

            if (!apiOptions.Authorization.ValidAudiences.Any())
            {
                apiOptions.Authorization.ValidAudiences = new[]
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
        }

        public void PostConfigure(string name, AuthenticationOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }
    }
}