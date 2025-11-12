// ReSharper disable InconsistentNaming
// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System.ComponentModel.DataAnnotations;

/// <summary>
/// Validates that a property, field, or parameter contains a valid IP address.
/// Supports both IPv4 and IPv6 address formats.
/// </summary>
[ExcludeFromCodeCoverage]
[SuppressMessage("Design", "CA1019:Define accessors for attribute arguments", Justification = "OK.")]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public sealed class IPAddressAttribute : ValidationAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IPAddressAttribute"/> class with optional validation.
    /// </summary>
    public IPAddressAttribute()
        : base("The {0} field requires a IPAddress value.")
    {
        Required = false;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IPAddressAttribute"/> class.
    /// </summary>
    /// <param name="required">Indicates whether the IP address value is required.</param>
    public IPAddressAttribute(bool required)
        : this()
    {
        Required = required;
    }

    /// <summary>
    /// Gets or sets a value indicating whether the IP address value is required.
    /// </summary>
    public bool Required { get; set; }

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

        var result = IPAddress.TryParse(value.ToString(), out _);
        if (result)
        {
            return true;
        }

        ErrorMessage = "The {0} field is not a valid IPAddress.";
        return false;
    }

    /// <summary>
    /// Attempts to validate the specified string as an IP address using default validation settings.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="errorMessage">When validation fails, contains a message describing the validation error.</param>
    /// <returns><c>true</c> if the value is a valid IP address; otherwise, <c>false</c>.</returns>
    public static bool TryIsValid(
        string value,
        out string errorMessage)
    {
        var attribute = new IPAddressAttribute();
        return TryIsValid(value, attribute, out errorMessage);
    }

    /// <summary>
    /// Attempts to validate the specified string as an IP address using the provided attribute configuration.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="attribute">The attribute instance containing validation settings.</param>
    /// <param name="errorMessage">When validation fails, contains a message describing the validation error.</param>
    /// <returns><c>true</c> if the value is valid according to the attribute settings; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="attribute"/> is null.</exception>
    public static bool TryIsValid(
        string value,
        IPAddressAttribute attribute,
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
            errorMessage = "The value is not a valid IPAddress.";
        }
        else
        {
            errorMessage = attribute.ErrorMessage
                .Replace("field {0}", "value", StringComparison.Ordinal)
                .Replace("{0} field", "value", StringComparison.Ordinal);
        }

        return false;
    }
}