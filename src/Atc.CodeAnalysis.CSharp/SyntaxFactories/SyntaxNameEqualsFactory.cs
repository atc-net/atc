namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="NameEqualsSyntax"/> nodes.
/// </summary>
public static class SyntaxNameEqualsFactory
{
    /// <summary>
    /// Creates a name-equals syntax node (used in attribute named arguments and object initializers).
    /// </summary>
    /// <param name="value">The identifier name for the name-equals clause.</param>
    /// <returns>A <see cref="NameEqualsSyntax"/> node.</returns>
    public static NameEqualsSyntax Create(string value)
        => SyntaxFactory.NameEquals(
            SyntaxFactory.IdentifierName(
                SyntaxFactory.Identifier(
                    SyntaxFactory.TriviaList(),
                    value,
                    new SyntaxTriviaList(SyntaxFactory.Space))));
}