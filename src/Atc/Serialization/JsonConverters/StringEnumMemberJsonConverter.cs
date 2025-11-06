namespace Atc.Serialization.JsonConverters;

/// <summary>
/// JSON converter that serializes enum values to and from their string representation, respecting <see cref="EnumMemberAttribute"/> values.
/// </summary>
/// <typeparam name="TEnum">The enum type to convert.</typeparam>
/// <remarks>
/// This converter reads enum values from their string representation and respects <see cref="EnumMemberAttribute"/> values if present.
/// During serialization, it writes the <see cref="EnumMemberAttribute.Value"/> if present, otherwise the enum's name.
/// The casing of the output string respects the <see cref="JsonSerializerOptions.PropertyNamingPolicy"/>.
/// </remarks>
public sealed class StringEnumMemberJsonConverter<TEnum> : JsonConverter<TEnum>
    where TEnum : Enum
{
    /// <inheritdoc />
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
                    return (TEnum)field.GetValue(null)!;
                case null:
                    continue;
            }

            if (enumMemberAttribute.Value!.Equals(enumValue, StringComparison.OrdinalIgnoreCase))
            {
                return (TEnum)field.GetValue(null)!;
            }
        }

        throw new JsonException($"Unable to convert \"{enumValue}\" to Enum \"{typeToConvert}\".");
    }

    /// <inheritdoc />
    public override void Write(
        Utf8JsonWriter writer,
        TEnum value,
        JsonSerializerOptions options)
    {
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        var enumMemberAttribute = value
            .GetType()
            .GetField(value.ToString())!
            .GetCustomAttribute<EnumMemberAttribute>();

        var enumValue = enumMemberAttribute?.Value ?? value.ToString();

        writer.WriteStringValue(options.PropertyNamingPolicy == JsonNamingPolicy.CamelCase
            ? enumValue.EnsureFirstCharacterToLower()
            : enumValue.EnsureFirstCharacterToUpper());
    }
}