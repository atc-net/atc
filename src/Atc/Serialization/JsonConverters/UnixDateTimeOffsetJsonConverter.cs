namespace Atc.Serialization.JsonConverters;

/// <summary>
/// JSON converter that serializes <see cref="DateTimeOffset"/> values to and from Unix timestamp (seconds since epoch) representation.
/// </summary>
/// <remarks>
/// This converter writes <see cref="DateTimeOffset"/> values as Unix timestamps (64-bit integers representing seconds since 1970-01-01T00:00:00Z)
/// and reads Unix timestamp integers back into <see cref="DateTimeOffset"/> objects. <see cref="DateTimeOffset.MinValue"/> is treated as null.
/// </remarks>
public sealed class UnixDateTimeOffsetJsonConverter : JsonConverter<DateTimeOffset?>
{
    /// <inheritdoc />
    public override DateTimeOffset? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
        => reader.TryGetInt64(out var value)
            ? DateTimeOffset.FromUnixTimeSeconds(value)
            : default;

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
            writer.WriteNumberValue(value.Value.ToUnixTimeSeconds());
        }
    }
}