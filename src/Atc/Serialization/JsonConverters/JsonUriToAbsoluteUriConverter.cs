namespace Atc.Serialization.JsonConverters;

public class JsonUriToAbsoluteUriConverter : JsonConverter<Uri?>
{
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