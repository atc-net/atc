namespace Atc.Serialization.JsonConverters;

/// <summary>
/// JSON converter that serializes <see cref="Uri"/> objects to and from their absolute URI string representation.
/// </summary>
/// <remarks>
/// This converter writes <see cref="Uri"/> objects as their <see cref="Uri.AbsoluteUri"/> property value
/// and reads absolute URI strings back into <see cref="Uri"/> objects. Null or empty values are preserved.
/// </remarks>
public sealed class UriToAbsoluteUriJsonConverter : JsonConverter<Uri?>
{
    /// <inheritdoc />
    public override Uri? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var absoluteUri = reader.GetString();
        return string.IsNullOrEmpty(absoluteUri)
            ? null
            : new Uri(absoluteUri);
    }

    /// <inheritdoc />
    public override void Write(
        Utf8JsonWriter writer,
        Uri? value,
        JsonSerializerOptions options)
    {
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        if (string.IsNullOrEmpty(value?.AbsoluteUri))
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteStringValue(value.AbsoluteUri);
        }
    }
}