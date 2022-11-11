namespace Atc.Rest.Models;

public sealed class RequestResponseLogModel
{
    public RequestResponseLogModel(
        HttpRequest request)
    {
        System = Assembly.GetExecutingAssembly().GetName().Name!.Replace('.', '-').ToLower(GlobalizationConstants.EnglishCultureInfo);
        Request = new RequestLogModel(request);
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