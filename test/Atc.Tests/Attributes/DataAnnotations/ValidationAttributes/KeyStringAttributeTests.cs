namespace Atc.Tests.Attributes.DataAnnotations.ValidationAttributes;

public static class KeyStringAttributeTests
{
    [Theory]
    [InlineData(true, null)]
    [InlineData(false, "")]
    [InlineData(true, "H")]
    [InlineData(true, "Hallo")]
    [InlineData(true, "HalloHalloHallo")]
    [InlineData(false, "HalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloXX")]
    [InlineData(false, "_Hallo")]
    [InlineData(false, "Hal lo")]
    [InlineData(false, "Hal.lo")]
    [InlineData(false, "Hal@lo")]
    [InlineData(false, "Hal\'lo")]
    public static void IsValid(
        bool expected,
        string input)
    {
        // Arrange
        var sut = new KeyStringAttribute();

        // Act
        var actual = sut.IsValid(input);

        // Assert
        Assert.Equal(expected, actual);
    }
}
