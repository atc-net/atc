namespace Atc.Tests.Extensions;

public class ClaimsPrincipalExtensionsTests
{
    [Theory]
    [InlineData("Hello World", "Hello World")]
    [InlineData("Hello.World", "Hello.World")]
    public void GetIdentity(
        string expected,
        string claimIdentifierValue)
    {
        // Arrange
        var objectIdentifierClaim = new Claim("http://schemas.microsoft.com/identity/claims/objectidentifier", claimIdentifierValue);
        var claims = new List<Claim> { objectIdentifierClaim };

        var identity = new ClaimsIdentity(claims);
        var claimsPrincipal = new ClaimsPrincipal(identity);

        // Act
        var actual = claimsPrincipal.GetIdentity();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("Jane Doe", "name", "Jane Doe")]
    [InlineData(null, "name", "")]
    [InlineData(null, "other", "Jane Doe")]
    public void GetDisplayName(
        string? expected,
        string claimType,
        string claimValue)
        => Assert.Equal(expected, Principal((claimType, claimValue)).GetDisplayName());

    [Fact]
    public void GetUsername_PrefersClaimTypesName()
        => Assert.Equal(
            "jane@contoso.com",
            Principal((ClaimTypes.Name, "jane@contoso.com"), ("preferred_username", "other@contoso.com")).GetUsername());

    [Fact]
    public void GetUsername_FallsBackToPreferredUsername()
        => Assert.Equal("jane@contoso.com", Principal(("preferred_username", "jane@contoso.com")).GetUsername());

    [Fact]
    public void GetUsername_ReturnsNull_WhenMissing()
        => Assert.Null(Principal(("name", "Jane Doe")).GetUsername());

    [Fact]
    public void GetEmail_PrefersClaimTypesEmail()
        => Assert.Equal(
            "a@contoso.com",
            Principal((ClaimTypes.Email, "a@contoso.com"), ("email", "b@contoso.com")).GetEmail());

    [Fact]
    public void GetEmail_FallsBackToTheEmailClaim()
        => Assert.Equal("b@contoso.com", Principal(("email", "b@contoso.com")).GetEmail());

    [Fact]
    public void GetEmail_FallsBackToAUsernameThatIsAnEmailAddress()
        => Assert.Equal("jane@contoso.com", Principal((ClaimTypes.Name, "jane@contoso.com")).GetEmail());

    [Fact]
    public void GetEmail_ReturnsNull_WhenTheUsernameIsNotAnEmailAddress()
        => Assert.Null(Principal((ClaimTypes.Name, "jane")).GetEmail());

    [Theory]
    [InlineData("11111111-1111-1111-1111-111111111111", "azp")]
    [InlineData("11111111-1111-1111-1111-111111111111", "appid")]
    [InlineData(null, "aud")]
    public void GetAppId(
        string? expected,
        string claimType)
        => Assert.Equal(expected, Principal((claimType, "11111111-1111-1111-1111-111111111111")).GetAppId());

    [Fact]
    public void GetAppId_PrefersAzp()
        => Assert.Equal("v2", Principal(("appid", "v1"), ("azp", "v2")).GetAppId());

    private static ClaimsPrincipal Principal(
        params (string Type, string Value)[] claims)
        => new(new ClaimsIdentity(claims.Select(c => new Claim(c.Type, c.Value))));
}