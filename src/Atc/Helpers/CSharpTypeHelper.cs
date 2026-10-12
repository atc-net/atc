namespace Atc.Helpers;

/// <summary>
/// Helper methods for C# type classification and checking.
/// </summary>
public static class CSharpTypeHelper
{
    /// <summary>
    /// Core numeric types: int, long, short, byte, float, double, decimal, Half.
    /// </summary>
    private static readonly HashSet<string> NumericTypes = new(StringComparer.Ordinal)
    {
        "int",
        "long",
        "short",
        "byte",
        "float",
        "double",
        "decimal",
        "Half",
    };

    /// <summary>
    /// Basic value types: numeric types + bool.
    /// </summary>
    private static readonly HashSet<string> BasicValueTypes = new(StringComparer.Ordinal)
    {
        "int",
        "long",
        "short",
        "byte",
        "bool",
        "float",
        "double",
        "decimal",
        "Half",
    };

    /// <summary>
    /// Extended value types: basic value types + Guid, DateTime, DateTimeOffset, DateOnly, TimeOnly, TimeSpan.
    /// </summary>
    private static readonly HashSet<string> ExtendedValueTypes = new(StringComparer.Ordinal)
    {
        "int",
        "long",
        "short",
        "byte",
        "bool",
        "float",
        "double",
        "decimal",
        "Half",
        "Guid",
        "DateTime",
        "DateTimeOffset",
        "DateOnly",
        "TimeOnly",
        "TimeSpan",
    };

    /// <summary>
    /// Determines if a type is a numeric type (int, long, short, byte, float, double, decimal, Half).
    /// Handles nullable types by checking the base type.
    /// </summary>
    /// <param name="typeName">The C# type name (e.g., "int", "long?").</param>
    /// <returns>True if the type is numeric.</returns>
    public static bool IsNumericType(string typeName)
        => NumericTypes.Contains(GetBaseType(typeName));

    /// <summary>
    /// Determines if a type is a basic value type (numeric + bool).
    /// Handles nullable types by checking the base type.
    /// </summary>
    /// <param name="typeName">The C# type name (e.g., "int", "bool?").</param>
    /// <returns>True if the type is a basic value type.</returns>
    public static bool IsBasicValueType(string typeName)
        => BasicValueTypes.Contains(GetBaseType(typeName));

    /// <summary>
    /// Determines if a type is an extended value type (includes Guid, DateTime, DateTimeOffset, DateOnly, TimeOnly, TimeSpan).
    /// Handles nullable types by checking the base type.
    /// </summary>
    /// <param name="typeName">The C# type name (e.g., "Guid", "DateTimeOffset?").</param>
    /// <returns>True if the type is an extended value type.</returns>
    public static bool IsExtendedValueType(string typeName)
        => ExtendedValueTypes.Contains(GetBaseType(typeName));

    /// <summary>
    /// Determines if a type is nullable (ends with ?).
    /// </summary>
    /// <param name="typeName">The C# type name.</param>
    /// <returns>True if the type is nullable.</returns>
    public static bool IsNullable(string typeName)
        => !string.IsNullOrEmpty(typeName) &&
           typeName.EndsWith("?", StringComparison.Ordinal);

    /// <summary>
    /// Gets the base type by removing the nullable marker (?).
    /// </summary>
    /// <param name="typeName">The C# type name (e.g., "int?").</param>
    /// <returns>The base type (e.g., "int").</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="typeName"/> is <see langword="null"/>.</exception>
    public static string GetBaseType(string typeName)
        => string.IsNullOrEmpty(typeName)
            ? string.Empty
            : typeName.TrimEnd('?');
}