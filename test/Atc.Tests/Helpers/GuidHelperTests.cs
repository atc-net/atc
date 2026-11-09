namespace Atc.Tests.Helpers;

public class GuidHelperTests
{
    // Expected values are SHA-256 based and independently computed; they must never change,
    // because callers store these ids.
    [Theory]
    [InlineData("128197ca-1bca-cabd-fac2-31b39a23dc4d", new[] { "a" })]
    [InlineData("9174bb27-8d27-375a-3046-9518b6264ddc", new[] { "device", "123" })]
    [InlineData("0caf0930-cfca-84de-7f88-bf21ed0757da", new[] { "Grønlandsvej", "8" })]
    public void CreateDeterministic_IsStable(
        string expected,
        string[] components)
        => Assert.Equal(Guid.Parse(expected), GuidHelper.CreateDeterministic(components));

    [Fact]
    public void CreateDeterministic_SameComponents_GiveTheSameGuid()
        => Assert.Equal(
            GuidHelper.CreateDeterministic("system", "42"),
            GuidHelper.CreateDeterministic("system", "42"));

    [Fact]
    public void CreateDeterministic_OrderMatters()
        => Assert.NotEqual(
            GuidHelper.CreateDeterministic("a", "b"),
            GuidHelper.CreateDeterministic("b", "a"));

    [Fact]
    public void CreateDeterministic_Throws_WhenNoComponents()
        => Assert.Throws<ArgumentException>(() => GuidHelper.CreateDeterministic());

    [Fact]
    public void CreateDeterministic_Throws_WhenAComponentIsNull()
        => Assert.Throws<ArgumentException>(() => GuidHelper.CreateDeterministic("a", null!));
}