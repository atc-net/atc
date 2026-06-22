namespace Atc.Tests.Units.DigitalInformation;

public class ByteSizeTests
{
    [Theory]
    [InlineData("1 B", 1)]
    [InlineData("1 KB", 1024L)]
    [InlineData("2 KB", 2 * 1024L)]
    [InlineData("1 MB", 1024L * 1024L)]
    [InlineData("1 GB", 1024L * 1024L * 1024L)]
    [InlineData("1 TB", 1024L * 1024L * 1024L * 1024L)]
    [InlineData("1 PB", 1024L * 1024L * 1024L * 1024L * 1024L)]
    [InlineData("1 EB", 1024L * 1024L * 1024L * 1024L * 1024L * 1024L)]
    public void Format_Default(
        string expected,
        long size)
    {
        // Arrange
        var byteSize = new ByteSize(size);

        // Atc
        var actual = byteSize.Format();

        // Assert
        Assert.Equal(expected, actual);
        Assert.Equal(expected, byteSize.ToString());
    }

    [Theory]
    [InlineData("1 B", 1)]
    [InlineData("1 KB", 1024L)]
    [InlineData("2 KB", 2 * 1024L)]
    [InlineData("1 MB", 1024L * 1024L)]
    [InlineData("1 GB", 1024L * 1024L * 1024L)]
    [InlineData("1 TB", 1024L * 1024L * 1024L * 1024L)]
    [InlineData("1 PB", 1024L * 1024L * 1024L * 1024L * 1024L)]
    [InlineData("1 EB", 1024L * 1024L * 1024L * 1024L * 1024L * 1024L)]
    public void Format_Default_Formatter(
        string expected,
        long size)
    {
        // Arrange
        var byteSize = new ByteSize(size);
        var formatter = new ByteSizeFormatter();

        // Atc
        var actual = byteSize.Format(formatter);

        // Assert
        Assert.Equal(expected, actual);
        Assert.Equal(expected, byteSize.ToString(formatter));
    }

    [Fact]
    public void GetHashCode_ShouldBeConsistentWithEquality()
    {
        // Arrange
        var a = new ByteSize(2048);
        var b = new ByteSize(2048);

        // Assert
        Assert.Equal(a, b);
        Assert.Equal(a.GetHashCode(), b.GetHashCode());
        Assert.Equal(a.Value.GetHashCode(), a.GetHashCode());
    }

    [Fact]
    public void GetHashCode_AllowsReliableUseAsHashSetKey()
    {
        // Arrange
        var set = new HashSet<ByteSize>
        {
            new(2048),
        };

        // Act & Assert - a value-equal instance must be found (broken when GetHashCode used base.GetHashCode()).
        Assert.Contains(new ByteSize(2048), set);
        Assert.DoesNotContain(new ByteSize(4096), set);
    }

    [Theory]
    [InlineData(-1, 1024, 2048)]
    [InlineData(1, 2048, 1024)]
    [InlineData(0, 512, 512)]
    public void CompareTo_OrdersCorrectly(
        int expectedSign,
        long a,
        long b)
    {
        // Arrange
        var left = new ByteSize(a);
        var right = new ByteSize(b);

        // Atc
        var actual = System.Math.Sign(left.CompareTo(right));

        // Assert
        Assert.Equal(expectedSign, actual);
    }

    [Fact]
    public void CompareTo_WithObject_OrdersCorrectly()
    {
        // Arrange
        var small = new ByteSize(512);
        var large = new ByteSize(2048);
        object boxedSmall = small;
        object boxedLarge = large;

        // Atc & Assert
        Assert.True(small.CompareTo(boxedSmall) == 0);
        Assert.True(small.CompareTo(boxedLarge) < 0);
        Assert.True(large.CompareTo(boxedSmall) > 0);
        Assert.Throws<ArgumentException>(() => small.CompareTo("not a ByteSize"));
    }

    [Fact]
    public void ComparisonOperators_WorkCorrectly()
    {
        var small = new ByteSize(100);
        var large = new ByteSize(200);
        Assert.True(small < large);
        Assert.True(small <= large);
        Assert.True(large > small);
        Assert.True(large >= small);
        Assert.False(small > large);
    }

    [Fact]
    public void ArithmeticOperators_AddAndSubtract()
    {
        var a = new ByteSize(1024);
        var b = new ByteSize(512);
        Assert.Equal(1536L, (a + b).Value);
        Assert.Equal(512L, (a - b).Value);
    }

    [Fact]
    public void TryParse_WithValidInput_ReturnsTrueAndValue()
    {
        // Arrange
        string value = "4096";

        // Atc
        var ok = ByteSize.TryParse(value, out var result);

        // Assert
        Assert.True(ok);
        Assert.Equal(4096L, result.Value);
    }

    [Theory]
    [InlineData(true, "1024", 1024)]
    [InlineData(true, "-512", -512)]
    [InlineData(true, "  0  ", 0)]
    [InlineData(false, "1.5", 0)]
    [InlineData(false, "abc", 0)]
    [InlineData(false, null, 0)]
    public void TryParse(
        bool expectedResult,
        string? input,
        long expectedValue)
    {
        var ok = ByteSize.TryParse(input, out var result);
        Assert.Equal(expectedResult, ok);
        if (ok)
        {
            Assert.Equal(expectedValue, result.Value);
        }
    }

    [Fact]
    public void Parse_ValidString_ReturnsByteSize()
    {
        var result = ByteSize.Parse("4096");
        Assert.Equal(4096L, result.Value);
    }

    [Fact]
    public void Parse_InvalidString_ThrowsFormatException()
        => Assert.Throws<FormatException>(() => ByteSize.Parse("not-a-number"));

    [Fact]
    public void Parse_NullString_ThrowsArgumentNullException()
        => Assert.Throws<ArgumentNullException>(() => ByteSize.Parse(null!));
}