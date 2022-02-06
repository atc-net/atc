namespace Atc.Rest;

public class RequestContext : IRequestContext
{
    private readonly IHttpContextAccessor accessor;

    public RequestContext(IHttpContextAccessor accessor)
    {
        this.accessor = accessor;
    }

    public string CallingIdentity
        => accessor.HttpContext?.User!.GetIdentity() ?? string.Empty;

    public string OnBehalfOfIdentity
        => accessor.HttpContext?.Request.Headers.GetCallingOnBehalfOfIdentity() ?? this.CallingIdentity;

    public string RequestId
        => accessor.HttpContext?.Request.Headers.GetOrAddRequestId() ?? string.Empty;

    public string CorrelationId
        => accessor.HttpContext?.Request.Headers.GetOrAddCorrelationId() ?? string.Empty;

    public CancellationToken RequestCancellationToken
        => accessor.HttpContext?.RequestAborted ?? CancellationToken.None;
}