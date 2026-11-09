namespace Atc.Tests.Helpers;

public class UniqueNameHelperTests
{
    [Fact]
    public void Claim_NumbersRepeats()
    {
        var taken = new HashSet<string>(StringComparer.Ordinal);

        Assert.Equal("id", UniqueNameHelper.Claim(taken, "id"));
        Assert.Equal("id2", UniqueNameHelper.Claim(taken, "id"));
        Assert.Equal("id3", UniqueNameHelper.Claim(taken, "id"));
        Assert.Equal("name", UniqueNameHelper.Claim(taken, "name"));
        Assert.Equal(new[] { "id", "id2", "id3", "name" }, taken.OrderBy(x => x, StringComparer.Ordinal), StringComparer.Ordinal);
    }

    [Fact]
    public void Claim_SkipsANumberedNameAlreadyTaken()
    {
        var taken = new HashSet<string>(StringComparer.Ordinal) { "id", "id2" };

        Assert.Equal("id3", UniqueNameHelper.Claim(taken, "id"));
    }

    [Fact]
    public void Claim_UsesTheComparerOfTheSet()
    {
        var taken = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "Id" };

        Assert.Equal("id2", UniqueNameHelper.Claim(taken, "id"));
    }

    [Fact]
    public void Claim_NullSet_Throws()
        => Assert.Throws<ArgumentNullException>(() => UniqueNameHelper.Claim(null!, "id"));
}