namespace Atc.Rest.Tests.Extensions;

public class AssemblyExtensionsTests
{
    [Fact]
    public void GetApiName()
    {
        // Arrange
        var assembly = Assembly.GetExecutingAssembly();

        // Act
        var actual = assembly.GetApiName();

        // Assert
        Assert.Equal("Atc Rest Tests", actual);
    }

    [Theory]
    [InlineData("Atc Rest Tests", false)]
    [InlineData("Atc Rest", true)]
    public void GetApiName_RemoveLastVerb(string expected, bool removeLastVerb)
    {
        // Arrange
        var assembly = Assembly.GetExecutingAssembly();

        // Act
        var actual = assembly.GetApiName(removeLastVerb);

        // Assert
        Assert.Equal(expected, actual);
    }
}