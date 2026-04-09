// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System.ComponentModel.DataAnnotations;

/// <summary>
/// Validates that a property, field, or parameter contains a valid URI with an allowed scheme.
/// Supports HTTP, HTTPS, FTP, FTPS, File, and OPC TCP schemes.
/// </summary>
[ExcludeFromCodeCoverage]
[SuppressMessage("Design", "CA1019:Define accessors for attribute arguments", Justification = "OK.")]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public sealed class UriAttribute : ValidationAttribute
{
    /// <summary>
    /// A default configuration that allows all URI schemes and does not require a value.
    /// </summary>
    public static readonly UriAttribute Default = new();

    /// <summary>
    /// A preset configuration that only allows HTTP and HTTPS schemes and requires a value.
    /// </summary>
    public static readonly UriAttribute HttpOrHttps = new()
    {
        Required = true,
        AllowHttp = true,
        AllowHttps = true,
        AllowFtp = false,
        AllowFtps = false,
        AllowFile = false,
        AllowOpcTcp = false,
    };

    /// <summary>
    /// A preset configuration that only allows OPC TCP scheme (opc.tcp://) URIs and requires a value.
    /// </summary>
    public static readonly UriAttribute OpcTcp = new()
    {
        Required = true,
        AllowHttp = false,
        AllowHttps = false,
        AllowFtp = false,
        AllowFtps = false,
        AllowFile = false,
        AllowOpcTcp = true,
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="UriAttribute"/> class with all URI schemes allowed.
    /// </summary>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="UriAttribute"/> class with specified allowed URI schemes.
    /// </summary>
    /// <param name="required">Indicates whether the URI value is required.</param>
    /// <param name="allowHttp">Indicates whether HTTP scheme (http://) is allowed.</param>
    /// <param name="allowHttps">Indicates whether HTTPS scheme (https://) is allowed.</param>
    /// <param name="allowFtp">Indicates whether FTP scheme (ftp://) is allowed.</param>
    /// <param name="allowFtps">Indicates whether FTPS scheme (ftps://) is allowed.</param>
    /// <param name="allowFile">Indicates whether File scheme (file://) is allowed.</param>
    /// <param name="allowOpcTcp">Indicates whether OPC TCP scheme (opc.tcp://) is allowed.</param>
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

    /// <summary>
    /// Gets or sets a value indicating whether the URI value is required.
    /// </summary>
    public bool Required { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the HTTP scheme is allowed.
    /// </summary>
    public bool AllowHttp { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the HTTPS scheme is allowed.
    /// </summary>
    public bool AllowHttps { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the FTP scheme is allowed.
    /// </summary>
    public bool AllowFtp { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the FTPS scheme is allowed.
    /// </summary>
    public bool AllowFtps { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the File scheme is allowed.
    /// </summary>
    public bool AllowFile { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the OPC TCP scheme is allowed.
    /// </summary>
    public bool AllowOpcTcp { get; set; }

    /// <inheritdoc />
    public override bool IsValid(object? value)
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

    /// <summary>
    /// Validates whether the specified value is a valid HTTP or HTTPS URI.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <returns><c>true</c> if the value is a valid http:// or https:// URI; otherwise, <c>false</c>.</returns>
    public static bool IsValidHttpOrHttps(object? value)
        => HttpOrHttps.IsValid(value);

    /// <summary>
    /// Validates whether the specified value is a valid OPC TCP URI.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <returns><c>true</c> if the value is a valid opc.tcp:// URI; otherwise, <c>false</c>.</returns>
    public static bool IsValidOpcTcp(object? value)
        => OpcTcp.IsValid(value);

    /// <summary>
    /// Attempts to validate the specified string as a URI using default validation settings (all schemes allowed).
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="errorMessage">When validation fails, contains a message describing the validation error.</param>
    /// <returns><c>true</c> if the value is a valid URI; otherwise, <c>false</c>.</returns>
    public static bool TryIsValid(
        string value,
        out string errorMessage)
    {
        var attribute = new UriAttribute();
        return TryIsValid(value, attribute, out errorMessage);
    }

    /// <summary>
    /// Attempts to validate the specified string as a URI using the provided attribute configuration.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="attribute">The attribute instance containing validation settings including allowed schemes.</param>
    /// <param name="errorMessage">When validation fails, contains a message describing the validation error.</param>
    /// <returns><c>true</c> if the value is valid according to the attribute settings; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="attribute"/> is null.</exception>
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

        if (attribute.ErrorMessage is null)
        {
            errorMessage = "The value is not a valid Uri.";
        }
        else
        {
            errorMessage = attribute.ErrorMessage
                .Replace("field {0}", "value", StringComparison.Ordinal)
                .Replace("{0} field", "value", StringComparison.Ordinal);
        }

        return false;
    }

    /// <summary>
    /// Attempts to validate the specified string as an HTTP or HTTPS URI.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="errorMessage">When validation fails, contains a message describing the validation error.</param>
    /// <returns><c>true</c> if the value is a valid http:// or https:// URI; otherwise, <c>false</c>.</returns>
    public static bool TryIsValidHttpOrHttps(
        string value,
        out string errorMessage)
        => TryIsValid(value, HttpOrHttps, out errorMessage);

    /// <summary>
    /// Attempts to validate the specified string as an OPC TCP URI.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="errorMessage">When validation fails, contains a message describing the validation error.</param>
    /// <returns><c>true</c> if the value is a valid opc.tcp:// URI; otherwise, <c>false</c>.</returns>
    public static bool TryIsValidOpcTcp(
        string value,
        out string errorMessage)
        => TryIsValid(value, OpcTcp, out errorMessage);
}