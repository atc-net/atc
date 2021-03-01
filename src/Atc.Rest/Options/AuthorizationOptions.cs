using System.Collections.Generic;
using System.Linq;

namespace Atc.Rest.Options
{
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
    public class AuthorizationOptions
    {
        public const string ConfigurationSectionName = "Authorization";

        public string ClientId { get; set; } = string.Empty;

        public string TenantId { get; set; } = string.Empty;

        public string Instance { get; set; } = string.Empty;

        public string Audience { get; set; } = string.Empty;

        public string Issuer { get; set; } = string.Empty;

        public List<string> ValidAudiences { get; set; } = new List<string>();

        public List<string> ValidIssuers { get; set; } = new List<string>();

        public bool IsSecurityEnabled()
            => !string.IsNullOrEmpty(ClientId) ||
               !string.IsNullOrEmpty(TenantId) ||
               !string.IsNullOrEmpty(Instance) ||
               !string.IsNullOrEmpty(Audience) ||
               !string.IsNullOrEmpty(Issuer) ||
               ValidAudiences.Any() ||
               ValidIssuers.Any();
    }
}