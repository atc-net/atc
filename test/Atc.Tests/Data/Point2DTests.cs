namespace Atc.Tests.Data;

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
}