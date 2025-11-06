namespace Atc.Serialization.JsonConverters;

/// <summary>
/// JSON converter that serializes <see cref="TimeSpan"/> values to and from their string representation.
/// </summary>
/// <remarks>
/// This converter writes <see cref="TimeSpan"/> values as culture-invariant strings and reads string values
/// back into <see cref="TimeSpan"/> objects using <see cref="CultureInfo.InvariantCulture"/> for parsing.
/// </remarks>
public sealed class TimeSpanJsonConverter : JsonConverter<TimeSpan>
{
    /// <inheritdoc />
    public override TimeSpan Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
        => TimeSpan.Parse(reader.GetString()!, CultureInfo.InvariantCulture);

    /// <inheritdoc />
    public override void Write(
        Utf8JsonWriter writer,
        TimeSpan value,
        JsonSerializerOptions options)
    {
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        writer.WriteStringValue(value.ToString());
    }
}