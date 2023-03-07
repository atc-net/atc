// ReSharper disable InvertIf
// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class RestApiExtendedExtensions
{
    public static IServiceCollection AddRestApi<TStartup>(
        this IServiceCollection services)
        => services.AddRestApi<TStartup>(mvc => { }, new RestApiExtendedOptions());

    public static IServiceCollection AddRestApi<TStartup>(
        this IServiceCollection services,
        RestApiExtendedOptions restApiOptions,
        IConfiguration configuration)
        => services.AddRestApi<TStartup>(mvc => { }, restApiOptions, configuration);

    public static IServiceCollection AddRestApi<TStartup>(
        this IServiceCollection services,
        Action<IMvcBuilder> setupMvcAction,
        RestApiExtendedOptions restApiOptions,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(setupMvcAction);
        ArgumentNullException.ThrowIfNull(restApiOptions);
        ArgumentNullException.ThrowIfNull(configuration);

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
            services.AddSwaggerGen();
        }

        services.AddRestApi<TStartup>(setupMvcAction, restApiOptions);

        if (restApiOptions.UseFluentValidation)
        {
            services.AddFluentValidation<TStartup>(restApiOptions.UseAutoRegistrateServices, restApiOptions.AssemblyPairs);
        }

        if (restApiOptions.Authorization is not null)
        {
            configuration.Bind(Atc.Rest.Options.AuthorizationOptions.ConfigurationSectionName, restApiOptions.Authorization);
            services.ConfigureOptions<ConfigureAuthorizationOptions>();
            services.AddAuthentication().AddJwtBearer();
        }

        return services;
    }
}