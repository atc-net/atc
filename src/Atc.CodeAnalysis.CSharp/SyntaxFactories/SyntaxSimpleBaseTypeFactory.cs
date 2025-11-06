namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="SimpleBaseTypeSyntax"/> nodes.
/// </summary>
public static class SyntaxSimpleBaseTypeFactory
{
    /// <summary>
    /// Creates a simple base type from a type name.
    /// </summary>
    /// <param name="typeName">The name of the base type.</param>
    /// <returns>A <see cref="SimpleBaseTypeSyntax"/> node.</returns>
    public static SimpleBaseTypeSyntax Create(string typeName)
    {
        return SyntaxFactory.SimpleBaseType(
            SyntaxFactory.ParseTypeName(typeName));
    }
}