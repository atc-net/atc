namespace Atc.Rest.HealthChecks.Models;

public sealed record HealthCheck(
    string Name,
    HealthStatus Status,
    TimeSpan Duration,
    string? Description,
    IReadOnlyDictionary<string, object>? Data);