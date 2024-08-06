// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder;

public static class RestApiExtendedBuilderExtensions
{
    public static IApplicationBuilder ConfigureRestApi(
        this IApplicationBuilder app,
        IWebHostEnvironment env)
        => app.ConfigureRestApi(env, new RestApiExtendedOptions(), _ => { });

    public static IApplicationBuilder ConfigureRestApi(
        this IApplicationBuilder app,
        IWebHostEnvironment env,
        RestApiExtendedOptions restApiOptions)
        => app.ConfigureRestApi(env, restApiOptions, _ => { });

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
            var cssFile = string.Empty;
            if (restApiOptions.SwaggerUiTheme.EndsWith(".css", StringComparison.Ordinal) &&
                restApiOptions.SwaggerUiTheme.Contains("Light", StringComparison.OrdinalIgnoreCase))
            {
                cssFile = "SwaggerLight.css";
            }
            else if (restApiOptions.SwaggerUiTheme.EndsWith(".css", StringComparison.Ordinal) &&
                     restApiOptions.SwaggerUiTheme.Contains("Dark", StringComparison.OrdinalIgnoreCase))
            {
                cssFile = "SwaggerDark.css";
            }

            var options = new SwaggerUIOptions();
            options.InjectStylesheet(restApiOptions.SwaggerUiTheme);
            options.EnableTryItOutByDefault();
            options.InjectStylesheet($"/swagger-ui/{cssFile}");
            options.InjectJavascript("/swagger-ui/main.js");

            app.UseOpenApiSpec(env, restApiOptions, options);
        }
        else
        {
            app.UseOpenApiSpec(env, restApiOptions);
        }

        return app;
    }
}