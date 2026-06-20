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
    private static readonly Dictionary<string, TEnum> NameToValue = BuildNameToValue();
    private static readonly Dictionary<TEnum, string> ValueToName = BuildValueToName();

    private static Dictionary<string, TEnum> BuildNameToValue()
    {
        var map = new Dictionary<string, TEnum>(StringComparer.OrdinalIgnoreCase);
        foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var member = field.GetCustomAttribute<EnumMemberAttribute>()?.Value ?? field.Name;
            map[member] = (TEnum)field.GetValue(null)!;
            if (!map.ContainsKey(field.Name))
            {
                map[field.Name] = (TEnum)field.GetValue(null)!;
            }
        }

        return map;
    }

    private static Dictionary<TEnum, string> BuildValueToName()
    {
        var map = new Dictionary<TEnum, string>();
        foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var key = (TEnum)field.GetValue(null)!;
            if (!map.ContainsKey(key))
            {
                map[key] = field.GetCustomAttribute<EnumMemberAttribute>()?.Value ?? field.Name;
            }
        }

        return map;
    }

    /// <inheritdoc />
    public override TEnum Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var enumValue = reader.GetString();
        if (enumValue is not null && NameToValue.TryGetValue(enumValue, out var result))
        {
            return result;
        }

        throw new JsonException($"Unable to convert \"{enumValue}\" to Enum \"{typeof(TEnum)}\".");
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

        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        var enumValue = ValueToName.TryGetValue(value, out var name) ? name : value.ToString();

        writer.WriteStringValue(options.PropertyNamingPolicy == JsonNamingPolicy.CamelCase
            ? enumValue.EnsureFirstCharacterToLower()
            : enumValue.EnsureFirstCharacterToUpper());
    }
}