namespace Atc.Rest.Extended.Versioning;

public class VersionErrorResponseProvider : IErrorResponseProvider
{
    private readonly TelemetryClient telemetry;

    public VersionErrorResponseProvider(
        TelemetryClient telemetry)
    {
        this.telemetry = telemetry;
    }

    public IActionResult CreateResponse(
        ErrorResponseContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var detail = new ValidationProblemDetails(
            new Dictionary<string, string[]>(StringComparer.Ordinal)
            {
                { context.ErrorCode, new[] { context.Message } },
            });

        telemetry.TrackTrace(
            "BadVersion",
            new Dictionary<string, string>(StringComparer.Ordinal)
            {
                { "Response.Body", JsonSerializer.Serialize(detail) },
            });

        return new BadRequestObjectResult(detail);
    }
}