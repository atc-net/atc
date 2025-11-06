namespace Atc.Tests.Comparers;

public class NumericAlphaComparerTests
{
    [Theory]
    [InlineData(new[] { "90", "101", "102", "103", "105" }, new[] { "105", "101", "102", "103", "90" })]
    [InlineData(new[] { null, "1A", "1B", "1C", "008", "9", "10" }, new[] { "008", "10", "1B", "1C", "9", null, "1A" })]
    [InlineData(new[] { null, "0", "1A", "1. B", "B1" }, new[] { "1. B", null, "0", "B1", "1A" })]
    public void NumericAlphaComparer(
        string[] expected,
        string[] input)
    {
        // Act
        var actual = input
            .OrderBy(x => x, new NumericAlphaComparer())
            .ToArray();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, "90", "89")]
    [InlineData(0, "90", "90")]
    [InlineData(-1, "90", "91")]
    public void NumericAlphaComparer_Compare(
        int expected,
        string a,
        string b)
    {
        // Arrange
        var comparer = new NumericAlphaComparer();

        // Act
        var actual = comparer.Compare(a, b);

        // Assert
        Assert.Equal(expected, actual);
    }
}