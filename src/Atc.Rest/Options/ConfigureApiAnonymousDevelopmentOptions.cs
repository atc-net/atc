using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Atc.Rest.Options
{
    public class ConfigureApiAnonymousDevelopmentOptions : IConfigureOptions<MvcOptions>
    {
        private readonly IWebHostEnvironment env;

        public ConfigureApiAnonymousDevelopmentOptions(IWebHostEnvironment env)
        {
            this.env = env ?? throw new ArgumentNullException(nameof(env));
        }

        public void Configure(MvcOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (env.IsDevelopment())
            {
                options.Filters.Add(new AllowAnonymousFilter());
            }
        }
    }
}