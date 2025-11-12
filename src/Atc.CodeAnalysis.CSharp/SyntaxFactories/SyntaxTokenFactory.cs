namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// SyntaxTokenFactory - for base methods.
/// </summary>
public static partial class SyntaxTokenFactory
{
    /// <summary>
    /// Creates a syntax token of the specified kind.
    /// </summary>
    /// <param name="syntaxKind">The kind of token to create.</param>
    /// <returns>A <see cref="SyntaxToken"/>.</returns>
    public static SyntaxToken Token(SyntaxKind syntaxKind)
        => SyntaxFactory.Token(syntaxKind);

    /// <summary>
    /// Creates a syntax token with a trailing space.
    /// </summary>
    /// <param name="syntaxKind">The kind of token to create.</param>
    /// <returns>A <see cref="SyntaxToken"/> with trailing space trivia.</returns>
    public static SyntaxToken TokenWithTrailingSpace(SyntaxKind syntaxKind)
        => TokenWithTrailing(syntaxKind, SyntaxFactory.Space);

    /// <summary>
    /// Creates a syntax token with trailing trivia.
    /// </summary>
    /// <param name="syntaxKind">The kind of token to create.</param>
    /// <param name="syntaxTrivia">The trailing trivia to add.</param>
    /// <returns>A <see cref="SyntaxToken"/> with the specified trailing trivia.</returns>
    public static SyntaxToken TokenWithTrailing(
        SyntaxKind syntaxKind,
        SyntaxTrivia syntaxTrivia)
        => SyntaxFactory.Token(syntaxKind).WithTrailingTrivia(syntaxTrivia);
}