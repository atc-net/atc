// ReSharper disable InconsistentNaming
namespace Atc.Tests.Attributes.DataAnnotations.ValidationAttributes;

public class IPAddressAttributeTests
{
    [Theory]
    [InlineData(true, null)]
    [InlineData(false, "")]
    [InlineData(false, "http://dr.dk")]
    [InlineData(true, "127.0.0.0")]
    [InlineData(true, "127.0.0.1")]
    [InlineData(true, "127.0.0.255")]
    [InlineData(false, "127.0.0.256")]
    public void IsValid(
        bool expected,
        string input)
    {
        // Arrange
        var sut = new IPAddressAttribute();

        // Act
        var actual = sut.IsValid(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, null, true)]
    [InlineData(false, "http://dr.dk", true)]
    [InlineData(true, "127.0.0.0", true)]
    [InlineData(true, "127.0.0.1", true)]
    [InlineData(true, "127.0.0.255", true)]
    [InlineData(false, "127.0.0.256", true)]
    public void IsValid_Required(
        bool expected,
        string input,
        bool required)
    {
        // Arrange
        var sut = new IPAddressAttribute(required);

        // Act
        var actual = sut.IsValid(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, "The value is not a valid IPAddress.", "http://dr.dk")]
    [InlineData(true, "", "127.0.0.0")]
    [InlineData(true, "", "127.0.0.1")]
    [InlineData(true, "", "127.0.0.255")]
    [InlineData(false, "The value is not a valid IPAddress.", "127.0.0.256")]
    public void TryIsValid(
        bool expected,
        string expectedMessage,
        string input)
    {
        // Act
        var actual = IPAddressAttribute.TryIsValid(input, out var errorMessage);

        // Assert
        Assert.Equal(expected, actual);
        Assert.Equal(expectedMessage, errorMessage);
    }
}