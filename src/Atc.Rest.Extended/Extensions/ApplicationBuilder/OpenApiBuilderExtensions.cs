// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder;

/// <summary>
/// Extension methods for configuring OpenAPI/Swagger middleware in the application pipeline.
/// </summary>
public static class OpenApiBuilderExtensions
{
    /// <summary>
    /// Configures the application to use OpenAPI specification with default options.
    /// </summary>
    /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
    /// <param name="env">The <see cref="IWebHostEnvironment"/> instance.</param>
    /// <returns>The <see cref="IApplicationBuilder"/> instance for method chaining.</returns>
    public static IApplicationBuilder UseOpenApiSpec(
        this IApplicationBuilder app,
        IWebHostEnvironment env)
        => app.UseOpenApiSpec(env, new RestApiExtendedOptions());

    /// <summary>
    /// Configures the application to use OpenAPI specification with custom options.
    /// Enables Swagger middleware and optionally Swagger UI based on environment or configuration.
    /// </summary>
    /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
    /// <param name="env">The <see cref="IWebHostEnvironment"/> instance.</param>
    /// <param name="restApiOptions">The REST API extended options.</param>
    /// <param name="swaggerUiOption">Optional Swagger UI configuration options.</param>
    /// <returns>The <see cref="IApplicationBuilder"/> instance for method chaining.</returns>
    public static IApplicationBuilder UseOpenApiSpec(
        this IApplicationBuilder app,
        IWebHostEnvironment env,
        RestApiExtendedOptions restApiOptions,
        SwaggerUIOptions? swaggerUiOption = null)
    {
        ArgumentNullException.ThrowIfNull(env);
        ArgumentNullException.ThrowIfNull(restApiOptions);

        if (!restApiOptions.UseOpenApiSpec)
        {
            return app;
        }

        app.UseSwagger();

        if (restApiOptions.UseSwaggerUi || env.IsDevelopment())
        {
            if (swaggerUiOption is null)
            {
                app.UseSwaggerUI();
            }
            else
            {
                app.UseSwaggerUI(swaggerUiOption);
            }
        }

        return app;
    }
}