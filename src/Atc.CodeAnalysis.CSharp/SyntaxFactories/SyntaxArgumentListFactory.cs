using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxArgumentListFactory
    {
        public static ArgumentListSyntax CreateWithOneItem(string argumentName)
        {
            if (argumentName == null)
            {
                throw new ArgumentNullException(nameof(argumentName));
            }

            return SyntaxFactory.ArgumentList(
                SyntaxFactory.SingletonSeparatedList(
                    SyntaxArgumentFactory.Create(argumentName)));
        }

        public static ArgumentListSyntax CreateWithTwoItems(
            string argumentName1,
            string argumentName2)
        {
            if (argumentName1 == null)
            {
                throw new ArgumentNullException(nameof(argumentName1));
            }

            if (argumentName2 == null)
            {
                throw new ArgumentNullException(nameof(argumentName2));
            }

            return CreateWithTwoExpressionItems(
                SyntaxFactory.IdentifierName(argumentName1),
                SyntaxFactory.IdentifierName(argumentName2));
        }

        public static ArgumentListSyntax CreateWithOneArgumentItem(ArgumentSyntax argument)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(nameof(argument));
            }

            return SyntaxFactory.ArgumentList(
                SyntaxFactory.SeparatedList<ArgumentSyntax>(
                    new SyntaxNodeOrToken[]
                    {
                        argument,
                    }));
        }

        public static ArgumentListSyntax CreateWithTwoArgumentItems(
            ArgumentSyntax argument1,
            ArgumentSyntax argument2)
        {
            if (argument1 == null)
            {
                throw new ArgumentNullException(nameof(argument1));
            }

            if (argument2 == null)
            {
                throw new ArgumentNullException(nameof(argument2));
            }

            return SyntaxFactory.ArgumentList(
                SyntaxFactory.SeparatedList<ArgumentSyntax>(
                    new SyntaxNodeOrToken[]
                    {
                        argument1,
                        SyntaxTokenFactory.Comma(),
                        argument2,
                    }));
        }

        public static ArgumentListSyntax CreateWithThreeArgumentItems(
            ArgumentSyntax argument1,
            ArgumentSyntax argument2,
            ArgumentSyntax argument3)
        {
            if (argument1 == null)
            {
                throw new ArgumentNullException(nameof(argument1));
            }

            if (argument2 == null)
            {
                throw new ArgumentNullException(nameof(argument2));
            }

            if (argument3 == null)
            {
                throw new ArgumentNullException(nameof(argument3));
            }

            return SyntaxFactory.ArgumentList(
                SyntaxFactory.SeparatedList<ArgumentSyntax>(
                    new SyntaxNodeOrToken[]
                    {
                        argument1,
                        SyntaxTokenFactory.Comma(),
                        argument2,
                        SyntaxTokenFactory.Comma(),
                        argument3,
                    }));
        }

        public static ArgumentListSyntax CreateWithOneExpressionItem(ExpressionSyntax argumentExpression1)
        {
            if (argumentExpression1 == null)
            {
                throw new ArgumentNullException(nameof(argumentExpression1));
            }

            return CreateWithOneArgumentItem(
                SyntaxFactory.Argument(argumentExpression1));
        }

        public static ArgumentListSyntax CreateWithTwoExpressionItems(
            ExpressionSyntax argumentExpression1,
            ExpressionSyntax argumentExpression2)
        {
            if (argumentExpression1 == null)
            {
                throw new ArgumentNullException(nameof(argumentExpression1));
            }

            if (argumentExpression2 == null)
            {
                throw new ArgumentNullException(nameof(argumentExpression2));
            }

            return CreateWithTwoArgumentItems(
                SyntaxFactory.Argument(argumentExpression1),
                SyntaxFactory.Argument(argumentExpression2));
        }

        public static ArgumentListSyntax CreateWithThreeExpressionItems(
            ExpressionSyntax argumentExpression1,
            ExpressionSyntax argumentExpression2,
            ExpressionSyntax argumentExpression3)
        {
            if (argumentExpression1 == null)
            {
                throw new ArgumentNullException(nameof(argumentExpression1));
            }

            if (argumentExpression2 == null)
            {
                throw new ArgumentNullException(nameof(argumentExpression2));
            }

            if (argumentExpression3 == null)
            {
                throw new ArgumentNullException(nameof(argumentExpression3));
            }

            return CreateWithThreeArgumentItems(
                SyntaxFactory.Argument(argumentExpression1),
                SyntaxFactory.Argument(argumentExpression2),
                SyntaxFactory.Argument(argumentExpression3));
        }
    }
}