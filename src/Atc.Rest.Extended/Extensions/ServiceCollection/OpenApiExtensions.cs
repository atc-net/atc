using System;
using System.IO;
using Atc.Rest.Extended.Filters;
using Atc.Rest.Extended.Options;
using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.SwaggerGen;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class OpenApiExtensions
    {
        public static IServiceCollection AddOpenApiSpec<TStartup>(this IServiceCollection services)
        {
            return services.AddOpenApiSpec<TStartup>(new RestApiExtendedOptions(), _ => { });
        }

        public static IServiceCollection AddOpenApiSpec<TStartup>(
            this IServiceCollection services,
            RestApiExtendedOptions restApiOptions)
        {
            return services.AddOpenApiSpec<TStartup>(restApiOptions, _ => { });
        }

        public static IServiceCollection AddOpenApiSpec<TStartup>(
            this IServiceCollection services,
            RestApiExtendedOptions restApiOptions,
            Action<SwaggerGenOptions> setupAction)
        {
            services.AddSwaggerGen(options =>
            {
                options.TagActionsBy(api =>
                {
                    if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
                    {
                        return new[] { controllerActionDescriptor.ControllerName };
                    }

                    if (api.HttpMethod != null)
                    {
                        return new[] { api.HttpMethod };
                    }

                    throw new InvalidOperationException("Unable to determine tag for endpoint.");
                });

                options.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");
                options.IgnoreObsoleteActions();
                options.IgnoreObsoleteProperties();
                options.DefaultResponseForSecuredOperations();
                options.TreatBadRequestAsDefaultResponse();

                if (!restApiOptions.AllowAnonymousAccessForDevelopment)
                {
                    options.OperationFilter<SecurityRequirementsOperationFilter>();
                }

                options.DocumentFilter<SwaggerEnumDescriptionsDocumentFilter>();

                if (restApiOptions.UseApiVersioning)
                {
                    options.ApplyApiVersioningFilters();
                    options.ApplyApiVersioningSwaggerDocuments(services, typeof(TStartup).GetApiName());
                }

                options.IncludeXmlComments(Path.ChangeExtension(typeof(TStartup).Assembly.Location, "xml"));

                foreach (var assemblyPairOptions in restApiOptions.AssemblyPairs)
                {
                    options.IncludeXmlComments(Path.ChangeExtension(assemblyPairOptions.ApiAssembly.Location, "xml"));
                }

                setupAction(options);
            });

            return services;
        }
    }
}