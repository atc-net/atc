namespace Atc.Serialization.JsonConverters;

public sealed class DateTimeOffsetMinToNullJsonConverter : JsonConverter<DateTimeOffset?>
{
    public override DateTimeOffset? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var result = new DateTimeOffset(reader.GetDateTime().ToUniversalTime());
        return result == DateTimeOffset.MinValue
            ? null
            : result;
    }

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
            writer.WriteStringValue(value.Value.ToUniversalTime());
        }
    }
}