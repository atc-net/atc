using System;
using System.Collections.Generic;
using Atc.Rest.Options;

namespace Atc.Rest.Extended.Options
{
    public class RestApiExtendedOptions : RestApiOptions
    {
        public bool UseApiVersioning { get; set; } = true;

        public bool UseFluentValidation { get; set; } = true;

        public bool UseOpenApiSpec { get; set; } = true;

        public string AuthorizationTenant { get; set; } = string.Empty;

        public string AuthorizationClientId { get; set; } = string.Empty;

        public IReadOnlyCollection<string> AuthorizationValidAudiences { get; set; } = Array.Empty<string>();
    }
}