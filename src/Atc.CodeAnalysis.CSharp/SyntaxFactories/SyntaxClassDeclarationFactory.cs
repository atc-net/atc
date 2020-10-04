using System;
using System.Diagnostics.CodeAnalysis;
using Atc.CodeAnalysis.CSharp.Factories;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxClassDeclarationFactory
    {
        public static ClassDeclarationSyntax Create(string classTypeName)
        {
            if (classTypeName == null)
            {
                throw new ArgumentNullException(nameof(classTypeName));
            }

            return SyntaxFactory.ClassDeclaration(classTypeName)
                .AddModifiers(SyntaxTokenFactory.PublicKeyword());
        }

        public static ClassDeclarationSyntax CreateWithInterface(string classTypeName, string interfaceTypeName)
        {
            if (classTypeName == null)
            {
                throw new ArgumentNullException(nameof(classTypeName));
            }

            return SyntaxFactory.ClassDeclaration(classTypeName)
                .AddModifiers(SyntaxTokenFactory.PublicKeyword())
                .WithBaseList(
                    SyntaxFactory.BaseList(
                        SyntaxFactory.SingletonSeparatedList<BaseTypeSyntax>(
                            SyntaxFactory.SimpleBaseType(
                                SyntaxFactory.IdentifierName(interfaceTypeName)))));
        }

        public static ClassDeclarationSyntax CreateAsPublicStatic(string classTypeName)
        {
            if (classTypeName == null)
            {
                throw new ArgumentNullException(nameof(classTypeName));
            }

            return SyntaxFactory.ClassDeclaration(classTypeName)
                .AddModifiers(SyntaxTokenFactory.PublicKeyword(), SyntaxTokenFactory.StaticKeyword());
        }

        public static ClassDeclarationSyntax CreateAsInternalStatic(string classTypeName)
        {
            if (classTypeName == null)
            {
                throw new ArgumentNullException(nameof(classTypeName));
            }

            return SyntaxFactory.ClassDeclaration(classTypeName)
                .AddModifiers(SyntaxTokenFactory.InternalKeyword(), SyntaxTokenFactory.StaticKeyword());
        }

        public static ClassDeclarationSyntax CreateWithSuppressMessageAttribute(string classTypeName, SuppressMessageAttribute suppressMessage)
        {
            if (classTypeName == null)
            {
                throw new ArgumentNullException(nameof(classTypeName));
            }

            if (suppressMessage == null)
            {
                throw new ArgumentNullException(nameof(suppressMessage));
            }

            return Create(classTypeName)
                .AddSuppressMessageAttribute(suppressMessage);
        }

        public static ClassDeclarationSyntax CreateWithSuppressMessageAttributeByCheckId(string classTypeName, int checkId, string justification = "")
        {
            if (classTypeName == null)
            {
                throw new ArgumentNullException(nameof(classTypeName));
            }

            return Create(classTypeName)
                .AddSuppressMessageAttribute(SuppressMessageAttributeFactory.Create(checkId, justification));
        }
    }
}