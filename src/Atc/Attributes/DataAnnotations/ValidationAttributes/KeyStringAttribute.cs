// ReSharper disable once CheckNamespace
namespace System.ComponentModel.DataAnnotations;

public sealed class KeyStringAttribute : StringAttribute
{
    public KeyStringAttribute()
    {
        this.InvalidCharacters = new[] { ' ', '.', '@', '\'' };
        this.InvalidPrefixStrings = new[] { "_" };
        this.RegularExpression = string.Empty;
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
}