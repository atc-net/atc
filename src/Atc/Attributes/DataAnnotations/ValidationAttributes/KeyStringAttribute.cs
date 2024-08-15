// ReSharper disable once CheckNamespace
namespace System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class KeyStringAttribute : StringAttribute
{
    public KeyStringAttribute()
    {
        Required = true;
        InvalidCharacters = new[] { ' ', '.', '@', '\'' };
        InvalidPrefixStrings = new[] { "_" };
        RegularExpression = string.Empty;
    }

    public KeyStringAttribute(
        bool required,
        uint minLength,
        uint maxLength)
        : base(
            required,
            minLength,
            maxLength)
    {
    }

    public KeyStringAttribute(
        bool required,
        uint minLength,
        uint maxLength,
        char[] invalidCharacters,
        string[] invalidPrefixStrings)
        : base(
            required,
            minLength,
            maxLength,
            invalidCharacters,
            invalidPrefixStrings)
    {
    }

    public KeyStringAttribute(
        bool required,
        uint minLength,
        uint maxLength,
        string regularExpression)
        : base(
            required,
            minLength,
            maxLength,
            regularExpression)
    {
    }

    public static new bool TryIsValid(
        string value,
        out string errorMessage)
    {
        var attribute = new KeyStringAttribute();
        return TryIsValid(value, attribute, out errorMessage);
    }

    public static bool TryIsValid(
        string value,
        KeyStringAttribute attribute,
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
            errorMessage = "The value is not a valid KeyString.";
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