namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="AttributeArgumentSyntax"/> nodes.
/// </summary>
public static class SyntaxAttributeArgumentFactory
{
    /// <summary>
    /// Creates an attribute argument from a string value.
    /// </summary>
    /// <param name="attributeValue">The string value for the attribute argument.</param>
    /// <returns>An <see cref="AttributeArgumentSyntax"/> node.</returns>
    public static AttributeArgumentSyntax Create(string attributeValue)
    {
        return SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(attributeValue));
    }

    /// <summary>
    /// Creates an attribute argument from an integer value.
    /// </summary>
    /// <param name="attributeValue">The integer value for the attribute argument.</param>
    /// <returns>An <see cref="AttributeArgumentSyntax"/> node.</returns>
    public static AttributeArgumentSyntax Create(int attributeValue)
    {
        return SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(attributeValue));
    }

    /// <summary>
    /// Creates an attribute argument from an object value converted to a numeric literal.
    /// </summary>
    /// <param name="attributeValue">The object value for the attribute argument.</param>
    /// <returns>An <see cref="AttributeArgumentSyntax"/> node.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="attributeValue"/> is null.</exception>
    public static AttributeArgumentSyntax Create(object attributeValue)
    {
        if (attributeValue is null)
        {
            throw new ArgumentNullException(nameof(attributeValue));
        }

        return SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(attributeValue.ToString()!, SyntaxKind.NumericLiteralExpression));
    }

    /// <summary>
    /// Creates an attribute argument with a name-equals syntax from a string value.
    /// </summary>
    /// <param name="attributeName">The name of the attribute property.</param>
    /// <param name="attributeValue">The string value for the attribute argument.</param>
    /// <returns>An <see cref="AttributeArgumentSyntax"/> node with a name-equals clause.</returns>
    public static AttributeArgumentSyntax CreateWithNameEquals(string attributeName, string attributeValue)
    {
        return SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(attributeValue))
            .WithNameEquals(SyntaxFactory.NameEquals(SyntaxFactory.IdentifierName(attributeName)));
    }

    /// <summary>
    /// Creates an attribute argument with a name-equals syntax from an integer value.
    /// </summary>
    /// <param name="attributeName">The name of the attribute property.</param>
    /// <param name="attributeValue">The integer value for the attribute argument.</param>
    /// <returns>An <see cref="AttributeArgumentSyntax"/> node with a name-equals clause.</returns>
    public static AttributeArgumentSyntax CreateWithNameEquals(string attributeName, int attributeValue)
    {
        return SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(attributeValue))
            .WithNameEquals(SyntaxFactory.NameEquals(SyntaxFactory.IdentifierName(attributeName)));
    }
}