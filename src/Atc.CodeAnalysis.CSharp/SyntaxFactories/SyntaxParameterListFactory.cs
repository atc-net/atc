using System;
using Microsoft.CodeAnalysis;
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

        public static ParameterListSyntax CreateWithOneParameterItem(ParameterSyntax parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            return SyntaxFactory.ParameterList(
                SyntaxFactory.SeparatedList<ParameterSyntax>(
                    new SyntaxNodeOrToken[]
                    {
                        parameter,
                    }));
        }

        public static ParameterListSyntax CreateWithTwoParameterItems(
            ParameterSyntax parameter1,
            ParameterSyntax parameter2)
        {
            if (parameter1 == null)
            {
                throw new ArgumentNullException(nameof(parameter1));
            }

            if (parameter2 == null)
            {
                throw new ArgumentNullException(nameof(parameter2));
            }

            return SyntaxFactory.ParameterList(
                SyntaxFactory.SeparatedList<ParameterSyntax>(
                    new SyntaxNodeOrToken[]
                    {
                        parameter1,
                        SyntaxTokenFactory.Comma(),
                        parameter2,
                    }));
        }

        public static ParameterListSyntax CreateWithThreeParameterItems(
            ParameterSyntax parameter1,
            ParameterSyntax parameter2,
            ParameterSyntax parameter3)
        {
            if (parameter1 == null)
            {
                throw new ArgumentNullException(nameof(parameter1));
            }

            if (parameter2 == null)
            {
                throw new ArgumentNullException(nameof(parameter2));
            }

            if (parameter3 == null)
            {
                throw new ArgumentNullException(nameof(parameter3));
            }

            return SyntaxFactory.ParameterList(
                SyntaxFactory.SeparatedList<ParameterSyntax>(
                    new SyntaxNodeOrToken[]
                    {
                        parameter1,
                        SyntaxTokenFactory.Comma(),
                        parameter2,
                        SyntaxTokenFactory.Comma(),
                        parameter3,
                    }));
        }
    }
}