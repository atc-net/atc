// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for <see cref="IHealthChecksBuilder"/>.
/// </summary>
public static class HealthChecksBuilderExtensions
{
    /// <summary>
    /// Publishes the health check results as metrics with <see cref="MetricsHealthCheckPublisher"/>
    /// (meter <see cref="MetricsHealthCheckPublisher.MeterName"/>). Calling it more than once registers the publisher once.
    /// </summary>
    /// <param name="builder">The health checks builder.</param>
    /// <returns>The <paramref name="builder"/>, for chaining.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="builder"/> is <see langword="null"/>.</exception>
    public static IHealthChecksBuilder AddMetricsPublisher(
        this IHealthChecksBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Services.AddMetrics();
        builder.Services.TryAddEnumerable(
            ServiceDescriptor.Singleton<IHealthCheckPublisher, MetricsHealthCheckPublisher>());

        return builder;
    }
}