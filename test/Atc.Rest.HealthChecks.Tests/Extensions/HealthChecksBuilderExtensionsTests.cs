namespace Atc.Rest.HealthChecks.Tests.Extensions;

public sealed class HealthChecksBuilderExtensionsTests
{
    [Fact]
    public void AddMetricsPublisher_RegistersThePublisherOnce()
    {
        // Arrange
        var services = new ServiceCollection();
        var builder = services.AddHealthChecks();

        // Act
        builder.AddMetricsPublisher();
        builder.AddMetricsPublisher();

        // Assert
        using var provider = services.BuildServiceProvider();
        var publisher = Assert.Single(provider.GetServices<IHealthCheckPublisher>());
        Assert.IsType<MetricsHealthCheckPublisher>(publisher);
    }
}