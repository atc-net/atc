using System;
using Atc.Rest.Extended.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerUI;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder
{
    public static class OpenApiBuilderExtensions
    {
        public static IApplicationBuilder UseOpenApiSpec<TStartup>(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            return app.UseOpenApiSpec<TStartup>(env, new RestApiExtendedOptions(), _ => { });
        }

        public static IApplicationBuilder UseOpenApiSpec<TStartup>(
            this IApplicationBuilder app,
            IWebHostEnvironment env,
            RestApiExtendedOptions restApiOptions)
        {
            return app.UseOpenApiSpec<TStartup>(env, restApiOptions, _ => { });
        }

        public static IApplicationBuilder UseOpenApiSpec<TStartup>(
            this IApplicationBuilder app,
            IWebHostEnvironment env,
            RestApiExtendedOptions restApiOptions,
            Action<SwaggerUIOptions> setupAction)
        {
            if (env == null)
            {
                throw new ArgumentNullException(nameof(env));
            }

            if (restApiOptions == null)
            {
                throw new ArgumentNullException(nameof(restApiOptions));
            }

            if (!restApiOptions.UseOpenApiSpec)
            {
                return app;
            }

            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseSwaggerUI();
            }

            return app;
        }
    }
}