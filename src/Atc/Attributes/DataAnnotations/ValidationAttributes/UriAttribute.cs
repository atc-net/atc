// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System.ComponentModel.DataAnnotations;

[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public sealed class UriAttribute : ValidationAttribute
{
    public UriAttribute()
        : base("The {0} field requires a Uri value.")
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
        if (value is null)
        {
            this.ErrorMessage = "Value is not a Uri.";
            return false;
        }

        var result = Uri.TryCreate(value.ToString(), UriKind.Absolute, out Uri uriResult)
                     && ((AllowHttp && string.Equals(uriResult.Scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase)) ||
                         (AllowHttps && string.Equals(uriResult.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase)) ||
                         (AllowFtp && string.Equals(uriResult.Scheme, Uri.UriSchemeFtp, StringComparison.OrdinalIgnoreCase)) ||
                         (AllowHttp && string.Equals(uriResult.Scheme, Uri.UriSchemeFile, StringComparison.OrdinalIgnoreCase)));
        if (result)
        {
            return true;
        }

        this.ErrorMessage = "Value is not a Uri.";
        return false;
    }
}