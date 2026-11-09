namespace Atc.Serialization.JsonConverters;

/// <summary>
/// JSON converter for a nullable enum that reads a value it does not know as <see langword="null"/> instead of failing,
/// e.g. when a third-party API adds enum values. Names follow <see cref="StringEnumMemberJsonConverter{TEnum}"/>.
/// </summary>
/// <typeparam name="TEnum">The enum type.</typeparam>
/// <remarks>
/// Reading gives <see langword="null"/> for a JSON <c>null</c>, an unknown string or a non-string token, and calls
/// the optional <c>onUnknownValue</c> callback for the unknown ones, so they can be logged.
/// Writing writes the JSON name, or <c>null</c> for <see langword="null"/>.
/// </remarks>
public sealed class LenientStringEnumMemberJsonConverter<TEnum> : JsonConverter<TEnum?>
    where TEnum : struct, Enum
{
    private readonly Action<Type, string?>? onUnknownValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="LenientStringEnumMemberJsonConverter{TEnum}"/> class.
    /// </summary>
    /// <param name="onUnknownValue">
    /// Called with the enum type and the unknown value (the raw text, or <see langword="null"/> for a non-string token)
    /// whenever a value is read as <see langword="null"/> because it is not known; e.g. to log a warning.
    /// </param>
    public LenientStringEnumMemberJsonConverter(
        Action<Type, string?>? onUnknownValue = null)
    {
        this.onUnknownValue = onUnknownValue;
    }

    /// <inheritdoc />
    public override bool HandleNull => true;

    /// <inheritdoc />
    public override TEnum? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.String:
                var text = reader.GetString();
                if (EnumMemberNames<TEnum>.TryGetValue(text, out var value))
                {
                    return value;
                }

                onUnknownValue?.Invoke(typeof(TEnum), text);
                return null;
            default:
                reader.Skip();
                onUnknownValue?.Invoke(typeof(TEnum), arg2: null);
                return null;
        }
    }

    /// <inheritdoc />
    public override void Write(
        Utf8JsonWriter writer,
        TEnum? value,
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

        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        EnumMemberNames<TEnum>.Write(writer, value.Value, options);
    }
}