namespace Atc.Serialization.JsonConverters;

/// <summary>
/// JSON converter that serializes <see cref="FileInfo"/> objects to and from their full file path string representation.
/// </summary>
/// <remarks>
/// This converter writes <see cref="FileInfo"/> as its FullName property value
/// and reads file path strings back into <see cref="FileInfo"/> objects. Null or empty values are preserved.
/// </remarks>
public sealed class FileInfoToFullNameJsonConverter : JsonConverter<FileInfo?>
{
    /// <inheritdoc />
    public override FileInfo? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var fillName = reader.GetString();
        return string.IsNullOrEmpty(fillName)
            ? null
            : new FileInfo(fillName);
    }

    /// <inheritdoc />
    public override void Write(
        Utf8JsonWriter writer,
        FileInfo? value,
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