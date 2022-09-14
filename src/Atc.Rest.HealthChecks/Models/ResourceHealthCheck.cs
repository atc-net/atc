namespace Atc.Rest.HealthChecks.Models;

public sealed record ResourceHealthCheck(
    string Name,
    HealthStatus Status,
    string Message,
    TimeSpan Duration);