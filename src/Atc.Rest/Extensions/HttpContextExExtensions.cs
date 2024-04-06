// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Http;

public static class HttpContextExExtensions
{
    public static string? GetCorrelationId(this HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return context.Request.Headers.TryGetValue(WellKnownHttpHeaders.CorrelationId, out var header)
            ? header.FirstOrDefault()
            : null;
    }

    public static string? GetRequestId(this HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return context.Request.Headers.TryGetValue(WellKnownHttpHeaders.RequestId, out var header)
            ? header.FirstOrDefault()
            : null;
    }
}