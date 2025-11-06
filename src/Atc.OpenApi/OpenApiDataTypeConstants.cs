// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models;

/// <summary>
/// Provides constant values for OpenAPI primitive data types as defined in the OpenAPI specification.
/// See: https://swagger.io/docs/specification/data-models/data-types/
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1720", Justification = "OK.")]
public static class OpenApiDataTypeConstants
{
    /// <summary>
    /// Array data type for ordered collections of values.
    /// </summary>
    public const string Array = "array";

    /// <summary>
    /// Boolean data type for true/false values.
    /// </summary>
    public const string Boolean = "boolean";

    /// <summary>
    /// Integer data type for whole numbers.
    /// </summary>
    public const string Integer = "integer";

    /// <summary>
    /// Number data type for numeric values (including decimals).
    /// </summary>
    public const string Number = "number";

    /// <summary>
    /// Object data type for structured key-value pairs.
    /// </summary>
    public const string Object = "object";

    /// <summary>
    /// String data type for text values.
    /// </summary>
    public const string String = "string";
}