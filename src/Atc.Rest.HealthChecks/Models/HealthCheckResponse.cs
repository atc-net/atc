namespace Atc.Rest.HealthChecks.Models;

public sealed record HealthCheckResponse(
    string ApplicationName,
    IList<HealthCheck> HealthChecks,
    HealthStatus Status,
    TimeSpan TotalDuration);