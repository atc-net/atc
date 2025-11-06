// ReSharper disable once CheckNamespace
namespace System.Net;

/// <summary>
/// Provides extension methods for the <see cref="HttpStatusCode"/> enumeration.
/// </summary>
public static class HttpStatusCodeExtensions
{
    /// <summary>
    /// Converts the HTTP status code to a normalized string representation.
    /// </summary>
    /// <param name="httpStatusCode">The HTTP status code to convert.</param>
    /// <returns>A normalized string representation of the HTTP status code (e.g., "Ok" instead of "OK").</returns>
    public static string ToNormalizedString(
        this HttpStatusCode httpStatusCode)
        => httpStatusCode switch
        {
            HttpStatusCode.OK => "Ok",
            HttpStatusCode.IMUsed => "ImUsed",
            _ => httpStatusCode.ToString(),
        };

    /// <summary>
    /// Converts the HTTP status code to a status codes constant name format.
    /// </summary>
    /// <param name="httpStatusCode">The HTTP status code to convert.</param>
    /// <returns>A string in the format "Status{code}{name}" (e.g., "Status200OK").</returns>
    public static string ToStatusCodesConstant(
        this HttpStatusCode httpStatusCode)
        => httpStatusCode switch
        {
            HttpStatusCode.NonAuthoritativeInformation => "Status203NonAuthoritative",
            HttpStatusCode.Unused => "Status306SwitchProxy",
            HttpStatusCode.RedirectKeepVerb => "Status307TemporaryRedirect",
            HttpStatusCode.HttpVersionNotSupported => "Status505HttpVersionNotsupported",
            _ => $"Status{(int)httpStatusCode}{httpStatusCode}",
        };

    /// <summary>
    /// Determines whether the HTTP status code is informational (1xx range).
    /// </summary>
    /// <param name="httpStatusCode">The HTTP status code to check.</param>
    /// <returns><see langword="true"/> if the status code is between 100-199; otherwise, <see langword="false"/>.</returns>
    public static bool IsInformational(this HttpStatusCode httpStatusCode)
        => (int)httpStatusCode >= 100 && (int)httpStatusCode < 200;

    /// <summary>
    /// Determines whether the HTTP status code indicates success (2xx range).
    /// </summary>
    /// <param name="httpStatusCode">The HTTP status code to check.</param>
    /// <returns><see langword="true"/> if the status code is between 200-299; otherwise, <see langword="false"/>.</returns>
    public static bool IsSuccessful(this HttpStatusCode httpStatusCode)
        => (int)httpStatusCode >= 200 && (int)httpStatusCode < 300;

    /// <summary>
    /// Determines whether the HTTP status code indicates a redirect (3xx range).
    /// </summary>
    /// <param name="httpStatusCode">The HTTP status code to check.</param>
    /// <returns><see langword="true"/> if the status code is between 300-399; otherwise, <see langword="false"/>.</returns>
    public static bool IsRedirect(this HttpStatusCode httpStatusCode)
        => (int)httpStatusCode >= 300 && (int)httpStatusCode < 400;

    /// <summary>
    /// Determines whether the HTTP status code indicates a client error (4xx range).
    /// </summary>
    /// <param name="httpStatusCode">The HTTP status code to check.</param>
    /// <returns><see langword="true"/> if the status code is between 400-499; otherwise, <see langword="false"/>.</returns>
    public static bool IsClientError(this HttpStatusCode httpStatusCode)
        => (int)httpStatusCode >= 400 && (int)httpStatusCode < 500;

    /// <summary>
    /// Determines whether the HTTP status code indicates a server error (5xx range).
    /// </summary>
    /// <param name="httpStatusCode">The HTTP status code to check.</param>
    /// <returns><see langword="true"/> if the status code is between 500-599; otherwise, <see langword="false"/>.</returns>
    public static bool IsServerError(this HttpStatusCode httpStatusCode)
        => (int)httpStatusCode >= 500 && (int)httpStatusCode < 600;

    /// <summary>
    /// Determines whether the HTTP status code indicates either a client error or a server error (4xx or 5xx range).
    /// </summary>
    /// <param name="httpStatusCode">The HTTP status code to check.</param>
    /// <returns><see langword="true"/> if the status code is between 400-599; otherwise, <see langword="false"/>.</returns>
    public static bool IsClientOrServerError(this HttpStatusCode httpStatusCode)
        => httpStatusCode.IsClientError() || httpStatusCode.IsServerError();
}