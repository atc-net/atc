// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault
namespace Atc.Serialization.JsonConverters;

/// <summary>
/// JSON converter that converts numeric values to string representation and vice versa.
/// </summary>
/// <remarks>
/// This converter handles conversion between JSON numbers and strings, allowing numeric values in JSON
/// to be read as strings. During deserialization, JSON numbers are converted to their string representation
/// using the current thread's culture. During serialization, any object is converted to its string representation.
/// </remarks>
public sealed class NumberToStringJsonConverter : JsonConverter<object>
{
    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert)
    {
        return typeof(string) == typeToConvert;
    }

    /// <inheritdoc />
    public override object Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Number:
                return reader.TryGetInt64(out var l)
                    ? l.ToString(Thread.CurrentThread.CurrentCulture)
                    : reader.GetDouble().ToString(Thread.CurrentThread.CurrentCulture);
            case JsonTokenType.String:
                return reader.GetString() ?? string.Empty;
            default:
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return document.RootElement.Clone().ToString();
            }
        }
    }

    /// <inheritdoc />
    public override void Write(
        Utf8JsonWriter writer,
        object value,
        JsonSerializerOptions options)
    {
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        writer.WriteStringValue(value.ToString());
    }
}