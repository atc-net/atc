namespace Atc.Rest.HealthChecks.Publishers;

/// <summary>
/// Publishes the latest health check results as metrics, so they can be charted and alerted on
/// (e.g. through OpenTelemetry), with one measurement per health check tagged <c>health_check.name</c>:
/// <list type="bullet">
///   <item><description><c>health_check.status</c>: 0 = Unhealthy, 0.5 = Degraded, 1 = Healthy.</description></item>
///   <item><description><c>health_check.duration</c>: how long the check took, in seconds.</description></item>
/// </list>
/// </summary>
/// <remarks>
/// Register it with <c>services.AddHealthChecks().AddMetricsPublisher()</c>, and export the meter, e.g.
/// <c>.WithMetrics(m =&gt; m.AddMeter(MetricsHealthCheckPublisher.MeterName))</c>. How often the checks run
/// is set by <see cref="HealthCheckPublisherOptions"/>.
/// </remarks>
public sealed class MetricsHealthCheckPublisher : IHealthCheckPublisher
{
    /// <summary>
    /// The name of the meter the health check metrics are published on.
    /// </summary>
    public const string MeterName = "Atc.Rest.HealthChecks";

    /// <summary>
    /// The name of the gauge with the status of each health check.
    /// </summary>
    public const string StatusInstrumentName = "health_check.status";

    /// <summary>
    /// The name of the gauge with the duration of each health check.
    /// </summary>
    public const string DurationInstrumentName = "health_check.duration";

    /// <summary>
    /// The name of the tag that holds the health check's registration name.
    /// </summary>
    public const string HealthCheckNameTag = "health_check.name";

    private HealthReport? lastReport;

    /// <summary>
    /// Initializes a new instance of the <see cref="MetricsHealthCheckPublisher"/> class.
    /// </summary>
    /// <param name="meterFactory">The meter factory that creates (and owns) the meter.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="meterFactory"/> is <see langword="null"/>.</exception>
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The meter is owned and disposed by the IMeterFactory.")]
    public MetricsHealthCheckPublisher(IMeterFactory meterFactory)
    {
        ArgumentNullException.ThrowIfNull(meterFactory);

        var meter = meterFactory.Create(MeterName);

        meter.CreateObservableGauge(
            StatusInstrumentName,
            ObserveStatus,
            unit: null,
            description: "Health check status (0 = Unhealthy, 0.5 = Degraded, 1 = Healthy)");

        meter.CreateObservableGauge(
            DurationInstrumentName,
            ObserveDuration,
            unit: "s",
            description: "Duration of the health check execution");
    }

    /// <inheritdoc />
    public Task PublishAsync(
        HealthReport report,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(report);

        Volatile.Write(ref lastReport, report);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Converts a <see cref="HealthStatus"/> to its metric value.
    /// </summary>
    /// <param name="status">The health status.</param>
    /// <returns>0 for Unhealthy, 0.5 for Degraded and 1 for Healthy.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown for an undefined <see cref="HealthStatus"/>.</exception>
    public static double ToMetricValue(HealthStatus status)
        => status switch
        {
            HealthStatus.Unhealthy => 0,
            HealthStatus.Degraded => 0.5,
            HealthStatus.Healthy => 1,
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, "Unexpected HealthStatus value."),
        };

    private IEnumerable<Measurement<double>> ObserveStatus()
        => Observe(entry => ToMetricValue(entry.Status));

    private IEnumerable<Measurement<double>> ObserveDuration()
        => Observe(entry => entry.Duration.TotalSeconds);

    private IEnumerable<Measurement<double>> Observe(
        Func<HealthReportEntry, double> value)
    {
        var report = Volatile.Read(ref lastReport);
        if (report is null)
        {
            return [];
        }

        return report.Entries
            .Select(e => new Measurement<double>(
                value(e.Value),
                new KeyValuePair<string, object?>(HealthCheckNameTag, e.Key)))
            .ToList();
    }
}