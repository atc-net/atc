// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ApplicationInsightsExtensions
{
    public static IServiceCollection AddCallingIdentityTelemetryInitializer(this IServiceCollection services)
    {
        services.AddSingleton<ITelemetryInitializer, CallingIdentityTelemetryInitializer>();
        services.AddSingleton<ITelemetryInitializer, Accept4xxResponseAsSuccessInitializer>();
        return services;
    }
}