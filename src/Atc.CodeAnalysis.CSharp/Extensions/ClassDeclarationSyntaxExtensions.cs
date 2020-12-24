using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;

// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis.CSharp.Syntax
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

            return classDeclaration
                .AddAttributeLists(SyntaxAttributeListFactory.Create(nameof(SuppressMessageAttribute), attributeArgumentList));
        }

        public static ClassDeclarationSyntax AddGeneratedCodeAttribute(this ClassDeclarationSyntax classDeclaration, string toolName, string version)
        {
            if (classDeclaration == null)
            {
                throw new ArgumentNullException(nameof(classDeclaration));
            }

            if (toolName == null)
            {
                throw new ArgumentNullException(nameof(toolName));
            }

            if (version == null)
            {
                throw new ArgumentNullException(nameof(version));
            }

            var attributeArgumentList = SyntaxFactory.AttributeArgumentList(
                SyntaxFactory.SeparatedList<AttributeArgumentSyntax>(SyntaxFactory.NodeOrTokenList(
                    SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(toolName)),
                    SyntaxTokenFactory.Comma(),
                    SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(version)))));

            return classDeclaration
                .AddAttributeLists(SyntaxAttributeListFactory.Create(nameof(GeneratedCodeAttribute), attributeArgumentList));
        }
    }
}