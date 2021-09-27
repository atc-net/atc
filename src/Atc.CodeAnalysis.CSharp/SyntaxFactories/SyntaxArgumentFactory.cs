using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxArgumentFactory
    {
        public static ArgumentSyntax Create(string argumentName)
        {
            if (argumentName is null)
            {
                throw new ArgumentNullException(nameof(argumentName));
            }

            return SyntaxFactory.Argument(
                SyntaxFactory.IdentifierName(argumentName));
        }
    }
}