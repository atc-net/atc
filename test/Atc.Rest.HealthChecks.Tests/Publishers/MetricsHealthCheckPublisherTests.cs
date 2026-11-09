namespace Atc.Rest.HealthChecks.Tests.Publishers;

public sealed class MetricsHealthCheckPublisherTests
{
    [Fact]
    public async Task PublishAsync_ExposesStatusAndDurationPerHealthCheck()
    {
        // Arrange
        using var provider = new ServiceCollection().AddMetrics().BuildServiceProvider();
        var meterFactory = provider.GetRequiredService<IMeterFactory>();
        var publisher = new MetricsHealthCheckPublisher(meterFactory);
        var measurements = new List<(string Instrument, double Value, string? Name)>();
        using var listener = Listen(meterFactory, measurements);

        var report = new HealthReport(
            new Dictionary<string, HealthReportEntry>(StringComparer.Ordinal)
            {
                ["cosmos"] = new(HealthStatus.Healthy, description: null, TimeSpan.FromMilliseconds(250), exception: null, data: null),
                ["eventhub"] = new(HealthStatus.Degraded, description: null, TimeSpan.FromSeconds(2), exception: null, data: null),
            },
            TimeSpan.FromSeconds(2));

        // Act
        await publisher.PublishAsync(report, CancellationToken.None);
        listener.RecordObservableInstruments();

        // Assert
        Assert.Contains((MetricsHealthCheckPublisher.StatusInstrumentName, 1d, "cosmos"), measurements);
        Assert.Contains((MetricsHealthCheckPublisher.StatusInstrumentName, 0.5d, "eventhub"), measurements);
        Assert.Contains((MetricsHealthCheckPublisher.DurationInstrumentName, 0.25d, "cosmos"), measurements);
        Assert.Contains((MetricsHealthCheckPublisher.DurationInstrumentName, 2d, "eventhub"), measurements);
    }

    [Fact]
    public void PublishAsync_CompletesSynchronously()
    {
        // Arrange
        using var provider = new ServiceCollection().AddMetrics().BuildServiceProvider();
        var publisher = new MetricsHealthCheckPublisher(provider.GetRequiredService<IMeterFactory>());
        var report = new HealthReport(
            new Dictionary<string, HealthReportEntry>(StringComparer.Ordinal),
            TimeSpan.Zero);

        // Act
        var task = publisher.PublishAsync(report, CancellationToken.None);

        // Assert
        Assert.True(task.IsCompletedSuccessfully);
    }

    [Fact]
    public void BeforeTheFirstReport_NothingIsMeasured()
    {
        // Arrange
        using var provider = new ServiceCollection().AddMetrics().BuildServiceProvider();
        var meterFactory = provider.GetRequiredService<IMeterFactory>();
        _ = new MetricsHealthCheckPublisher(meterFactory);
        var measurements = new List<(string Instrument, double Value, string? Name)>();
        using var listener = Listen(meterFactory, measurements);

        // Act
        listener.RecordObservableInstruments();

        // Assert
        Assert.Empty(measurements);
    }

    [Theory]
    [InlineData(HealthStatus.Unhealthy, 0)]
    [InlineData(HealthStatus.Degraded, 0.5)]
    [InlineData(HealthStatus.Healthy, 1)]
    public void ToMetricValue(
        HealthStatus status,
        double expected)
        => Assert.Equal(expected, MetricsHealthCheckPublisher.ToMetricValue(status));

    [Fact]
    public void ToMetricValue_Throws_ForAnUndefinedStatus()
        => Assert.Throws<ArgumentOutOfRangeException>(() => MetricsHealthCheckPublisher.ToMetricValue((HealthStatus)42));

    private static MeterListener Listen(
        IMeterFactory meterFactory,
        List<(string Instrument, double Value, string? Name)> measurements)
    {
        // Meters from IMeterFactory carry the factory as their scope, so only this test's publisher is observed.
        var listener = new MeterListener
        {
            InstrumentPublished = (instrument, l) =>
            {
                if (ReferenceEquals(instrument.Meter.Scope, meterFactory) &&
                    instrument.Meter.Name == MetricsHealthCheckPublisher.MeterName)
                {
                    l.EnableMeasurementEvents(instrument);
                }
            },
        };

        listener.SetMeasurementEventCallback<double>((instrument, value, tags, _) =>
        {
            string? name = null;
            foreach (var tag in tags)
            {
                if (tag.Key == MetricsHealthCheckPublisher.HealthCheckNameTag)
                {
                    name = tag.Value as string;
                }
            }

            measurements.Add((instrument.Name, value, name));
        });

        listener.Start();
        return listener;
    }
}