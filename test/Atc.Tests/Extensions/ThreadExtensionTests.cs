namespace Atc.Tests.Extensions;

public class ThreadExtensionTests
{
    [Theory]
    [InlineData("da-DK", 1030)]
    [InlineData("en-US", 1033)]
    public void SetCulture(
        string expected,
        int lcid)
    {
        // Arrange
        var cultureInfo = new CultureInfo(lcid);

        // Act
        Thread.CurrentThread.SetCulture(cultureInfo);

        // Assert
        Assert.Equal(expected, Thread.CurrentThread.CurrentCulture.Name);
        Assert.Equal(expected, Thread.CurrentThread.CurrentUICulture.Name);
    }
}