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
        => app.ConfigureRestApi(env, new RestApiOptions(), _ => { });

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
        => app.ConfigureRestApi(env, restApiOptions, _ => { });

    /// <summary>
    /// Configures the REST API middleware pipeline with custom setup action.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="env">The web host environment.</param>
    /// <param name="restApiOptions">The REST API configuration options.</param>
    /// <param name="setupAction">
    /// Custom setup action invoked after the built-in middleware (CORS, correlation, telemetry,
    /// optional request/response logger) and <b>before</b> HSTS, HTTPS redirection, static files,
    /// routing, authentication and authorization. This is the recommended hook point for adding
    /// <c>app.UseRateLimiter()</c> (.NET 7+), <c>app.UseRequestTimeouts()</c> (.NET 8+), output
    /// caching, response compression, header policies or any other application-level middleware.
    /// </param>
    /// <returns>The application builder for method chaining.</returns>
    /// <remarks>
    /// <para>
    /// This method configures the following middleware in order:
    /// </para>
    /// <list type="number">
    /// <item>Developer exception page (Development only)</item>
    /// <item>CORS with permissive policy</item>
    /// <item>Keep-alive middleware</item>
    /// <item>Request correlation middleware</item>
    /// <item>Exception telemetry middleware</item>
    /// <item>Request/response logger middleware (if enabled)</item>
    /// <item><c>setupAction</c> — recommended position for rate-limiting, request timeouts and other custom middleware</item>
    /// <item>HSTS (non-Development only)</item>
    /// <item>HTTPS redirection</item>
    /// <item>Static files</item>
    /// <item>Routing, authentication, and authorization</item>
    /// <item>Endpoints (controllers and API specification)</item>
    /// </list>
    /// <para>
    /// Example — enabling rate-limiting and a 30-second per-request timeout:
    /// </para>
    /// <code>
    /// services.AddRateLimiter(options =&gt; options.AddFixedWindowLimiter("api", o =&gt;
    /// {
    ///     o.PermitLimit = 100;
    ///     o.Window = TimeSpan.FromMinutes(1);
    /// }));
    /// services.AddRequestTimeouts(options =&gt;
    ///     options.DefaultPolicy = new RequestTimeoutPolicy { Timeout = TimeSpan.FromSeconds(30) });
    ///
    /// app.ConfigureRestApi(env, restApiOptions, builder =&gt;
    /// {
    ///     builder.UseRateLimiter();
    ///     builder.UseRequestTimeouts();
    /// });
    /// </code>
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

        if (restApiOptions.AllowedCorsOrigins is { Count: > 0 })
        {
            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.WithOrigins(restApiOptions.AllowedCorsOrigins.ToArray());
                options.AllowCredentials();
            });
        }
        else
        {
            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });
        }

        app.UseMiddleware<KeepAliveMiddleware>();
        app.UseMiddleware<RequestCorrelationMiddleware>();
        app.UseMiddleware<ExceptionTelemetryMiddleware>();

        if (restApiOptions.EnableRequestResponseLogger)
        {
            app.UseMiddleware<RequestResponseLoggerMiddleware>();
        }

        setupAction(app);

        if (!env.IsDevelopment())
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        // Static files inherit the CORS policy applied above by app.UseCors(...).
        // We deliberately do NOT inject an unconditional "Access-Control-Allow-Origin: *"
        // header here, because doing so would bypass an explicit allowlist when
        // RestApiOptions.AllowedCorsOrigins is configured, and would conflict with any
        // future use of credentials.
        app.UseStaticFiles();

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