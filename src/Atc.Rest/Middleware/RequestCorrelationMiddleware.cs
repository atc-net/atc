namespace Atc.Rest.Middleware;

/// <summary>
/// Responsible for ensuring x-correlation-id and x-request-id are set on request and response.
/// </summary>
public class RequestCorrelationMiddleware
{
    private readonly RequestDelegate next;

    public RequestCorrelationMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public Task InvokeAsync(HttpContext context)
    {
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var correlationId = context.Request.Headers.GetOrAddCorrelationId();
        context.Request.Headers.GetOrAddRequestId();
        context.Response.Headers.AddCorrelationId(correlationId);
        return next(context);
    }
}