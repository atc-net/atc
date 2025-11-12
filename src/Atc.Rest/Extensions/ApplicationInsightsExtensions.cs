// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for configuring Application Insights telemetry.
/// </summary>
public static class ApplicationInsightsExtensions
{
    /// <summary>
    /// Registers telemetry initializers for enriching Application Insights telemetry with request context information.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for method chaining.</returns>
    /// <remarks>
    /// This method registers the following telemetry initializers:
    /// <list type="bullet">
    /// <item><see cref="CallingIdentityTelemetryInitializer"/> - Adds calling identity and request correlation IDs to telemetry.</item>
    /// <item><see cref="Accept4xxResponseAsSuccessInitializer"/> - Treats certain 4xx responses (BadRequest, NotFound) as successful requests.</item>
    /// </list>
    /// </remarks>
    public static IServiceCollection AddCallingIdentityTelemetryInitializer(
        this IServiceCollection services)
    {
        services.AddSingleton<ITelemetryInitializer, CallingIdentityTelemetryInitializer>();
        services.AddSingleton<ITelemetryInitializer, Accept4xxResponseAsSuccessInitializer>();
        return services;
    }
}