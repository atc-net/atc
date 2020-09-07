// ReSharper disable once CheckNamespace
namespace System.Security.Claims
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetIdentity(this ClaimsPrincipal principal)
        {
            var identity = principal?.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier");
            return identity?.Value;
        }
    }
}