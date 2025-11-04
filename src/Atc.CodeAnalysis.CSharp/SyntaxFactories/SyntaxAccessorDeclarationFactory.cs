namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

public static class SyntaxAccessorDeclarationFactory
{
    public static AccessorDeclarationSyntax Get(bool withSemicolon = true)
    {
        return withSemicolon
            ? SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxTokenFactory.Semicolon())
            : SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.MissingToken(SyntaxKind.SemicolonToken));
    }

    public static AccessorDeclarationSyntax Set(bool withSemicolon = true)
    {
        return withSemicolon
            ? SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SyntaxTokenFactory.Semicolon())
            : SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.MissingToken(SyntaxKind.SemicolonToken));
    }
}