namespace Atc.Tests.Serialization.JsonConverters;

public sealed class VersionJsonConverterTests
{
    [Fact]
    public void Read_ShouldDeserializeVersionFromObject()
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new VersionJsonConverter();

        const string json = """
                            {
                                "_Major": 1,
                                "_Minor": 2,
                                "_Build": 3,
                                "_Revision": 4
                            }
                            """;

        var utf8JsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));

        utf8JsonReader.Read();

        // Act
        var result = jsonConverter.Read(ref utf8JsonReader, typeof(Version), jsonSerializerOptions);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new Version(1, 2, 3, 4), result);
    }

    [Theory]
    [InlineData("1.2.3.4", "1.2.3.4")]
    [InlineData("1.2.3.4", "[1.2.3.4]")]
    [InlineData("1.2.3.4", "(1.2.3.4)")]
    [InlineData("1.2.3.0", "1.2.3")]
    [InlineData("1.2.3.0", "[1.2.3]")]
    [InlineData("1.2.3.0", "(1.2.3)")]
    [InlineData("1.2.0.0", "1.2")]
    [InlineData("1.2.0.0", "[1.2]")]
    [InlineData("1.2.0.0", "(1.2)")]
    [InlineData("1.0.0.0", "1")]
    [InlineData("1.0.0.0", "[1]")]
    [InlineData("1.0.0.0", "(1)")]
    public void Read_ShouldDeserializeVersionFromString(
        string expected,
        string value)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new VersionJsonConverter();

        var json = $"\"{value}\"";

        var utf8JsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));

        utf8JsonReader.Read();

        // Act
        var result = jsonConverter.Read(ref utf8JsonReader, typeof(Version), jsonSerializerOptions);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(Version.Parse(expected), result);
    }

    [Fact]
    public void Read_ShouldReturnDefaultVersionForInvalidJson()
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new VersionJsonConverter();

        const string json = "\"invalid_version\"";

        var utf8JsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));

        utf8JsonReader.Read();

        // Act
        var result = jsonConverter.Read(ref utf8JsonReader, typeof(Version), jsonSerializerOptions);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new Version(), result);
    }

    [Fact]
    public void Write_ShouldSerializeVersionToString()
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new VersionJsonConverter();

        var version = new Version(1, 2, 3, 4);

        using var memoryStream = new MemoryStream();
        using var writer = new Utf8JsonWriter(memoryStream);

        // Act
        jsonConverter.Write(writer, version, jsonSerializerOptions);

        writer.Flush();
        var json = Encoding.UTF8.GetString(memoryStream.ToArray());

        // Assert
        Assert.Equal("\"1.2.3.4\"", json);
    }

    [Fact]
    public void Write_ShouldThrowArgumentNullException_WhenWriterIsNull()
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new VersionJsonConverter();

        var version = new Version(1, 2, 3, 4);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(
            () => jsonConverter.Write(null!, version, jsonSerializerOptions));
    }

    [Fact]
    public void Write_ShouldThrowArgumentNullException_WhenValueIsNull()
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new VersionJsonConverter();

        using var memoryStream = new MemoryStream();
        using var writer = new Utf8JsonWriter(memoryStream);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(
            () => jsonConverter.Write(writer, null!, jsonSerializerOptions));
    }

    [Fact]
    public void SerializeAndDeserialize()
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create(
            new JsonSerializerFactorySettings
            {
                UseConverterVersion = true,
            });

        var data = AssemblyHelper.GetAssemblyInformationsByStartsWith("Atc");

        // Act
        var actualJson = JsonSerializer.Serialize(data, jsonSerializerOptions);
        var actualData = JsonSerializer.Deserialize<List<AssemblyInformation>>(actualJson, jsonSerializerOptions);

        // Assert
        actualData
            .Should()
            .NotBeNull();
    }
}