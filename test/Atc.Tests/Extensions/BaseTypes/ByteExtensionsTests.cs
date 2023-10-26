// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable StringLiteralTypo
namespace Atc.Tests.Extensions.BaseTypes;

public class ByteExtensionsTests
{
    [Fact]
    public void ToHex_NullByteArray()
    {
        byte[] nullArray = null;

        Assert.Throws<ArgumentNullException>(() => nullArray.ToHex());
    }

    [Fact]
    public void ToHex_EmptyByteArray()
    {
        var byteArray = Array.Empty<byte>();

        var actual = byteArray.ToHex();

        Assert.Equal(string.Empty, actual);
    }

    [Fact]
    public void ToHex_WithoutSeparator()
    {
        byte[] byteArray = { 0x12, 0x34, 0x56 };

        var actual = byteArray.ToHex();

        Assert.Equal("123456", actual);
    }

    [Fact]
    public void ToHex_WithSeparator1()
    {
        byte[] byteArray = { 0x12, 0x34, 0x56 };

        var actual = byteArray.ToHex("-");

        Assert.Equal("12-34-56", actual);
    }

    [Fact]
    public void ToHex_WithSeparator2()
    {
        byte[] byteArray = { 0x12, 0x34, 0x56 };

        var actual = byteArray.ToHex(":");

        Assert.Equal("12:34:56", actual);
    }

    [Fact]
    public void ToHex_WithSeparatorAndHexSign1()
    {
        byte[] byteArray = { 0x12, 0x34, 0x56 };

        var actual = byteArray.ToHex(", ", showHexSign: true);

        Assert.Equal("0x12, 0x34, 0x56", actual);
    }

    [Fact]
    public void ToHex_WithSeparatorAndHexSign2()
    {
        byte[] byteArray = { 0x12, 0x34, 0x56 };

        var actual = byteArray.ToHex(" - ", showHexSign: true);

        Assert.Equal("0x12 - 0x34 - 0x56", actual);
    }
}