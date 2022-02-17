namespace Atc.Tests.Helpers;

[Trait(Traits.Category, Traits.Categories.Integration)]
[Trait(Traits.Category, Traits.Categories.SkipWhenLiveUnitTesting)]
public class NetworkInformationHelperTests
{
    [Fact]
    public void HasConnection()
        => Assert.True(NetworkInformationHelper.HasConnection());

    [Fact]
    public void GetPublicIpAddress()
        => Assert.NotNull(NetworkInformationHelper.GetPublicIpAddress());
}