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

    [Theory]
    [InlineData("10A", "9B")]
    [InlineData("2B", "1A")]
    public void NumericAlphaComparer_Compare_IsConsistentAcrossCultures(
        string greater,
        string lesser)
    {
        // The old ExtractLetters used Thread.CurrentThread.CurrentCulture which is locale-dependent.
        // With a culture that formats "10" differently (e.g., some locales use different digit grouping),
        // the Replace call could fail to strip the number, causing wrong ordering. After the fix,
        // EnglishCultureInfo is always used regardless of the ambient thread culture.
        var originalCulture = Thread.CurrentThread.CurrentCulture;
        try
        {
            Thread.CurrentThread.CurrentCulture = GlobalizationConstants.EnglishCultureInfo;
            var comparer = new NumericAlphaComparer();
            Assert.Equal(1, comparer.Compare(greater, lesser));
        }
        finally
        {
            Thread.CurrentThread.CurrentCulture = originalCulture;
        }
    }
}