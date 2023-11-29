namespace Atc.Tests.Serialization.JsonConverters;

public class JsonFileInfoToFullNameConverterTests
{
    [Theory]
    [InlineData(@"C:\Temp\test.txt")]
    public void Read_ShouldReturnExpectedFileInfo(string file)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new JsonFileInfoToFullNameConverter();
        var json = $"\"{file.Replace("\\", "\\\\", StringComparison.Ordinal)}\"";
        var utf8JsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));

        utf8JsonReader.Read();

        // Act
        var result = jsonConverter.Read(ref utf8JsonReader, typeof(FileInfo), jsonSerializerOptions);

        // Assert
        Assert.NotNull(result);
        if (OperatingSystem.IsWindows())
        {
            Assert.Equal(file, result.FullName);
        }
    }

    [Theory]
    [InlineData(@"C:\Temp\test.txt")]
    public void Write_ShouldWriteFileInfoFullNameToUtf8JsonWriter(string file)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new JsonFileInfoToFullNameConverter();
        var memoryStream = new MemoryStream();
        using var utf8JsonWriter = new Utf8JsonWriter(memoryStream);
        var fileInfo = new FileInfo(file);

        // Act
        jsonConverter.Write(utf8JsonWriter, fileInfo, jsonSerializerOptions);

        // Assert
        utf8JsonWriter.Flush();
        var result = Encoding.UTF8.GetString(memoryStream.ToArray());

        Assert.NotNull(result);
        if (OperatingSystem.IsWindows())
        {
            Assert.Equal($"\"{file}\"", result.Replace("\\\\", "\\", StringComparison.Ordinal));
        }
    }
}