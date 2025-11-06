namespace Atc.Rest.HealthChecks.Models;

/// <summary>
/// Represents the aggregate health check response for an application.
/// </summary>
/// <param name="ApplicationName">The name of the application being health checked.</param>
/// <param name="HealthChecks">The collection of individual health check results.</param>
/// <param name="Status">The overall health status of the application, derived from all health checks.</param>
/// <param name="TotalDuration">The total time taken to execute all health checks.</param>
public sealed record HealthCheckResponse(
    string ApplicationName,
    IList<HealthCheck> HealthChecks,
    HealthStatus Status,
    TimeSpan TotalDuration);