namespace Atc.Serialization.JsonConverters;

public class JsonFileInfoToFullNameConverter : JsonConverter<FileInfo?>
{
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