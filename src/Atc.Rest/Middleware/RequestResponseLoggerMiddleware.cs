// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault
namespace Atc.Rest.Middleware;

[SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
[SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
[SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "OK.")]
public class RequestResponseLoggerMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<RequestResponseLoggerMiddleware> logger;
    private readonly JsonSerializerOptions jsonSerializerOptions;
    private readonly RestApiOptions apiOptions;

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

    public async Task InvokeAsync(
        HttpContext httpContext)
    {
        if (!httpContext.Request.Path.HasValue ||
            (apiOptions.RequestResponseLoggerOptions.SkipSwaggerRequests &&
             httpContext.Request.Path.Value.StartsWith("/swagger", StringComparison.Ordinal)))
        {
            await next(httpContext);
            return;
        }

        var logModel = await CreateRequestResponseLogModel(httpContext);

        Stream? originalResponseBody = null;
        using var swapStream = new MemoryStream();
        if (apiOptions.RequestResponseLoggerOptions.IncludeResponseBody)
        {
            // Temporarily replace the HttpResponseStream, which is a write-only stream, with a MemoryStream to capture its value in-flight.
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

        logModel.Response = new ResponseLogModel(httpContext.Response);

        if (apiOptions.RequestResponseLoggerOptions.IncludeResponseBody &&
            originalResponseBody is not null)
        {
            swapStream.Seek(0, SeekOrigin.Begin);
            var responseBodyText = await new StreamReader(swapStream).ReadToEndAsync();

            swapStream.Seek(0, SeekOrigin.Begin);
            await swapStream.CopyToAsync(originalResponseBody);
            httpContext.Response.Body = originalResponseBody;

            logModel.Response.Body = responseBodyText;
        }

        // Exception was managed at app.UseExceptionHandler() or by any middleware
        var contextFeature = httpContext.Features.Get<IExceptionHandlerPathFeature>();
        if (contextFeature is { Error: { } })
        {
            logModel.SetException(contextFeature.Error);
        }

        Log(logModel);
    }

    private static async Task<RequestResponseLogModel> CreateRequestResponseLogModel(
        HttpContext httpContext)
        => new(httpContext.Request)
        {
            Request =
            {
                Body = await ReadBodyFromRequest(httpContext.Request),
            },
        };

    private void Log(
        RequestResponseLogModel logModel)
    {
        if (string.IsNullOrEmpty(logModel.ExceptionMessage))
        {
            switch (apiOptions.RequestResponseLoggerOptions.DefaultLogLevel)
            {
                case LogLevel.Trace:
                    logger.LogTrace(JsonSerializer.Serialize(logModel, jsonSerializerOptions));
                    break;
                case LogLevel.Debug:
                    logger.LogDebug(JsonSerializer.Serialize(logModel, jsonSerializerOptions));
                    break;
                case LogLevel.Information:
                case LogLevel.Warning:
                case LogLevel.Error:
                case LogLevel.Critical:
                case LogLevel.None:
                    logger.LogInformation(JsonSerializer.Serialize(logModel, jsonSerializerOptions));
                    break;
            }
        }
        else
        {
            logger.LogError(JsonSerializer.Serialize(logModel, jsonSerializerOptions));
        }
    }

    private static async Task<string> ReadBodyFromRequest(
        HttpRequest request)
    {
        // Ensure the request's body can be read multiple times for the next middleware in the pipeline
        request.EnableBuffering();
        using var streamReader = new StreamReader(request.Body, leaveOpen: true);
        var requestBody = await streamReader.ReadToEndAsync();

        // Reset the request's body stream position for next middleware in the pipeline.
        request.Body.Position = 0;
        return requestBody;
    }
}