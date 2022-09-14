namespace Atc.Rest.HealthChecks.Models;

public sealed record HealthCheck(
    string Name,
    IList<ResourceHealthCheck> Resources,
    HealthStatus Status,
    TimeSpan Duration);