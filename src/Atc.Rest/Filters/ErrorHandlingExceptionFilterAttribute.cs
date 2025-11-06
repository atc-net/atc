// ReSharper disable InvertIf
// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Mvc.Filters;

/// <summary>
/// Exception filter attribute that handles unhandled exceptions and converts them to standardized HTTP responses.
/// </summary>
/// <remarks>
/// This filter intercepts exceptions thrown during action execution and:
/// <list type="bullet">
/// <item>Maps exception types to appropriate HTTP status codes</item>
/// <item>Tracks exceptions in Application Insights telemetry</item>
/// <item>Returns either ProblemDetails or plain text error messages</item>
/// <item>Includes correlation ID for request tracing</item>
/// </list>
/// Supported exception mappings:
/// <list type="bullet">
/// <item><see cref="ValidationException"/> → 400 Bad Request</item>
/// <item><see cref="UnauthorizedAccessException"/> → 401 Unauthorized</item>
/// <item><see cref="InvalidOperationException"/> → 409 Conflict</item>
/// <item><see cref="NotImplementedException"/> → 501 Not Implemented</item>
/// <item>All other exceptions → 500 Internal Server Error</item>
/// </list>
/// </remarks>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class ErrorHandlingExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly TelemetryClient telemetryClient;
    private readonly bool includeException;
    private readonly bool useProblemDetailsAsResponseBody;

    private readonly Regex ensurePascalCaseAndSpacesBetweenWordsRegex =
        new("(?<=[a-z])([A-Z])", RegexOptions.Compiled, TimeSpan.FromSeconds(1));

    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorHandlingExceptionFilterAttribute"/> class.
    /// </summary>
    /// <param name="telemetryClient">The Application Insights telemetry client.</param>
    /// <param name="options">The REST API configuration options.</param>
    [SuppressMessage("Design", "CA1019:Define accessors for attribute arguments", Justification = "OK.")]
    public ErrorHandlingExceptionFilterAttribute(
        TelemetryClient telemetryClient,
        RestApiOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        this.telemetryClient = telemetryClient;
        includeException = options.ErrorHandlingExceptionFilter.IncludeExceptionDetails;
        useProblemDetailsAsResponseBody = options.ErrorHandlingExceptionFilter.UseProblemDetailsAsResponseBody;
    }

    /// <summary>
    /// Called when an exception occurs during action execution.
    /// </summary>
    /// <param name="context">The exception context.</param>
    public override void OnException(ExceptionContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        HandleException(context);
        context.ExceptionHandled = true;

        telemetryClient.TrackException(context.Exception);
    }

    private static HttpStatusCode GetHttpStatusCodeByExceptionType(ExceptionContext context)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        if (context.Exception is null)
        {
            return statusCode;
        }

        var exceptionType = context.Exception.GetType();
        if (exceptionType == typeof(ValidationException))
        {
            statusCode = HttpStatusCode.BadRequest;
        }
        else if (exceptionType == typeof(UnauthorizedAccessException))
        {
            statusCode = HttpStatusCode.Unauthorized;
        }
        else if (exceptionType == typeof(InvalidOperationException))
        {
            statusCode = HttpStatusCode.Conflict;
        }
        else if (exceptionType == typeof(NotImplementedException))
        {
            statusCode = HttpStatusCode.NotImplemented;
        }

        return statusCode;
    }

    private void HandleException(ExceptionContext context)
    {
        context.Result = new ContentResult
        {
            ContentType = MediaTypeNames.Application.Json,
            StatusCode = (int)GetHttpStatusCodeByExceptionType(context),
            Content = useProblemDetailsAsResponseBody
                ? JsonSerializer.Serialize(CreateProblemDetails(context))
                : CreateMessage(context),
        };
    }

    [SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "OK.")]
    [SuppressMessage("Usage", "MA0011:IFormatProvider is missing", Justification = "OK.")]
    private string CreateMessage(ExceptionContext context)
    {
        var sb = new StringBuilder();

        var traceId = context.HttpContext.GetCorrelationId();
        if (!string.IsNullOrEmpty(traceId))
        {
            sb.Append($"TraceId: {traceId}");
        }

        if (includeException && context.Exception is not null)
        {
            sb.Append(" # ");
            sb.Append(context.Exception.GetMessage(includeInnerMessage: true, includeExceptionName: true));
        }

        return sb.ToString();
    }

    private ProblemDetails CreateProblemDetails(ExceptionContext context)
    {
        var statusCode = GetHttpStatusCodeByExceptionType(context);
        var title = ensurePascalCaseAndSpacesBetweenWordsRegex.Replace(statusCode.ToString(), " $1");

        return new ProblemDetails { Status = (int)statusCode, Title = title, Detail = CreateMessage(context) };
    }
}