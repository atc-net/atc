using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxObjectCreationExpressionFactory
    {
        public static ObjectCreationExpressionSyntax Create(string identifierName)
        {
            if (identifierName == null)
            {
                throw new ArgumentNullException(nameof(identifierName));
            }

            return SyntaxFactory.ObjectCreationExpression(SyntaxFactory.IdentifierName(identifierName));
        }
    }
}