// ReSharper disable PropertyCanBeMadeInitOnly.Local
namespace Atc.Tests.Serialization.JsonConverters;

public sealed class InterfaceJsonConverterTests
{
    [Fact]
    public void Constructor_ShouldThrowInvalidOperationException_WhenTInterfaceIsNotAnInterface()
    {
        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() =>
            new InterfaceJsonConverter<TestClass>());

        Assert.Equal("The type 'TestClass' must be an interface.", exception.Message);
    }

    [Fact]
    public void Constructor_ShouldNotThrow_WhenTInterfaceIsAnInterface()
    {
        // Act & Assert
        var exception = Record.Exception(() =>
            new InterfaceJsonConverter<ITestInterface>());

        Assert.Null(exception);
    }

    [Fact]
    public void Read_ShouldReturnExpectedInterfaceImplementation()
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new InterfaceJsonConverter<ITestInterface>();

        const string json = """
                            {
                                "Name": "John Doe",
                                "Age": 30,
                                "ExtraProperty": "Foo"
                            }
                            """;

        var utf8JsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));

        utf8JsonReader.Read();

        // Act
        var result = jsonConverter.Read(ref utf8JsonReader, typeof(TestClass), jsonSerializerOptions) as TestClass;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<TestClass>(result);
        Assert.Equal("John Doe", result.Name);
        Assert.Equal(30, result.Age);
        Assert.Equal("Foo", result.ExtraProperty);
    }

    [Fact]
    public void Deserialize_ShouldThrowNotSupportedException_WhenTargetTypeIsInterface()
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        jsonSerializerOptions.Converters.Add(new InterfaceJsonConverter<ITestInterface>());

        const string json = """
                            {
                                "Name": "John Doe",
                                "Age": 30,
                                "ExtraProperty": "Foo"
                            }
                            """;

        // Act & Assert
        var exception = Assert.Throws<NotSupportedException>(
            () => JsonSerializer.Deserialize<ITestInterface>(json, jsonSerializerOptions));

        Assert.StartsWith($"Deserialization of interface types is not supported. Use a concrete type instead of '{nameof(ITestInterface)}'.", exception.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void Deserialize_ShouldReturnExpectedType()
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        jsonSerializerOptions.Converters.Add(new InterfaceJsonConverter<ITestInterface>());

        var json = """
        {
           "Name": "John Doe",
           "Age": 30,
           "ExtraProperty": "Foo"
        }
        """;

        // Act
        var result = JsonSerializer.Deserialize<TestClass>(json, jsonSerializerOptions);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<TestClass>(result);
        Assert.Equal("John Doe", result.Name);
        Assert.Equal(30, result.Age);
        Assert.Equal("Foo", result.ExtraProperty);
    }

    [Fact]
    public void Write_ShouldWritePropertiesOfInterfaceToUtf8JsonWriter()
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new InterfaceJsonConverter<ITestInterface>();
        using var memoryStream = new MemoryStream();
        using var utf8JsonWriter = new Utf8JsonWriter(memoryStream);

        ITestInterface testObject = new TestClass { Name = "John Doe", Age = 30, ExtraProperty = "Foo" };

        // Act
        jsonConverter.Write(utf8JsonWriter, testObject, jsonSerializerOptions);

        // Assert
        utf8JsonWriter.Flush();
        var jsonResult = Encoding.UTF8.GetString(memoryStream.ToArray());

        Assert.NotNull(jsonResult);
        Assert.Contains("\"name\":\"John Doe\"", jsonResult, StringComparison.Ordinal);
        Assert.Contains("\"age\":30", jsonResult, StringComparison.Ordinal);
        Assert.Contains("\"extraProperty\":\"Foo\"", jsonResult, StringComparison.Ordinal);
    }

    [Fact]
    public void Write_ShouldThrowArgumentNullException_WhenWriterIsNull()
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new InterfaceJsonConverter<ITestInterface>();

        ITestInterface testObject = new TestClass { Name = "John Doe", Age = 30, ExtraProperty = "Foo" };

        // Act & Assert
        Assert.Throws<ArgumentNullException>(
            () => jsonConverter.Write(null!, testObject, jsonSerializerOptions));
    }

    [Fact]
    public void Serialize_ShouldSerialize()
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        jsonSerializerOptions.Converters.Add(new InterfaceJsonConverter<ITestInterface>());

        ITestInterface testObject = new TestClass { Name = "John Doe", Age = 30, ExtraProperty = "Foo" };

        // Act
        var jsonResult = JsonSerializer.Serialize(testObject, jsonSerializerOptions);

        // Assert
        Assert.NotNull(jsonResult);
        Assert.Contains("\"name\": \"John Doe\"", jsonResult, StringComparison.Ordinal);
        Assert.Contains("\"age\": 30", jsonResult, StringComparison.Ordinal);
        Assert.Contains("\"extraProperty\": \"Foo\"", jsonResult, StringComparison.Ordinal);
    }

    private interface ITestInterface
    {
        string Name { get; set; }

        int Age { get; set; }
    }

    private sealed class TestClass : ITestInterface
    {
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string? ExtraProperty { get; set; }
    }
}