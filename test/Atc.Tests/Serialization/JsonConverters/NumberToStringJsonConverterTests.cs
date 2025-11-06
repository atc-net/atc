namespace Atc.Tests.Serialization.JsonConverters;

public sealed class NumberToStringJsonConverterTests
{
    [Theory]
    [InlineData(123, 123)]
    [InlineData(123.45, 123.45)]
    public void Read_ShouldReturnStringRepresentationOfNumber(
        double expected,
        double number)
    {
        // Arrange
        Thread.CurrentThread.CurrentCulture = GlobalizationConstants.EnglishCultureInfo;
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new NumberToStringJsonConverter();
        var json = $"\"{number}\"";
        var utf8JsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));

        utf8JsonReader.Read();

        // Act
        var result = jsonConverter.Read(ref utf8JsonReader, typeof(string), jsonSerializerOptions);

        // Assert
        Assert.NotNull(result);
        Assert.True(NumberHelper.IsDouble(result.ToString()!, GlobalizationConstants.EnglishCultureInfo));
        Assert.Equal(expected, NumberHelper.ParseToDouble(result.ToString()!, GlobalizationConstants.EnglishCultureInfo));
    }

    [Theory]
    [InlineData(123)]
    [InlineData(123.45)]
    public void Write_ShouldWriteStringRepresentationOfNumber(double number)
    {
        // Arrange
        Thread.CurrentThread.CurrentCulture = GlobalizationConstants.EnglishCultureInfo;
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new NumberToStringJsonConverter();
        var memoryStream = new MemoryStream();
        using var utf8JsonWriter = new Utf8JsonWriter(memoryStream);

        // Act
        jsonConverter.Write(utf8JsonWriter, number, jsonSerializerOptions);

        // Assert
        utf8JsonWriter.Flush();
        var result = Encoding.UTF8.GetString(memoryStream.ToArray());

        Assert.NotNull(result);
        var resultValue = result.Replace("\"", string.Empty, StringComparison.Ordinal);
        Assert.True(NumberHelper.IsNumber(resultValue, useUiCulture: false));
        Assert.Equal(number, NumberHelper.ParseToDouble(resultValue, useUiCulture: false));
    }
}