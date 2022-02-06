namespace Atc.Serialization.JsonConverters;

public class JsonTimeSpanConverter : JsonConverter<TimeSpan>
{
    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => TimeSpan.Parse(reader.GetString()!, CultureInfo.InvariantCulture);

    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString());
}