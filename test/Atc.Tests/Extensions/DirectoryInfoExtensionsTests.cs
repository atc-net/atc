// ReSharper disable StringLiteralTypo
namespace Atc.Tests.Extensions;

[Collection("TestCollection")]
[Trait(Traits.Category, Traits.Categories.Integration)]
[Trait(Traits.Category, Traits.Categories.SkipWhenLiveUnitTesting)]
public class DirectoryInfoExtensionsTests
{
    [Theory]
    [InlineData("Extensions", "ServiceCollectionExtensions.cs")]
    [InlineData("Config", "appsettings.json")]
    [InlineData("Reports", "AnnualReport.pdf")]
    public void CombineFileInfo(
        string subPath1,
        string subPath2)
    {
        // Arrange
        var tempDir = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        if (!tempDir.Exists)
        {
            Directory.CreateDirectory(tempDir.FullName);
        }

        var expected = Path.Combine(tempDir.FullName, subPath1, subPath2);

        // Act
        var result = tempDir.CombineFileInfo(subPath1, subPath2);

        // Assert
        Assert.Equal(expected, result.FullName);

        // Cleanup
        if (tempDir.Exists)
        {
            Directory.Delete(tempDir.FullName, recursive: true);
        }
    }

    [Theory]
    [InlineData(1, 1, 0)]
    public void GetFilesForAuthorizedAccess(
        int expected,
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate)
    {
        // Arrange
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        PrepareTempFiles(numberOfTempFilesToCreate, numberOfTempFoldersToCreate);

        // Atc
        var actual = root.GetFilesForAuthorizedAccess();

        // Assert
        Assert.Equal(expected, actual.Length);
    }

    [Theory]
    [InlineData(1, "*.*", 1, 0)]
    public void GetFilesForAuthorizedAccess_SearchPattern(
        int expected,
        string searchPattern,
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate)
    {
        // Arrange
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        PrepareTempFiles(numberOfTempFilesToCreate, numberOfTempFoldersToCreate);

        // Atc
        var actual = root.GetFilesForAuthorizedAccess(searchPattern);

        // Assert
        Assert.Equal(expected, actual.Length);
    }

    [Theory]
    [InlineData(1, "*.*", SearchOption.TopDirectoryOnly, 1, 0)]
    public void GetFilesForAuthorizedAccess_SearchPattern_SearchOptions(
        int expected,
        string searchPattern,
        SearchOption searchOption,
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate)
    {
        // Arrange
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        PrepareTempFiles(numberOfTempFilesToCreate, numberOfTempFoldersToCreate);

        // Atc
        var actual = root.GetFilesForAuthorizedAccess(searchPattern, searchOption);

        // Assert
        Assert.Equal(expected, actual.Length);
    }

