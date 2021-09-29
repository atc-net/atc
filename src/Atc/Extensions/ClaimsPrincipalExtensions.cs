using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace System.Security.Claims
{
    public static class ClaimsPrincipalExtensions
    {
        [SuppressMessage("Minor Code Smell", "S4834:Controlling permissions is security-sensitive", Justification = "OK.")]
        [SuppressMessage("Encryption of Sensitive Data", "S5332:Using clear-text protocols is security-sensitive", Justification = "OK.")]
        public static string? GetIdentity(this ClaimsPrincipal principal)
        {
            var identity = principal.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier");
            return identity?.Value;
        }
    }
}