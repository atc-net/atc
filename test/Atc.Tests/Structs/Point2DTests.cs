namespace Atc.Tests.Structs;

public class Point2DTests
{
    [Theory]
    [InlineData(true, 0, 0)]
    [InlineData(false, 1, 0)]
    [InlineData(false, 0, 1)]
    [InlineData(false, 1, 1)]
    public void IsDefault(
        bool expected,
        int x,
        int y)
    {
        // Arrange
        var input = new Point2D(x, y);

        // Act
        var actual = input.IsDefault;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsDefault_WithTinyNonZeroX_ReturnsFalse()
    {
        // Arrange — value must exceed DoubleEpsilon (1e-9) to be considered non-default
        var input = new Point2D(DoubleExtensions.DoubleEpsilon * 10, 0);

        // Act / Assert
        Assert.False(input.IsDefault);
    }

    [Fact]
    public void IsDefault_WithTinyNonZeroY_ReturnsFalse()
    {
        var input = new Point2D(0, DoubleExtensions.DoubleEpsilon * 10);
        Assert.False(input.IsDefault);
    }

    [Theory]
    [InlineData("0, 0", 0, 0)]
    [InlineData("1, 0", 1, 0)]
    [InlineData("0, 1", 0, 1)]
    [InlineData("1, 1", 1, 1)]
    public void ToStringShort(
        string expected,
        int x,
        int y)
    {
        // Arrange
        var input = new Point2D(x, y);

        // Act
        var actual = input.ToStringShort();

        // Assert
        Assert.Equal(expected, actual);
    }
}