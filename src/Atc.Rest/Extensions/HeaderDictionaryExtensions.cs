// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Http;

/// <summary>
/// Extension methods for <see cref="IHeaderDictionary"/> to manage request correlation and identity headers.
/// </summary>
public static class HeaderDictionaryExtensions
{
    /// <summary>
    /// Gets the correlation ID from the header, or generates and adds a new one if not found.
    /// </summary>
    /// <param name="headers">The headers.</param>
    /// <returns>The correlation ID for the request.</returns>
    public static string GetOrAddCorrelationId(this IHeaderDictionary headers)
    {
        ArgumentNullException.ThrowIfNull(headers);

        return headers.TryGetValue(WellKnownHttpHeaders.CorrelationId, out var header)
            ? header.FirstOrDefault()!
            : headers.AddCorrelationId(Guid.NewGuid().ToString().ToUpperInvariant());
    }

    /// <summary>
    /// Adds a correlation ID to the header dictionary.
    /// </summary>
    /// <param name="headers">The headers.</param>
    /// <param name="correlationId">The correlation ID to add.</param>
    /// <returns>The correlation ID that was added.</returns>
    public static string AddCorrelationId(this IHeaderDictionary headers, string correlationId)
    {
        ArgumentNullException.ThrowIfNull(headers);

        headers[WellKnownHttpHeaders.CorrelationId] = correlationId;
        return correlationId;
    }

    /// <summary>
    /// Gets the request ID from the header, or generates and adds a new one if not found.
    /// </summary>
    /// <param name="headers">The headers.</param>
    /// <returns>The request ID for the request.</returns>
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

    /// <summary>
    /// Gets the on-behalf-of identity from the x-on-behalf-of header.
    /// </summary>
    /// <param name="headers">The headers.</param>
    /// <returns>The on-behalf-of identity if present; otherwise, null.</returns>
    /// <remarks>
    /// This header is used in scenarios where a service acts on behalf of a user or another service.
    /// </remarks>
    public static string? GetCallingOnBehalfOfIdentity(this IHeaderDictionary headers)
    {
        ArgumentNullException.ThrowIfNull(headers);

        return headers.TryGetValue(WellKnownHttpHeaders.OnBehalfOf, out var header)
            ? header.FirstOrDefault()
            : null;
    }
}