namespace Atc.Serialization.JsonConverters;

/// <summary>
/// JSON converter that serializes <see cref="DirectoryInfo"/> objects to and from their full directory path string representation.
/// </summary>
/// <remarks>
/// This converter writes <see cref="DirectoryInfo"/> as its FullName property value
/// and reads directory path strings back into <see cref="DirectoryInfo"/> objects. Null or empty values are preserved.
/// </remarks>
public sealed class DirectoryInfoToFullNameJsonConverter : JsonConverter<DirectoryInfo?>
{
    /// <inheritdoc />
    public override DirectoryInfo? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var fillName = reader.GetString();
        return string.IsNullOrEmpty(fillName)
            ? null
            : new DirectoryInfo(fillName);
    }

    /// <inheritdoc />
    public override void Write(
        Utf8JsonWriter writer,
        DirectoryInfo? value,
        JsonSerializerOptions options)
    {
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        if (string.IsNullOrEmpty(value?.FullName))
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteStringValue(value.FullName);
        }
    }
}