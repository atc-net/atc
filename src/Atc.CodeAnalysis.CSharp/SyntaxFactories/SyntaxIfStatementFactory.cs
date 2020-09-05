using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxIfStatementFactory
    {
        public static StatementSyntax CreateParameterArgumentNullCheck(string parameterName)
        {
            return SyntaxFactory.IfStatement(
                SyntaxFactory.BinaryExpression(
                    SyntaxKind.EqualsExpression,
                    SyntaxFactory.IdentifierName(parameterName),
                    SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression)),
                SyntaxFactory.Block(
                    SyntaxFactory.SingletonList<StatementSyntax>(
                        SyntaxFactory.ThrowStatement(
                            SyntaxObjectCreationExpressionFactory.Create(nameof(ArgumentNullException))
                                .WithArgumentList(
                                    SyntaxFactory.ArgumentList(
                                        SyntaxFactory.SingletonSeparatedList(
                                            SyntaxFactory.Argument(
                                                SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("nameof"))
                                                    .WithArgumentList(SyntaxArgumentListFactory.CreateWithOneItem(parameterName))))))))));
        }
    }
}