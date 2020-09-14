using System.Reflection;
using Atc;
using Atc.Rest.Extended.Options;
using Atc.Rest.Options;
using Demo.Api.Full.Configuration;
using Demo.Api.Generated;
using Demo.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Api.Full
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            restApiOptions = new RestApiExtendedOptions
            {
                // Base
                AllowAnonymousAccessForDevelopment = true,
                UseApplicationInsights = true,
                UseAutoRegistrateServices = true,
                UseEnumAsStringInSerialization = true,
                ErrorHandlingExceptionFilter = new RestApiOptionsErrorHandlingExceptionFilter
                {
                    Enable = true,
                    UseProblemDetailsAsResponseBody = true,
                    IncludeExceptionDetails = true
                },
                UseRequireHttpsPermanent = true,
                UseJsonSerializerOptionsIgnoreNullValues = true,
                JsonSerializerCasingStyle = CasingStyle.CamelCase,
                UseValidateServiceRegistrations = true,

                // Extended
                UseApiVersioning = true,
                UseFluentValidation = true,
                UseOpenApiSpec = true,

                // Auth
                AuthorizationClientId = "e7cbb57b-4d3d-4cf4-b8df-175ca5120fa2",
                AuthorizationTenant = "8089c11e-7333-4156-8602-1203b5aad8dd",
                AuthorizationValidAudiences = new[]
                {
                    "e7cbb57b-4d3d-4cf4-b8df-175ca5120fa2",
                    "api://e7cbb57b-4d3d-4cf4-b8df-175ca5120fa2"
                }
            };

            restApiOptions.AddAssemblyPairs(
                Assembly.GetAssembly(typeof(ApiGenerated)),
                Assembly.GetAssembly(typeof(DomainRegistration)));
        }

        public IConfiguration Configuration { get; }

        private readonly RestApiExtendedOptions restApiOptions;

        public void ConfigureServices(IServiceCollection services)
        {
            if (!restApiOptions.UseAutoRegistrateServices)
            {
                // Manual ConfigureServices
                services.ConfigureServices();
            }

            services.AddRestApi<Startup>(restApiOptions, Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureRestApi(env, restApiOptions);
        }
    }
}