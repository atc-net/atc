namespace Atc.Serialization.JsonConverters;

/// <summary>
/// Converter factory that handles every enum and nullable enum with the string-enum-member converters: a non-nullable
/// enum is strict (<see cref="StringEnumMemberJsonConverter{TEnum}"/>), and a nullable enum is lenient
/// (<see cref="LenientStringEnumMemberJsonConverter{TEnum}"/>) unless turned off.
/// </summary>
/// <remarks>
/// Lenient nullable enums suit clients of third-party APIs that may add enum values: declare the properties that can
/// receive new values as nullable, and an unknown value becomes <see langword="null"/> instead of failing the whole response.
/// </remarks>
/// <example>
/// <code>
/// var options = new JsonSerializerOptions();
/// options.Converters.Add(new StringEnumMemberJsonConverterFactory(
///     onUnknownValue: (type, value) => logger.LogWarning("Unknown {Type} value {Value}", type.Name, value)));
/// </code>
/// </example>
public sealed class StringEnumMemberJsonConverterFactory : JsonConverterFactory
{
    private readonly bool lenientForNullable;
    private readonly Action<Type, string?>? onUnknownValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="StringEnumMemberJsonConverterFactory"/> class.
    /// </summary>
    /// <param name="lenientForNullable">
    /// If set to <see langword="true"/> (the default), a nullable enum reads an unknown value as <see langword="null"/>;
    /// otherwise it is strict like a non-nullable enum.
    /// </param>
    /// <param name="onUnknownValue">Called for each unknown value read as <see langword="null"/>; e.g. to log it.</param>
    public StringEnumMemberJsonConverterFactory(
        bool lenientForNullable = true,
        Action<Type, string?>? onUnknownValue = null)
    {
        this.lenientForNullable = lenientForNullable;
        this.onUnknownValue = onUnknownValue;
    }

    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert)
    {
        if (typeToConvert is null)
        {
            throw new ArgumentNullException(nameof(typeToConvert));
        }

        // A strict nullable enum is left to System.Text.Json, which wraps the enum's converter.
        return typeToConvert.IsEnum ||
               (lenientForNullable && Nullable.GetUnderlyingType(typeToConvert)?.IsEnum == true);
    }

    /// <inheritdoc />
    public override JsonConverter CreateConverter(
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (typeToConvert is null)
        {
            throw new ArgumentNullException(nameof(typeToConvert));
        }

        var underlying = Nullable.GetUnderlyingType(typeToConvert);
        return underlying is not null
            ? (JsonConverter)Activator.CreateInstance(
                typeof(LenientStringEnumMemberJsonConverter<>).MakeGenericType(underlying),
                onUnknownValue)!
            : (JsonConverter)Activator.CreateInstance(
                typeof(StringEnumMemberJsonConverter<>).MakeGenericType(typeToConvert))!;
    }
}