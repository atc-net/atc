// ReSharper disable InconsistentNaming
namespace Atc.Tests.Attributes.DataAnnotations.ValidationAttributes;

public class IPAddressAttributeTests
{
    [Theory]
    [InlineData(true, null)]
    [InlineData(false, "")]
    [InlineData(false, " ")]
    [InlineData(false, "http://dr.dk")]
    [InlineData(false, "not-an-ip")]
    [InlineData(false, "abc.def.ghi.jkl")]

    [InlineData(true, "0.0.0.0")]
    [InlineData(true, "127.0.0.0")]
    [InlineData(true, "127.0.0.1")]
    [InlineData(true, "127.0.0.255")]
    [InlineData(true, "192.168.1.1")]
    [InlineData(true, "10.0.0.1")]
    [InlineData(true, "255.255.255.255")]

    [InlineData(false, "127.0.0.256")]
    [InlineData(false, "999.999.999.999")]
    [InlineData(false, "1231.0.0.1")]
    [InlineData(false, "192.168.1.1:8080")]
    [InlineData(true, "192.168.1")]
    [InlineData(false, "192.168.1.1.1")]

    [InlineData(true, "::1")]
    [InlineData(true, "::")]
    [InlineData(true, "2001:db8::1")]
    [InlineData(true, "fe80::1")]
    [InlineData(true, "::ffff:192.168.1.1")]
    [InlineData(true, "2001:0db8:85a3:0000:0000:8a2e:0370:7334")]

    [InlineData(true, "[::1]")]
    [InlineData(false, "2001:db8::g")]
    [InlineData(true, "2001:db8::1:8080")]
    public void IsValid(
        bool expected,
        string? input)
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
    [InlineData(false, "", true)]

    [InlineData(false, "http://dr.dk", true)]
    [InlineData(false, "not-an-ip", true)]
    [InlineData(false, "127.0.0.256", true)]
    [InlineData(false, "999.999.999.999", true)]

    [InlineData(true, "127.0.0.0", true)]
    [InlineData(true, "127.0.0.1", true)]
    [InlineData(true, "127.0.0.255", true)]
    [InlineData(true, "192.168.1.1", true)]

    [InlineData(true, "::1", true)]
    [InlineData(true, "2001:db8::1", true)]

    [InlineData(true, null, false)]
    public void IsValid_Required(
        bool expected,
        string? input,
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
    [InlineData(false, "The value is not a valid IPAddress.", "")]
    [InlineData(false, "The value is not a valid IPAddress.", "http://dr.dk")]
    [InlineData(false, "The value is not a valid IPAddress.", "not-an-ip")]
    [InlineData(false, "The value is not a valid IPAddress.", "127.0.0.256")]
    [InlineData(false, "The value is not a valid IPAddress.", "999.999.999.999")]
    [InlineData(false, "The value is not a valid IPAddress.", "1231.0.0.1")]
    [InlineData(true, "", "0.0.0.0")]
    [InlineData(true, "", "127.0.0.0")]
    [InlineData(true, "", "127.0.0.1")]
    [InlineData(true, "", "127.0.0.255")]
    [InlineData(true, "", "192.168.1.1")]
    [InlineData(true, "", "255.255.255.255")]
    [InlineData(true, "", "::1")]
    [InlineData(true, "", "2001:db8::1")]
    [InlineData(true, "", "::ffff:192.168.1.1")]
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

    [Theory]
    [InlineData(false, "The value is not a valid IPAddress.", "", true)]
    [InlineData(false, "The value is not a valid IPAddress.", "not-an-ip", true)]
    [InlineData(false, "The value is not a valid IPAddress.", "999.999.999.999", true)]
    [InlineData(true, "", "192.168.1.1", false)]
    [InlineData(true, "", "::1", false)]
    public void TryIsValid_WithAttribute(
        bool expected,
        string expectedMessage,
        string input,
        bool required)
    {
        // Arrange
        var attribute = new IPAddressAttribute(required);

        // Act
        var actual = IPAddressAttribute.TryIsValid(input, attribute, out var errorMessage);

        // Assert
        Assert.Equal(expected, actual);
        Assert.Equal(expectedMessage, errorMessage);
    }
}