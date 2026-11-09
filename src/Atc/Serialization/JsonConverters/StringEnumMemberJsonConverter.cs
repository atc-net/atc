namespace Atc.Serialization.JsonConverters;

/// <summary>
/// JSON converter that serializes enum values to and from their string representation, respecting
/// <see cref="JsonStringEnumMemberNameAttribute"/> and <see cref="EnumMemberAttribute"/> values.
/// </summary>
/// <typeparam name="TEnum">The enum type to convert.</typeparam>
/// <remarks>
/// <para>
/// A member's JSON name is its <see cref="JsonStringEnumMemberNameAttribute.Name"/> if present, else its
/// <see cref="EnumMemberAttribute.Value"/> if present, else the enum's name. Reading accepts the JSON name and
/// the member name, case-insensitively, and throws a <see cref="JsonException"/> for any other value; use
/// <see cref="LenientStringEnumMemberJsonConverter{TEnum}"/> to read unknown values of a nullable enum as
/// <see langword="null"/> instead.
/// </para>
/// <para>
/// A <see cref="JsonStringEnumMemberNameAttribute"/> name is written exactly as given; for other names the casing
/// of the first character follows the <see cref="JsonSerializerOptions.PropertyNamingPolicy"/> (camelCase or not).
/// </para>
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
        var enumValue = reader.TokenType == JsonTokenType.String
            ? reader.GetString()
            : null;
        if (EnumMemberNames<TEnum>.TryGetValue(enumValue, out var result))
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

        EnumMemberNames<TEnum>.Write(writer, value, options);
    }
}