namespace Atc.Rest.HealthChecks.Factories;

public static class HealthCheckOptionsFactory
{
    public static HealthCheckOptions CreateJson(
        string applicationName,
        JsonSerializerOptions? jsonSerializerOptions)
        => new()
        {
            ResponseWriter = async (c, r) =>
            {
                c.Response.ContentType = MediaTypeNames.Application.Json;

                var response = new HealthCheckResponse(
                    applicationName,
                    r.Entries.ToHealthChecks(),
                    r.Status,
                    r.TotalDuration);

                await c.Response.WriteAsync(
                    JsonSerializer.Serialize(
                        response,
                        jsonSerializerOptions ?? JsonSerializerOptionsFactory.Create()));
            },
        };
}