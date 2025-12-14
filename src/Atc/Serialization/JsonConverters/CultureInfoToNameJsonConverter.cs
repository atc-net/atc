namespace Atc.Serialization.JsonConverters;

/// <summary>
/// JSON converter that serializes <see cref="CultureInfo"/> objects to and from their culture name string representation.
/// </summary>
/// <remarks>
/// This converter writes <see cref="CultureInfo"/> as its <see cref="CultureInfo.Name"/> property value (e.g., "en-US", "da-DK")
/// and reads culture name strings back into <see cref="CultureInfo"/> objects. Null or empty values are preserved.
/// </remarks>
public sealed class CultureInfoToNameJsonConverter : JsonConverter<CultureInfo?>
{
    /// <inheritdoc />
    public override CultureInfo? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var name = reader.GetString();
        return string.IsNullOrEmpty(name)
            ? null
            : new CultureInfo(name);
    }

    /// <inheritdoc />
    public override void Write(
        Utf8JsonWriter writer,
        CultureInfo? value,
        JsonSerializerOptions options)
    {
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        if (string.IsNullOrEmpty(value?.Name))
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteStringValue(value!.Name);
        }
    }
}