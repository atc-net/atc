// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
namespace Atc.Rest.Options;

/// <summary>
/// Copy and fill out the AzureAd section into the project User Secrets.
/// </summary>
/// <code>
/// {
///   "Authorization": {
///     /*
///       This will be used to set the Authority on the JWT bearer options
///       - 'https://login.microsoftonline.com' (For Azure AD)
///       - 'https://adfs1.some.organization.com' (For on-prem ADFS)
///     */
///     "Instance": "https://login.microsoftonline.com",
///     "ClientId": "[Application ID of the Azure AD App Registration]",
///     /*
///       You need specify the TenantId only if you want to accept access tokens from a single tenant
///      (line-of-business app).
///       Otherwise, you can leave them set to common.
///       This can be:
///       - A GUID (Tenant ID = Directory ID)
///       - 'common' (any organization and personal accounts)
///       - 'organizations' (any organization)
///       - 'consumers' (Microsoft personal accounts)
///       - 'adfs' (For on-prem ADFS)
///     */
///     "TenantId": "common",
///     "Audience": "[App Identifier URI of the Azure AD App Registration]"
///     "Issuer": "[The token iss claim also specified as the access_token_issuer from the OpenID configuration]"
///     "ValidAudiences": ["A", "collection", "of", "app", "identifier", "URIs"]
///   }
/// }.
/// </code>
[SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "OK.")]
public class AuthorizationOptions
{
    public const string ConfigurationSectionName = "Authorization";

    /// <summary>
    /// Gets or sets the Azure AD Application (client) ID.
    /// </summary>
    public string ClientId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Azure AD Tenant ID or special values (common, organizations, consumers, adfs).
    /// </summary>
    public string TenantId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the authentication authority instance URL (e.g., https://login.microsoftonline.com for Azure AD).
    /// </summary>
    public string Instance { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the expected audience for token validation (typically the App ID URI).
    /// </summary>
    public string Audience { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the expected token issuer for validation.
    /// </summary>
    public string Issuer { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a collection of valid audiences for token validation.
    /// </summary>
    public List<string> ValidAudiences { get; set; } = new();

    /// <summary>
    /// Gets or sets a collection of valid issuers for token validation.
    /// </summary>
    public List<string> ValidIssuers { get; set; } = new();

    /// <summary>
    /// Gets or sets the JWT claim type used to populate ASP.NET Core roles for
    /// <c>[Authorize(Roles=…)]</c>. For Azure AD access tokens the claim is <c>"roles"</c>;
    /// for client-credentials tokens the scope claim is <c>"scp"</c>.
    /// When <see langword="null"/> or empty, the framework default
    /// (<c>ClaimTypes.Role</c> = the long URI form) is used, which does not match
    /// the short-form claims issued by Azure AD.
    /// </summary>
    public string? RoleClaimType { get; set; }

    /// <summary>
    /// Gets or sets the JWT claim type used to populate the user's identity name (<see cref="System.Security.Claims.ClaimsIdentity.Name"/>).
    /// For Azure AD access tokens the claim is typically <c>"name"</c> or <c>"preferred_username"</c>.
    /// When <see langword="null"/> or empty, the framework default
    /// (<c>ClaimTypes.Name</c> = the long URI form) is used.
    /// </summary>
    public string? NameClaimType { get; set; }

    /// <summary>
    /// Determines whether any security settings are configured.
    /// </summary>
    /// <returns>True if at least one security setting is configured; otherwise, false.</returns>
    public bool IsSecurityEnabled()
        => !string.IsNullOrEmpty(ClientId) ||
           !string.IsNullOrEmpty(TenantId) ||
           !string.IsNullOrEmpty(Instance) ||
           !string.IsNullOrEmpty(Audience) ||
           !string.IsNullOrEmpty(Issuer) ||
           (ValidAudiences is not null && ValidAudiences.Any()) ||
           (ValidIssuers is not null && ValidIssuers.Any());
}