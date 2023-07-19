namespace Atc.Serialization.JsonConverters;

public class JsonCultureInfoToLcidConverter : JsonConverter<CultureInfo?>
{
    public override CultureInfo? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        return NumberHelper.TryParseToInt(value, out var lcid)
            ? new CultureInfo(lcid)
            : null;
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