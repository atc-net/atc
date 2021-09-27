using System;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis.CSharp.Syntax
{
    public static class CompilationUnitSyntaxExtensions
    {
        public static CompilationUnitSyntax AddUsingStatements(this CompilationUnitSyntax compilationUnit, string[] usingStatements)
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
}