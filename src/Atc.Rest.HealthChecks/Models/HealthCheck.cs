namespace Atc.Rest.HealthChecks.Models;

/// <summary>
/// Represents the result of a single health check execution.
/// </summary>
/// <param name="Name">The name of the health check.</param>
/// <param name="Status">The status of the health check (Healthy, Degraded, or Unhealthy).</param>
/// <param name="Duration">The time taken to execute the health check.</param>
/// <param name="Description">An optional description providing additional context about the health check result.</param>
/// <param name="ExceptionMessage">
/// The exception message if the health check failed with an exception; otherwise null.
/// </param>
/// <param name="Data">Optional key-value data associated with the health check result.</param>
/// <remarks>
/// <para>
/// <b>Security warning:</b> <see cref="ExceptionMessage"/> may contain sensitive information
/// such as connection strings, file paths, internal hostnames, or other internal details.
/// Only populate this field when the response is consumed by trusted callers (e.g. behind
/// authentication or in non-production environments). Use the <c>includeExceptionDetails</c>
/// flag on the <c>ToHealthCheck</c> / <c>ToHealthChecks</c> extension methods or
/// <c>HealthCheckOptionsFactory.CreateJson</c> to opt in.
/// </para>
/// </remarks>
public sealed record HealthCheck(
    string Name,
    HealthStatus Status,
    TimeSpan Duration,
    string? Description,
    string? ExceptionMessage,
    IReadOnlyDictionary<string, object>? Data);