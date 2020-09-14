using Atc.Rest.Options;

namespace Atc.Rest.Extended.Options
{
    public class RestApiExtendedOptions : RestApiOptions
    {
        public bool UseApiVersioning { get; set; } = true;

        public bool UseFluentValidation { get; set; } = true;

        public bool UseOpenApiSpec { get; set; } = true;
    }
}