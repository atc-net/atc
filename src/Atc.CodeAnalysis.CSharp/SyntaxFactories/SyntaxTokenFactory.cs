using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static partial class SyntaxTokenFactory
    {
        public static SyntaxToken Token(SyntaxKind syntaxKind)
        {
            return SyntaxFactory.Token(syntaxKind);
        }

        public static SyntaxToken TokenWithTrailingSpace(SyntaxKind syntaxKind)
        {
            return TokenWithTrailing(syntaxKind, SyntaxFactory.Space);
        }

        public static SyntaxToken TokenWithTrailing(SyntaxKind syntaxKind, SyntaxTrivia syntaxTrivia)
        {
            return SyntaxFactory.Token(SyntaxTriviaList.Empty, syntaxKind, new SyntaxTriviaList(syntaxTrivia));
        }
    }
}