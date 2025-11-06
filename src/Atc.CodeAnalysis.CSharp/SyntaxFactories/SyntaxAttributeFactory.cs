namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Syntax Attribute Factory.
/// </summary>
/// <remarks>
/// List of ValidationAttribute's:
/// https://referencesource.microsoft.com/#System.ComponentModel.DataAnnotations/DataAnnotations/ValidationAttribute.cs.
/// </remarks>
public static class SyntaxAttributeFactory
{
    /// <summary>
    /// Creates an attribute from a name.
    /// </summary>
    /// <param name="attributeName">The name of the attribute (with or without "Attribute" suffix).</param>
    /// <returns>An <see cref="AttributeSyntax"/> node.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="attributeName"/> is null.</exception>
    public static AttributeSyntax Create(string attributeName)
    {
        if (attributeName is null)
        {
            throw new ArgumentNullException(nameof(attributeName));
        }

        return SyntaxFactory.Attribute(SyntaxFactory.IdentifierName(RemoveSuffix(attributeName)));
    }

    /// <summary>
    /// Creates an attribute with a single string argument.
    /// </summary>
    /// <param name="attributeName">The name of the attribute (with or without "Attribute" suffix).</param>
    /// <param name="argumentValue">The string value for the argument.</param>
    /// <returns>An <see cref="AttributeSyntax"/> node with one argument.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="attributeName"/> or <paramref name="argumentValue"/> is null.</exception>
    public static AttributeSyntax CreateWithOneItemWithOneArgument(string attributeName, string argumentValue)
    {
        if (attributeName is null)
        {
            throw new ArgumentNullException(nameof(attributeName));
        }

        if (argumentValue is null)
        {
            throw new ArgumentNullException(nameof(argumentValue));
        }

        return SyntaxFactory.Attribute(SyntaxFactory.IdentifierName(RemoveSuffix(attributeName)))
            .WithArgumentList(
                SyntaxFactory.AttributeArgumentList(
                    SyntaxFactory.SingletonSeparatedList(
                        SyntaxAttributeArgumentFactory.Create(argumentValue))));
    }

    /// <summary>
    /// Creates an attribute with a single integer argument.
    /// </summary>
    /// <param name="attributeName">The name of the attribute (with or without "Attribute" suffix).</param>
    /// <param name="argumentValue">The integer value for the argument.</param>
    /// <returns>An <see cref="AttributeSyntax"/> node with one argument.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="attributeName"/> is null.</exception>
    public static AttributeSyntax CreateWithOneItemWithOneArgument(string attributeName, int argumentValue)
    {
        if (attributeName is null)
        {
            throw new ArgumentNullException(nameof(attributeName));
        }

        return SyntaxFactory.Attribute(SyntaxFactory.IdentifierName(RemoveSuffix(attributeName)))
            .WithArgumentList(
                SyntaxFactory.AttributeArgumentList(
                    SyntaxFactory.SingletonSeparatedList(
                        SyntaxAttributeArgumentFactory.Create(argumentValue))));
    }

    /// <summary>
    /// Creates an attribute with two arguments.
    /// </summary>
    /// <param name="attributeName">The name of the attribute (with or without "Attribute" suffix).</param>
    /// <param name="argumentValue1">The first argument value.</param>
    /// <param name="argumentValue2">The second argument value.</param>
    /// <returns>An <see cref="AttributeSyntax"/> node with two arguments.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="attributeName"/> is null.</exception>
    public static AttributeSyntax CreateWithOneItemWithTwoArgument(string attributeName, object argumentValue1, object argumentValue2)
    {
        if (attributeName is null)
        {
            throw new ArgumentNullException(nameof(attributeName));
        }

        return SyntaxFactory.Attribute(SyntaxFactory.IdentifierName(RemoveSuffix(attributeName)))
            .WithArgumentList(
                SyntaxFactory.AttributeArgumentList(
                    SyntaxFactory.SeparatedList<AttributeArgumentSyntax>(
                        new SyntaxNodeOrToken[]
                        {
                            SyntaxAttributeArgumentFactory.Create(argumentValue1),
                            SyntaxTokenFactory.Comma(),
                            SyntaxAttributeArgumentFactory.Create(argumentValue2),
                        })));
    }

    /// <summary>
    /// Creates an attribute syntax from a <see cref="ValidationAttribute"/> instance.
    /// </summary>
    /// <param name="validationAttribute">The validation attribute to convert.</param>
    /// <returns>An <see cref="AttributeSyntax"/> node representing the validation attribute.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="validationAttribute"/> is null.</exception>
    /// <exception cref="NotImplementedException">Thrown when the validation attribute type is not supported.</exception>
    public static AttributeSyntax CreateFromValidationAttribute(ValidationAttribute validationAttribute)
    {
        if (validationAttribute is null)
        {
            throw new ArgumentNullException(nameof(validationAttribute));
        }

        var attributeSyntax = validationAttribute switch
        {
            EmailAddressAttribute _ => Create(nameof(EmailAddressAttribute)),
            MinLengthAttribute attribute => CreateWithOneItemWithOneArgument(nameof(MinLengthAttribute), attribute.Length),
            MaxLengthAttribute attribute => CreateWithOneItemWithOneArgument(nameof(MaxLengthAttribute), attribute.Length),
            RangeAttribute attribute => CreateWithOneItemWithTwoArgument(nameof(RangeAttribute), attribute.Minimum, attribute.Maximum),
            RegularExpressionAttribute attribute => CreateWithOneItemWithOneArgument(nameof(RegularExpressionAttribute), attribute.Pattern),
            RequiredAttribute _ => Create(nameof(RequiredAttribute)),
            StringLengthAttribute attribute => CreateWithOneItemWithOneArgument(nameof(StringLengthAttribute), attribute.MaximumLength),
            UrlAttribute _ => Create(nameof(UrlAttribute)),
            _ => throw new NotImplementedException($"{nameof(ValidationAttribute)} {validationAttribute.GetType()} must be implemented."),
        };

        return attributeSyntax;
    }

    /// <summary>
    /// Removes the "Attribute" suffix from an attribute name if present.
    /// </summary>
    /// <param name="attributeName">The attribute name to process.</param>
    /// <returns>The attribute name without the "Attribute" suffix.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="attributeName"/> is null.</exception>
    public static string RemoveSuffix(string attributeName)
    {
        if (attributeName is null)
        {
            throw new ArgumentNullException(nameof(attributeName));
        }

        return attributeName.Replace("Attribute", string.Empty, StringComparison.Ordinal);
    }
}