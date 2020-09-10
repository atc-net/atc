using System;
using System.Diagnostics.CodeAnalysis;
using Atc.Rest.Extensions;
using Atc.Rest.Middleware;
using Atc.Rest.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder
{
    public static class RestApiBuilderExtensions
    {
        public static IApplicationBuilder UseRestApi(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            return app.UseRestApi(env, new RestApiOptions(), _ => { });
        }

        public static IApplicationBuilder UseRestApi(
            this IApplicationBuilder app,
            IWebHostEnvironment env,
            RestApiOptions restApiOptions)
        {
            return app.UseRestApi(env, restApiOptions, _ => { });
        }

        [SuppressMessage("Minor Code Smell", "S4507:Delivering code in production with debug features activated is security-sensitive", Justification = "OK.")]
        public static IApplicationBuilder UseRestApi(
            this IApplicationBuilder app,
            IWebHostEnvironment env,
            RestApiOptions restApiOptions,
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

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            setupAction(app);

            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });

            app.UseMiddleware<KeepAliveMiddleware>();
            app.UseMiddleware<RequestCorrelationMiddleware>();
            app.UseMiddleware<ExceptionTelemetryMiddleware>();
            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
                },
            });

            app.UseRouting();

            if (!restApiOptions.AllowAnonymousAccessForDevelopment)
            {
                app.UseAuthentication();
                app.UseAuthorization();
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapApiSpecificationEndpoint(restApiOptions.AssemblyPairs);
                endpoints.MapControllers();
            });

            return app;
        }
    }
}