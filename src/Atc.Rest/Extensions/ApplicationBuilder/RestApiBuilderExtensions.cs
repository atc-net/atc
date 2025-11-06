// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder;

/// <summary>
/// Extension methods for configuring the REST API middleware pipeline using <see cref="IApplicationBuilder"/>.
/// </summary>
public static class RestApiBuilderExtensions
{
    /// <summary>
    /// Configures the REST API middleware pipeline with default options.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="env">The web host environment.</param>
    /// <returns>The application builder for method chaining.</returns>
    public static IApplicationBuilder UseRestApi(
        this IApplicationBuilder app,
        IWebHostEnvironment env)
    {
        return app.ConfigureRestApi(env, new RestApiOptions(), _ => { });
    }

    /// <summary>
    /// Configures the REST API middleware pipeline with the specified options.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="env">The web host environment.</param>
    /// <param name="restApiOptions">The REST API configuration options.</param>
    /// <returns>The application builder for method chaining.</returns>
    public static IApplicationBuilder ConfigureRestApi(
        this IApplicationBuilder app,
        IWebHostEnvironment env,
        RestApiOptions restApiOptions)
    {
        return app.ConfigureRestApi(env, restApiOptions, _ => { });
    }

    /// <summary>
    /// Configures the REST API middleware pipeline with custom setup action.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="env">The web host environment.</param>
    /// <param name="restApiOptions">The REST API configuration options.</param>
    /// <param name="setupAction">Custom setup action to configure additional middleware.</param>
    /// <returns>The application builder for method chaining.</returns>
    /// <remarks>
    /// This method configures the following middleware in order:
    /// <list type="number">
    /// <item>Developer exception page (Development only)</item>
    /// <item>CORS with permissive policy</item>
    /// <item>Keep-alive middleware</item>
    /// <item>Request correlation middleware</item>
    /// <item>Exception telemetry middleware</item>
    /// <item>Request/response logger middleware (if enabled)</item>
    /// <item>HSTS (non-Development only)</item>
    /// <item>HTTPS redirection</item>
    /// <item>Static files</item>
    /// <item>Routing, authentication, and authorization</item>
    /// <item>Endpoints (controllers and API specification)</item>
    /// </list>
    /// </remarks>
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