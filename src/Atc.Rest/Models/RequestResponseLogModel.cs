namespace Atc.Rest.Models;

[SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
public sealed class RequestResponseLogModel
{
    public RequestResponseLogModel(
        HttpRequest request,
        bool includeQueryParameters = true,
        bool includeHeaderParameters = true)
    {
        System = AssemblyHelper.GetSystemNameAsKebabCasing();
        Request = new RequestLogModel(
            request,
            includeQueryParameters,
            includeHeaderParameters);
    }

    public string System { get; init; }

    public RequestLogModel Request { get; init; }

    public ResponseLogModel? Response { get; set; }

    public string? ExecutionTime
        => Response is null
            ? null
            : (Response.DateTimeUtc - Request.DateTimeUtc).GetPrettyTime();

    public string? ExceptionMessage { get; set; }

    public string? ExceptionStackTrace { get; set; }

    public void SetException(
        Exception exception)
    {
        ExceptionMessage = exception.Message;
        ExceptionStackTrace = exception.StackTrace;
    }
}