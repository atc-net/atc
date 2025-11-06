namespace Atc.Rest;

/// <summary>
/// Default implementation of <see cref="IRequestContext"/> that provides access to HTTP request context information.
/// </summary>
/// <remarks>
/// This class uses <see cref="IHttpContextAccessor"/> to access the current HTTP context and extract
/// identity, correlation, and request identifiers. It is registered as a transient service when
/// <see cref="RestApiOptions.UseHttpContextAccessor"/> is enabled.
/// </remarks>
public class RequestContext : IRequestContext
{
    private readonly IHttpContextAccessor accessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="RequestContext"/> class.
    /// </summary>
    /// <param name="accessor">The HTTP context accessor.</param>
    public RequestContext(IHttpContextAccessor accessor)
    {
        this.accessor = accessor;
    }

    /// <inheritdoc />
    public string CallingIdentity
        => accessor.HttpContext?.User!.GetIdentity() ?? string.Empty;

    /// <inheritdoc />
    public string OnBehalfOfIdentity
        => accessor.HttpContext?.Request.Headers.GetCallingOnBehalfOfIdentity() ?? CallingIdentity;

    /// <inheritdoc />
    public string RequestId
        => accessor.HttpContext?.Request.Headers.GetOrAddRequestId() ?? string.Empty;

    /// <inheritdoc />
    public string CorrelationId
        => accessor.HttpContext?.Request.Headers.GetOrAddCorrelationId() ?? string.Empty;

    /// <inheritdoc />
    public CancellationToken RequestCancellationToken
        => accessor.HttpContext?.RequestAborted ?? CancellationToken.None;
}