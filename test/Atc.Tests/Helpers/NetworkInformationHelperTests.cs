namespace Atc.Tests.Helpers;

public class NetworkInformationHelperTests
{
    [Fact]
    public void HasConnection()
        => Assert.True(NetworkInformationHelper.HasConnection());

    [Fact]
    public void GetPublicIpAddress()
        => Assert.NotNull(NetworkInformationHelper.GetPublicIpAddress());
}