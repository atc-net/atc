namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="ArgumentListSyntax"/> nodes.
/// </summary>
public static class SyntaxArgumentListFactory
{
    /// <summary>
    /// Creates an argument list with a single argument from an identifier name.
    /// </summary>
    /// <param name="argumentName">The name of the argument identifier.</param>
    /// <returns>An <see cref="ArgumentListSyntax"/> containing one argument.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="argumentName"/> is null.</exception>
    public static ArgumentListSyntax CreateWithOneItem(string argumentName)
    {
        if (argumentName is null)
        {
            throw new ArgumentNullException(nameof(argumentName));
        }

        return SyntaxFactory.ArgumentList(
            SyntaxFactory.SingletonSeparatedList(
                SyntaxArgumentFactory.Create(argumentName)));
    }

    /// <summary>
    /// Creates an argument list with two arguments from identifier names.
    /// </summary>
    /// <param name="argumentName1">The name of the first argument identifier.</param>
    /// <param name="argumentName2">The name of the second argument identifier.</param>
    /// <returns>An <see cref="ArgumentListSyntax"/> containing two arguments.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="argumentName1"/> or <paramref name="argumentName2"/> is null.</exception>
    public static ArgumentListSyntax CreateWithTwoItems(
        string argumentName1,
        string argumentName2)
    {
        if (argumentName1 is null)
        {
            throw new ArgumentNullException(nameof(argumentName1));
        }

        if (argumentName2 is null)
        {
            throw new ArgumentNullException(nameof(argumentName2));
        }

        return CreateWithTwoExpressionItems(
            SyntaxFactory.IdentifierName(argumentName1),
            SyntaxFactory.IdentifierName(argumentName2));
    }

    /// <summary>
    /// Creates an argument list with a single argument.
    /// </summary>
    /// <param name="argument">The argument to include.</param>
    /// <returns>An <see cref="ArgumentListSyntax"/> containing one argument.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="argument"/> is null.</exception>
    public static ArgumentListSyntax CreateWithOneArgumentItem(ArgumentSyntax argument)
    {
        if (argument is null)
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

    /// <summary>
    /// Creates an argument list with two arguments.
    /// </summary>
    /// <param name="argument1">The first argument to include.</param>
    /// <param name="argument2">The second argument to include.</param>
    /// <returns>An <see cref="ArgumentListSyntax"/> containing two arguments.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="argument1"/> or <paramref name="argument2"/> is null.</exception>
    public static ArgumentListSyntax CreateWithTwoArgumentItems(
        ArgumentSyntax argument1,
        ArgumentSyntax argument2)
    {
        if (argument1 is null)
        {
            throw new ArgumentNullException(nameof(argument1));
        }

        if (argument2 is null)
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

    /// <summary>
    /// Creates an argument list with three arguments.
    /// </summary>
    /// <param name="argument1">The first argument to include.</param>
    /// <param name="argument2">The second argument to include.</param>
    /// <param name="argument3">The third argument to include.</param>
    /// <returns>An <see cref="ArgumentListSyntax"/> containing three arguments.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any argument parameter is null.</exception>
    public static ArgumentListSyntax CreateWithThreeArgumentItems(
        ArgumentSyntax argument1,
        ArgumentSyntax argument2,
        ArgumentSyntax argument3)
    {
        if (argument1 is null)
        {
            throw new ArgumentNullException(nameof(argument1));
        }

        if (argument2 is null)
        {
            throw new ArgumentNullException(nameof(argument2));
        }

        if (argument3 is null)
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

    /// <summary>
    /// Creates an argument list with a single argument from an expression.
    /// </summary>
    /// <param name="argumentExpression1">The expression to use as the argument.</param>
    /// <returns>An <see cref="ArgumentListSyntax"/> containing one argument.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="argumentExpression1"/> is null.</exception>
    public static ArgumentListSyntax CreateWithOneExpressionItem(ExpressionSyntax argumentExpression1)
    {
        if (argumentExpression1 is null)
        {
            throw new ArgumentNullException(nameof(argumentExpression1));
        }

        return CreateWithOneArgumentItem(
            SyntaxFactory.Argument(argumentExpression1));
    }

    /// <summary>
    /// Creates an argument list with two arguments from expressions.
    /// </summary>
    /// <param name="argumentExpression1">The expression to use as the first argument.</param>
    /// <param name="argumentExpression2">The expression to use as the second argument.</param>
    /// <returns>An <see cref="ArgumentListSyntax"/> containing two arguments.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any expression parameter is null.</exception>
    public static ArgumentListSyntax CreateWithTwoExpressionItems(
        ExpressionSyntax argumentExpression1,
        ExpressionSyntax argumentExpression2)
    {
        if (argumentExpression1 is null)
        {
            throw new ArgumentNullException(nameof(argumentExpression1));
        }

        if (argumentExpression2 is null)
        {
            throw new ArgumentNullException(nameof(argumentExpression2));
        }

        return CreateWithTwoArgumentItems(
            SyntaxFactory.Argument(argumentExpression1),
            SyntaxFactory.Argument(argumentExpression2));
    }

    /// <summary>
    /// Creates an argument list with three arguments from expressions.
    /// </summary>
    /// <param name="argumentExpression1">The expression to use as the first argument.</param>
    /// <param name="argumentExpression2">The expression to use as the second argument.</param>
    /// <param name="argumentExpression3">The expression to use as the third argument.</param>
    /// <returns>An <see cref="ArgumentListSyntax"/> containing three arguments.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any expression parameter is null.</exception>
    public static ArgumentListSyntax CreateWithThreeExpressionItems(
        ExpressionSyntax argumentExpression1,
        ExpressionSyntax argumentExpression2,
        ExpressionSyntax argumentExpression3)
    {
        if (argumentExpression1 is null)
        {
            throw new ArgumentNullException(nameof(argumentExpression1));
        }

        if (argumentExpression2 is null)
        {
            throw new ArgumentNullException(nameof(argumentExpression2));
        }

        if (argumentExpression3 is null)
        {
            throw new ArgumentNullException(nameof(argumentExpression3));
        }

        return CreateWithThreeArgumentItems(
            SyntaxFactory.Argument(argumentExpression1),
            SyntaxFactory.Argument(argumentExpression2),
            SyntaxFactory.Argument(argumentExpression3));
    }
}