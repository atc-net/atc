namespace Atc.Rest.Options;

public sealed class RequestResponseLoggerOptions
{
    /// <summary>
    /// Indicates the default log level for the logger.
    /// </summary>
    public LogLevel DefaultLogLevel { get; set; } = LogLevel.Information;

    /// <summary>
    /// Indicates if swagger requests should be exempt from logger.
    /// </summary>
    /// <remarks>
    /// Default set to <see langword="true"/>.
    /// </remarks>
    public bool SkipSwaggerRequests { get; set; } = true;

    /// <summary>
    /// Indicates if response body is logged.
    /// </summary>
    /// <remarks>
    /// Default set to <see langword="true"/>.
    /// </remarks>
    public bool IncludeResponseBody { get; set; } = true;
}