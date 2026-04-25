// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault
namespace Atc.Rest.Middleware;

/// <summary>
/// Middleware that logs HTTP request and response details for debugging and monitoring purposes.
/// </summary>
/// <remarks>
/// This middleware captures request and response information including headers, query parameters, and body content.
/// It supports configurable logging options through <see cref="RequestResponseLoggerOptions"/>, such as:
/// <list type="bullet">
/// <item>Skipping Swagger and SignalR requests</item>
/// <item>Including/excluding query parameters, headers, and response body</item>
/// <item>Automatic redaction of binary content</item>
/// <item>Exception tracking</item>
/// </list>
/// Binary content is replaced with "# BINARY-DATA-REDACTED #" to prevent large log entries.
/// </remarks>
[SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
[SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
[SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "OK.")]
[SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
public class RequestResponseLoggerMiddleware
{
    private const string BinaryDataRedactedString = "# BINARY-DATA-REDACTED #";

    private readonly RequestDelegate next;
    private readonly ILogger<RequestResponseLoggerMiddleware> logger;
    private readonly JsonSerializerOptions jsonSerializerOptions;
    private readonly RestApiOptions apiOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="RequestResponseLoggerMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware delegate in the pipeline.</param>
    /// <param name="logger">The logger instance.</param>
    /// <param name="apiOptions">The REST API configuration options.</param>
    public RequestResponseLoggerMiddleware(
        RequestDelegate next,
        ILogger<RequestResponseLoggerMiddleware> logger,
        IOptions<RestApiOptions> apiOptions)
    {
        this.next = next;
        this.logger = logger;
        this.apiOptions = apiOptions.Value;
        jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
    }

    /// <summary>
    /// Invokes the middleware to log request and response details.
    /// </summary>
    /// <param name="httpContext">The HTTP context.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task InvokeAsync(HttpContext httpContext)
    {
        if (!httpContext.Request.Path.HasValue ||
            (apiOptions.RequestResponseLoggerOptions.SkipSwaggerRequests &&
             httpContext.Request.Path.Value.StartsWith("/swagger", StringComparison.Ordinal)) ||
            (apiOptions.RequestResponseLoggerOptions.SkipSignalrRequests &&
             (httpContext.Request.Path.Value.StartsWith("/signalr/", StringComparison.Ordinal) ||
              httpContext.Request.Path.Value.StartsWith("/hubs/", StringComparison.Ordinal))))
        {
            await next(httpContext);
            return;
        }

        var logModel = await CreateRequestResponseLogModel(httpContext);

        Stream? originalResponseBody = null;
        MemoryStream? swapStream = null;
        if (apiOptions.RequestResponseLoggerOptions.IncludeResponseBody)
        {
            // Temporarily replace the HttpResponseStream, which is a write-only stream, with a MemoryStream to capture its value in-flight.
            swapStream = new MemoryStream();
            var response = httpContext.Response;
            originalResponseBody = response.Body;
            response.Body = swapStream;
        }

        try
        {
            // Call the next middleware in the pipeline
            await next(httpContext);
        }
        catch (Exception exception)
        {
            // Exception was not managed at app.UseExceptionHandler() or by any middleware
            logModel.SetException(exception);
        }

        logModel.Response = new ResponseLogModel(
            httpContext.Response,
            apiOptions.RequestResponseLoggerOptions.IncludeResponseHeaderParameters);

        if (apiOptions.RequestResponseLoggerOptions.IncludeResponseBody &&
            originalResponseBody is not null &&
            swapStream is not null)
        {
            try
            {
                if (logModel.Response.ContentType is not null &&
                    IsBinaryContent(logModel.Response.ContentType))
                {
                    swapStream.Seek(0, SeekOrigin.Begin);
                    await swapStream.CopyToAsync(originalResponseBody);
                    httpContext.Response.Body = originalResponseBody;

                    logModel.Response.Body = BinaryDataRedactedString;
                }
                else
                {
                    swapStream.Seek(0, SeekOrigin.Begin);
                    string responseBodyText;
                    using (var reader = new StreamReader(swapStream, leaveOpen: true))
                    {
                        responseBodyText = await reader.ReadToEndAsync();
                    }

                    swapStream.Seek(0, SeekOrigin.Begin);
                    await swapStream.CopyToAsync(originalResponseBody);
                    httpContext.Response.Body = originalResponseBody;

                    StripBinaryContentPartFromRequestResponseBody(ref responseBodyText);

                    logModel.Response.Body = responseBodyText;
                }
            }
            finally
            {
                await swapStream.DisposeAsync();
            }
        }

        // Exception was managed at app.UseExceptionHandler() or by any middleware
        var contextFeature = httpContext.Features.Get<IExceptionHandlerPathFeature>();
        if (contextFeature is { Error: { } })
        {
            logModel.SetException(contextFeature.Error);
        }

        Log(logModel);
    }

    private async Task<RequestResponseLogModel> CreateRequestResponseLogModel(
        HttpContext httpContext)
        => new(
            httpContext.Request,
            apiOptions.RequestResponseLoggerOptions.IncludeRequestQueryParameters,
            apiOptions.RequestResponseLoggerOptions.IncludeRequestHeaderParameters)
        {
            Request =
            {
                Body = await ReadBodyFromRequest(httpContext.Request, apiOptions.RequestResponseLoggerOptions.MaxRequestBodyBufferSize),
            },
        };

    private static async Task<string> ReadBodyFromRequest(
        HttpRequest request,
        long maxBufferSize = 0)
    {
        // Ensure the request's body can be read multiple times for the next middleware in the pipeline
        if (maxBufferSize > 0)
        {
            request.EnableBuffering(bufferThreshold: (int)System.Math.Min(maxBufferSize, int.MaxValue));
        }
        else
        {
            request.EnableBuffering();
        }

        using var streamReader = new StreamReader(request.Body, leaveOpen: true);
        var requestBody = await streamReader.ReadToEndAsync();

        // Reset the request's body stream position for next middleware in the pipeline.
        request.Body.Position = 0;

        StripBinaryContentPartFromRequestResponseBody(ref requestBody);

        return requestBody;
    }

    private static void StripBinaryContentPartFromRequestResponseBody(
        ref string bodyContent)
    {
        if (string.IsNullOrEmpty(bodyContent))
        {
            return;
        }

        var saContentTypes = bodyContent.Split(
            new[] { "Content-Type: " },
            StringSplitOptions.RemoveEmptyEntries);

        if (saContentTypes.Length <= 1)
        {
            return;
        }

        var sb = new StringBuilder();
        foreach (var part in saContentTypes)
        {
            if (IsBinaryContent(part))
            {
                if (part.StartsWith("application/json", StringComparison.OrdinalIgnoreCase) ||
                    part.StartsWith("application/xml", StringComparison.OrdinalIgnoreCase))
                {
                    sb.AppendLine(part);
                }
                else
                {
                    var saDoubleNewLines = part.Split(
                        new[] { $"{Environment.NewLine}{Environment.NewLine}" },
                        StringSplitOptions.RemoveEmptyEntries);

                    if (saDoubleNewLines.Length <= 1)
                    {
                        continue;
                    }

                    const int MaxAsciiValue = 255;
                    var sbOverridePart = new StringBuilder();
                    foreach (var s in saDoubleNewLines)
                    {
                        sbOverridePart.Append(
                            s.Any(c => c > MaxAsciiValue)
                                ? $"{Environment.NewLine}{BinaryDataRedactedString}"
                                : s);
                    }

                    sb.AppendLine(sbOverridePart.ToString());
                }
            }
            else
            {
                sb.AppendLine(part);
            }
        }

        bodyContent = sb.ToString();
    }

    private void Log(RequestResponseLogModel logModel)
    {
        var logLevel = string.IsNullOrEmpty(logModel.ExceptionMessage)
            ? apiOptions.RequestResponseLoggerOptions.DefaultLogLevel
            : LogLevel.Error;

        if (!logger.IsEnabled(logLevel))
        {
            return;
        }

#pragma warning disable CA2254 // Template should be a static expression
        logger.Log(
            logLevel,
            "{System} {Method} {Path} {Status} {ExecutionTime} {RequestResponseLog}",
            logModel.System,
            logModel.Request.Method,
            logModel.Request.Path,
            logModel.Response?.Status,
            logModel.ExecutionTime,
            JsonSerializer.Serialize(logModel, jsonSerializerOptions));
#pragma warning restore CA2254
    }

    private static bool IsBinaryContent(string contentType)
        => !contentType.Equals(MediaTypeNames.Application.Json, StringComparison.OrdinalIgnoreCase) &&
           !contentType.Equals(MediaTypeNames.Application.JsonPatch, StringComparison.OrdinalIgnoreCase) &&
           !contentType.Equals(MediaTypeNames.Application.Xml, StringComparison.OrdinalIgnoreCase) &&
           (contentType.StartsWith("application/", StringComparison.OrdinalIgnoreCase) ||
            contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) ||
            contentType.StartsWith("audio/", StringComparison.OrdinalIgnoreCase) ||
            contentType.StartsWith("video/", StringComparison.OrdinalIgnoreCase) ||
            contentType.StartsWith("multipart/", StringComparison.OrdinalIgnoreCase));
}