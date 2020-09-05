using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxParameterListFactory
    {
        public static ParameterListSyntax CreateWithOneItem(string parameterTypeName, string parameterName, string? genericListTypeName = null)
        {
            if (parameterTypeName == null)
            {
                throw new ArgumentNullException(nameof(parameterTypeName));
            }

            if (parameterName == null)
            {
                throw new ArgumentNullException(nameof(parameterName));
            }

            return SyntaxFactory.ParameterList(
                SyntaxFactory.SingletonSeparatedList(
                    SyntaxParameterFactory.Create(parameterTypeName, parameterName, genericListTypeName)));
        }
    }
}