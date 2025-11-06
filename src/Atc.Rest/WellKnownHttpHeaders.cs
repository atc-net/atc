// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Http;

/// <summary>
/// Defines well-known HTTP header names used throughout the REST API framework.
/// </summary>
/// <remarks>
/// These header names follow common conventions for distributed tracing, pagination,
/// conditional requests, and identity propagation in microservice architectures.
/// </remarks>
public static class WellKnownHttpHeaders
{
    /// <summary>
    /// The correlation ID header name for distributed tracing across service boundaries.
    /// </summary>
    public const string CorrelationId = "x-correlation-id";

    /// <summary>
    /// The request ID header name for tracking individual requests.
    /// </summary>
    public const string RequestId = "x-request-id";

    /// <summary>
    /// The on-behalf-of header name for identity delegation in service-to-service calls.
    /// </summary>
    public const string OnBehalfOf = "x-on-behalf-of";

    /// <summary>
    /// The calling identity header name for tracking the authenticated user identity.
    /// </summary>
    public const string CallingIdentity = "x-calling-identity";

    /// <summary>
    /// The maximum item count header name for pagination requests.
    /// </summary>
    public const string MaxItemCount = "x-max-item-count";

    /// <summary>
    /// The continuation token header name for cursor-based pagination.
    /// </summary>
    public const string Continuation = "x-continuation";

    /// <summary>
    /// The filename header name for file download operations.
    /// </summary>
    public const string Filename = "x-filename";

    /// <summary>
    /// The standard separator for multiple header values.
    /// </summary>
    public const string ValueSeparator = ", ";

    /// <summary>
    /// The If-Match header name for conditional requests based on ETag.
    /// </summary>
    public const string IfMatch = "If-Match";

    /// <summary>
    /// The If-None-Match header name for conditional requests based on ETag.
    /// </summary>
    public const string IfNoneMatch = "If-NoneMatch";

    /// <summary>
    /// The ETag header name for entity versioning and caching.
    /// </summary>
    public const string ETag = "etag";
}