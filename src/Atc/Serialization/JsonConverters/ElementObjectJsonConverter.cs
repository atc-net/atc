namespace Atc.Serialization.JsonConverters;

/// <summary>
/// JSON converter that deserializes JSON elements into appropriate CLR object types (dictionaries, lists, primitives).
/// </summary>
/// <remarks>
/// This converter is used internally by <see cref="DynamicJson"/> to convert JSON structures into dynamic objects.
/// It maps JSON objects to <see cref="Dictionary{TKey, TValue}"/>, JSON arrays to <see cref="List{T}"/>,
/// and JSON primitives to their corresponding CLR types. This converter only supports reading; writing is not supported.
/// </remarks>
public sealed class ElementObjectJsonConverter : JsonConverter<object>
{
    /// <inheritdoc />
    public override object? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        return ConvertElementToObject(doc.RootElement);
    }

    /// <inheritdoc />
    /// <exception cref="InvalidOperationException">This converter does not support writing.</exception>
    public override void Write(
        Utf8JsonWriter writer,
        object value,
        JsonSerializerOptions options)
    {
        throw new InvalidOperationException("Should not get here.");
    }

    private static object? ConvertElementToObject(
        JsonElement element)
        => element.ValueKind switch
        {
            JsonValueKind.Object => element
                .EnumerateObject()
                .ToDictionary(prop => prop.Name, prop => ConvertElementToObject(prop.Value), StringComparer.Ordinal),
            JsonValueKind.Array => element
                .EnumerateArray()
                .Select(ConvertElementToObject).ToList(),
            JsonValueKind.String => element.GetString(),
            JsonValueKind.Number => element.GetDecimal(),
            JsonValueKind.True => true,
            JsonValueKind.False => false,
            JsonValueKind.Null => null,
            _ => throw new SwitchCaseDefaultException(element.ValueKind),
        };
}