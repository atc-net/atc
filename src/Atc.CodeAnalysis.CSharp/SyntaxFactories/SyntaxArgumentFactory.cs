namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="ArgumentSyntax"/> nodes.
/// </summary>
public static class SyntaxArgumentFactory
{
    /// <summary>
    /// Creates an argument from an identifier name.
    /// </summary>
    /// <param name="argumentName">The name of the argument identifier.</param>
    /// <returns>An <see cref="ArgumentSyntax"/> node.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="argumentName"/> is null.</exception>
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