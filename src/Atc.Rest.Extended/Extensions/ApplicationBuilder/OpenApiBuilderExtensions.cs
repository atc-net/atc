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
                app.UseSwaggerUI(options =>
                {
                    app.ConfigureSwaggerEndpointPerApiVersion(options, restApiOptions);
                    options.EnableValidator();
                    options.DocExpansion(DocExpansion.List);
                    options.SupportedSubmitMethods(SubmitMethod.Get, SubmitMethod.Post, SubmitMethod.Put, SubmitMethod.Patch, SubmitMethod.Delete);
                    options.DefaultModelRendering(ModelRendering.Model);
                    options.DisplayRequestDuration();
                    options.EnableDeepLinking();
                    options.ShowCommonExtensions();
                    options.DocumentTitle = typeof(TStartup).GetApiName(true);
                    options.InjectStylesheet("/swagger-ui/style.css");
                    options.InjectJavascript("/swagger-ui/main.js");

                    setupAction(options);
                });
            }

            return app;
        }

        private static void ConfigureSwaggerEndpointPerApiVersion(
            this IApplicationBuilder app,
            SwaggerUIOptions options,
            RestApiExtendedOptions restApiOptions)
        {
            if (restApiOptions.UseApiVersioning)
            {
                var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }
            }
            else
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Default");
            }
        }
    }
}