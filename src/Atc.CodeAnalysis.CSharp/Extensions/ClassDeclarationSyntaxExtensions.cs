using System;
using System.Diagnostics.CodeAnalysis;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

// ReSharper disable CheckNamespace
namespace Atc.CodeAnalysis.CSharp
{
    public static class ClassDeclarationSyntaxExtensions
    {
        public static ClassDeclarationSyntax AddSuppressMessageAttribute(this ClassDeclarationSyntax classDeclaration, SuppressMessageAttribute suppressMessage)
        {
            if (classDeclaration == null)
            {
                throw new ArgumentNullException(nameof(classDeclaration));
            }

            if (suppressMessage == null)
            {
                throw new ArgumentNullException(nameof(suppressMessage));
            }

            if (string.IsNullOrEmpty(suppressMessage.Justification))
            {
                throw new ArgumentException(nameof(suppressMessage.Justification));
            }

            var attributeArgumentList = SyntaxFactory.AttributeArgumentList(
                SyntaxFactory.SeparatedList<AttributeArgumentSyntax>(SyntaxFactory.NodeOrTokenList(
                    SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(suppressMessage.Category)),
                    SyntaxTokenFactory.Comma(),
                    SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(suppressMessage.CheckId)),
                    SyntaxTokenFactory.Comma(),
                    SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(suppressMessage.Justification!))
                        .WithNameEquals(
                            SyntaxNameEqualsFactory.Create(nameof(SuppressMessageAttribute.Justification))
                                .WithEqualsToken(SyntaxTokenFactory.Equals())))));

            return classDeclaration
                .AddAttributeLists(SyntaxAttributeListFactory.Create(nameof(SuppressMessageAttribute), attributeArgumentList));
        }
    }
}