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

    /// <summary>
    /// Retrieves the display name of the user from the <c>name</c> claim, e.g. "Jane Doe" in a Microsoft Entra ID token.
    /// </summary>
    /// <param name="principal">The claims principal to read from.</param>
    /// <returns>The display name if the claim is present and not empty; otherwise, <see langword="null"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="principal"/> is <see langword="null"/>.</exception>
    public static string? GetDisplayName(this ClaimsPrincipal principal)
    {
        if (principal is null)
        {
            throw new ArgumentNullException(nameof(principal));
        }

        return FirstValue(principal, "name");
    }

    /// <summary>
    /// Retrieves the username (sign-in name) of the user from <see cref="ClaimTypes.Name"/>, falling back to the
    /// <c>preferred_username</c> claim that Microsoft Entra ID v2 tokens use when claim types are not mapped.
    /// </summary>
    /// <param name="principal">The claims principal to read from.</param>
    /// <returns>The username if found; otherwise, <see langword="null"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="principal"/> is <see langword="null"/>.</exception>
    public static string? GetUsername(this ClaimsPrincipal principal)
    {
        if (principal is null)
        {
            throw new ArgumentNullException(nameof(principal));
        }

        return FirstValue(principal, ClaimTypes.Name) ??
               FirstValue(principal, "preferred_username");
    }

    /// <summary>
    /// Retrieves the email address of the user from <see cref="ClaimTypes.Email"/>, then the <c>email</c> claim,
    /// and finally the username when that is an email address (as it usually is in Microsoft Entra ID).
    /// </summary>
    /// <param name="principal">The claims principal to read from.</param>
    /// <returns>The email address if found; otherwise, <see langword="null"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="principal"/> is <see langword="null"/>.</exception>
    public static string? GetEmail(this ClaimsPrincipal principal)
    {
        if (principal is null)
        {
            throw new ArgumentNullException(nameof(principal));
        }

        var email = FirstValue(principal, ClaimTypes.Email) ??
                    FirstValue(principal, "email");
        if (email is not null)
        {
            return email;
        }

        var username = principal.GetUsername();
        return username is not null && username.IsEmailAddress()
            ? username
            : null;
    }

    /// <summary>
    /// Retrieves the client (application) id of the app that obtained the token, from the <c>azp</c> claim
    /// (Microsoft Entra ID v2 tokens), falling back to the <c>appid</c> claim (v1 tokens).
    /// </summary>
    /// <param name="principal">The claims principal to read from.</param>
    /// <returns>The application id if found; otherwise, <see langword="null"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="principal"/> is <see langword="null"/>.</exception>
    public static string? GetAppId(this ClaimsPrincipal principal)
    {
        if (principal is null)
        {
            throw new ArgumentNullException(nameof(principal));
        }

        return FirstValue(principal, "azp") ??
               FirstValue(principal, "appid");
    }

    private static string? FirstValue(
        ClaimsPrincipal principal,
        string claimType)
    {
        var value = principal.FindFirst(claimType)?.Value;
        return string.IsNullOrEmpty(value)
            ? null
            : value;
    }
}