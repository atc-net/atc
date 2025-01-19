namespace Atc.Serialization.JsonConverters;

public sealed class StringEnumMemberJsonConverter<TEnum> : JsonConverter<TEnum>
    where TEnum : Enum
{
    public override TEnum Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (typeToConvert is null)
        {
            throw new ArgumentNullException(nameof(typeToConvert));
        }

        var enumValue = reader.GetString();
        foreach (var field in typeToConvert.GetFields())
        {
            var enumMemberAttribute = field.GetCustomAttribute<EnumMemberAttribute>();

            switch (enumMemberAttribute)
            {
                case null when
                    field.Name.Equals(enumValue, StringComparison.OrdinalIgnoreCase):
                    return (TEnum)field.GetValue(null);
                case null:
                    continue;
            }

            if (enumMemberAttribute.Value.Equals(enumValue, StringComparison.OrdinalIgnoreCase))
            {
                return (TEnum)field.GetValue(null);
            }
        }

        throw new JsonException($"Unable to convert \"{enumValue}\" to Enum \"{typeToConvert}\".");
    }

    public override void Write(
        Utf8JsonWriter writer,
        TEnum value,
        JsonSerializerOptions options)
    {
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        var enumMemberAttribute = value
            .GetType()
            .GetField(value.ToString())
            .GetCustomAttribute<EnumMemberAttribute>();

        var enumValue = enumMemberAttribute?.Value ?? value.ToString();

        writer.WriteStringValue(options.PropertyNamingPolicy == JsonNamingPolicy.CamelCase
            ? enumValue.EnsureFirstCharacterToLower()
            : enumValue.EnsureFirstCharacterToUpper());
    }
}