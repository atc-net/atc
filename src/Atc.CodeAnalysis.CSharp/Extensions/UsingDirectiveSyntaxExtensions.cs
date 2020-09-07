using System;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis.CSharp.Syntax
{
    public static class UsingDirectiveSyntaxExtensions
    {
        internal static SyntaxList<UsingDirectiveSyntax> Sort(this SyntaxList<UsingDirectiveSyntax> usingDirectives, bool placeSystemNamespaceFirst = true) =>
            SyntaxFactory.List(
                usingDirectives
                    .OrderBy(x => x.StaticKeyword.IsKind(SyntaxKind.StaticKeyword) ? 1 : x.Alias == null ? 0 : 2)
                    .ThenBy(x => x.Alias?.ToString())
                    .ThenByDescending(x => placeSystemNamespaceFirst && x.Name.ToString().StartsWith(nameof(System), StringComparison.Ordinal))
                    .ThenBy(x => x.Name.ToString()));
    }
}