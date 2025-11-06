namespace Atc.Rest.Middleware;

/// <summary>
/// Middleware that handles Azure App Service keep-alive pings to prevent false-negative health check reports.
/// </summary>
/// <remarks>
/// This middleware intercepts GET requests to the root path (/) and returns HTTP 200 OK immediately.
/// This prevents Application Insights from reporting failed requests when Azure App Service performs
/// keep-alive pings over HTTP instead of HTTPS.
/// </remarks>
public class KeepAliveMiddleware
{
    private readonly RequestDelegate next;

    /// <summary>
    /// Initializes a new instance of the <see cref="KeepAliveMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware delegate in the pipeline.</param>
    public KeepAliveMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    /// <summary>
    /// Invokes the middleware to process the HTTP request.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
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