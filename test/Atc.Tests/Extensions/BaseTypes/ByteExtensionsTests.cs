// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable StringLiteralTypo
namespace Atc.Tests.Extensions.BaseTypes;

public class ByteExtensionsTests
{
    [Theory]
    [InlineData(new byte[] { 1, 2, 3, 4, 5 }, 0, 3, new byte[] { 1, 2, 3 })]
    [InlineData(new byte[] { 1, 2, 3, 4, 5 }, 2, 2, new byte[] { 3, 4 })]
    [InlineData(new byte[] { 1, 2, 3, 4, 5 }, 0, 0, new byte[] { })]
    public void TakeBytes(
        byte[] value,
        int startPosition,
        int length,
        byte[] expected)
    {
        // Act
        var actual = value.TakeBytes(startPosition, length);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new byte[] { 1, 0, 0, 0 }, 0, 4, 1)]
    [InlineData(new byte[] { 255, 0, 0, 0 }, 0, 4, 255)]
    public void TakeBytesAndConvertToInt(
        byte[] value,
        int startPosition,
        int length,
        int expected)
    {
        // Act
        var actual = value.TakeBytesAndConvertToInt(startPosition, length);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new byte[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 0, 8, 1L)]
    [InlineData(new byte[] { 255, 0, 0, 0, 0, 0, 0, 0 }, 0, 8, 255L)]
    public void TakeBytesAndConvertToLong(
        byte[] value,
        int startPosition,
        int length,
        long expected)
    {
        // Act
        var actual = value.TakeBytesAndConvertToLong(startPosition, length);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new byte[] { 1, 2, 3, 4, 5 }, 0, new byte[] { 1, 2, 3, 4, 5 })]
    [InlineData(new byte[] { 1, 2, 3, 4, 5 }, 2, new byte[] { 3, 4, 5 })]
    [InlineData(new byte[] { 1, 2, 3, 4, 5 }, 5, new byte[] { })]
    public void TakeRemainingBytes(
        byte[] value,
        int startPosition,
        byte[] expected)
    {
        // Act
        var actual = value.TakeRemainingBytes(startPosition);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Split()
    {
        // Arrange
        byte[] value = { 1, 2, 0, 3, 4, 0, 5 };
        byte splitByte = 0;

        // Act
        var actual = new List<byte[]>();
        foreach (var range in value
                     .AsSpan()
                     .Split(splitByte))
        {
            actual.Add(value[range].ToArray());
        }

        // Assert
        Assert.Equal(3, actual.Count);
        Assert.Equal(new byte[] { 1, 2 }, actual[0]);
        Assert.Equal(new byte[] { 3, 4 }, actual[1]);
        Assert.Equal(new byte[] { 5 }, actual[2]);
    }

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