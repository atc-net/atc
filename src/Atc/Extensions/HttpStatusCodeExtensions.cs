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
    public static string ToNormalizedString(this HttpStatusCode httpStatusCode)
        => httpStatusCode switch
        {
            HttpStatusCode.OK => "Ok",
#if !NETSTANDARD2_0
            HttpStatusCode.IMUsed => "ImUsed",
#endif
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
    /// Gets a stable C# identifier for the HTTP status code: the <see cref="HttpStatusCode"/> member name, with one fixed
    /// name for the codes that have aliases, and <c>Status{code}</c> for a code that is not a member.
    /// </summary>
    /// <remarks>
    /// <see cref="Enum.ToString()"/> picks any one of the aliases for 300, 301, 302, 303, 307 and 422; this method always
    /// gives <c>MultipleChoices</c>, <c>MovedPermanently</c>, <c>Found</c>, <c>SeeOther</c>, <c>TemporaryRedirect</c> and
    /// <c>UnprocessableEntity</c>. A code the running framework does not define (e.g. 499, or 429 on .NET Standard 2.0)
    /// becomes <c>Status499</c>.
    /// </remarks>
    /// <param name="httpStatusCode">The HTTP status code.</param>
    /// <returns>An identifier such as <c>OK</c>, <c>NotFound</c>, <c>Found</c> or <c>Status499</c>.</returns>
    public static string ToEnumName(this HttpStatusCode httpStatusCode)
    {
        var statusCode = (int)httpStatusCode;
        switch (statusCode)
        {
            case 300:
                return "MultipleChoices";
            case 301:
                return "MovedPermanently";
            case 302:
                return "Found";
            case 303:
                return "SeeOther";
            case 307:
                return "TemporaryRedirect";
            case 422:
                return "UnprocessableEntity";
        }

        return Enum.IsDefined(typeof(HttpStatusCode), httpStatusCode)
            ? httpStatusCode.ToString()
            : $"Status{statusCode.ToString(CultureInfo.InvariantCulture)}";
    }

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