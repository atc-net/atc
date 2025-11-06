namespace Atc.Serialization.JsonConverters;

/// <summary>
/// JSON converter that serializes <see cref="CultureInfo"/> objects to and from their LCID (Locale ID) integer representation.
/// </summary>
/// <remarks>
/// This converter writes <see cref="CultureInfo"/> as an integer LCID value (e.g., 1033 for en-US) and reads integer LCID values
/// back into <see cref="CultureInfo"/> objects. Null values are preserved during serialization and deserialization.
/// </remarks>
public sealed class CultureInfoToLcidJsonConverter : JsonConverter<CultureInfo?>
{
    /// <inheritdoc />
    public override CultureInfo? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var lcid = reader.GetInt32();
        return new CultureInfo(lcid);
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

        if (value?.LCID is null)
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteNumberValue(value.LCID);
        }
    }
}