// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System.ComponentModel.DataAnnotations;

[ExcludeFromCodeCoverage]
[SuppressMessage("Design", "CA1019:Define accessors for attribute arguments", Justification = "OK.")]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public sealed class UriAttribute : ValidationAttribute
{
    public UriAttribute()
        : base("The {0} field requires a Uri value.")
    {
        Required = false;
        AllowHttp = true;
        AllowHttps = true;
        AllowFtp = true;
        AllowFtps = true;
        AllowFile = true;
        AllowOpcTcp = true;
    }

    public UriAttribute(
        bool required,
        bool allowHttp,
        bool allowHttps,
        bool allowFtp,
        bool allowFtps,
        bool allowFile,
        bool allowOpcTcp)
        : this()
    {
        Required = required;
        AllowHttp = allowHttp;
        AllowHttps = allowHttps;
        AllowFtp = allowFtp;
        AllowFtps = allowFtps;
        AllowFile = allowFile;
        AllowOpcTcp = allowOpcTcp;
    }

    public bool Required { get; set; }

    public bool AllowHttp { get; set; }

    public bool AllowHttps { get; set; }

    public bool AllowFtp { get; set; }

    public bool AllowFtps { get; set; }

    public bool AllowFile { get; set; }

    public bool AllowOpcTcp { get; set; }

    /// <inheritdoc />
    public override bool IsValid(
        object? value)
    {
        if (Required &&
            value is null)
        {
            ErrorMessage = "The {0} field is required.";
            return false;
        }

        if (value is null)
        {
            return true;
        }

        var result = Uri.TryCreate(value.ToString(), UriKind.Absolute, out var uriResult)
                     && ((AllowHttp && string.Equals(uriResult.Scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase)) ||
                         (AllowHttps && string.Equals(uriResult.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase)) ||
                         (AllowFtp && string.Equals(uriResult.Scheme, Uri.UriSchemeFtp, StringComparison.OrdinalIgnoreCase)) ||
                         (AllowFtps && string.Equals(uriResult.Scheme, "ftps", StringComparison.OrdinalIgnoreCase)) ||
                         (AllowFile && string.Equals(uriResult.Scheme, Uri.UriSchemeFile, StringComparison.OrdinalIgnoreCase)) ||
                         (AllowOpcTcp && string.Equals(uriResult.Scheme, "opc.tcp", StringComparison.OrdinalIgnoreCase)));
        if (result)
        {
            return true;
        }

        ErrorMessage = "The {0} field is not a valid Uri.";
        return false;
    }

    public static bool TryIsValid(
        string value,
        out string errorMessage)
    {
        var attribute = new UriAttribute();
        return TryIsValid(value, attribute, out errorMessage);
    }

    public static bool TryIsValid(
        string value,
        UriAttribute attribute,
        out string errorMessage)
    {
        if (attribute is null)
        {
            throw new ArgumentNullException(nameof(attribute));
        }

        if (attribute.IsValid(value))
        {
            errorMessage = string.Empty;
            return true;
        }

        errorMessage = attribute.ErrorMessage
            .Replace("field {0}", "value", StringComparison.Ordinal)
            .Replace("{0} field", "value", StringComparison.Ordinal);

        return false;
    }
}