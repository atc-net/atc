using System;
using System.Collections.Generic;

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
    ///   }
    /// }.
    /// </code>
    public class AuthorizationOptions
    {
        public const string ConfigurationSectionName = "Authorization";

        private string clientId = string.Empty;
        public string ClientId
        {
            get => clientId;
            set
            {
                clientId = value;
                ValidAudiences = new[]
                {
                    clientId,
                    $"api://{clientId}"
                };
            }
        }

        public string TenantId { get; set; } = string.Empty;

        public string Instance { get; set; } = string.Empty;

        public string Audience { get; set; } = string.Empty;

        public string Issuer { get; set; } = string.Empty;

        public IReadOnlyCollection<string> ValidAudiences { get; set; } = Array.Empty<string>();
    }
}