// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder;

public static class OpenApiBuilderExtensions
{
    public static IApplicationBuilder UseOpenApiSpec(
        this IApplicationBuilder app,
        IWebHostEnvironment env)
        => app.UseOpenApiSpec(env, new RestApiExtendedOptions());

    public static IApplicationBuilder UseOpenApiSpec(
        this IApplicationBuilder app,
        IWebHostEnvironment env,
        RestApiExtendedOptions restApiOptions)
    {
        ArgumentNullException.ThrowIfNull(env);
        ArgumentNullException.ThrowIfNull(restApiOptions);

        if (!restApiOptions.UseOpenApiSpec)
        {
            return app;
        }

        app.UseSwagger();

        if (env.IsDevelopment())
        {
            app.UseSwaggerUI();
        }

        return app;
    }
}