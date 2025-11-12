namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="TypeArgumentListSyntax"/> nodes.
/// </summary>
public static class SyntaxTypeArgumentListFactory
{
    /// <summary>
    /// Creates a type argument list with a single type.
    /// </summary>
    /// <param name="typeName">The name of the type argument.</param>
    /// <returns>A <see cref="TypeArgumentListSyntax"/> containing one type.</returns>
    public static TypeArgumentListSyntax CreateWithOneItem(string typeName)
        => SyntaxFactory.TypeArgumentList(
            SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                SyntaxFactory.IdentifierName(typeName)));

    /// <summary>
    /// Creates a type argument list with two types.
    /// </summary>
    /// <param name="typeName1">The name of the first type argument.</param>
    /// <param name="typeName2">The name of the second type argument.</param>
    /// <returns>A <see cref="TypeArgumentListSyntax"/> containing two types.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public static TypeArgumentListSyntax CreateWithTwoItems(
        string typeName1,
        string typeName2)
    {
        if (typeName1 is null)
        {
            throw new ArgumentNullException(nameof(typeName1));
        }

        if (typeName2 is null)
        {
            throw new ArgumentNullException(nameof(typeName2));
        }

        return SyntaxFactory.TypeArgumentList(
            SyntaxFactory.SeparatedList<TypeSyntax>(
                new SyntaxNodeOrToken[]
                {
                    SyntaxFactory.IdentifierName(typeName1),
                    SyntaxTokenFactory.Comma(),
                    SyntaxFactory.IdentifierName(typeName2),
                }));
    }
}