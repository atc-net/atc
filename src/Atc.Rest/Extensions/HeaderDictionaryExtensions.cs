// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Http;

public static class HeaderDictionaryExtensions
{
    /// <summary>
    /// Gets the correlation id from header , if not found a new is added to the header and returned.
    /// </summary>
    /// <param name="headers">The headers.</param>
    /// <returns>Correlation id for request.</returns>
    public static string GetOrAddCorrelationId(this IHeaderDictionary headers)
    {
        ArgumentNullException.ThrowIfNull(headers);

        return headers.TryGetValue(WellKnownHttpHeaders.CorrelationId, out var header)
            ? header.FirstOrDefault()!
            : headers.AddCorrelationId(Guid.NewGuid().ToString().ToUpperInvariant());
    }

    public static string AddCorrelationId(this IHeaderDictionary headers, string correlationId)
    {
        ArgumentNullException.ThrowIfNull(headers);

        headers[WellKnownHttpHeaders.CorrelationId] = correlationId;
        return correlationId;
    }

    public static string? GetOrAddRequestId(this IHeaderDictionary headers)
    {
        ArgumentNullException.ThrowIfNull(headers);

        if (headers.TryGetValue(WellKnownHttpHeaders.RequestId, out var header))
        {
            return header.FirstOrDefault();
        }

        var requestId = Guid.NewGuid().ToString().ToUpperInvariant();
        headers[WellKnownHttpHeaders.RequestId] = requestId;
        return requestId;
    }

    public static string? GetCallingOnBehalfOfIdentity(this IHeaderDictionary headers)
    {
        ArgumentNullException.ThrowIfNull(headers);

        return headers.TryGetValue(WellKnownHttpHeaders.OnBehalfOf, out var header)
            ? header.FirstOrDefault()
            : null;
    }
}