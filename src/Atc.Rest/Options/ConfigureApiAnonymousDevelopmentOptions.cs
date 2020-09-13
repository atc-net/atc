using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Atc.Rest.Options
{
    public class ConfigureApiAnonymousDevelopmentOptions : IConfigureOptions<MvcOptions>
    {
        private readonly IWebHostEnvironment env;
        private readonly RestApiOptions apiOptions;

        public ConfigureApiAnonymousDevelopmentOptions(
            IWebHostEnvironment env,
            RestApiOptions apiOptions)
        {
            this.env = env ?? throw new ArgumentNullException(nameof(env));
            this.apiOptions = apiOptions ?? throw new ArgumentNullException(nameof(apiOptions));
        }

        public void Configure(MvcOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.Filters.Add(
                apiOptions.AllowAnonymousAccessForDevelopment && env.IsDevelopment()
                    ? new AllowAnonymousFilter()
                    : new AuthorizeFilter(
                        new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build()) as IFilterMetadata);
        }
    }
}