using System;
using Atc.Rest.Extended.Options;
using Microsoft.AspNetCore.Hosting;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder
{
    public static class RestApiExtendedBuilderExtensions
    {
        public static IApplicationBuilder ConfigureRestApi(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            return app.ConfigureRestApi(env, new RestApiExtendedOptions(), _ => { });
        }

        public static IApplicationBuilder ConfigureRestApi(
            this IApplicationBuilder app,
            IWebHostEnvironment env,
            RestApiExtendedOptions restApiOptions)
        {
            return app.ConfigureRestApi(env, restApiOptions, _ => { });
        }

        public static IApplicationBuilder ConfigureRestApi(
            this IApplicationBuilder app,
            IWebHostEnvironment env,
            RestApiExtendedOptions restApiOptions,
            Action<IApplicationBuilder> setupAction)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (env == null)
            {
                throw new ArgumentNullException(nameof(env));
            }

            if (restApiOptions == null)
            {
                throw new ArgumentNullException(nameof(restApiOptions));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            app.UseRestApi(env, restApiOptions, setupAction);

            if (restApiOptions.UseOpenApiSpec)
            {
                app.UseOpenApiSpec(env, restApiOptions);
            }

            return app;
        }
    }
}