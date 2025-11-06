namespace Atc.Rest;

/// <summary>
/// Provides access to HTTP request context information including identity and correlation identifiers.
/// </summary>
/// <remarks>
/// This interface is typically used in service layers to access request-scoped information
/// without directly depending on <see cref="HttpContext"/>.
/// </remarks>
public interface IRequestContext
{
    /// <summary>
    /// Gets the identity of the current caller from the authentication principal.
    /// </summary>
    string CallingIdentity { get; }

    /// <summary>
    /// Gets the identity of the original caller when the service is acting on behalf of another user or service.
    /// </summary>
    /// <remarks>
    /// In service-to-service scenarios, this represents the end-user identity when a core service
    /// makes the request. If not acting on behalf of another identity, this returns the same value as <see cref="CallingIdentity"/>.
    /// </remarks>
    string OnBehalfOfIdentity { get; }

    /// <summary>
    /// Gets the unique request ID for the current HTTP request.
    /// </summary>
    /// <remarks>
    /// This ID is used for tracking individual requests and correlating log entries.
    /// </remarks>
    string RequestId { get; }

    /// <summary>
    /// Gets the correlation ID that tracks a request across multiple services.
    /// </summary>
    /// <remarks>
    /// The correlation ID is propagated across service boundaries to enable distributed tracing
    /// and tracking of a logical operation that spans multiple microservices.
    /// </remarks>
    string CorrelationId { get; }

    /// <summary>
    /// Gets the cancellation token that is triggered when the HTTP request is aborted.
    /// </summary>
    /// <remarks>
    /// This token should be passed to asynchronous operations to allow graceful cancellation
    /// when the client disconnects or the request times out.
    /// </remarks>
    CancellationToken RequestCancellationToken { get; }
}