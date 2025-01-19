namespace Atc.Tests.Serialization.JsonConverters;

[SuppressMessage("Design", "CA1054:URI-like parameters should not be strings", Justification = "OK.")]
public sealed class UriToAbsoluteUriJsonConverterTests
{
    [Theory]
    [InlineData("http://dr.dk/")]
    public void Read_ShouldReturnExpectedAbsoluteUri(string url)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new UriToAbsoluteUriJsonConverter();
        var json = $"\"{url}\"";
        var utf8JsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));

        utf8JsonReader.Read();

        // Act
        var result = jsonConverter.Read(ref utf8JsonReader, typeof(Uri), jsonSerializerOptions);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(url, result.AbsoluteUri);
    }

    [Theory]
    [InlineData("http://dr.dk/")]
    public void Write_ShouldWriteUriAbsoluteUriToUtf8JsonWriter(string url)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new UriToAbsoluteUriJsonConverter();
        var memoryStream = new MemoryStream();
        using var utf8JsonWriter = new Utf8JsonWriter(memoryStream);
        var uri = new Uri(url);

        // Act
        jsonConverter.Write(utf8JsonWriter, uri, jsonSerializerOptions);

        // Assert
        utf8JsonWriter.Flush();
        var result = Encoding.UTF8.GetString(memoryStream.ToArray());

        Assert.NotNull(result);
        Assert.Equal($"\"{url}\"", result);
    }
}