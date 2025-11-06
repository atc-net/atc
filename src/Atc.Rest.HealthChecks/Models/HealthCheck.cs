namespace Atc.Rest.HealthChecks.Models;

/// <summary>
/// Represents the result of a single health check execution.
/// </summary>
/// <param name="Name">The name of the health check.</param>
/// <param name="Status">The status of the health check (Healthy, Degraded, or Unhealthy).</param>
/// <param name="Duration">The time taken to execute the health check.</param>
/// <param name="Description">An optional description providing additional context about the health check result.</param>
/// <param name="Data">Optional key-value data associated with the health check result.</param>
public sealed record HealthCheck(
    string Name,
    HealthStatus Status,
    TimeSpan Duration,
    string? Description,
    IReadOnlyDictionary<string, object>? Data);