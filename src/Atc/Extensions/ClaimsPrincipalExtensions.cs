// ReSharper disable once CheckNamespace
namespace System.Security.Claims;

/// <summary>
/// Provides extension methods for the <see cref="ClaimsPrincipal"/> class.
/// </summary>
public static class ClaimsPrincipalExtensions
{
    /// <summary>
    /// Retrieves the object identifier claim value from the claims principal, typically used for Azure AD authentication.
    /// </summary>
    /// <param name="principal">The claims principal to extract the identity from.</param>
    /// <returns>The object identifier claim value if found; otherwise, <see langword="null"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="principal"/> is <see langword="null"/>.</exception>
    [SuppressMessage("Minor Code Smell", "S4834:Controlling permissions is security-sensitive", Justification = "OK.")]
    [SuppressMessage("Encryption of Sensitive Data", "S5332:Using clear-text protocols is security-sensitive", Justification = "OK.")]
    public static string? GetIdentity(this ClaimsPrincipal principal)
    {
        if (principal is null)
        {
            throw new ArgumentNullException(nameof(principal));
        }

        var identity = principal.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier");
        return identity?.Value;
    }
}