namespace Atc.Rest.HealthCheck.Models;

public sealed record ResourceHealthCheck(
    string Name,
    HealthStatus Status,
    string Message,
    TimeSpan Duration);