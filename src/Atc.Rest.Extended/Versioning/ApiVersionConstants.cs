namespace Atc.Rest.Extended.Versioning;

/// <summary>
/// Constants for API versioning parameter names used in headers, media types, and query strings.
/// </summary>
public static class ApiVersionConstants
{
    /// <summary>
    /// The header parameter name for API version ("x-api-version").
    /// </summary>
    public const string ApiVersionHeaderParameter = "x-api-version";

    /// <summary>
    /// The media type parameter name for API version ("v").
    /// </summary>
    public const string ApiVersionMediaTypeParameter = "v";

    /// <summary>
    /// The query parameter name for API version ("api-version").
    /// </summary>
    public const string ApiVersionQueryParameter = "api-version";

    /// <summary>
    /// The short query parameter name for API version ("v").
    /// </summary>
    public const string ApiVersionQueryParameterShort = "v";
}