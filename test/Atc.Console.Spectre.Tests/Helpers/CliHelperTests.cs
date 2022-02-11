namespace Atc.Console.Spectre.Tests.Helpers;

public class CliHelperTests
{
    [Fact]
    public void GetFileVersion()
    {
        // Act
        var actual = CliHelper.GetCurrentVersion();

        // Assert
        Assert.NotNull(actual);
    }
}