// ReSharper disable once CheckNamespace
namespace Microsoft.ApplicationInsights.Extensibility;

/// <summary>
/// Telemetry initializer that enriches Application Insights telemetry with request context information.
/// </summary>
/// <remarks>
/// This initializer adds the following properties to all telemetry:
/// <list type="bullet">
/// <item>Authenticated user ID on the telemetry context</item>
/// <item>On-behalf-of identity for service-to-service scenarios</item>
/// <item>Calling identity for the current authenticated user</item>
/// <item>Correlation ID for distributed tracing</item>
/// <item>Request ID for individual request tracking</item>
/// </list>
/// These properties enable filtering and correlation of telemetry by user, request, and call chain.
/// </remarks>
public class CallingIdentityTelemetryInitializer : ITelemetryInitializer
{
    private readonly IRequestContext context;

    /// <summary>
    /// Initializes a new instance of the <see cref="CallingIdentityTelemetryInitializer"/> class.
    /// </summary>
    /// <param name="context">The request context providing identity and correlation information.</param>
    public CallingIdentityTelemetryInitializer(IRequestContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Initializes the telemetry object by adding request context properties.
    /// </summary>
    /// <param name="telemetry">The telemetry object to initialize.</param>
    public void Initialize(ITelemetry telemetry)
    {
        ArgumentNullException.ThrowIfNull(telemetry);

        telemetry.Context.User.AuthenticatedUserId = context.CallingIdentity;
        if (telemetry is not ISupportProperties sp)
        {
            return;
        }

        sp.Properties[WellKnownHttpHeaders.OnBehalfOf] = context.OnBehalfOfIdentity;
        sp.Properties[WellKnownHttpHeaders.CallingIdentity] = context.CallingIdentity;
        sp.Properties[WellKnownHttpHeaders.CorrelationId] = context.CorrelationId;
        sp.Properties[WellKnownHttpHeaders.RequestId] = context.RequestId;
    }
}