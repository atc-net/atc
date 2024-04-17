namespace Atc.Tests.Helpers;

public class ByteHelperTests
{
    [Theory]
    [InlineData(256, new byte[] { 0x00, 0x01 })]
    [InlineData(65535, new byte[] { 0xFF, 0xFF })]
    [InlineData(-1, new byte[] { 0xFF, 0xFF })]
    public void ConvertToTwoBytes(int input, byte[] expected)
    {
        // Arrange & Act
        var actual = ByteHelper.ConvertToTwoBytes(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, new byte[] { 0x01, 0x00, 0x00, 0x00 })]
    [InlineData(-1, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF })]
    [InlineData(16777216, new byte[] { 0x00, 0x00, 0x00, 0x01 })]
    public void ConvertToFourBytes(int input, byte[] expected)
    {
        // Arrange & Act
        var actual = ByteHelper.ConvertToFourBytes(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(255)]
    public void CreateZeroArray(int size)
    {
        // Arrange & Act
        var actual = ByteHelper.CreateZeroArray(size);

        // Assert
        Assert.All(actual, b => Assert.Equal(0, b));
        Assert.Equal(size, actual.Length);
    }

    [Theory]
    [InlineData(0b00001010, 0b00000010, true)]
    [InlineData(0b00001010, 0b00000100, false)]
    [InlineData(0b00001010, 0b00001000, true)]
    public void HasBitByte(byte value, byte checkValue, bool expected)
    {
        // Arrange & Act
        var actual = ByteHelper.HasBit(value, checkValue);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0b00001010, 0b00000010, true)]
    [InlineData(0b00001010, 0b00000100, false)]
    [InlineData(0b00001010, 0b00001000, true)]
    public void HasBitInt(byte value, int checkValue, bool expected)
    {
        // Arrange & Act
        var actual = ByteHelper.HasBit(value, checkValue);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new byte[] { 0x1A, 0x2B, 0x3C }, "0x1A, 0x2B, 0x3C")]
    public void ToStringWithPrefix(byte[] bytes, string expected)
    {
        // Arrange & Act
        var actual = ByteHelper.ToStringWithPrefix(bytes);

        // Assert
        Assert.Equal(expected, actual);
    }
}