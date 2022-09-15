namespace Atc.Tests.Attributes.DataAnnotations.ValidationAttributes;

public static class KeyStringAttributeTests
{
    [Theory]
    [InlineData(false, null)]
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

    [Theory]
    [InlineData(false, "The value is required.", null)]
    [InlineData(false, "The value must be between 1 and 256.", "")]
    [InlineData(true, "", "H")]
    [InlineData(true, "", "Hallo")]
    [InlineData(true, "", "HalloHalloHallo")]
    [InlineData(false, "The value must be between 1 and 256.", "HalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloXX")]
    [InlineData(false, "The value cannot start with: _.", "_Hallo")]
    [InlineData(false, "The value cannot contain:  , ., @, '.", "Hal lo")]
    [InlineData(false, "The value cannot contain:  , ., @, '.", "Hal.lo")]
    [InlineData(false, "The value cannot contain:  , ., @, '.", "Hal@lo")]
    [InlineData(false, "The value cannot contain:  , ., @, '.", "Hal\'lo")]
    public static void TryIsValid(
        bool expected,
        string expectedMessage,
        string input)
    {
        // Act
        var actual = KeyStringAttribute.TryIsValid(input, out var errorMessage);

        // Assert
        Assert.Equal(expected, actual);
        Assert.Equal(expectedMessage, errorMessage);
    }
}