namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="AttributeListSyntax"/> nodes.
/// </summary>
public static class SyntaxAttributeListFactory
{
    /// <summary>
    /// Creates an attribute list with a single attribute.
    /// </summary>
    /// <param name="attributeName">The name of the attribute.</param>
    /// <returns>An <see cref="AttributeListSyntax"/> containing one attribute.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="attributeName"/> is null.</exception>
    public static AttributeListSyntax Create(string attributeName)
    {
        if (attributeName is null)
        {
            throw new ArgumentNullException(nameof(attributeName));
        }

        return SyntaxFactory.AttributeList(
            SyntaxFactory.SingletonSeparatedList(
                SyntaxAttributeFactory.Create(attributeName)));
    }

    /// <summary>
    /// Creates an attribute list with a single attribute that has an argument list.
    /// </summary>
    /// <param name="attributeName">The name of the attribute.</param>
    /// <param name="attributeArgumentList">The argument list for the attribute.</param>
    /// <returns>An <see cref="AttributeListSyntax"/> containing one attribute with arguments.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="attributeName"/> is null.</exception>
    public static AttributeListSyntax Create(
        string attributeName,
        AttributeArgumentListSyntax attributeArgumentList)
    {
        if (attributeName is null)
        {
            throw new ArgumentNullException(nameof(attributeName));
        }

        return SyntaxFactory.AttributeList(
            SyntaxFactory.SingletonSeparatedList(
                SyntaxAttributeFactory.Create(attributeName)
                    .WithArgumentList(attributeArgumentList)));
    }

    /// <summary>
    /// Creates an attribute list with a single attribute and one string argument.
    /// </summary>
    /// <param name="attributeName">The name of the attribute.</param>
    /// <param name="argumentValue">The string value for the argument.</param>
    /// <returns>An <see cref="AttributeListSyntax"/> containing one attribute with one argument.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="attributeName"/> is null.</exception>
    public static AttributeListSyntax CreateWithOneItemWithOneArgument(
        string attributeName,
        string argumentValue)
    {
        if (attributeName is null)
        {
            throw new ArgumentNullException(nameof(attributeName));
        }

        return SyntaxFactory.AttributeList(
            SyntaxFactory.SingletonSeparatedList(
                SyntaxAttributeFactory.Create(attributeName)
                    .WithArgumentList(
                        SyntaxFactory.AttributeArgumentList(
                            SyntaxFactory.SingletonSeparatedList(
                                SyntaxAttributeArgumentFactory.Create(argumentValue))))));
    }

    /// <summary>
    /// Creates an attribute list with a single attribute and one named argument.
    /// </summary>
    /// <param name="attributeName">The name of the attribute.</param>
    /// <param name="argumentName">The name of the argument property.</param>
    /// <param name="argumentValue">The string value for the argument.</param>
    /// <returns>An <see cref="AttributeListSyntax"/> containing one attribute with a named argument.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="attributeName"/> is null.</exception>
    public static AttributeListSyntax CreateWithOneItemWithOneArgumentWithNameEquals(
        string attributeName,
        string argumentName,
        string argumentValue)
    {
        if (attributeName is null)
        {
            throw new ArgumentNullException(nameof(attributeName));
        }

        return SyntaxFactory.AttributeList(
            SyntaxFactory.SingletonSeparatedList(
                SyntaxAttributeFactory
                    .Create(attributeName)
                    .WithArgumentList(
                        SyntaxAttributeArgumentListFactory.CreateWithOneItemWithNameEquals(argumentName, argumentValue))));
    }
}