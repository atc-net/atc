using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxIfStatementFactory
    {
        public static StatementSyntax CreateParameterArgumentNullCheck(string parameterName, bool includeSystem = true)
        {
            return SyntaxFactory.IfStatement(
                SyntaxFactory.IsPatternExpression(
                    SyntaxFactory.IdentifierName(parameterName),
                    SyntaxFactory.ConstantPattern(
                        SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression))),
                SyntaxFactory.Block(
                    SyntaxFactory.SingletonList<StatementSyntax>(
                        SyntaxThrowStatementFactory.CreateArgumentNullException(parameterName, includeSystem))));
        }
    }
}