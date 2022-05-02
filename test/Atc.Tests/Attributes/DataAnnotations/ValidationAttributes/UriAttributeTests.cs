namespace Atc.Tests.Attributes.DataAnnotations.ValidationAttributes;

public class UriAttributeTests
{
    [Theory]
    [InlineData(true, "http://dr.dk")]
    [InlineData(true, "https://dr.dk")]
    [InlineData(true, "ftp://dr.dk")]
    [InlineData(true, "http://www.dr.dk")]
    [InlineData(true, "https://www.dr.dk")]
    [InlineData(true, "ftp://www.dr.dk")]
    [InlineData(true, "file://c:/temp/file.txt")]
    [InlineData(true, "opc.tcp://milo.digitalpetri.com:62541/milo")]
    [InlineData(false, "httpx://www.dr.dk")]
    [InlineData(false, "httpsx://www.dr.dk")]
    [InlineData(false, "ftpx://www.dr.dk")]
    [InlineData(false, "filex://c:/temp/file.txt")]
    [InlineData(false, "opa.tcp://milo.digitalpetri.com:62541/milo")]
    public void IsValid(
        bool expected,
        string input)
    {
        // Arrange
        var sut = new UriAttribute();

        // Act
        var actual = sut.IsValid(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, "", "http://dr.dk")]
    [InlineData(true, "", "https://dr.dk")]
    [InlineData(true, "", "ftp://dr.dk")]
    [InlineData(true, "", "http://www.dr.dk")]
    [InlineData(true, "", "https://www.dr.dk")]
    [InlineData(true, "", "ftp://www.dr.dk")]
    [InlineData(true, "", "file://c:/temp/file.txt")]
    [InlineData(true, "", "opc.tcp://milo.digitalpetri.com:62541/milo")]
    [InlineData(false, "The value is not a valid Uri.", "httpx://www.dr.dk")]
    [InlineData(false, "The value is not a valid Uri.", "httpsx://www.dr.dk")]
    [InlineData(false, "The value is not a valid Uri.", "ftpx://www.dr.dk")]
    [InlineData(false, "The value is not a valid Uri.", "filex://c:/temp/file.txt")]
    [InlineData(false, "The value is not a valid Uri.", "opa.tcp://milo.digitalpetri.com:62541/milo")]
    public void TryIsValid(
        bool expected,
        string expectedMessage,
        string input)
    {
        // Act
        var actual = UriAttribute.TryIsValid(input, out var errorMessage);

        // Assert
        Assert.Equal(expected, actual);
        Assert.Equal(expectedMessage, errorMessage);
    }
}