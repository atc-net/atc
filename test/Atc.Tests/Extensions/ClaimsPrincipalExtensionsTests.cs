namespace Atc.Tests.Extensions;

public class ClaimsPrincipalExtensionsTests
{
    [Theory]
    [InlineData("Hello World", "Hello World")]
    [InlineData("Hello.World", "Hello.World")]
    public void GetIdentity(string expected, string claimIdentifierValue)
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
}