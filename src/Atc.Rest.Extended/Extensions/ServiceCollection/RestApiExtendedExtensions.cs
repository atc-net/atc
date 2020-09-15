using System;
using Atc.Rest.Extended.Options;
using Atc.Rest.Options;
using Microsoft.Extensions.Configuration;

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
            RestApiExtendedOptions restApiOptions,
            IConfiguration configuration)
        {
            return services.AddRestApi<TStartup>(mvc => { }, restApiOptions, configuration);
        }

        public static IServiceCollection AddRestApi<TStartup>(
            this IServiceCollection services,
            Action<IMvcBuilder> setupMvcAction,
            RestApiExtendedOptions restApiOptions,
            IConfiguration configuration)
        {
            if (setupMvcAction == null)
            {
                throw new ArgumentNullException(nameof(setupMvcAction));
            }

            if (restApiOptions == null)
            {
                throw new ArgumentNullException(nameof(restApiOptions));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.AddSingleton(restApiOptions);
            services.AddSingleton<RestApiOptions>(restApiOptions);

            if (restApiOptions.UseApiVersioning)
            {
                services.ConfigureOptions<ConfigureApiVersioningOptions>();
                services.AddApiVersioning();
                services.AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'VV");
            }

            if (restApiOptions.UseOpenApiSpec)
            {
                services.ConfigureOptions<ConfigureSwaggerOptions>();
                services.AddOpenApiSpec<TStartup>(restApiOptions);
            }

            services.AddRestApi<TStartup>(setupMvcAction, restApiOptions);

            if (restApiOptions.UseFluentValidation)
            {
                services.AddFluentValidation<TStartup>(restApiOptions.UseAutoRegistrateServices, restApiOptions.AssemblyPairs);
            }

            configuration.Bind(AuthorizationOptions.ConfigurationSectionName, restApiOptions.Authorization);
            services.ConfigureOptions<ConfigureAuthorizationOptions>();
            services.AddAuthentication().AddJwtBearer();

            return services;
        }
    }
}