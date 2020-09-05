using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxAccessorDeclarationFactory
    {
        public static AccessorDeclarationSyntax Get(bool withSemicolon = true)
        {
            return withSemicolon
                ? SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxTokenFactory.Semicolon())
                : SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration);
        }

        public static AccessorDeclarationSyntax Set(bool withSemicolon = true)
        {
            return withSemicolon
                ? SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SyntaxTokenFactory.Semicolon())
                : SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration);
        }
    }
}