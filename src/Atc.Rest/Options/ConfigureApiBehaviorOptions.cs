namespace Atc.Rest.Options;

public class ConfigureApiBehaviorOptions : IConfigureOptions<ApiBehaviorOptions>
{
    private readonly TelemetryClient telemetry;

    public ConfigureApiBehaviorOptions(TelemetryClient telemetry)
    {
        this.telemetry = telemetry;
    }

    public void Configure(ApiBehaviorOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        options.SuppressInferBindingSourcesForParameters = true;
        options.InvalidModelStateResponseFactory = context =>
        {
            var error = new ValidationProblemDetails(context.ModelState)
            {
                Extensions =
                {
                    ["traceId"] = context.HttpContext.GetCorrelationId(),
                },
            };

            telemetry.TrackTrace(
                "BadRequest",
                new Dictionary<string, string>(StringComparer.Ordinal)
                {
                    { "Response.Body", JsonSerializer.Serialize(error) },
                });

            return new BadRequestObjectResult(error);
        };
    }
}