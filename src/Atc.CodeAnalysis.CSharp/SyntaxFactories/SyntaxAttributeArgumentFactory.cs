using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxAttributeArgumentFactory
    {
        public static AttributeArgumentSyntax Create(string attributeValue)
        {
            return SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(attributeValue));
        }

        public static AttributeArgumentSyntax Create(int attributeValue)
        {
            return SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(attributeValue));
        }

        public static AttributeArgumentSyntax Create(object attributeValue)
        {
            if (attributeValue is null)
            {
                throw new ArgumentNullException(nameof(attributeValue));
            }

            return SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(attributeValue.ToString()!, SyntaxKind.NumericLiteralExpression));
        }

        public static AttributeArgumentSyntax CreateWithNameEquals(string attributeName, string attributeValue)
        {
            return SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(attributeValue))
                .WithNameEquals(SyntaxFactory.NameEquals(SyntaxFactory.IdentifierName(attributeName)));
        }

        public static AttributeArgumentSyntax CreateWithNameEquals(string attributeName, int attributeValue)
        {
            return SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(attributeValue))
                .WithNameEquals(SyntaxFactory.NameEquals(SyntaxFactory.IdentifierName(attributeName)));
        }
    }
}