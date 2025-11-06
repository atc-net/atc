namespace Atc.Serialization.JsonConverters;

/// <summary>
/// JSON converter that serializes <see cref="DateTimeOffset"/> values to and from ISO 8601 string format,
/// treating <see cref="DateTimeOffset.MinValue"/> as null.
/// </summary>
/// <remarks>
/// This converter writes <see cref="DateTimeOffset"/> values as ISO 8601 UTC strings. When reading or writing,
/// <see cref="DateTimeOffset.MinValue"/> is treated as null and serialized as a JSON null value. All dates are
/// normalized to UTC during serialization and deserialization.
/// </remarks>
public sealed class DateTimeOffsetMinToNullJsonConverter : JsonConverter<DateTimeOffset?>
{
    /// <inheritdoc />
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

    /// <inheritdoc />
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