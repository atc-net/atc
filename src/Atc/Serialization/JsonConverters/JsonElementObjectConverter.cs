namespace Atc.Serialization.JsonConverters;

public class JsonElementObjectConverter : JsonConverter<object>
{
    public override object? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        return ConvertElementToObject(doc.RootElement);
    }

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