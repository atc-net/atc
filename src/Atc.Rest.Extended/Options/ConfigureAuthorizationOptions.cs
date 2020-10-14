using System;
using System.Collections.Generic;
using System.Linq;
using Atc.Rest.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Atc.Rest.Extended.Options
{
    public class ConfigureAuthorizationOptions :
        IPostConfigureOptions<JwtBearerOptions>,
        IPostConfigureOptions<AuthenticationOptions>
    {
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
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (apiOptions.AllowAnonymousAccessForDevelopment && environment?.IsDevelopment() == true)
            {
                return;
            }

            if (string.IsNullOrEmpty(apiOptions.Authorization.TenantId))
            {
                throw new InvalidOperationException(
                    $"Missing TenantId. Please verify the {AuthorizationOptions.ConfigurationSectionName} section in appsettings");
            }

            if (string.IsNullOrEmpty(apiOptions.Authorization.ClientId) && string.IsNullOrEmpty(apiOptions.Authorization.Audience))
            {
                throw new InvalidOperationException(
                    $"Missing ClientId and Audience. Please verify the {AuthorizationOptions.ConfigurationSectionName} section in appsettings and ensure that the ClientId or Audience is specified");
            }

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

            if (options.TokenValidationParameters.ValidateIssuer)
            {
                options.TokenValidationParameters.ValidIssuer = apiOptions.Authorization.Issuer;
                options.TokenValidationParameters.ValidIssuers = apiOptions.Authorization.ValidIssuers ?? new List<string>();
            }
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