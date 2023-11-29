namespace Atc.Serialization.JsonConverters;

public class JsonDirectoryInfoToFullNameConverter : JsonConverter<DirectoryInfo?>
{
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