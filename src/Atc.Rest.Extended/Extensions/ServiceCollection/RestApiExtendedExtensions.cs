// ReSharper disable InvertIf
// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for adding REST API services with extended features to the service collection.
/// </summary>
public static class RestApiExtendedExtensions
{
    /// <summary>
    /// Adds REST API services with default extended options.
    /// </summary>
    /// <typeparam name="TStartup">The startup type used to locate API resources.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> instance.</param>
    /// <returns>The <see cref="IServiceCollection"/> instance for method chaining.</returns>
    public static IServiceCollection AddRestApi<TStartup>(
        this IServiceCollection services)
        => services.AddRestApi<TStartup>(mvc => { }, new RestApiExtendedOptions());

    /// <summary>
    /// Adds REST API services with custom extended options and configuration.
    /// </summary>
    /// <typeparam name="TStartup">The startup type used to locate API resources.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> instance.</param>
    /// <param name="restApiOptions">The REST API extended options.</param>
    /// <param name="configuration">The application configuration for binding authorization settings.</param>
    /// <returns>The <see cref="IServiceCollection"/> instance for method chaining.</returns>
    public static IServiceCollection AddRestApi<TStartup>(
        this IServiceCollection services,
        RestApiExtendedOptions restApiOptions,
        IConfiguration configuration)
        => services.AddRestApi<TStartup>(mvc => { }, restApiOptions, configuration);

    /// <summary>
    /// Adds REST API services with custom extended options, configuration, and MVC builder setup action.
    /// Configures API versioning, OpenAPI/Swagger, FluentValidation, and JWT authentication as specified in options.
    /// </summary>
    /// <typeparam name="TStartup">The startup type used to locate API resources.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> instance.</param>
    /// <param name="setupMvcAction">Action to configure the MVC builder.</param>
    /// <param name="restApiOptions">The REST API extended options.</param>
    /// <param name="configuration">The application configuration for binding authorization settings.</param>
    /// <returns>The <see cref="IServiceCollection"/> instance for method chaining.</returns>
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
            services.AddApiVersioning(options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ReportApiVersions = true;
                })
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VV";
                    options.SubstituteApiVersionInUrl = true;
                });
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