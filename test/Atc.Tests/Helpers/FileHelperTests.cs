namespace Atc.Tests.Helpers;

public sealed class FileHelperTests : IDisposable
{
    private readonly DirectoryInfo testDirectory;
    private readonly FileInfo testFile;

    public FileHelperTests()
    {
        testDirectory = new DirectoryInfo(Path.Combine(Path.GetTempPath(), $"FileHelperTests_{Guid.NewGuid()}"));
        testDirectory.Create();
        testFile = new FileInfo(Path.Combine(testDirectory.FullName, "test.txt"));
        File.WriteAllText(testFile.FullName, "Test Content");
    }

    public void Dispose()
    {
        if (testDirectory.Exists)
        {
            testDirectory.Delete(recursive: true);
        }
    }

    [Fact]
    public void GetFiles_WithStringPath()
    {
        // Act
        var actual = FileHelper.GetFiles(testDirectory.FullName);

        // Assert
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
    }

    [Fact]
    public void GetFiles_WithDirectoryInfo()
    {
        // Act
        var actual = FileHelper.GetFiles(testDirectory);

        // Assert
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
    }

    [Fact]
    public void ReadAllText()
    {
        // Act
        var actual = FileHelper.ReadAllText(testFile);

        // Assert
        Assert.Equal("Test Content", actual);
    }

    [Fact]
    public void ReadAllText_NonExistentFile_ReturnsEmpty()
    {
        // Arrange
        var nonExistentFile = new FileInfo(Path.Combine(testDirectory.FullName, "nonexistent.txt"));

        // Act
        var actual = FileHelper.ReadAllText(nonExistentFile);

        // Assert
        Assert.Equal(string.Empty, actual);
    }

    [Fact]
    public async Task ReadAllTextAsync()
    {
        // Act
        var actual = await FileHelper.ReadAllTextAsync(testFile);

        // Assert
        Assert.Equal("Test Content", actual);
    }

    [Fact]
    public void ReadAllTextToLines()
    {
        // Arrange
        var multilineFile = new FileInfo(Path.Combine(testDirectory.FullName, "multiline.txt"));
        File.WriteAllText(multilineFile.FullName, "Line1\nLine2\nLine3");

        // Act
        var actual = FileHelper.ReadAllTextToLines(multilineFile);

        // Assert
        Assert.Equal(3, actual.Length);
    }

    [Fact]
    public async Task ReadAllTextToLinesAsync()
    {
        // Arrange
        var multilineFile = new FileInfo(Path.Combine(testDirectory.FullName, "multiline.txt"));
        await File.WriteAllTextAsync(multilineFile.FullName, "Line1\nLine2\nLine3");

        // Act
        var actual = await FileHelper.ReadAllTextToLinesAsync(multilineFile);

        // Assert
        Assert.Equal(3, actual.Length);
    }

    [Fact]
    public void ReadToByteArray()
    {
        // Act
        var actual = FileHelper.ReadToByteArray(testFile);

        // Assert
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
    }

    [Fact]
    public async Task ReadToByteArrayAsync()
    {
        // Act
        var actual = await FileHelper.ReadToByteArrayAsync(testFile);

        // Assert
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
    }

    [Fact]
    public void ReadToMemoryStream()
    {
        // Act
        using var actual = FileHelper.ReadToMemoryStream(testFile);

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.Length > 0);
    }

    [Fact]
    public async Task ReadToMemoryStreamAsync()
    {
        // Act
        using var actual = await FileHelper.ReadToMemoryStreamAsync(testFile);

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.Length > 0);
    }

    [Fact]
    public void WriteAllText()
    {
        // Arrange
        var outputFile = new FileInfo(Path.Combine(testDirectory.FullName, "output.txt"));

        // Act
        FileHelper.WriteAllText(outputFile, "New Content");

        // Assert
        Assert.True(outputFile.Exists);
        Assert.Equal("New Content", File.ReadAllText(outputFile.FullName));
    }

    [Fact]
    public async Task WriteAllTextAsync()
    {
        // Arrange
        var outputFile = new FileInfo(Path.Combine(testDirectory.FullName, "output-async.txt"));

        // Act
        await FileHelper.WriteAllTextAsync(outputFile, "New Content");

        // Assert
        Assert.True(outputFile.Exists);
        Assert.Equal("New Content", await File.ReadAllTextAsync(outputFile.FullName));
    }

    [Fact]
    public void WriteModelToJsonFile_FileInfo()
    {
        // Arrange
        var outputFile = new FileInfo(Path.Combine(testDirectory.FullName, "model.json"));
        var model = new { Name = "Test", Value = 123 };

        // Act
        FileHelper.WriteModelToJsonFile(outputFile, model);

        // Assert
        Assert.True(outputFile.Exists);
    }

    [Fact]
    public void WriteModelToJsonFile_FileInfo_WithOptions()
    {
        // Arrange
        var outputFile = new FileInfo(Path.Combine(testDirectory.FullName, "model2.json"));
        var model = new { Name = "Test", Value = 123 };
        var options = JsonSerializerOptionsFactory.Create();

        // Act
        FileHelper.WriteModelToJsonFile(outputFile, model, options);

        // Assert
        Assert.True(outputFile.Exists);
    }

    [Fact]
    public void WriteModelToJsonFile_Stream()
    {
        // Arrange
        using var stream = new MemoryStream();
        var model = new { Name = "Test", Value = 123 };

        // Act
        FileHelper.WriteModelToJsonFile(stream, model);

        // Assert
        Assert.True(stream.Length > 0);
    }

    [Fact]
    public void WriteModelToJsonFile_Stream_WithOptions()
    {
        // Arrange
        using var stream = new MemoryStream();
        var model = new { Name = "Test", Value = 123 };
        var options = JsonSerializerOptionsFactory.Create();

        // Act
        FileHelper.WriteModelToJsonFile(stream, model, options);

        // Assert
        Assert.True(stream.Length > 0);
    }

    [Fact]
    public async Task WriteModelToJsonFileAsync_FileInfo()
    {
        // Arrange
        var outputFile = new FileInfo(Path.Combine(testDirectory.FullName, "model-async.json"));
        var model = new { Name = "Test", Value = 123 };

        // Act
        await FileHelper.WriteModelToJsonFileAsync(outputFile, model);

        // Assert
        Assert.True(outputFile.Exists);
    }

    [Fact]
    public async Task WriteModelToJsonFileAsync_FileInfo_WithOptions()
    {
        // Arrange
        var outputFile = new FileInfo(Path.Combine(testDirectory.FullName, "model-async2.json"));
        var model = new { Name = "Test", Value = 123 };
        var options = JsonSerializerOptionsFactory.Create();

        // Act
        await FileHelper.WriteModelToJsonFileAsync(outputFile, model, options);

        // Assert
        Assert.True(outputFile.Exists);
    }

    [Fact]
    public async Task WriteModelToJsonFileAsync_Stream()
    {
        // Arrange
        using var stream = new MemoryStream();
        var model = new { Name = "Test", Value = 123 };

        // Act
        await FileHelper.WriteModelToJsonFileAsync(stream, model);

        // Assert
        Assert.True(stream.Length > 0);
    }

    [Fact]
    public async Task WriteModelToJsonFileAsync_Stream_WithOptions()
    {
        // Arrange
        using var stream = new MemoryStream();
        var model = new { Name = "Test", Value = 123 };
        var options = JsonSerializerOptionsFactory.Create();

        // Act
        await FileHelper.WriteModelToJsonFileAsync(stream, model, options);

        // Assert
        Assert.True(stream.Length > 0);
    }
}