namespace Atc.Tests.Helpers;

[SuppressMessage("Design", "CA1054:URI-like parameters should not be strings", Justification = "OK.")]
[Trait(Traits.Category, Traits.Categories.Integration)]
[Trait(Traits.Category, Traits.Categories.SkipWhenLiveUnitTesting)]
public class NetworkInformationHelperTests
{
    [Fact]
    public void HasConnection()
        => Assert.True(NetworkInformationHelper.HasConnection());

    [Theory]
    [InlineData("8.8.8.8")]
    [InlineData("1.1.1.1")]
    public void HasConnection_WithIpAddress(string ipAddressString)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = NetworkInformationHelper.HasConnection(ipAddress);

        // Assert
        Assert.True(result);
    }

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

    [Theory]
    [InlineData("8.8.8.8", 53)]
    [InlineData("1.1.1.1", 53)]
    public void HasTcpConnection_WithIpAddressAndPort(
        string ipAddressString,
        int port)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = NetworkInformationHelper.HasTcpConnection(ipAddress, port);

        // Assert - DNS servers typically accept TCP connections on port 53
        Assert.True(result);
    }

    [Fact]
    public async Task HasConnectionAsync()
        => Assert.True(await NetworkInformationHelper.HasConnectionAsync());

    [Theory]
    [InlineData("8.8.8.8")]
    [InlineData("1.1.1.1")]
    public async Task HasConnectionAsync_WithIpAddress(string ipAddressString)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = await NetworkInformationHelper.HasConnectionAsync(ipAddress);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task HasHttpConnectionAsync()
        => Assert.True(await NetworkInformationHelper.HasHttpConnectionAsync());

    [Theory]
    [InlineData("https://www.google.com/")]
    public async Task HasHttpConnectionAsync_Uri(string url)
        => Assert.True(await NetworkInformationHelper.HasHttpConnectionAsync(new Uri(url)));

    [Fact]
    public async Task GetPublicIpAddressAsync()
        => Assert.NotNull(await NetworkInformationHelper.GetPublicIpAddressAsync());

    [Theory]
    [InlineData("8.8.8.8", 53)]
    [InlineData("1.1.1.1", 53)]
    public async Task HasTcpConnectionAsync_WithIpAddressAndPort(
        string ipAddressString,
        int port)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = await NetworkInformationHelper.HasTcpConnectionAsync(ipAddress, port);

        // Assert
        Assert.True(result);
    }
}