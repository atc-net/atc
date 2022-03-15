namespace Atc.Tests.Helpers;

[SuppressMessage("Design", "CA1054:URI-like parameters should not be strings", Justification = "OK.")]
[Trait(Traits.Category, Traits.Categories.Integration)]
[Trait(Traits.Category, Traits.Categories.SkipWhenLiveUnitTesting)]
public class NetworkInformationHelperTests
{
    [Fact]
    public void HasConnection()
        => Assert.True(NetworkInformationHelper.HasConnection());

    [Fact]
    public void HasHttpConnection()
        => Assert.True(NetworkInformationHelper.HasHttpConnection());

    [Theory]
    [InlineData("https://www.google.com/")]
    public void HasHttpConnection_Uri(string url)
        => Assert.True(NetworkInformationHelper.HasHttpConnection(new Uri(url)));

    [Fact]
    public void GetPublicIpAddress()
        => Assert.NotNull(NetworkInformationHelper.GetPublicIpAddress());
}