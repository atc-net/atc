namespace Atc.Tests.Attributes.DataAnnotations.ValidationAttributes;

public class IsoCurrencySymbolAttributeTests
{
    [Theory]
    [InlineData(true, null)]
    [InlineData(false, "")]
    [InlineData(false, "H")]
    [InlineData(false, "ABC")]
    [InlineData(true, "DKK")]
    public void IsValid(
        bool expected,
        string input)
    {
        // Arrange
        var sut = new IsoCurrencySymbolAttribute();

        // Act
        var actual = sut.IsValid(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, null)]
    [InlineData(false, "")]
    [InlineData(false, "H")]
    [InlineData(false, "ABC")]
    [InlineData(true, "DKK")]
    public void IsValid_Required(
        bool expected,
        string input)
    {
        // Arrange
        var sut = new IsoCurrencySymbolAttribute
        {
            Required = true,
        };

        // Act
        var actual = sut.IsValid(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, null)]
    [InlineData(false, "")]
    [InlineData(false, "H")]
    [InlineData(false, "ABC")]
    [InlineData(true, "DKK")]
    public void IsValid_IsoCurrencySymbols(
        bool expected,
        string input)
    {
        // Arrange
        var sut = new IsoCurrencySymbolAttribute
        {
            IsoCurrencySymbols = new[] { "DKK" },
        };

        // Act
        var actual = sut.IsValid(input);

        // Assert
        Assert.Equal(expected, actual);
    }
}