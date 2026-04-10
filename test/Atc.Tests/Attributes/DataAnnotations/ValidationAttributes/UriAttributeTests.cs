namespace Atc.Tests.Attributes.DataAnnotations.ValidationAttributes;

public class UriAttributeTests
{
    [Theory]
    [InlineData(true, "http://dr.dk")]
    [InlineData(true, "https://dr.dk")]
    [InlineData(true, "ftp://dr.dk")]
    [InlineData(true, "ftps://dr.dk")]
    [InlineData(true, "http://www.dr.dk")]
    [InlineData(true, "https://www.dr.dk")]
    [InlineData(true, "ftp://www.dr.dk")]
    [InlineData(true, "file://c:/temp/file.txt")]
    [InlineData(true, "opc.tcp://milo.digitalpetri.com:62541/milo")]
    [InlineData(true, "http://192.168.1.1:8080")]
    [InlineData(true, "https://10.0.0.1")]
    [InlineData(true, "http://127.0.0.1")]
    [InlineData(true, "opc.tcp://192.168.1.1:4840")]
    [InlineData(true, "http://[::1]:8080")]
    [InlineData(true, "https://[::1]")]
    [InlineData(true, "opc.tcp://[::1]:4840")]
    [InlineData(true, "opc.tcp://[2001:db8::1]:4840")]
    [InlineData(true, "http://localhost:8080")]
    [InlineData(false, "httpx://www.dr.dk")]
    [InlineData(false, "httpsx://www.dr.dk")]
    [InlineData(false, "ftpx://www.dr.dk")]
    [InlineData(false, "filex://c:/temp/file.txt")]
    [InlineData(false, "opa.tcp://milo.digitalpetri.com:62541/milo")]
    [InlineData(false, "http://1231.0.0.1:8080")]
    [InlineData(false, "https://999.999.999.999")]
    [InlineData(false, "opc.tcp://1231.0.0.1:4840")]
    [InlineData(false, "opc.tcp://999.999.999.999:4840")]
    [InlineData(false, "ftp://256.1.1.1")]
    [InlineData(true, "http://dr.dk:0")]
    [InlineData(true, "http://dr.dk:65535")]
    [InlineData(true, "opc.tcp://192.168.1.1:65535")]
    [InlineData(false, "http://dr.dk:65536")]
    [InlineData(false, "http://dr.dk:99999")]
    [InlineData(false, "opc.tcp://192.168.1.1:-1")]
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
    [InlineData(true, null, false, false, false, false, false, false, false)]
    [InlineData(false, "", false, false, false, false, false, false, false)]
    [InlineData(false, "http://dr.dk", false, false, false, false, false, false, false)]
    [InlineData(true, "http://dr.dk", false, true, false, false, false, false, false)]
    [InlineData(false, "https://dr.dk", false, false, false, false, false, false, false)]
    [InlineData(true, "https://dr.dk", false, false, true, false, false, false, false)]
    [InlineData(false, "ftp://dr.dk", false, false, false, false, false, false, false)]
    [InlineData(true, "ftp://dr.dk", false, false, false, true, false, false, false)]
    [InlineData(false, "file://c:/temp/file.txt", false, false, false, false, false, false, false)]
    [InlineData(true, "file://c:/temp/file.txt", false, false, false, false, false, true, false)]
    [InlineData(false, "opc.tcp://milo.digitalpetri.com:62541/milo", false, false, false, false, false, false, false)]
    [InlineData(true, "opc.tcp://milo.digitalpetri.com:62541/milo", false, false, false, false, false, false, true)]
    [InlineData(false, null, true, false, false, false, false, false, false)]
    [InlineData(false, "", true, false, false, false, false, false, false)]
    public void IsValid_RequiredOrAllow(
        bool expected,
        string input,
        bool required,
        bool allowHttp,
        bool allowHttps,
        bool allowFtp,
        bool allowFtps,
        bool allowFile,
        bool allowOpcTcp)
    {
        // Arrange
        var sut = new UriAttribute(required, allowHttp, allowHttps, allowFtp, allowFtps, allowFile, allowOpcTcp);

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
    [InlineData(true, "", "http://192.168.1.1:8080")]
    [InlineData(true, "", "opc.tcp://[::1]:4840")]
    [InlineData(false, "The value is not a valid Uri.", "http://1231.0.0.1:8080")]
    [InlineData(false, "The value is not a valid Uri.", "opc.tcp://999.999.999.999:4840")]
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

    [Theory]
    [InlineData(true, "http://dr.dk")]
    [InlineData(true, "https://dr.dk")]
    [InlineData(true, "http://www.dr.dk")]
    [InlineData(true, "https://www.dr.dk")]
    [InlineData(false, null)]
    [InlineData(false, "")]
    [InlineData(false, "ftp://dr.dk")]
    [InlineData(false, "ftps://dr.dk")]
    [InlineData(false, "file://c:/temp/file.txt")]
    [InlineData(false, "opc.tcp://milo.digitalpetri.com:62541/milo")]
    [InlineData(true, "http://192.168.1.1:8080")]
    [InlineData(true, "https://10.0.0.1")]
    [InlineData(true, "http://[::1]:8080")]
    [InlineData(false, "http://999.999.999.999:8080")]
    [InlineData(false, "https://1231.0.0.1")]
    [InlineData(true, "http://dr.dk:8080")]
    [InlineData(true, "https://dr.dk:443")]
    [InlineData(false, "http://dr.dk:65536")]
    public void IsValidHttpOrHttps(
        bool expected,
        string? input)
    {
        // Act
        var actual = UriAttribute.IsValidHttpOrHttps(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, "", "http://dr.dk")]
    [InlineData(true, "", "https://dr.dk")]
    [InlineData(false, "The value is not a valid Uri.", "ftp://dr.dk")]
    [InlineData(false, "The value is not a valid Uri.", "opc.tcp://milo.digitalpetri.com:62541/milo")]
    [InlineData(false, "The value is not a valid Uri.", "")]
    [InlineData(true, "", "https://192.168.1.1:443")]
    [InlineData(true, "", "http://[::1]:8080")]
    [InlineData(false, "The value is not a valid Uri.", "http://999.999.999.999:8080")]
    public void TryIsValidHttpOrHttps(
        bool expected,
        string expectedMessage,
        string input)
    {
        // Act
        var actual = UriAttribute.TryIsValidHttpOrHttps(input, out var errorMessage);

        // Assert
        Assert.Equal(expected, actual);
        Assert.Equal(expectedMessage, errorMessage);
    }

    [Theory]
    [InlineData(true, "opc.tcp://milo.digitalpetri.com:62541/milo")]
    [InlineData(false, null)]
    [InlineData(false, "")]
    [InlineData(false, "https://dr.dk")]
    [InlineData(false, "http://dr.dk")]
    [InlineData(false, "ftp://dr.dk")]
    [InlineData(false, "file://c:/temp/file.txt")]
    [InlineData(true, "opc.tcp://192.168.1.1:4840")]
    [InlineData(true, "opc.tcp://[::1]:4840")]
    [InlineData(true, "opc.tcp://[2001:db8::1]:4840")]
    [InlineData(false, "opc.tcp://1231.0.0.1:4840")]
    [InlineData(false, "opc.tcp://999.999.999.999:4840")]
    [InlineData(true, "opc.tcp://192.168.1.1:0")]
    [InlineData(true, "opc.tcp://192.168.1.1:65535")]
    [InlineData(false, "opc.tcp://192.168.1.1:65536")]
    public void IsValidOpcTcp(
        bool expected,
        string? input)
    {
        // Act
        var actual = UriAttribute.IsValidOpcTcp(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, "", "opc.tcp://milo.digitalpetri.com:62541/milo")]
    [InlineData(false, "The value is not a valid Uri.", "https://dr.dk")]
    [InlineData(false, "The value is not a valid Uri.", "http://dr.dk")]
    [InlineData(false, "The value is not a valid Uri.", "")]
    [InlineData(true, "", "opc.tcp://192.168.1.1:4840")]
    [InlineData(true, "", "opc.tcp://[::1]:4840")]
    [InlineData(false, "The value is not a valid Uri.", "opc.tcp://1231.0.0.1:4840")]
    public void TryIsValidOpcTcp(
        bool expected,
        string expectedMessage,
        string input)
    {
        // Act
        var actual = UriAttribute.TryIsValidOpcTcp(input, out var errorMessage);

        // Assert
        Assert.Equal(expected, actual);
        Assert.Equal(expectedMessage, errorMessage);
    }
}