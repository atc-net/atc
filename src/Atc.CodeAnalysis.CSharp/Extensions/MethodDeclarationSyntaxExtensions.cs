using System;
using System.Diagnostics.CodeAnalysis;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.Extensions
{
    public static class MethodDeclarationSyntaxExtensions
    {
        public static MethodDeclarationSyntax AddSuppressMessageAttribute(this MethodDeclarationSyntax methodDeclaration, SuppressMessageAttribute suppressMessage)
        {
            if (methodDeclaration == null)
            {
                throw new ArgumentNullException(nameof(methodDeclaration));
            }

            if (suppressMessage == null)
            {
                throw new ArgumentNullException(nameof(suppressMessage));
            }

            if (string.IsNullOrEmpty(suppressMessage.Justification))
            {
                throw new ArgumentPropertyNullException(nameof(suppressMessage), "Justification is invalid.");
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

            return methodDeclaration
                .AddAttributeLists(SyntaxAttributeListFactory.Create(nameof(SuppressMessageAttribute), attributeArgumentList));
        }
    }
}