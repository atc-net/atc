namespace Atc.Tests.Extensions;

public class FileInfoExtensionsTests
{
    [Fact]
    public void ReadToByteArray()
    {
        // Arrange
        var prepareTempFile = PrepareTempFiles(1).First();
        var fileInfo = new FileInfo(prepareTempFile.FullName);

        // Atc
        var actual = fileInfo.ReadToByteArray();

        // Assert
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
    }

    [Fact]
    public async Task ReadToByteArrayAsync()
    {
        // Arrange
        var prepareTempFile = PrepareTempFiles(1).First();
        var fileInfo = new FileInfo(prepareTempFile.FullName);

        // Atc
        var actual = await fileInfo.ReadToByteArrayAsync();

        // Assert
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
    }

    [Fact]
    public async Task ReadToByteArrayAsync_CancellationToken()
    {
        // Arrange
        var prepareTempFile = PrepareTempFiles(1).First();
        var fileInfo = new FileInfo(prepareTempFile.FullName);
        var cancellationToken = CancellationToken.None;

        // Atc
        var actual = await fileInfo.ReadToByteArrayAsync(cancellationToken);

        // Assert
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
    }

    [Fact]
    public void ReadToMemoryStream()
    {
        // Arrange
        var prepareTempFile = PrepareTempFiles(1).First();
        var fileInfo = new FileInfo(prepareTempFile.FullName);

        // Atc
        var actual = fileInfo.ReadToMemoryStream();

        // Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public async Task ReadToMemoryStreamAsync()
    {
        // Arrange
        var prepareTempFile = PrepareTempFiles(1).First();
        var fileInfo = new FileInfo(prepareTempFile.FullName);

        // Atc
        var actual = await fileInfo.ReadToMemoryStreamAsync();

        // Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public async Task ReadToMemoryStreamAsync_CancellationToken()
    {
        // Arrange
        var prepareTempFile = PrepareTempFiles(1).First();
        var fileInfo = new FileInfo(prepareTempFile.FullName);
        var cancellationToken = CancellationToken.None;

        // Atc
        var actual = await fileInfo.ReadToMemoryStreamAsync(cancellationToken);

        // Assert
        Assert.NotNull(actual);
    }

    private static DirectoryInfo GetTempTestPath()
    {
        return new DirectoryInfo(Path.Combine(Path.GetTempPath(), nameof(FileInfoExtensionsTests)));
    }

    private static IEnumerable<FileInfo> PrepareTempFiles(
        int numberOfTempFilesToCreate)
    {
        var root = GetTempTestPath();
        if (root.Exists)
        {
            Directory.Delete(root.FullName, recursive: true);
        }

        Directory.CreateDirectory(root.FullName);

        var files = new List<FileInfo>();
        for (var i = 0; i < numberOfTempFilesToCreate; i++)
        {
            var fileInfo = new FileInfo(Path.Combine(root.FullName, $"Tmp{i}_{DateTime.Now.Ticks}.txt"));
            File.WriteAllText(fileInfo.FullName, "Hello World");
            files.Add(fileInfo);
        }

        return files.ToArray();
    }
}