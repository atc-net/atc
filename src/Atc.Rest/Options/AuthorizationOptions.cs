using System;
using System.Collections.Generic;

namespace Atc.Rest.Options
{
    public class AuthorizationOptions
    {
        public const string ConfigurationSectionName = "AzureAd";

        public bool UseAzureADBearer { get; set; }

        public string ClientId { get; set; } = string.Empty;

        public string TenantId { get; set; } = string.Empty;

        public string Instance { get; set; } = string.Empty;

        public string Domain { get; set; } = string.Empty;

        public string Audience { get; set; } = string.Empty;

        public IReadOnlyCollection<string> ValidAudiences { get; set; } = Array.Empty<string>();
    }
}