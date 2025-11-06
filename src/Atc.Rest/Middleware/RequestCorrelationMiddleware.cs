namespace Atc.Rest.Middleware;

/// <summary>
/// Middleware that ensures correlation and request IDs are present in both request and response headers.
/// </summary>
/// <remarks>
/// This middleware manages the x-correlation-id and x-request-id headers, generating new GUIDs if not provided.
/// These headers are essential for distributed tracing and request tracking across microservices.
/// </remarks>
public class RequestCorrelationMiddleware
{
    private readonly RequestDelegate next;

    /// <summary>
    /// Initializes a new instance of the <see cref="RequestCorrelationMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware delegate in the pipeline.</param>
    public RequestCorrelationMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    /// <summary>
    /// Invokes the middleware to ensure correlation headers are set.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task InvokeAsync(HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var correlationId = context.Request.Headers.GetOrAddCorrelationId();
        context.Request.Headers.GetOrAddRequestId();
        context.Response.Headers.AddCorrelationId(correlationId);
        return next(context);
    }
}