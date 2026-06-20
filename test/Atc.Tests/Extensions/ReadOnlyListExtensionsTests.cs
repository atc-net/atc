namespace Atc.Tests.Extensions;

public class ReadOnlyListExtensionsTests
{
    [Theory]
    [InlineData(15, new[] { "a", "b", "c", "d" })]
    public void GetUniqueCombinations(
        int expected,
        string[] input)
    {
        // Act
        var actual = input.GetUniqueCombinations();

        // Assert
        actual
            .Should().NotBeNull()
            .And.HaveCount(expected);
    }

    [Fact]
    public void GetUniqueCombinations_WithCommaContainingElement_PreservesElementIntegrity()
    {
        // Arrange: "a,b" contains a comma — the old split(',') approach would shred it into "a" and "b".
        IReadOnlyList<string> list = new List<string> { "a,b", "c" };

        // Act
        var result = list.GetUniqueCombinations().ToList();

        // Assert: 3 non-empty subsets: {"a,b"}, {"c"}, {"a,b","c"}
        Assert.Equal(3, result.Count);
        Assert.Contains(result, r => r.SequenceEqual(new[] { "a,b" }, StringComparer.Ordinal));
        Assert.Contains(result, r => r.SequenceEqual(new[] { "c" }, StringComparer.Ordinal));
        Assert.Contains(result, r => r.SequenceEqual(new[] { "a,b", "c" }, StringComparer.Ordinal));
    }

    [Theory]
    [InlineData(15, new[] { "a", "b", "c", "d" })]
    public void GetUniqueCombinationsAsCommaSeparated(
        int expected,
        string[] input)
    {
        // Act
        var actual = input.GetUniqueCombinationsAsCommaSeparated();

        // Assert
        actual
            .Should().NotBeNull()
            .And.HaveCount(expected);
    }

    [Theory]
    [InlineData(16, new[] { "a", "b", "c", "d" })]
    public void GetPowerSet(
        int expected,
        string[] input)
    {
        // Act
        var actual = input.GetPowerSet();

        // Assert
        actual
            .Should().NotBeNull()
            .And.HaveCount(expected);
    }

    [Fact]
    public void GetPowerSet_WhenListCountIs32_ThrowsArgumentOutOfRangeException()
    {
        // `1 << 32` wraps to 1 in int arithmetic (shift mod 32), so the power set of
        // 32 elements silently returns 1 subset instead of 2^32. Any count >= 31 is unsupported.
        IReadOnlyList<string> list = Enumerable.Range(0, 32).Select(i => i.ToString(GlobalizationConstants.EnglishCultureInfo)).ToList();

        Assert.Throws<ArgumentOutOfRangeException>(() => list.GetPowerSet().ToList());
    }
}