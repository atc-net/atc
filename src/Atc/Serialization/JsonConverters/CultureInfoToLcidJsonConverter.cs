namespace Atc.Serialization.JsonConverters;

public sealed class CultureInfoToLcidJsonConverter : JsonConverter<CultureInfo?>
{
    public override CultureInfo? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var lcid = reader.GetInt32();
        return new CultureInfo(lcid);
    }

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