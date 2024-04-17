// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable StringLiteralTypo
namespace Atc.Tests.Extensions.BaseTypes;

public class ByteExtensionsTests
{
    [Fact]
    public void ToHex_NullByteArray()
    {
        // Arrange
        byte[] nullArray = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => nullArray.ToHex());
    }

    [Fact]
    public void ToHex_EmptyByteArray()
    {
        // Arrange
        var byteArray = Array.Empty<byte>();

        var actual = byteArray.ToHex();

        // Assert
        Assert.Equal(string.Empty, actual);
    }

    [Fact]
    public void ToHex_WithoutSeparator()
    {
        // Arrange
        byte[] byteArray = { 0x12, 0x34, 0x56 };

        var actual = byteArray.ToHex();

        // Assert
        Assert.Equal("123456", actual);
    }

    [Fact]
    public void ToHex_WithSeparator1()
    {
        // Arrange
        byte[] byteArray = { 0x12, 0x34, 0x56 };

        // Act
        var actual = byteArray.ToHex("-");

        // Assert
        Assert.Equal("12-34-56", actual);
    }

    [Fact]
    public void ToHex_WithSeparator2()
    {
        // Arrange
        byte[] byteArray = { 0x12, 0x34, 0x56 };

        // Act
        var actual = byteArray.ToHex(":");

        // Assert
        Assert.Equal("12:34:56", actual);
    }

    [Fact]
    public void ToHex_WithSeparatorAndHexSign1()
    {
        // Arrange
        byte[] byteArray = { 0x12, 0x34, 0x56 };

        // Act
        var actual = byteArray.ToHex(", ", showHexSign: true);

        // Assert
        Assert.Equal("0x12, 0x34, 0x56", actual);
    }

    [Fact]
    public void ToHex_WithSeparatorAndHexSign2()
    {
        // Arrange
        byte[] byteArray = { 0x12, 0x34, 0x56 };

        // Act
        var actual = byteArray.ToHex(" - ", showHexSign: true);

        // Assert
        Assert.Equal("0x12 - 0x34 - 0x56", actual);
    }

    [Fact]
    public void ToHexWithPrefix()
    {
        // Arrange
        byte[] byteArray = { 0x1A, 0x2B, 0x3C };

        // Act
        var actual = byteArray.ToHexWithPrefix();

        // Assert
        Assert.Equal("0x1A, 0x2B, 0x3C", actual);
    }
}