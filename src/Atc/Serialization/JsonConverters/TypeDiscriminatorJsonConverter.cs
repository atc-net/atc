// ReSharper disable ConstantConditionalAccessQualifier
namespace Atc.Serialization.JsonConverters;

public sealed class TypeDiscriminatorJsonConverter<T> : JsonConverter<T>
    where T : ITypeDiscriminator
{
    private readonly IEnumerable<Type> types;

    public TypeDiscriminatorJsonConverter()
    {
        var type = typeof(T);
        types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract)
            .ToList();
    }

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

    public override void Write(
        Utf8JsonWriter writer,
        T value,
        JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, (object)value, options);
}