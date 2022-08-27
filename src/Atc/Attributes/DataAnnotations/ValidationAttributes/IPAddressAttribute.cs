// ReSharper disable InconsistentNaming
// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System.ComponentModel.DataAnnotations;

[ExcludeFromCodeCoverage]
[SuppressMessage("Design", "CA1019:Define accessors for attribute arguments", Justification = "OK.")]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public sealed class IPAddressAttribute : ValidationAttribute
{
    public IPAddressAttribute()
        : base("The {0} field requires a IPAddress value.")
    {
        this.Required = false;
    }

    public IPAddressAttribute(
        bool required)
        : this()
    {
        this.Required = required;
    }

    public bool Required { get; set; }

    /// <inheritdoc />
    public override bool IsValid(
        object? value)
    {
        if (this.Required &&
            value is null)
        {
            this.ErrorMessage = "The {0} field is required.";
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

        this.ErrorMessage = "The {0} field is not a valid IPAddress.";
        return false;
    }

    public static bool TryIsValid(
        string value,
        out string errorMessage)
    {
        var attribute = new IPAddressAttribute();
        return TryIsValid(value, attribute, out errorMessage);
    }

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

        errorMessage = attribute.ErrorMessage
            .Replace("field {0}", "value", StringComparison.Ordinal)
            .Replace("{0} field", "value", StringComparison.Ordinal);

        return false;
    }
}