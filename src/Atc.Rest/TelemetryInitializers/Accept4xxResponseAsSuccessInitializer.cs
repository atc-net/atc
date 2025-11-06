// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Microsoft.ApplicationInsights.Extensibility;

/// <summary>
/// Telemetry initializer that treats certain 4xx HTTP status codes as successful requests in Application Insights.
/// </summary>
/// <remarks>
/// By default, Application Insights considers all 4xx responses as failed requests. This initializer
/// reclassifies specific client errors (400 Bad Request and 404 Not Found) as successful, which is often
/// more appropriate for API scenarios where these represent expected validation or resource lookup results
/// rather than application failures.
/// </remarks>
[SuppressMessage("Minor Code Smell", "S101:Types should be named in PascalCase", Justification = "OK.")]
public class Accept4xxResponseAsSuccessInitializer : ITelemetryInitializer
{
    /// <summary>
    /// Initializes the telemetry object by marking certain 4xx responses as successful.
    /// </summary>
    /// <param name="telemetry">The telemetry object to initialize.</param>
    public void Initialize(ITelemetry telemetry)
    {
        if (!(telemetry is RequestTelemetry requestTelemetry) ||
            requestTelemetry.Success.GetValueOrDefault(defaultValue: false))
        {
            return;
        }

        if (!int.TryParse(requestTelemetry.ResponseCode, NumberStyles.Any, GlobalizationConstants.EnglishCultureInfo, out var code))
        {
            return;
        }

        requestTelemetry.Success = code switch
        {
            (int)HttpStatusCode.BadRequest => true,
            (int)HttpStatusCode.NotFound => true,
            _ => requestTelemetry.Success,
        };
    }
}