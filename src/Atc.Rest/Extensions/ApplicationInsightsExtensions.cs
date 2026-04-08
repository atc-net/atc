// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for configuring Application Insights telemetry.
/// </summary>
public static class ApplicationInsightsExtensions
{
    /// <summary>
    /// Registers OpenTelemetry activity processors for enriching Application Insights telemetry with request context information.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for method chaining.</returns>
    /// <remarks>
    /// This method registers the following activity processors:
    /// <list type="bullet">
    /// <item><see cref="CallingIdentityTelemetryProcessor"/> - Adds calling identity and request correlation IDs to telemetry.</item>
    /// <item><see cref="Accept4xxResponseAsSuccessProcessor"/> - Treats certain 4xx responses (BadRequest, NotFound) as successful requests.</item>
    /// </list>
    /// </remarks>
    public static IServiceCollection AddCallingIdentityTelemetryInitializer(
        this IServiceCollection services)
    {
        services.AddOpenTelemetry().WithTracing(builder =>
        {
            builder.AddProcessor<Accept4xxResponseAsSuccessProcessor>();
            builder.AddProcessor(sp => new CallingIdentityTelemetryProcessor(sp));
        });

        return services;
    }
}