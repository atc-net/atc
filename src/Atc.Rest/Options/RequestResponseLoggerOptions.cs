namespace Atc.Rest.Options;

public sealed class RequestResponseLoggerOptions
{
    /// <summary>
    /// Gets or sets the default log level for the logger.
    /// </summary>
    /// <value>The default log level. The default is <see cref="LogLevel.Information"/>.</value>
    public LogLevel DefaultLogLevel { get; set; } = LogLevel.Information;

    /// <summary>
    /// Gets or sets a value indicating whether Swagger requests should be exempt from logging.
    /// </summary>
    /// <value><see langword="true" /> if Swagger requests should be skipped; otherwise, <see langword="false" />. The default is <see langword="true" />.</value>
    /// <remarks>
    /// Skipping Swagger requests can reduce noise in logs from automated or development-time API exploration.
    /// </remarks>
    public bool SkipSwaggerRequests { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether SignalR requests should be exempt from logging.
    /// </summary>
    /// <value><see langword="true" /> if SignalR requests should be skipped; otherwise, <see langword="false" />. The default is <see langword="true" />.</value>
    /// <remarks>
    /// Skipping SignalR requests can reduce noise in logs from real-time communications.
    /// </remarks>
    public bool SkipSignalrRequests { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether request query parameters should be included in logs.
    /// </summary>
    /// <value><see langword="true" /> if request query parameters should be logged; otherwise, <see langword="false" />. The default is <see langword="true" />.</value>
    public bool IncludeRequestQueryParameters { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether request header parameters should be included in logs.
    /// </summary>
    /// <value><see langword="true" /> if request header parameters should be logged; otherwise, <see langword="false" />. The default is <see langword="true" />.</value>
    public bool IncludeRequestHeaderParameters { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether response header parameters should be included in logs.
    /// </summary>
    /// <value><see langword="true" /> if response header parameters should be logged; otherwise, <see langword="false" />. The default is <see langword="true" />.</value>
    public bool IncludeResponseHeaderParameters { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether the response body should be logged.
    /// </summary>
    /// <value><see langword="true" /> if the response body should be logged; otherwise, <see langword="false" />. The default is <see langword="true" />.</value>
    /// <remarks>
    /// Logging the response body can be useful for debugging responses but may increase the size of log files.
    /// </remarks>
    public bool IncludeResponseBody { get; set; } = true;

    /// <summary>
    /// Gets or sets the maximum request body size in bytes that will be buffered for logging.
    /// </summary>
    /// <value>The maximum body size in bytes. Default is 1 MB (1,048,576 bytes). Set to 0 for unlimited.</value>
    /// <remarks>
    /// When the request body exceeds this limit, buffering is still enabled but the body content
    /// is not captured in logs. This prevents memory exhaustion from excessively large request bodies.
    /// </remarks>
    public long MaxRequestBodyBufferSize { get; set; } = 1_048_576;

    /// <inheritdoc />
    public override string ToString()
        => $"{nameof(DefaultLogLevel)}: {DefaultLogLevel}, {nameof(SkipSwaggerRequests)}: {SkipSwaggerRequests}, {nameof(SkipSignalrRequests)}: {SkipSignalrRequests}, {nameof(IncludeRequestQueryParameters)}: {IncludeRequestQueryParameters}, {nameof(IncludeRequestHeaderParameters)}: {IncludeRequestHeaderParameters}, {nameof(IncludeResponseHeaderParameters)}: {IncludeResponseHeaderParameters}, {nameof(IncludeResponseBody)}: {IncludeResponseBody}";
}