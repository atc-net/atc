namespace Atc.Serialization.JsonConverters;

public sealed class InterfaceJsonConverter<TInterface> : JsonConverter<TInterface>
{
    public InterfaceJsonConverter()
    {
        if (!typeof(TInterface).IsInterface)
        {
            throw new InvalidOperationException($"The type '{typeof(TInterface).Name}' must be an interface.");
        }
    }

    public override TInterface Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (typeToConvert is null)
        {
            throw new ArgumentNullException(nameof(typeToConvert));
        }

        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("Expected StartObject token.");
        }

        if (typeToConvert == typeof(TInterface))
        {
            throw new NotSupportedException($"Deserialization of interface types is not supported. Use a concrete type instead of '{typeof(TInterface).Name}'.");
        }

        using var document = JsonDocument.ParseValue(ref reader);
        var jsonObject = document.RootElement;

        // Create a new JsonSerializerOptions without this converter
        var modifiedOptions = new JsonSerializerOptions(options);
        var converterToRemove = modifiedOptions.Converters.FirstOrDefault(c => c is InterfaceJsonConverter<TInterface>);
        if (converterToRemove != null)
        {
            modifiedOptions.Converters.Remove(converterToRemove);
        }

        // Deserialize using the provided concrete type
        return (TInterface)JsonSerializer.Deserialize(jsonObject.GetRawText(), typeToConvert, modifiedOptions)!;
    }

    public override void Write(
        Utf8JsonWriter writer,
        TInterface value,
        JsonSerializerOptions options)
    {
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        writer.WriteStartObject();

        var runtimeType = value!.GetType();
        foreach (var property in runtimeType.GetProperties())
        {
            if (!property.CanRead || property.GetMethod?.IsPublic != true)
            {
                continue;
            }

            var propertyValue = property.GetValue(value);

            var propertyName = options?.PropertyNamingPolicy?.ConvertName(property.Name) ?? property.Name;

            writer.WritePropertyName(propertyName);
            JsonSerializer.Serialize(writer, propertyValue, options);
        }

        writer.WriteEndObject();
    }
}