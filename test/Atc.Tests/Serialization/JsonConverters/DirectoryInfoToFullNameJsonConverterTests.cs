namespace Atc.Tests.Serialization.JsonConverters;

public sealed class DirectoryInfoToFullNameJsonConverterTests
{
    [Theory]
    [InlineData(@"C:\Temp")]
    public void Read_ShouldReturnExpectedDirectoryInfo(string directory)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new DirectoryInfoToFullNameJsonConverter();
        var json = $"\"{directory.Replace("\\", "\\\\", StringComparison.Ordinal)}\"";
        var utf8JsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));

        utf8JsonReader.Read();

        // Act
        var result = jsonConverter.Read(ref utf8JsonReader, typeof(DirectoryInfo), jsonSerializerOptions);

        // Assert
        Assert.NotNull(result);
        if (OperatingSystem.IsWindows())
        {
            Assert.Equal(directory, result.FullName);
        }
    }

    [Theory]
    [InlineData(@"C:\Temp")]
    public void Write_ShouldWriteDirectoryInfoFullNameToUtf8JsonWriter(string directory)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new DirectoryInfoToFullNameJsonConverter();
        var memoryStream = new MemoryStream();
        using var utf8JsonWriter = new Utf8JsonWriter(memoryStream);
        var directoryInfo = new DirectoryInfo(directory);

        // Act
        jsonConverter.Write(utf8JsonWriter, directoryInfo, jsonSerializerOptions);

        // Assert
        utf8JsonWriter.Flush();
        var result = Encoding.UTF8.GetString(memoryStream.ToArray());

        Assert.NotNull(result);
        if (OperatingSystem.IsWindows())
        {
            Assert.Equal($"\"{directory}\"", result.Replace("\\\\", "\\", StringComparison.Ordinal));
        }
    }
}