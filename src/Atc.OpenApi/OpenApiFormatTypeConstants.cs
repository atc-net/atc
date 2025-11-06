// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models;

/// <summary>
/// Provides constant values for OpenAPI format types as defined in the OpenAPI specification.
/// These format types provide additional semantic information about data types.
/// See: https://swagger.io/docs/specification/data-models/data-types/
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", Justification = "OK.")]
public static class OpenApiFormatTypeConstants
{
    /// <summary>
    /// UUID format type for string data (universally unique identifier).
    /// </summary>
    public const string Uuid = "uuid";

    /// <summary>
    /// Date format type for string data (full-date as defined by RFC 3339).
    /// </summary>
    public const string Date = "date";

    /// <summary>
    /// Time format type for string data (full-time as defined by RFC 3339).
    /// </summary>
    public const string Time = "time";

    /// <summary>
    /// Timestamp format type for string data (legacy format).
    /// </summary>
    public const string Timestamp = "timestamp"; // This is a legacy

    /// <summary>
    /// Date-time format type for string data (date-time as defined by RFC 3339).
    /// </summary>
    public const string DateTime = "date-time";

    /// <summary>
    /// Byte format type for string data (base64-encoded characters).
    /// </summary>
    public const string Byte = "byte";

    /// <summary>
    /// Binary format type for string data (any sequence of octets).
    /// </summary>
    public const string Binary = "binary";

    /// <summary>
    /// Int32 format type for integer data (signed 32-bit integer).
    /// </summary>
    public const string Int32 = "int32";

    /// <summary>
    /// Int64 format type for integer data (signed 64-bit integer).
    /// </summary>
    public const string Int64 = "int64";

    /// <summary>
    /// Email format type for string data (email address).
    /// </summary>
    public const string Email = "email";

    /// <summary>
    /// URI format type for string data (Uniform Resource Identifier).
    /// </summary>
    public const string Uri = "uri";

    /// <summary>
    /// Float format type for number data (single-precision floating point).
    /// </summary>
    public const string Float = "float";

    /// <summary>
    /// Double format type for number data (double-precision floating point).
    /// </summary>
    public const string Double = "double";
}