using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxAttributeListFactory
    {
        public static AttributeListSyntax Create(string attributeName)
        {
            if (attributeName is null)
            {
                throw new ArgumentNullException(nameof(attributeName));
            }

            return SyntaxFactory.AttributeList(
                SyntaxFactory.SingletonSeparatedList(
                    SyntaxAttributeFactory.Create(attributeName)));
        }

        public static AttributeListSyntax Create(string attributeName, AttributeArgumentListSyntax attributeArgumentList)
        {
            if (attributeName is null)
            {
                throw new ArgumentNullException(nameof(attributeName));
            }

            return SyntaxFactory.AttributeList(
                SyntaxFactory.SingletonSeparatedList(
                    SyntaxAttributeFactory.Create(attributeName)
                    .WithArgumentList(attributeArgumentList)));
        }

        public static AttributeListSyntax CreateWithOneItemWithOneArgument(string attributeName, string argumentValue)
        {
            if (attributeName is null)
            {
                throw new ArgumentNullException(nameof(attributeName));
            }

            return SyntaxFactory.AttributeList(
                SyntaxFactory.SingletonSeparatedList(
                    SyntaxAttributeFactory.Create(attributeName)
                        .WithArgumentList(
                            SyntaxFactory.AttributeArgumentList(
                                SyntaxFactory.SingletonSeparatedList(
                                    SyntaxAttributeArgumentFactory.Create(argumentValue))))));
        }

        public static AttributeListSyntax CreateWithOneItemWithOneArgumentWithNameEquals(string attributeName, string argumentName, string argumentValue)
        {
            if (attributeName is null)
            {
                throw new ArgumentNullException(nameof(attributeName));
            }

            return SyntaxFactory.AttributeList(
                SyntaxFactory.SingletonSeparatedList(
                    SyntaxAttributeFactory
                        .Create(attributeName)
                        .WithArgumentList(
                            SyntaxAttributeArgumentListFactory.CreateWithOneItemWithNameEquals(argumentName, argumentValue))));
        }
    }
}