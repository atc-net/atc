namespace Atc.Tests.Serialization.JsonConverters;

public class JsonCultureInfoToLcidConverterTests
{
    [Theory]
    [InlineData(1033)]
    [InlineData(1036)]
    [InlineData(1041)]
    public void Read_ShouldReturnExpectedCultureInfo(int lcid)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new JsonCultureInfoToLcidConverter();
        var json = $"{lcid}";
        var utf8JsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));

        utf8JsonReader.Read();

        // Act
        var result = jsonConverter.Read(ref utf8JsonReader, typeof(CultureInfo), jsonSerializerOptions);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(lcid, result.LCID);
    }

    [Theory]
    [InlineData(1033)]
    [InlineData(1036)]
    [InlineData(1041)]
    public void Write_ShouldWriteCultureInfoNameToUtf8JsonWriter(int lcid)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new JsonCultureInfoToLcidConverter();
        var memoryStream = new MemoryStream();
        using var utf8JsonWriter = new Utf8JsonWriter(memoryStream);
        var cultureInfo = new CultureInfo(lcid);

        // Act
        jsonConverter.Write(utf8JsonWriter, cultureInfo, jsonSerializerOptions);

        // Assert
        utf8JsonWriter.Flush();
        var result = Encoding.UTF8.GetString(memoryStream.ToArray());

        Assert.NotNull(result);
        Assert.True(NumberHelper.IsInt(result));
        Assert.Equal(lcid, NumberHelper.ParseToInt(result));
    }
}