using System.Diagnostics.CodeAnalysis;

// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System.ComponentModel.DataAnnotations
{
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public sealed class UriAttribute : ValidationAttribute
    {
        public UriAttribute() : base("The {0} field requires a Uri value.")
        {
            this.AllowHttp = true;
            this.AllowHttps = true;
            this.AllowFtp = true;
            this.AllowFile = true;
        }

        public bool AllowHttp { get; set; }

        public bool AllowHttps { get; set; }

        public bool AllowFtp { get; set; }

        public bool AllowFile { get; set; }

        /// <inheritdoc />
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                this.ErrorMessage = "Value is not a Uri.";
                return false;
            }

            bool result = Uri.TryCreate(value.ToString(), UriKind.Absolute, out Uri uriResult)
                && ((AllowHttp && uriResult.Scheme == Uri.UriSchemeHttp) ||
                    (AllowHttps && uriResult.Scheme == Uri.UriSchemeHttps) ||
                    (AllowFtp && uriResult.Scheme == Uri.UriSchemeFtp) ||
                    (AllowHttp && uriResult.Scheme == Uri.UriSchemeFile));
            if (result)
            {
                return true;
            }

            this.ErrorMessage = "Value is not a Uri.";
            return false;
        }
    }
}