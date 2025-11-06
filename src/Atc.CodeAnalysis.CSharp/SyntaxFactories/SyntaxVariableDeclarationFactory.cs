namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="VariableDeclarationSyntax"/> nodes.
/// </summary>
public static class SyntaxVariableDeclarationFactory
{
    /// <summary>
    /// Creates a variable declaration.
    /// </summary>
    /// <param name="identifierTypeName">The type name of the variable.</param>
    /// <param name="identifierName">The name of the variable.</param>
    /// <returns>A <see cref="VariableDeclarationSyntax"/> node.</returns>
    public static VariableDeclarationSyntax Create(
        string identifierTypeName,
        string identifierName)
    {
        return SyntaxFactory.VariableDeclaration(
                SyntaxFactory.IdentifierName(
                    SyntaxFactory.Identifier(SyntaxTriviaList.Empty, identifierTypeName, new SyntaxTriviaList(SyntaxFactory.Space))))
            .WithVariables(
                SyntaxFactory.SingletonSeparatedList(
                    SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier(identifierName))));
    }
}