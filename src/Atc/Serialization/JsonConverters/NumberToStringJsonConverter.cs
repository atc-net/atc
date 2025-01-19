// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault
namespace Atc.Serialization.JsonConverters;

public sealed class NumberToStringJsonConverter : JsonConverter<object>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeof(string) == typeToConvert;
    }

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