using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxAssignmentExpressionFactory
    {
        public static AssignmentExpressionSyntax CreateSimple(string toIdentifierName, string fromIdentifierName)
        {
            return SyntaxFactory.AssignmentExpression(
                SyntaxKind.SimpleAssignmentExpression,
                SyntaxFactory.IdentifierName(toIdentifierName),
                SyntaxFactory.IdentifierName(fromIdentifierName));
        }
    }
}