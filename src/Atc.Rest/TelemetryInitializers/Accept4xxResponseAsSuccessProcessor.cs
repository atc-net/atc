// ReSharper disable InconsistentNaming
namespace Atc.Rest.TelemetryInitializers;

/// <summary>
/// OpenTelemetry activity processor that treats certain 4xx HTTP status codes as successful requests in Application Insights.
/// </summary>
/// <remarks>
/// By default, Application Insights considers all 4xx responses as failed requests. This processor
/// reclassifies specific client errors (400 Bad Request and 404 Not Found) as successful, which is often
/// more appropriate for API scenarios where these represent expected validation or resource lookup results
/// rather than application failures.
/// </remarks>
[SuppressMessage("Minor Code Smell", "S101:Types should be named in PascalCase", Justification = "OK.")]
public class Accept4xxResponseAsSuccessProcessor : BaseProcessor<Activity>
{
    /// <summary>
    /// Called when an activity is ended. Marks certain 4xx responses as successful.
    /// </summary>
    /// <param name="activity">The activity being ended.</param>
    public override void OnEnd(Activity activity)
    {
        ArgumentNullException.ThrowIfNull(activity);

        if (activity.Kind != ActivityKind.Server)
        {
            return;
        }

        var statusCodeTag = activity.GetTagItem("http.response.status_code")?.ToString();
        if (statusCodeTag is null)
        {
            return;
        }

        if (!int.TryParse(statusCodeTag, NumberStyles.Any, GlobalizationConstants.EnglishCultureInfo, out var code))
        {
            return;
        }

        if (code is (int)HttpStatusCode.BadRequest or (int)HttpStatusCode.NotFound)
        {
            activity.SetStatus(ActivityStatusCode.Unset);
        }
    }
}