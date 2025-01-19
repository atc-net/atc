namespace Atc.Tests.Serialization.JsonConverters;

public sealed class CultureInfoToNameJsonConverterTests
{
    [Theory]
    [InlineData("en-US")]
    [InlineData("fr-FR")]
    [InlineData("ja-JP")]
    public void Read_ShouldReturnExpectedCultureInfo(string cultureName)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new CultureInfoToNameJsonConverter();
        var json = $"\"{cultureName}\"";
        var utf8JsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));

        utf8JsonReader.Read();

        // Act
        var result = jsonConverter.Read(ref utf8JsonReader, typeof(CultureInfo), jsonSerializerOptions);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(cultureName, result.Name);
    }

    [Theory]
    [InlineData("en-US")]
    [InlineData("fr-FR")]
    [InlineData("ja-JP")]
    public void Write_ShouldWriteCultureInfoNameToUtf8JsonWriter(string cultureName)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new CultureInfoToNameJsonConverter();
        var memoryStream = new MemoryStream();
        using var utf8JsonWriter = new Utf8JsonWriter(memoryStream);
        var cultureInfo = new CultureInfo(cultureName);

        // Act
        jsonConverter.Write(utf8JsonWriter, cultureInfo, jsonSerializerOptions);

        // Assert
        utf8JsonWriter.Flush();
        var result = Encoding.UTF8.GetString(memoryStream.ToArray());

        Assert.NotNull(result);
        Assert.Equal($"\"{cultureName}\"", result);
    }
}