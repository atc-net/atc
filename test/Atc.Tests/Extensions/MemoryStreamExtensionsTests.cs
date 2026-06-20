namespace Atc.Tests.Extensions;

public class MemoryStreamExtensionsTests
{
    [Fact]
    public void ToString_ExplicitUtf8()
    {
        // Arrange
        var input = "Hallo world".ToStream() as MemoryStream;

        // Act
        var actual = input!.ToString(Encoding.UTF8);

        // Assert
        Assert.Equal("Hallo world", actual);
    }

    [Fact]
    public void ToString_DefaultEncoding_IsUtf8()
    {
        // Arrange — UTF-8 bytes for "Héllo"
        var bytes = Encoding.UTF8.GetBytes("Héllo");
        using var input = new MemoryStream(bytes);

        // Act — no encoding argument; must default to UTF-8, not UTF-16
        var actual = input.ToString();

        // Assert
        Assert.Equal("Héllo", actual);
    }
}