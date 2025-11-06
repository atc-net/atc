// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis.CSharp.Syntax;

/// <summary>
/// Extension methods for <see cref="CompilationUnitSyntax"/>.
/// </summary>
public static class CompilationUnitSyntaxExtensions
{
    /// <summary>
    /// Adds using statements to the compilation unit and sorts them.
    /// </summary>
    /// <param name="compilationUnit">The compilation unit to modify.</param>
    /// <param name="usingStatements">The array of using statement strings to add.</param>
    /// <returns>A new <see cref="CompilationUnitSyntax"/> with the using statements added and sorted.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="compilationUnit"/> or <paramref name="usingStatements"/> is null.</exception>
    public static CompilationUnitSyntax AddUsingStatements(
        this CompilationUnitSyntax compilationUnit,
        string[] usingStatements)
    {
        if (compilationUnit is null)
        {
            throw new ArgumentNullException(nameof(compilationUnit));
        }

        if (usingStatements is null)
        {
            throw new ArgumentNullException(nameof(usingStatements));
        }

        if (usingStatements.Length == 0)
        {
            return compilationUnit;
        }

        compilationUnit = compilationUnit.AddUsings(
            usingStatements
                .Select(s => SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(s)))
                .ToArray());

        return compilationUnit.WithUsings(compilationUnit.Usings.Sort());
    }
}