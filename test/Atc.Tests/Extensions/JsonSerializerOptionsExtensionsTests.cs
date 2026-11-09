namespace Atc.Tests.Extensions;

public class JsonSerializerOptionsExtensionsTests
{
    /// <summary>
    /// The settable <see cref="JsonSerializerOptions"/> properties CopyTo deliberately does not copy as a plain value.
    /// </summary>
    private static readonly string[] NotCopiedAsValue =
    [
        nameof(JsonSerializerOptions.TypeInfoResolver), // copied only when the source has one
    ];

    [Fact]
    public void CopyTo_CopiesEverySetting()
    {
        // Arrange
        var source = new JsonSerializerOptions
        {
            AllowDuplicateProperties = false,
            AllowOutOfOrderMetadataProperties = true,
            AllowTrailingCommas = true,
            DefaultBufferSize = 4096,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            DictionaryKeyPolicy = JsonNamingPolicy.SnakeCaseLower,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            IgnoreReadOnlyFields = true,
            IgnoreReadOnlyProperties = true,
            IncludeFields = true,
            IndentCharacter = '\t',
            IndentSize = 1,
            MaxDepth = 16,
            NewLine = "\n",
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            PreferredObjectCreationHandling = JsonObjectCreationHandling.Populate,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            ReadCommentHandling = JsonCommentHandling.Skip,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            RespectNullableAnnotations = true,
            RespectRequiredConstructorParameters = true,
            TypeInfoResolver = new DefaultJsonTypeInfoResolver(),
            UnknownTypeHandling = JsonUnknownTypeHandling.JsonNode,
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
            WriteIndented = true,
        };
        var target = new JsonSerializerOptions();

        // Act
        source.CopyTo(target);

        // Assert
        foreach (var property in SettableProperties())
        {
            Assert.Equal(property.GetValue(source), property.GetValue(target));
        }

        Assert.Same(source.TypeInfoResolver, target.TypeInfoResolver);
    }

    [Fact]
    public void CopyTo_ReplacesTheConverters()
    {
        // Arrange
        var converter = new JsonStringEnumConverter();
        var source = new JsonSerializerOptions { Converters = { converter } };
        var target = new JsonSerializerOptions { Converters = { new TimeSpanJsonConverter() } };

        // Act
        source.CopyTo(target);

        // Assert
        Assert.Same(converter, Assert.Single(target.Converters));
    }

    [Fact]
    public void CopyTo_KeepsTheTargetResolver_WhenTheSourceHasNone()
    {
        // Arrange
        var resolver = new DefaultJsonTypeInfoResolver();
        var target = new JsonSerializerOptions { TypeInfoResolver = resolver };

        // Act
        new JsonSerializerOptions().CopyTo(target);

        // Assert
        Assert.Same(resolver, target.TypeInfoResolver);
    }

    [Fact]
    public void CopyTo_Throws_WhenTheTargetIsReadOnly()
    {
        // Arrange
        var target = new JsonSerializerOptions { TypeInfoResolver = new DefaultJsonTypeInfoResolver() };
        target.MakeReadOnly();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => new JsonSerializerOptions().CopyTo(target));
    }

    [Fact]
    public void CopyTo_HandlesEverySettableProperty()
    {
        // A new settable property in System.Text.Json fails this test, so CopyTo is kept complete.
        var handled = new[]
        {
            nameof(JsonSerializerOptions.AllowDuplicateProperties),
            nameof(JsonSerializerOptions.AllowOutOfOrderMetadataProperties),
            nameof(JsonSerializerOptions.AllowTrailingCommas),
            nameof(JsonSerializerOptions.DefaultBufferSize),
            nameof(JsonSerializerOptions.DefaultIgnoreCondition),
            nameof(JsonSerializerOptions.DictionaryKeyPolicy),
            nameof(JsonSerializerOptions.Encoder),
            nameof(JsonSerializerOptions.IgnoreReadOnlyFields),
            nameof(JsonSerializerOptions.IgnoreReadOnlyProperties),
            nameof(JsonSerializerOptions.IncludeFields),
            nameof(JsonSerializerOptions.IndentCharacter),
            nameof(JsonSerializerOptions.IndentSize),
            nameof(JsonSerializerOptions.MaxDepth),
            nameof(JsonSerializerOptions.NewLine),
            nameof(JsonSerializerOptions.NumberHandling),
            nameof(JsonSerializerOptions.PreferredObjectCreationHandling),
            nameof(JsonSerializerOptions.PropertyNameCaseInsensitive),
            nameof(JsonSerializerOptions.PropertyNamingPolicy),
            nameof(JsonSerializerOptions.ReadCommentHandling),
            nameof(JsonSerializerOptions.ReferenceHandler),
            nameof(JsonSerializerOptions.RespectNullableAnnotations),
            nameof(JsonSerializerOptions.RespectRequiredConstructorParameters),
            nameof(JsonSerializerOptions.TypeInfoResolver),
            nameof(JsonSerializerOptions.UnknownTypeHandling),
            nameof(JsonSerializerOptions.UnmappedMemberHandling),
            nameof(JsonSerializerOptions.WriteIndented),
        };

        var settable = typeof(JsonSerializerOptions)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.SetMethod?.IsPublic == true && p.GetCustomAttribute<ObsoleteAttribute>() is null)
            .Select(p => p.Name)
            .OrderBy(n => n, StringComparer.Ordinal);

        Assert.Equal(handled.OrderBy(n => n, StringComparer.Ordinal), settable);
    }

    private static IEnumerable<PropertyInfo> SettableProperties()
        => typeof(JsonSerializerOptions)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.SetMethod?.IsPublic == true &&
                        p.GetCustomAttribute<ObsoleteAttribute>() is null &&
                        !NotCopiedAsValue.Contains(p.Name, StringComparer.Ordinal));
}