namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="BaseListSyntax"/> nodes.
/// </summary>
public static class SyntaxBaseListFactory
{
    /// <summary>
    /// Creates a base list with a single base type.
    /// </summary>
    /// <param name="typeName">The name of the base type.</param>
    /// <returns>A <see cref="BaseListSyntax"/> containing one base type.</returns>
    public static BaseListSyntax CreateOneSimpleBaseType(string typeName)
    {
        return SyntaxFactory.BaseList(
            SyntaxFactory.SingletonSeparatedList<BaseTypeSyntax>(
                SyntaxSimpleBaseTypeFactory.Create(typeName)));
    }

    /// <summary>
    /// Creates a base list with two base types.
    /// </summary>
    /// <param name="typeName1">The name of the first base type.</param>
    /// <param name="typeName2">The name of the second base type.</param>
    /// <returns>A <see cref="BaseListSyntax"/> containing two base types.</returns>
    public static BaseListSyntax CreateTwoSimpleBaseTypes(
        string typeName1,
        string typeName2)
    {
        return SyntaxFactory.BaseList(
            SyntaxFactory.SeparatedList<BaseTypeSyntax>(
                new SyntaxNodeOrToken[]
                {
                    SyntaxSimpleBaseTypeFactory.Create(typeName1),
                    SyntaxTokenFactory.Comma(),
                    SyntaxSimpleBaseTypeFactory.Create(typeName2),
                }));
    }
}