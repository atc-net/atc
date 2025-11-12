// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis.CSharp.Syntax;

/// <summary>
/// Extension methods for <see cref="UsingDirectiveSyntax"/>.
/// </summary>
public static class UsingDirectiveSyntaxExtensions
{
    /// <summary>
    /// Sorts a list of using directives by type and namespace.
    /// </summary>
    /// <param name="usingDirectives">The list of using directives to sort.</param>
    /// <param name="placeSystemNamespaceFirst">If <c>true</c>, places System namespace directives first; otherwise, sorts alphabetically.</param>
    /// <returns>A sorted <see cref="SyntaxList{T}"/> of <see cref="UsingDirectiveSyntax"/>.</returns>
    internal static SyntaxList<UsingDirectiveSyntax> Sort(
        this SyntaxList<UsingDirectiveSyntax> usingDirectives,
        bool placeSystemNamespaceFirst = true) =>
        SyntaxFactory.List(
            usingDirectives
                .OrderBy(Compare)
                .ThenBy(x => x.Alias?.ToString(), StringComparer.Ordinal)
                .ThenByDescending(x => placeSystemNamespaceFirst &&
                                       x.Name!
                                           .ToString()
                                           .StartsWith(nameof(System), StringComparison.Ordinal))
                .ThenBy(x => x.Name!.ToString(), StringComparer.Ordinal));

    private static int Compare(UsingDirectiveSyntax directive)
    {
        var alternativeComparison = directive.Alias is null
            ? 0
            : 2;

        return directive.StaticKeyword.IsKind(SyntaxKind.StaticKeyword)
            ? 1
            : alternativeComparison;
    }
}