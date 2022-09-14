namespace Atc.Rest.HealthCheck.Models;

public sealed record HealthCheck(
    string Name,
    IList<ResourceHealthCheck> Resources,
    HealthStatus Status,
    TimeSpan Duration);