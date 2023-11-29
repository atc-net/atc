// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder;

public static class RestApiBuilderExtensions
{
    public static IApplicationBuilder UseRestApi(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        return app.ConfigureRestApi(env, new RestApiOptions(), _ => { });
    }

    public static IApplicationBuilder ConfigureRestApi(
        this IApplicationBuilder app,
        IWebHostEnvironment env,
        RestApiOptions restApiOptions)
    {
        return app.ConfigureRestApi(env, restApiOptions, _ => { });
    }

    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    [SuppressMessage("Minor Code Smell", "S4507:Delivering code in production with debug features activated is security-sensitive", Justification = "OK.")]
    [SuppressMessage("Insecure Configuration", "S5122:Having a permissive Cross-Origin Resource Sharing policy is security-sensitive", Justification = "OK.")]
    public static IApplicationBuilder ConfigureRestApi(
        this IApplicationBuilder app,
        IWebHostEnvironment env,
        RestApiOptions restApiOptions,
        Action<IApplicationBuilder> setupAction)
    {
        ArgumentNullException.ThrowIfNull(app);
        ArgumentNullException.ThrowIfNull(env);
        ArgumentNullException.ThrowIfNull(restApiOptions);
        ArgumentNullException.ThrowIfNull(setupAction);

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        setupAction(app);

        app.UseCors(options =>
        {
            options.AllowAnyHeader();
            options.AllowAnyMethod();
            options.AllowAnyOrigin();
        });

        app.UseMiddleware<KeepAliveMiddleware>();
        app.UseMiddleware<RequestCorrelationMiddleware>();
        app.UseMiddleware<ExceptionTelemetryMiddleware>();

        if (restApiOptions.EnableRequestResponseLogger)
        {
            app.UseMiddleware<RequestResponseLoggerMiddleware>();
        }

        if (!env.IsDevelopment())
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles(new StaticFileOptions
        {
            OnPrepareResponse = ctx =>
            {
                ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
            },
        });

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapApiSpecificationEndpoint(restApiOptions.AssemblyPairs);
            endpoints.MapControllers();
        });

        return app;
    }
}