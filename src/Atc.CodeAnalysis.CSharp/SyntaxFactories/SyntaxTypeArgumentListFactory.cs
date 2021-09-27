using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxTypeArgumentListFactory
    {
        public static TypeArgumentListSyntax CreateWithOneItem(string typeName)
        {
            return SyntaxFactory.TypeArgumentList(
                SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                    SyntaxFactory.IdentifierName(typeName)));
        }

        public static TypeArgumentListSyntax CreateWithTwoItems(
            string typeName1,
            string typeName2)
        {
            if (typeName1 is null)
            {
                throw new ArgumentNullException(nameof(typeName1));
            }

            if (typeName2 is null)
            {
                throw new ArgumentNullException(nameof(typeName2));
            }

            return SyntaxFactory.TypeArgumentList(
                SyntaxFactory.SeparatedList<TypeSyntax>(
                    new SyntaxNodeOrToken[]
                    {
                        SyntaxFactory.IdentifierName(typeName1),
                        SyntaxTokenFactory.Comma(),
                        SyntaxFactory.IdentifierName(typeName2),
                    }));
        }
    }
}