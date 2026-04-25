namespace Atc.Rest.HealthChecks.Factories;

/// <summary>
/// Factory for creating health check options configurations.
/// </summary>
public static class HealthCheckOptionsFactory
{
    /// <summary>
    /// Creates health check options configured to return JSON formatted responses.
    /// </summary>
    /// <param name="applicationName">The name of the application to include in the health check response.</param>
    /// <param name="jsonSerializerOptions">Optional custom JSON serializer options. If null, default options are used.</param>
    /// <param name="includeExceptionDetails">
    /// When <see langword="true"/>, the JSON response includes raw exception messages from failing
    /// health checks. Defaults to <see langword="false"/> because exception messages can contain
    /// sensitive information (connection strings, file paths, internal hostnames). Only enable
    /// when the endpoint is restricted to trusted callers.
    /// </param>
    /// <returns>A <see cref="HealthCheckOptions"/> instance configured for JSON responses.</returns>
    public static HealthCheckOptions CreateJson(
        string applicationName,
        JsonSerializerOptions? jsonSerializerOptions,
        bool includeExceptionDetails = false)
        => new()
        {
            ResponseWriter = async (c, r) =>
            {
                c.Response.ContentType = MediaTypeNames.Application.Json;

                var response = new HealthCheckResponse(
                    applicationName,
                    r.Entries.ToHealthChecks(includeExceptionDetails),
                    r.Status,
                    r.TotalDuration);

                await c.Response.WriteAsync(
                    JsonSerializer.Serialize(
                        response,
                        jsonSerializerOptions ?? JsonSerializerOptionsFactory.Create()));
            },
        };
}