namespace Atc.Rest.Middleware;

/// <summary>
/// Middleware responsible for handling the App service keep alive ping on http://{host-endpoint}.
/// If not enabled the application insights will report a failed request as the goes to http and not https.
/// </summary>
public class KeepAliveMiddleware
{
    private readonly RequestDelegate next;

    public KeepAliveMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public Task InvokeAsync(HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return InternalInvokeAsync(context);
    }

    private static bool IsKeepAlivePing(HttpRequest request)
    {
        return request.Path == "/" &&
               string.Equals(request.Method, "GET", StringComparison.Ordinal) &&
               !request.PathBase.HasValue;
    }

    private async Task InternalInvokeAsync(HttpContext context)
    {
        if (IsKeepAlivePing(context.Request))
        {
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            await context.Response.WriteAsync(nameof(HttpStatusCode.OK));
            return;
        }

        await next(context);
    }
}