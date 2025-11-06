namespace Atc.Rest.HealthChecks.Models;

/// <summary>
/// Represents a health check result for a specific resource or dependency.
/// </summary>
/// <param name="Name">The name of the resource being checked.</param>
/// <param name="Status">The health status of the resource (Healthy, Degraded, or Unhealthy).</param>
/// <param name="Description">A description providing details about the resource health check result.</param>
/// <param name="Duration">The time taken to execute the resource health check.</param>
public sealed record ResourceHealthCheck(
    string Name,
    HealthStatus Status,
    string Description,
    TimeSpan Duration);