    [Theory]
    [InlineData(1, 1, 0)]
    [InlineData(0, 0, 1)]
    [InlineData(1, 1, 1)]
    [InlineData(3, 3, 4)]
    public void GetFilesCount(
        int expected,
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate)
    {
        // Arrange
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        PrepareTempFiles(numberOfTempFilesToCreate, numberOfTempFoldersToCreate);

        // Atc
        var actual = root.GetFilesCount();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, "*.*", 1, 0)]
    [InlineData(0, "*.cs", 1, 0)]
    [InlineData(1, "*.txt", 1, 0)]
    public void GetFilesCount_SearchPattern(
        int expected,
        string searchPattern,
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate)
    {
        // Arrange
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        PrepareTempFiles(numberOfTempFilesToCreate, numberOfTempFoldersToCreate);

        // Atc
        var actual = root.GetFilesCount(searchPattern);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, "*.*", SearchOption.TopDirectoryOnly, 1, 0)]
    [InlineData(0, "*.cs", SearchOption.TopDirectoryOnly, 1, 0)]
    [InlineData(1, "*.txt", SearchOption.TopDirectoryOnly, 1, 0)]
    public void GetFilesCount_SearchPattern_SearchOptions(
        int expected,
        string searchPattern,
        SearchOption searchOption,
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate)
    {
        // Arrange
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        PrepareTempFiles(numberOfTempFilesToCreate, numberOfTempFoldersToCreate);

        // Atc
        var actual = root.GetFilesCount(searchPattern, searchOption);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, "*", 0, 1)]
    [InlineData(0, "*", 1, 0)]
    [InlineData(1, "*", 1, 1)]
    [InlineData(4, "*", 3, 4)]
    public void GetFoldersCount_SearchPattern(
        int expected,
        string searchPattern,
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate)
    {
        // Arrange
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        PrepareTempFiles(numberOfTempFilesToCreate, numberOfTempFoldersToCreate);

        // Atc
        var actual = root.GetFoldersCount(searchPattern);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, "*", SearchOption.TopDirectoryOnly, 0, 1)]
    [InlineData(0, "*", SearchOption.TopDirectoryOnly, 1, 0)]
    [InlineData(1, "*", SearchOption.TopDirectoryOnly, 1, 1)]
    [InlineData(4, "*", SearchOption.TopDirectoryOnly, 3, 4)]
    public void GetFoldersCount_SearchPattern_SearchOptions(
        int expected,
        string searchPattern,
        SearchOption searchOption,
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate)
    {
        // Arrange
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        PrepareTempFiles(numberOfTempFilesToCreate, numberOfTempFoldersToCreate);

        // Atc
        var actual = root.GetFoldersCount(searchPattern, searchOption);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 0, 1)]
    [InlineData(0, 1, 0)]
    [InlineData(1, 1, 1)]
    [InlineData(4, 3, 4)]
    public void GetFoldersCount(
        int expected,
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate)
    {
        // Arrange
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        PrepareTempFiles(numberOfTempFilesToCreate, numberOfTempFoldersToCreate);

        // Atc
        var actual = root.GetFoldersCount();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(11, 1, 0)]
    public void GetByteSize(
        int expected,
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate)
    {
        // Arrange
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        PrepareTempFiles(numberOfTempFilesToCreate, numberOfTempFoldersToCreate);

        // Atc
        var actual = root.GetByteSize();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(11, "*.*", 1, 0)]
    public void GetByteSize_SearchPattern(
        int expected,
        string searchPattern,
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate)
    {
        // Arrange
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        PrepareTempFiles(numberOfTempFilesToCreate, numberOfTempFoldersToCreate);

        // Atc
        var actual = root.GetByteSize(searchPattern);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(11, "*.*", SearchOption.TopDirectoryOnly, 1, 0)]
    public void GetByteSize_SearchPattern_SearchOptions(
        int expected,
        string searchPattern,
        SearchOption searchOption,
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate)
    {
        // Arrange
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        PrepareTempFiles(numberOfTempFilesToCreate, numberOfTempFoldersToCreate);

        // Atc
        var actual = root.GetByteSize(searchPattern, searchOption);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("11 B", 1, 0, GlobalizationLcidConstants.Denmark)]
    [InlineData("1,08 KB", 101, 0, GlobalizationLcidConstants.Denmark)]
    public void GetPrettySize(
        string expected,
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate,
        int lcid)
    {
        // Arrange
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        PrepareTempFiles(numberOfTempFilesToCreate, numberOfTempFoldersToCreate);
        Thread.CurrentThread.SetCulture(new CultureInfo(lcid));

        // Atc
        var actual = root.GetPrettySize();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("11 B", "*.*", 1, 0, GlobalizationLcidConstants.Denmark)]
    [InlineData("1,08 KB", "*.*", 101, 0, GlobalizationLcidConstants.Denmark)]
    public void GetPrettySize_SearchPattern(
        string expected,
        string searchPattern,
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate,
        int lcid)
    {
        // Arrange
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        PrepareTempFiles(numberOfTempFilesToCreate, numberOfTempFoldersToCreate);
        Thread.CurrentThread.SetCulture(new CultureInfo(lcid));

        // Atc
        var actual = root.GetPrettySize(searchPattern);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("11 B", "*.*", SearchOption.TopDirectoryOnly, 1, 0, GlobalizationLcidConstants.Denmark)]
    [InlineData("1,08 KB", "*.*", SearchOption.TopDirectoryOnly, 101, 0, GlobalizationLcidConstants.Denmark)]
    public void GetPrettySize_SearchPattern_SearchOptions(
        string expected,
        string searchPattern,
        SearchOption searchOption,
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate,
        int lcid)
    {
        // Arrange
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        PrepareTempFiles(numberOfTempFilesToCreate, numberOfTempFoldersToCreate);
        Thread.CurrentThread.SetCulture(new CultureInfo(lcid));

        // Atc
        var actual = root.GetPrettySize(searchPattern, searchOption);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("11 bytes", "*.*", 1, 0, GlobalizationLcidConstants.Denmark)]
    [InlineData("1.111 bytes", "*.*", 101, 0, GlobalizationLcidConstants.Denmark)]
    public void GetPrettyByteSize_SearchPattern(
        string expected,
        string searchPattern,
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate,
        int lcid)
    {
        // Arrange
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        PrepareTempFiles(numberOfTempFilesToCreate, numberOfTempFoldersToCreate);
        Thread.CurrentThread.SetCulture(new CultureInfo(lcid));

        // Atc
        var actual = root.GetPrettyByteSize(searchPattern);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("11 bytes", "*.*", SearchOption.TopDirectoryOnly, 1, 0, GlobalizationLcidConstants.Denmark)]
    [InlineData("1.111 bytes", "*.*", SearchOption.TopDirectoryOnly, 101, 0, GlobalizationLcidConstants.Denmark)]
    public void GetPrettyByteSize_SearchPattern_SearchOptions(
        string expected,
        string searchPattern,
        SearchOption searchOption,
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate,
        int lcid)
    {
        // Arrange
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        PrepareTempFiles(numberOfTempFilesToCreate, numberOfTempFoldersToCreate);
        Thread.CurrentThread.SetCulture(new CultureInfo(lcid));

        // Atc
        var actual = root.GetPrettyByteSize(searchPattern, searchOption);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("11 bytes", 1, 0, GlobalizationLcidConstants.Denmark)]
    [InlineData("1.111 bytes", 101, 0, GlobalizationLcidConstants.Denmark)]
    public void GetPrettyByteSize(
        string expected,
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate,
        int lcid)
    {
        // Arrange
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        PrepareTempFiles(numberOfTempFilesToCreate, numberOfTempFoldersToCreate);
        Thread.CurrentThread.SetCulture(new CultureInfo(lcid));

        // Atc
        var actual = root.GetPrettyByteSize();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetFileInfo()
    {
        // Arrange
        var directoryInfo = DirectoryInfoHelper.GetTempPath();
        var expected = Path.Combine(directoryInfo.FullName, "myfile.txt");

        // Atc
        var actual = directoryInfo.GetFileInfo("myfile.txt");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual.FullName);
    }

    private static void PrepareTempFiles(
        int numberOfTempFilesToCreate,
        int numberOfTempFoldersToCreate)
    {
        var root = DirectoryInfoHelper.GetTempPathWithSubFolder(nameof(DirectoryInfoExtensionsTests));
        if (root.Exists)
        {
            Directory.Delete(root.FullName, recursive: true);
        }

        Directory.CreateDirectory(root.FullName);

        for (var i = 0; i < numberOfTempFoldersToCreate; i++)
        {
            Directory.CreateDirectory(Path.Combine(root.FullName, $"Folder{i}"));
        }

        for (var i = 0; i < numberOfTempFilesToCreate; i++)
        {
            var fileInfo = new FileInfo(Path.Combine(root.FullName, $"Tmp{i}.txt"));
            File.WriteAllText(fileInfo.FullName, "Hello World");
        }
    }
}