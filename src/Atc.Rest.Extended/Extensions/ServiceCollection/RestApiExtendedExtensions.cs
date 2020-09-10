using System;
using Atc.Rest.Extended.Options;
using Atc.Rest.Options;

// ReSharper disable InvertIf
// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class RestApiExtendedExtensions
    {
        public static IServiceCollection AddRestApi<TStartup>(this IServiceCollection services)
        {
            return services.AddRestApi<TStartup>(mvc => { }, new RestApiExtendedOptions());
        }

        public static IServiceCollection AddRestApi<TStartup>(
            this IServiceCollection services,
            RestApiExtendedOptions restApiOptions)
        {
            return services.AddRestApi<TStartup>(mvc => { }, restApiOptions);
        }

        public static IServiceCollection AddRestApi<TStartup>(
            this IServiceCollection services,
            Action<IMvcBuilder> setupMvcAction,
            RestApiExtendedOptions restApiOptions)
        {
            if (setupMvcAction == null)
            {
                throw new ArgumentNullException(nameof(setupMvcAction));
            }

            if (restApiOptions == null)
            {
                throw new ArgumentNullException(nameof(restApiOptions));
            }

            services.AddSingleton(restApiOptions);

            if (restApiOptions.UseApiVersioning)
            {
                services.ConfigureOptions<ConfigureApiVersioningOptions>();
                services.AddApiVersioning();
                services.AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'VV");
            }

            if (restApiOptions.UseOpenApiSpec)
            {
                services.AddOpenApiSpec<TStartup>(restApiOptions);
            }

            services.AddRestApi<TStartup>(setupMvcAction, restApiOptions as RestApiOptions);

            if (restApiOptions.UseFluentValidation)
            {
                services.AddFluentValidation<TStartup>(restApiOptions.UseAutoRegistrateServices, restApiOptions.AssemblyPairs);
            }

            return services;
        }
    }
}