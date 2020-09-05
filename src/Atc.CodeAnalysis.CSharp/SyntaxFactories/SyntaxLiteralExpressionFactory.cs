using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

// ReSharper disable InvertIf
namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxLiteralExpressionFactory
    {
        public static LiteralExpressionSyntax Create(string value, SyntaxKind syntaxKind = SyntaxKind.StringLiteralExpression)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (syntaxKind == SyntaxKind.NumericLiteralExpression)
            {
                if (int.TryParse(value, out var parsedInt))
                {
                    return SyntaxFactory.LiteralExpression(syntaxKind, SyntaxFactory.Literal(parsedInt));
                }

                value = value.Replace(".", ",", StringComparison.Ordinal);
                if (double.TryParse(value, out var parsedDouble))
                {
                    return SyntaxFactory.LiteralExpression(syntaxKind, SyntaxFactory.Literal(parsedDouble));
                }
            }

            return SyntaxFactory.LiteralExpression(syntaxKind, SyntaxFactory.Literal(value));
        }

        public static LiteralExpressionSyntax Create(int value)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(value));
        }
    }
}