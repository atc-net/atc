namespace Atc.Rest.TelemetryInitializers;

/// <summary>
/// OpenTelemetry activity processor that enriches telemetry with request context information.
/// </summary>
/// <remarks>
/// This processor adds the following tags to server activities:
/// <list type="bullet">
/// <item>Authenticated user ID on the activity context</item>
/// <item>On-behalf-of identity for service-to-service scenarios</item>
/// <item>Calling identity for the current authenticated user</item>
/// <item>Correlation ID for distributed tracing</item>
/// <item>Request ID for individual request tracking</item>
/// </list>
/// These properties enable filtering and correlation of telemetry by user, request, and call chain.
/// </remarks>
public class CallingIdentityTelemetryProcessor : BaseProcessor<Activity>
{
    private readonly IServiceProvider serviceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="CallingIdentityTelemetryProcessor"/> class.
    /// </summary>
    /// <param name="serviceProvider">The service provider used to resolve <see cref="IRequestContext"/> per request.</param>
    public CallingIdentityTelemetryProcessor(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Called when an activity is ended. Adds request context properties as activity tags.
    /// </summary>
    /// <param name="activity">The activity being ended.</param>
    public override void OnEnd(Activity activity)
    {
        ArgumentNullException.ThrowIfNull(activity);

        if (activity.Kind != ActivityKind.Server)
        {
            return;
        }

        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetService<IRequestContext>();
        if (context is null)
        {
            return;
        }

        activity.SetTag("enduser.id", context.CallingIdentity);
        activity.SetTag(WellKnownHttpHeaders.OnBehalfOf, context.OnBehalfOfIdentity);
        activity.SetTag(WellKnownHttpHeaders.CallingIdentity, context.CallingIdentity);
        activity.SetTag(WellKnownHttpHeaders.CorrelationId, context.CorrelationId);
        activity.SetTag(WellKnownHttpHeaders.RequestId, context.RequestId);
    }
}