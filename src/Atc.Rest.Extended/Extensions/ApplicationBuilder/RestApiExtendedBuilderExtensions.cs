// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder;

/// <summary>
/// Extension methods for configuring REST API with extended features in the application pipeline.
/// </summary>
public static class RestApiExtendedBuilderExtensions
{
    /// <summary>
    /// Configures the REST API with default extended options.
    /// </summary>
    /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
    /// <param name="env">The <see cref="IWebHostEnvironment"/> instance.</param>
    /// <returns>The <see cref="IApplicationBuilder"/> instance for method chaining.</returns>
    public static IApplicationBuilder ConfigureRestApi(
        this IApplicationBuilder app,
        IWebHostEnvironment env)
        => app.ConfigureRestApi(env, new RestApiExtendedOptions(), _ => { });

    /// <summary>
    /// Configures the REST API with custom extended options.
    /// </summary>
    /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
    /// <param name="env">The <see cref="IWebHostEnvironment"/> instance.</param>
    /// <param name="restApiOptions">The REST API extended options.</param>
    /// <returns>The <see cref="IApplicationBuilder"/> instance for method chaining.</returns>
    public static IApplicationBuilder ConfigureRestApi(
        this IApplicationBuilder app,
        IWebHostEnvironment env,
        RestApiExtendedOptions restApiOptions)
        => app.ConfigureRestApi(env, restApiOptions, _ => { });

    /// <summary>
    /// Configures the REST API with custom extended options and setup action.
    /// Enables features like OpenAPI/Swagger with custom themes, API versioning, and authentication.
    /// </summary>
    /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
    /// <param name="env">The <see cref="IWebHostEnvironment"/> instance.</param>
    /// <param name="restApiOptions">The REST API extended options.</param>
    /// <param name="setupAction">Additional setup action for the application builder.</param>
    /// <returns>The <see cref="IApplicationBuilder"/> instance for method chaining.</returns>
    public static IApplicationBuilder ConfigureRestApi(
        this IApplicationBuilder app,
        IWebHostEnvironment env,
        RestApiExtendedOptions restApiOptions,
        Action<IApplicationBuilder> setupAction)
    {
        ArgumentNullException.ThrowIfNull(app);
        ArgumentNullException.ThrowIfNull(env);
        ArgumentNullException.ThrowIfNull(restApiOptions);
        ArgumentNullException.ThrowIfNull(setupAction);

        if (env.IsDevelopment())
        {
            IdentityModelEventSource.ShowPII = true;
        }

        // Cast to base-restApiOptions to force to use ConfigureRestApi in RestApiBuilderExtensions
        app.ConfigureRestApi(env, restApiOptions as RestApiOptions, setupAction);

        if (!restApiOptions.UseOpenApiSpec)
        {
            return app;
        }

        if ((env.IsDevelopment() || restApiOptions.UseSwaggerUi) &&
            restApiOptions.SwaggerUiTheme is not null)
        {
            var cssFile = restApiOptions.SwaggerUiTheme.EndsWith(".css", StringComparison.Ordinal) switch
            {
                false when restApiOptions.SwaggerUiTheme.Contains("Light", StringComparison.OrdinalIgnoreCase) =>
                    "SwaggerLight.css",
                false when restApiOptions.SwaggerUiTheme.Contains("Dark", StringComparison.OrdinalIgnoreCase) =>
                    "SwaggerDark.css",
                _ => string.Empty,
            };

            var options = new SwaggerUIOptions();
            options.EnableTryItOutByDefault();
            options.InjectStylesheet($"/swagger-ui/{cssFile}");
            options.InjectJavascript("/swagger-ui/main.js");

            // TODO: Add support for multiple versions
            var groupName = "v1.0";
            var url = $"/swagger/{groupName}/swagger.json";
            var applicationName = env.ApplicationName;
            var name = groupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, $"{applicationName} {name}");

            app.UseOpenApiSpec(env, restApiOptions, options);
        }
        else
        {
            app.UseOpenApiSpec(env, restApiOptions);
        }

        return app;
    }
}