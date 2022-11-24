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

        if (restApiOptions.UseOpenApiSpec)
        {
            app.UseOpenApiSpec(env, restApiOptions);
        }

        return app;
    }
}