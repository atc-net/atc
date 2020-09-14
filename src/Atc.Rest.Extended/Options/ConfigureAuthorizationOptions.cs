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
                throw new InvalidOperationException("AuthorizationTenant not defined");
            }

            if (string.IsNullOrEmpty(apiOptions.Authorization.ClientId))
            {
                throw new InvalidOperationException("AuthorizationClientId not defined");
            }

            if (!apiOptions.Authorization.ValidAudiences.Any())
            {
                throw new InvalidOperationException("AuthorizationValidAudiences is empty");
            }

            options.Authority = $"https://login.microsoftonline.com/{apiOptions.AuthorizationTenant}/";
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudiences = apiOptions.AuthorizationValidAudiences,
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