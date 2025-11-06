namespace Atc.Rest.Options;

/// <summary>
/// Configures ASP.NET Core API behavior options for model validation and error responses.
/// </summary>
/// <remarks>
/// This class customizes the default API behavior to:
/// <list type="bullet">
/// <item>Suppress automatic binding source inference for better control</item>
/// <item>Return ValidationProblemDetails for invalid model state</item>
/// <item>Include correlation ID in validation error responses</item>
/// <item>Track validation errors in Application Insights telemetry</item>
/// </list>
/// </remarks>
public class ConfigureApiBehaviorOptions : IConfigureOptions<ApiBehaviorOptions>
{
    private readonly TelemetryClient telemetry;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigureApiBehaviorOptions"/> class.
    /// </summary>
    /// <param name="telemetry">The Application Insights telemetry client.</param>
    public ConfigureApiBehaviorOptions(TelemetryClient telemetry)
    {
        this.telemetry = telemetry;
    }

    /// <summary>
    /// Configures the API behavior options.
    /// </summary>
    /// <param name="options">The API behavior options to configure.</param>
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