// ReSharper disable ReturnTypeCanBeEnumerable.Global
// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis.CSharp.Syntax;

/// <summary>
/// Extension methods for <see cref="SyntaxNode"/>.
/// </summary>
public static class SyntaxNodeExtensions
{
    /// <summary>
    /// Selects all descendant nodes of type <typeparamref name="T"/> from the syntax node.
    /// </summary>
    /// <typeparam name="T">The type of syntax nodes to select.</typeparam>
    /// <param name="syntaxNode">The syntax node to search.</param>
    /// <returns>An enumerable collection of syntax nodes of type <typeparamref name="T"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="syntaxNode"/> is null.</exception>
    public static IEnumerable<T> Select<T>(this SyntaxNode syntaxNode)
    {
        if (syntaxNode is null)
        {
            throw new ArgumentNullException(nameof(syntaxNode));
        }

        return syntaxNode
            .DescendantNodes()
            .OfType<T>();
    }

    /// <summary>
    /// Selects all descendant nodes of type <typeparamref name="T"/> from the syntax node and returns them as an array.
    /// </summary>
    /// <typeparam name="T">The type of syntax nodes to select.</typeparam>
    /// <param name="syntaxNode">The syntax node to search.</param>
    /// <returns>An array of syntax nodes of type <typeparamref name="T"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="syntaxNode"/> is null.</exception>
    public static T[] SelectToArray<T>(this SyntaxNode syntaxNode)
    {
        if (syntaxNode is null)
        {
            throw new ArgumentNullException(nameof(syntaxNode));
        }

        return syntaxNode
            .Select<T>()
            .ToArray();
    }

    /// <summary>
    /// Gets all using directive statements from the syntax node.
    /// </summary>
    /// <param name="syntaxNode">The syntax node to search.</param>
    /// <returns>An array of using directive strings.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="syntaxNode"/> is null.</exception>
    public static string[] GetUsedUsingStatements(this SyntaxNode syntaxNode)
    {
        if (syntaxNode is null)
        {
            throw new ArgumentNullException(nameof(syntaxNode));
        }

        return syntaxNode
            .Select<UsingDirectiveSyntax>()
            .Select(x => x.Name!.ToFullString())
            .ToArray();
    }

    /// <summary>
    /// Gets all using directive statements from the syntax node, excluding those with aliases.
    /// </summary>
    /// <param name="syntaxNode">The syntax node to search.</param>
    /// <returns>An array of using directive strings without aliases.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="syntaxNode"/> is null.</exception>
    public static string[] GetUsedUsingStatementsWithoutAlias(
        this SyntaxNode syntaxNode)
    {
        if (syntaxNode is null)
        {
            throw new ArgumentNullException(nameof(syntaxNode));
        }

        return syntaxNode
            .Select<UsingDirectiveSyntax>()
            .Where(x => x.Alias is null)
            .Select(x => x.Name!.ToFullString())
            .ToArray();
    }
}