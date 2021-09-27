using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxInterfaceDeclarationFactory
    {
        public static InterfaceDeclarationSyntax Create(string interfaceTypeName)
        {
            if (interfaceTypeName is null)
            {
                throw new ArgumentNullException(nameof(interfaceTypeName));
            }

            return SyntaxFactory.InterfaceDeclaration(interfaceTypeName)
                .AddModifiers(SyntaxTokenFactory.PublicKeyword());
        }
    }
}