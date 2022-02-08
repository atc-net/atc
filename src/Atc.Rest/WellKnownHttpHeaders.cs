// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Http;

public static class WellKnownHttpHeaders
{
    public const string CorrelationId = "x-correlation-id";
    public const string RequestId = "x-request-id";
    public const string OnBehalfOf = "x-on-behalf-of";
    public const string CallingIdentity = "x-calling-identity";

    public const string MaxItemCount = "x-max-item-count";
    public const string Continuation = "x-continuation";

    public const string Filename = "x-filename";

    public const string ValueSeparator = ", ";
    public const string IfMatch = "If-Match";
    public const string IfNoneMatch = "If-NoneMatch";
    public const string ETag = "etag";
}