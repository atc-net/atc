namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="ParameterListSyntax"/> nodes.
/// </summary>
public static class SyntaxParameterListFactory
{
    /// <summary>
    /// Creates a parameter list with a single parameter.
    /// </summary>
    /// <param name="parameterTypeName">The type name of the parameter.</param>
    /// <param name="parameterName">The name of the parameter.</param>
    /// <param name="genericListTypeName">The generic list type name (e.g., "List", "IEnumerable").</param>
    /// <returns>A <see cref="ParameterListSyntax"/> containing one parameter.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter (except genericListTypeName) is null.</exception>
    public static ParameterListSyntax CreateWithOneItem(
        string parameterTypeName,
        string parameterName,
        string? genericListTypeName = null)
    {
        if (parameterTypeName is null)
        {
            throw new ArgumentNullException(nameof(parameterTypeName));
        }

        if (parameterName is null)
        {
            throw new ArgumentNullException(nameof(parameterName));
        }

        return SyntaxFactory.ParameterList(
            SyntaxFactory.SingletonSeparatedList(
                SyntaxParameterFactory.Create(parameterTypeName, parameterName, genericListTypeName)));
    }

    /// <summary>
    /// Creates a parameter list with one parameter.
    /// </summary>
    /// <param name="parameter">The parameter to include.</param>
    /// <returns>A <see cref="ParameterListSyntax"/> containing one parameter.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="parameter"/> is null.</exception>
    public static ParameterListSyntax CreateWithOneParameterItem(ParameterSyntax parameter)
    {
        if (parameter is null)
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

    /// <summary>
    /// Creates a parameter list with two parameters.
    /// </summary>
    /// <param name="parameter1">The first parameter to include.</param>
    /// <param name="parameter2">The second parameter to include.</param>
    /// <returns>A <see cref="ParameterListSyntax"/> containing two parameters.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public static ParameterListSyntax CreateWithTwoParameterItems(
        ParameterSyntax parameter1,
        ParameterSyntax parameter2)
    {
        if (parameter1 is null)
        {
            throw new ArgumentNullException(nameof(parameter1));
        }

        if (parameter2 is null)
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

    /// <summary>
    /// Creates a parameter list with three parameters.
    /// </summary>
    /// <param name="parameter1">The first parameter to include.</param>
    /// <param name="parameter2">The second parameter to include.</param>
    /// <param name="parameter3">The third parameter to include.</param>
    /// <returns>A <see cref="ParameterListSyntax"/> containing three parameters.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public static ParameterListSyntax CreateWithThreeParameterItems(
        ParameterSyntax parameter1,
        ParameterSyntax parameter2,
        ParameterSyntax parameter3)
    {
        if (parameter1 is null)
        {
            throw new ArgumentNullException(nameof(parameter1));
        }

        if (parameter2 is null)
        {
            throw new ArgumentNullException(nameof(parameter2));
        }

        if (parameter3 is null)
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