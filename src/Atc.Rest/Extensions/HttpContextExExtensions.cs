// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Http;

/// <summary>
/// Extension methods for <see cref="HttpContext"/> to retrieve request correlation identifiers.
/// </summary>
public static class HttpContextExExtensions
{
    /// <summary>
    /// Gets the correlation ID from the request headers.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>The correlation ID if present in the request headers; otherwise, null.</returns>
    public static string? GetCorrelationId(this HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return context.Request.Headers.TryGetValue(WellKnownHttpHeaders.CorrelationId, out var header)
            ? header.FirstOrDefault()
            : null;
    }

    /// <summary>
    /// Gets the request ID from the request headers.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>The request ID if present in the request headers; otherwise, null.</returns>
    public static string? GetRequestId(this HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return context.Request.Headers.TryGetValue(WellKnownHttpHeaders.RequestId, out var header)
            ? header.FirstOrDefault()
            : null;
    }
}