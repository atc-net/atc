// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis.CSharp.Syntax;

public static class UsingDirectiveSyntaxExtensions
{
    internal static SyntaxList<UsingDirectiveSyntax> Sort(this SyntaxList<UsingDirectiveSyntax> usingDirectives, bool placeSystemNamespaceFirst = true) =>
        SyntaxFactory.List(
            usingDirectives
                .OrderBy(Compare)
                .ThenBy(x => x.Alias?.ToString(), StringComparer.Ordinal)
                .ThenByDescending(x => placeSystemNamespaceFirst && x.Name.ToString().StartsWith(nameof(System), StringComparison.Ordinal))
                .ThenBy(x => x.Name.ToString(), StringComparer.Ordinal));

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