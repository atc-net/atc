namespace Atc.Rest.Models;

/// <summary>
/// Represents logged information for a complete HTTP request/response cycle.
/// </summary>
/// <remarks>
/// This model combines request and response log information along with execution time
/// and exception details for comprehensive logging and debugging.
/// </remarks>
[SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
public sealed class RequestResponseLogModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RequestResponseLogModel"/> class.
    /// </summary>
    /// <param name="request">The HTTP request to log.</param>
    /// <param name="includeQueryParameters">If true, includes query parameters in the log model.</param>
    /// <param name="includeHeaderParameters">If true, includes header parameters in the log model.</param>
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

    /// <summary>
    /// Gets the system name in kebab-casing format.
    /// </summary>
    public string System { get; init; }

    /// <summary>
    /// Gets the request log information.
    /// </summary>
    public RequestLogModel Request { get; init; }

    /// <summary>
    /// Gets or sets the response log information.
    /// </summary>
    public ResponseLogModel? Response { get; set; }

    /// <summary>
    /// Gets the formatted execution time between request and response.
    /// </summary>
    public string? ExecutionTime
        => Response is null
            ? null
            : (Response.DateTimeUtc - Request.DateTimeUtc).GetPrettyTime();

    /// <summary>
    /// Gets or sets the exception message if an exception occurred during request processing.
    /// </summary>
    public string? ExceptionMessage { get; set; }

    /// <summary>
    /// Gets or sets the exception stack trace if an exception occurred during request processing.
    /// </summary>
    public string? ExceptionStackTrace { get; set; }

    /// <summary>
    /// Sets exception information from the specified exception.
    /// </summary>
    /// <param name="exception">The exception that occurred during request processing.</param>
    public void SetException(
        Exception exception)
    {
        ExceptionMessage = exception.Message;
        ExceptionStackTrace = exception.StackTrace;
    }
}