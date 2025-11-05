namespace Atc.Tests.Helpers;

public sealed class FileHelperGenericTests : IDisposable
{
    private const string JsonContent = "{\"Name\":\"Test\",\"Value\":123}";
    private readonly DirectoryInfo testDirectory;
    private readonly FileInfo testFile;

    public FileHelperGenericTests()
    {
        testDirectory = new DirectoryInfo(Path.Combine(Path.GetTempPath(), $"FileHelperGenericTests_{Guid.NewGuid()}"));
        testDirectory.Create();
        testFile = new FileInfo(Path.Combine(testDirectory.FullName, "test.json"));
        File.WriteAllText(testFile.FullName, JsonContent);
    }

    public void Dispose()
    {
        if (testDirectory.Exists)
        {
            testDirectory.Delete(recursive: true);
        }
    }

    [Fact]
    public void ReadJsonFileToModel_FileInfo()
    {
        // Act
        var actual = FileHelper<TestModel>.ReadJsonFileToModel(testFile);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal("Test", actual.Name);
        Assert.Equal(123, actual.Value);
    }

    [Fact]
    public void ReadJsonFileToModel_FileInfo_WithOptions()
    {
        // Arrange
        var options = JsonSerializerOptionsFactory.Create();

        // Act
        var actual = FileHelper<TestModel>.ReadJsonFileToModel(testFile, options);

        // Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public void ReadJsonFileToModel_Stream()
    {
        // Arrange
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(JsonContent));

        // Act
        var actual = FileHelper<TestModel>.ReadJsonFileToModel(stream);

        // Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public void ReadJsonFileToModel_Stream_WithOptions()
    {
        // Arrange
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(JsonContent));
        var options = JsonSerializerOptionsFactory.Create();

        // Act
        var actual = FileHelper<TestModel>.ReadJsonFileToModel(stream, options);

        // Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public async Task ReadJsonFileToModelAsync_FileInfo()
    {
        // Act
        var actual = await FileHelper<TestModel>.ReadJsonFileToModelAsync(testFile);

        // Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public async Task ReadJsonFileToModelAsync_FileInfo_WithOptions()
    {
        // Arrange
        var options = JsonSerializerOptionsFactory.Create();

        // Act
        var actual = await FileHelper<TestModel>.ReadJsonFileToModelAsync(testFile, options);

        // Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public async Task ReadJsonFileToModelAsync_Stream()
    {
        // Arrange
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(JsonContent));

        // Act
        var actual = await FileHelper<TestModel>.ReadJsonFileToModelAsync(stream);

        // Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public async Task ReadJsonFileToModelAsync_Stream_WithOptions()
    {
        // Arrange
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(JsonContent));
        var options = JsonSerializerOptionsFactory.Create();

        // Act
        var actual = await FileHelper<TestModel>.ReadJsonFileToModelAsync(stream, options);

        // Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public async Task WriteModelToJsonFileAsync_FileInfo()
    {
        // Arrange
        var model = new TestModel { Name = "Test", Value = 123 };
        var outputFile = new FileInfo(Path.Combine(testDirectory.FullName, "output.json"));

        // Act
        await FileHelper<TestModel>.WriteModelToJsonFileAsync(outputFile, model);

        // Assert
        Assert.True(outputFile.Exists);
    }

    [Fact]
    public async Task WriteModelToJsonFileAsync_FileInfo_WithOptions()
    {
        // Arrange
        var model = new TestModel { Name = "Test", Value = 123 };
        var outputFile = new FileInfo(Path.Combine(testDirectory.FullName, "output2.json"));
        var options = JsonSerializerOptionsFactory.Create();

        // Act
        await FileHelper<TestModel>.WriteModelToJsonFileAsync(outputFile, model, options);

        // Assert
        Assert.True(outputFile.Exists);
    }

    [Fact]
    public async Task WriteModelToJsonFileAsync_Stream()
    {
        // Arrange
        var model = new TestModel { Name = "Test", Value = 123 };
        using var stream = new MemoryStream();

        // Act
        await FileHelper<TestModel>.WriteModelToJsonFileAsync(stream, model);

        // Assert
        Assert.True(stream.Length > 0);
    }

    [Fact]
    public async Task WriteModelToJsonFileAsync_Stream_WithOptions()
    {
        // Arrange
        var model = new TestModel { Name = "Test", Value = 123 };
        using var stream = new MemoryStream();
        var options = JsonSerializerOptionsFactory.Create();

        // Act
        await FileHelper<TestModel>.WriteModelToJsonFileAsync(stream, model, options);

        // Assert
        Assert.True(stream.Length > 0);
    }

    private sealed class TestModel
    {
        public string Name { get; set; } = string.Empty;

        public int Value { get; set; }
    }
}