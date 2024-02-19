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
    /// <value><c>true</c> if Swagger requests should be skipped; otherwise, <c>false</c>. The default is <c>true</c>.</value>
    /// <remarks>
    /// Skipping Swagger requests can reduce noise in logs from automated or development-time API exploration.
    /// </remarks>
    public bool SkipSwaggerRequests { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether SignalR requests should be exempt from logging.
    /// </summary>
    /// <value><c>true</c> if SignalR requests should be skipped; otherwise, <c>false</c>. The default is <c>true</c>.</value>
    /// <remarks>
    /// Skipping SignalR requests can reduce noise in logs from real-time communications.
    /// </remarks>
    public bool SkipSignalrRequests { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether request query parameters should be included in logs.
    /// </summary>
    /// <value><c>true</c> if request query parameters should be logged; otherwise, <c>false</c>. The default is <c>true</c>.</value>
    public bool IncludeRequestQueryParameters { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether request header parameters should be included in logs.
    /// </summary>
    /// <value><c>true</c> if request header parameters should be logged; otherwise, <c>false</c>. The default is <c>true</c>.</value>
    public bool IncludeRequestHeaderParameters { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether response header parameters should be included in logs.
    /// </summary>
    /// <value><c>true</c> if response header parameters should be logged; otherwise, <c>false</c>. The default is <c>true</c>.</value>
    public bool IncludeResponseHeaderParameters { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether the response body should be logged.
    /// </summary>
    /// <value><c>true</c> if the response body should be logged; otherwise, <c>false</c>. The default is <c>true</c>.</value>
    /// <remarks>
    /// Logging the response body can be useful for debugging responses but may increase the size of log files.
    /// </remarks>
    public bool IncludeResponseBody { get; set; } = true;

    /// <inheritdoc />
    public override string ToString()
        => $"{nameof(DefaultLogLevel)}: {DefaultLogLevel}, {nameof(SkipSwaggerRequests)}: {SkipSwaggerRequests}, {nameof(SkipSignalrRequests)}: {SkipSignalrRequests}, {nameof(IncludeRequestQueryParameters)}: {IncludeRequestQueryParameters}, {nameof(IncludeRequestHeaderParameters)}: {IncludeRequestHeaderParameters}, {nameof(IncludeResponseHeaderParameters)}: {IncludeResponseHeaderParameters}, {nameof(IncludeResponseBody)}: {IncludeResponseBody}";
}