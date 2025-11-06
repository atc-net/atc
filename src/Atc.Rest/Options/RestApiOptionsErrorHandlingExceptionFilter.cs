namespace Atc.Rest.Options;

/// <summary>
/// Configuration options for the error handling exception filter.
/// </summary>
/// <remarks>
/// These settings control how unhandled exceptions are converted to HTTP error responses.
/// </remarks>
public class RestApiOptionsErrorHandlingExceptionFilter
{
    /// <summary>
    /// Gets or sets a value indicating whether to enable the error handling exception filter.
    /// </summary>
    public bool Enable { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to format error responses as RFC 7807 ProblemDetails.
    /// </summary>
    /// <remarks>
    /// When true, returns structured ProblemDetails JSON. When false, returns plain text error messages.
    /// </remarks>
    public bool UseProblemDetailsAsResponseBody { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to include exception details in error responses.
    /// </summary>
    /// <remarks>
    /// When true, includes exception messages in the response. Set to false in production environments
    /// to avoid exposing internal implementation details.
    /// </remarks>
    public bool IncludeExceptionDetails { get; set; } = true;
}