using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxThrowStatementFactory
    {
        public static ThrowStatementSyntax CreateNotImplementedException(bool includeSystem = true)
        {
            if (includeSystem)
            {
                return SyntaxFactory.ThrowStatement(
                    SyntaxObjectCreationExpressionFactory.Create("System", "NotImplementedException")
                        .WithArgumentList(SyntaxFactory.ArgumentList()));
            }

            return SyntaxFactory.ThrowStatement(
                SyntaxObjectCreationExpressionFactory.Create("NotImplementedException")
                    .WithArgumentList(SyntaxFactory.ArgumentList()));
        }

        public static ThrowStatementSyntax CreateArgumentNullException(string parameterName, bool includeSystem = true)
        {
            if (includeSystem)
            {
                return SyntaxFactory.ThrowStatement(
                    SyntaxObjectCreationExpressionFactory.Create("System", nameof(ArgumentNullException))
                        .WithArgumentList(
                            SyntaxFactory.ArgumentList(
                                SyntaxFactory.SingletonSeparatedList(
                                    SyntaxFactory.Argument(
                                        SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("nameof"))
                                            .WithArgumentList(
                                                SyntaxArgumentListFactory.CreateWithOneItem(parameterName)))))));
            }

            return SyntaxFactory.ThrowStatement(
                SyntaxObjectCreationExpressionFactory.Create(nameof(ArgumentNullException))
                    .WithArgumentList(
                        SyntaxFactory.ArgumentList(
                            SyntaxFactory.SingletonSeparatedList(
                                SyntaxFactory.Argument(
                                    SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("nameof"))
                                        .WithArgumentList(
                                            SyntaxArgumentListFactory.CreateWithOneItem(parameterName)))))));
        }
    }
}