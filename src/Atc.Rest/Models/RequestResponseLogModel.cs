namespace Atc.Rest.Models;

[SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
public sealed class RequestResponseLogModel
{
    public RequestResponseLogModel(
        HttpRequest request)
    {
        var assembly = Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
        System = assembly.GetName().Name!.Replace('.', '-').ToLower(GlobalizationConstants.EnglishCultureInfo);
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