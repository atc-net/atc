namespace Atc.Serialization.JsonConverters;

public class JsonUnixDateTimeOffsetConverter : JsonConverter<DateTimeOffset?>
{
    public override DateTimeOffset? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
        => reader.TryGetInt64(out var value)
            ? DateTimeOffset.FromUnixTimeSeconds(value)
            : default;

    public override void Write(
        Utf8JsonWriter writer,
        DateTimeOffset? value,
        JsonSerializerOptions options)
    {
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        if (!value.HasValue || value == DateTimeOffset.MinValue)
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteNumberValue(value.Value.ToUnixTimeSeconds());
        }
    }
}