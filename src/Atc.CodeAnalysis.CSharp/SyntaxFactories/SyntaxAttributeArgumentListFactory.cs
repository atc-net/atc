namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="AttributeArgumentListSyntax"/> nodes.
/// </summary>
public static class SyntaxAttributeArgumentListFactory
{
    /// <summary>
    /// Creates an attribute argument list with a single named argument from a string value.
    /// </summary>
    /// <param name="attributeName">The name of the attribute property.</param>
    /// <param name="attributeValue">The string value for the attribute argument.</param>
    /// <returns>An <see cref="AttributeArgumentListSyntax"/> containing one named argument.</returns>
    public static AttributeArgumentListSyntax CreateWithOneItemWithNameEquals(
        string attributeName,
        string attributeValue)
    {
        return SyntaxFactory.AttributeArgumentList(
            SyntaxFactory.SingletonSeparatedList(
                SyntaxAttributeArgumentFactory.CreateWithNameEquals(attributeName, attributeValue)));
    }

    /// <summary>
    /// Creates an attribute argument list with a single named argument from an integer value.
    /// </summary>
    /// <param name="attributeName">The name of the attribute property.</param>
    /// <param name="attributeValue">The integer value for the attribute argument.</param>
    /// <returns>An <see cref="AttributeArgumentListSyntax"/> containing one named argument.</returns>
    public static AttributeArgumentListSyntax CreateWithOneItemWithNameEquals(
        string attributeName,
        int attributeValue)
    {
        return SyntaxFactory.AttributeArgumentList(
            SyntaxFactory.SingletonSeparatedList(
                SyntaxAttributeArgumentFactory.CreateWithNameEquals(attributeName, attributeValue)));
    }
}