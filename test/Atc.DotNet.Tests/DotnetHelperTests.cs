namespace Atc.DotNet.Tests;

public class DotnetHelperTests
{
    [Fact]
    public void GetDotnetDirectory()
    {
        // Act
        var actual = DotnetHelper.GetDotnetDirectory();

        // Assert
        Assert.NotNull(actual);
        Assert.True(Directory.Exists(actual.FullName));
    }

    [Fact]
    public void GetDotnetExecutable()
    {
        // Act
        var actual = DotnetHelper.GetDotnetExecutable();

        // Assert
        Assert.NotNull(actual);
        Assert.True(File.Exists(actual.FullName));
    }

    [Fact]
    public async Task GetDotnetVersion()
    {
        // Act
        var actual = await DotnetHelper.GetDotnetVersion();

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual != new Version(0, 0));
    }
}