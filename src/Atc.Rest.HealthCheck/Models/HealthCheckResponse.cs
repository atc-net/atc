namespace Atc.Rest.HealthCheck.Models;

public sealed record HealthCheckResponse(
    string ApplicationName,
    IList<HealthCheck> HealthChecks,
    HealthStatus Status,
    TimeSpan TotalDuration);