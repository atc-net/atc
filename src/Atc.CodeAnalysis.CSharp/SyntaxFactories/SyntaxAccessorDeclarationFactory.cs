namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="AccessorDeclarationSyntax"/> nodes.
/// </summary>
public static class SyntaxAccessorDeclarationFactory
{
    /// <summary>
    /// Creates a get accessor declaration.
    /// </summary>
    /// <param name="withSemicolon">If <c>true</c>, includes a semicolon token; otherwise, uses a missing token.</param>
    /// <returns>An <see cref="AccessorDeclarationSyntax"/> representing a get accessor.</returns>
    public static AccessorDeclarationSyntax Get(bool withSemicolon = true)
        => withSemicolon
            ? SyntaxFactory
                .AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                .WithSemicolonToken(SyntaxTokenFactory.Semicolon())
            : SyntaxFactory
                .AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                .WithSemicolonToken(SyntaxFactory.MissingToken(SyntaxKind.SemicolonToken));

    /// <summary>
    /// Creates a set accessor declaration.
    /// </summary>
    /// <param name="withSemicolon">If <c>true</c>, includes a semicolon token; otherwise, uses a missing token.</param>
    /// <returns>An <see cref="AccessorDeclarationSyntax"/> representing a set accessor.</returns>
    public static AccessorDeclarationSyntax Set(bool withSemicolon = true)
        => withSemicolon
            ? SyntaxFactory
                .AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                .WithSemicolonToken(SyntaxTokenFactory.Semicolon())
            : SyntaxFactory
                .AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                .WithSemicolonToken(SyntaxFactory.MissingToken(SyntaxKind.SemicolonToken));
}