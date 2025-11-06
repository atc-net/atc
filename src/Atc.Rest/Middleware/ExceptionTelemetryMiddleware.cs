namespace Atc.Rest.Middleware;

/// <summary>
/// Middleware that tracks exceptions in Application Insights telemetry and returns a generic error response.
/// </summary>
/// <remarks>
/// This middleware captures unhandled exceptions from the pipeline, tracks them in Application Insights,
/// and returns an HTTP 500 status with a user-friendly error message including the correlation ID.
/// </remarks>
public class ExceptionTelemetryMiddleware
{
    private readonly RequestDelegate next;
    private readonly TelemetryClient client;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionTelemetryMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware delegate in the pipeline.</param>
    /// <param name="client">The Application Insights telemetry client.</param>
    public ExceptionTelemetryMiddleware(
        RequestDelegate next,
        TelemetryClient client)
    {
        this.next = next;
        this.client = client;
    }

    /// <summary>
    /// Invokes the middleware to process the HTTP request and track exceptions.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task InvokeAsync(HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return InternalInvokeAsync(context);
    }

    private async Task InternalInvokeAsync(HttpContext context)
    {
        var requestFailed = false;

        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            client.TrackException(ex);

            if (context.Response.HasStarted)
            {
                throw;
            }

            requestFailed = true;
        }

        if (requestFailed)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context
                .Response
                .WriteAsync($"Something is broken. Please contact the development team with the value of the returned header named '{WellKnownHttpHeaders.CorrelationId}'");
        }
    }
}