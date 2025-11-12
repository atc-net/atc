// ReSharper disable ConstantConditionalAccessQualifier
namespace Atc.Serialization.JsonConverters;

/// <summary>
/// JSON converter that enables polymorphic deserialization based on a type discriminator property.
/// </summary>
/// <typeparam name="T">The base type implementing <see cref="ITypeDiscriminator"/>.</typeparam>
/// <remarks>
/// This converter enables deserialization of polymorphic types by reading a discriminator property from the JSON payload
/// and matching it to concrete types in the current application domain. All concrete types implementing <typeparamref name="T"/>
/// are discovered at runtime and used for type resolution based on the TypeDiscriminator property value.
/// </remarks>
public sealed class TypeDiscriminatorJsonConverter<T> : JsonConverter<T>
    where T : ITypeDiscriminator
{
    private readonly IEnumerable<Type> types;

    /// <summary>
    /// Initializes a new instance of the <see cref="TypeDiscriminatorJsonConverter{T}"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor scans all loaded assemblies in the current <see cref="AppDomain"/> to find all
    /// concrete (non-abstract) class types that implement <typeparamref name="T"/>.
    /// </remarks>
    public TypeDiscriminatorJsonConverter()
    {
        var type = typeof(T);
        types = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract)
            .ToList();
    }

    /// <inheritdoc />
    public override T Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        var typeDiscriminatorName = options?.PropertyNamingPolicy is null
            ? nameof(ITypeDiscriminator.TypeDiscriminator)
            : nameof(ITypeDiscriminator.TypeDiscriminator).EnsureFirstCharacterToLower();

        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        if (!jsonDocument.RootElement.TryGetProperty(typeDiscriminatorName, out var typeProperty))
        {
            throw new JsonException();
        }

        var type = types.FirstOrDefault(x => x.Name == typeProperty.GetString());
        if (type is null)
        {
            throw new JsonException();
        }

        var jsonObject = jsonDocument.RootElement.GetRawText();
        var result = (T)JsonSerializer.Deserialize(jsonObject, type, options)!;

        return result;
    }

    /// <inheritdoc />
    public override void Write(
        Utf8JsonWriter writer,
        T value,
        JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, (object)value, options);
}