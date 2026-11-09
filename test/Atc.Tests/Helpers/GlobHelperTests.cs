namespace Atc.Tests.Helpers;

public class GlobHelperTests
{
    [Theory]
    [InlineData(true, "/pets", "/pets")]
    [InlineData(true, "pets", "/pets")]
    [InlineData(true, "/PETS", "/pets")]
    [InlineData(true, "/pets/42", "/pets/*")]
    [InlineData(false, "/pets", "/pets/*")]
    [InlineData(false, "/pets/42/owner", "/pets/*")]
    [InlineData(true, "/pets/42/owner", "/pets/**")]
    [InlineData(true, "/pets", "/pets/**")]
    [InlineData(true, "/api/v1/users/42", "/api/**/users/*")]
    [InlineData(true, "/api/users/42", "/api/**/users/*")]
    [InlineData(false, "/api/v1/orders/42", "/api/**/users/*")]
    [InlineData(true, "/a/x/b/y/c", "/**/a/**/b/**/c")]
    [InlineData(true, "src/a/b/Program.cs", "src/**/*.cs")]
    [InlineData(true, @"src\a\b\Program.cs", "src/**/*.cs")]
    [InlineData(false, "src/a/b/Program.csproj", "src/**/*.cs")]
    [InlineData(true, "src/Program.cs", "src/Pro?ram.cs")]
    [InlineData(false, "src/Proogram.cs", "src/Pro?ram.cs")]
    [InlineData(true, "src/Program.cs", "src/*gram*")]
    [InlineData(true, "/anything/at/all", "**")]
    public void IsMatch(
        bool expected,
        string path,
        string pattern)
        => Assert.Equal(expected, GlobHelper.IsMatch(path, pattern));

    [Fact]
    public void IsMatch_CaseSensitive_RespectsCase()
    {
        Assert.False(GlobHelper.IsMatch("/PETS", "/pets", ignoreCase: false));
        Assert.True(GlobHelper.IsMatch("/pets", "/pets", ignoreCase: false));
    }

    [Fact]
    public void IsMatch_ManyDoubleStars_IsFast()
    {
        var path = "/" + string.Join("/", Enumerable.Repeat("a", 200)) + "/b";
        var pattern = string.Concat(Enumerable.Repeat("/**/a", 20)) + "/**/c";

        Assert.False(GlobHelper.IsMatch(path, pattern));
    }

    [Fact]
    public void IsMatch_NullPattern_Throws()
        => Assert.Throws<ArgumentNullException>(() => GlobHelper.IsMatch("/pets", null!));

    [Theory]
    [InlineData(true, "/pets/42")]
    [InlineData(true, "/users")]
    [InlineData(false, "/orders")]
    public void IsMatchAny(
        bool expected,
        string path)
    {
        var patterns = new[] { "/pets/*", "/users" };

        Assert.Equal(expected, GlobHelper.IsMatchAny(path, patterns));
    }
}