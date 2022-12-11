// ReSharper disable StringLiteralTypo
namespace Atc.Tests.Helpers;

public class DirectoryInfoHelperTests
{
    [Fact]
    public void GetTempPath()
    {
        // Arrange
        var expected = Path.GetTempPath();

        // Atc
        var actual = DirectoryInfoHelper.GetTempPath();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual.FullName);
    }

    [Fact]
    public void GetTempPathWithSubFolder()
    {
        // Arrange
        var expected = Path.Combine(Path.GetTempPath(), "myfolder");

        // Atc
        var actual = DirectoryInfoHelper.GetTempPathWithSubFolder("myfolder");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual.FullName);
    }
}