// ReSharper disable ReturnTypeCanBeEnumerable.Global
// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis.CSharp.Syntax;

public static class SyntaxNodeExtensions
{
    public static IEnumerable<T> Select<T>(this SyntaxNode syntaxNode)
    {
        if (syntaxNode is null)
        {
            throw new ArgumentNullException(nameof(syntaxNode));
        }

        return syntaxNode.DescendantNodes().OfType<T>();
    }

    public static T[] SelectToArray<T>(this SyntaxNode syntaxNode)
    {
        if (syntaxNode is null)
        {
            throw new ArgumentNullException(nameof(syntaxNode));
        }

        return syntaxNode.Select<T>().ToArray();
    }

    public static string[] GetUsedUsingStatements(this SyntaxNode syntaxNode)
    {
        if (syntaxNode is null)
        {
            throw new ArgumentNullException(nameof(syntaxNode));
        }

        return syntaxNode.Select<UsingDirectiveSyntax>()
            .Select(x => x.Name!.ToFullString())
            .ToArray();
    }

    public static string[] GetUsedUsingStatementsWithoutAlias(this SyntaxNode syntaxNode)
    {
        if (syntaxNode is null)
        {
            throw new ArgumentNullException(nameof(syntaxNode));
        }

        return syntaxNode.Select<UsingDirectiveSyntax>()
            .Where(x => x.Alias is null)
            .Select(x => x.Name!.ToFullString())
            .ToArray();
    }
}