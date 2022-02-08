namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// SyntaxTokenFactory - for char and symbols methods.
/// </summary>
[SuppressMessage("Design", "MA0048:File name must match type name", Justification = "OK. Partial class.")]
public static partial class SyntaxTokenFactory
{
    public static SyntaxToken LineFeed()
    {
        return SyntaxFactory.Token(new SyntaxTriviaList(SyntaxFactory.LineFeed), SyntaxKind.None, SyntaxTriviaList.Empty);
    }

    public static SyntaxToken CarriageReturnLineFeed()
    {
        return SyntaxFactory.Token(new SyntaxTriviaList(SyntaxFactory.CarriageReturnLineFeed), SyntaxKind.None, SyntaxTriviaList.Empty);
    }

    public static SyntaxToken Comma(bool withTrailingSpace = true)
    {
        return TokenWithTrailing(SyntaxKind.CommaToken, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);
    }

    public static SyntaxToken Colon(bool withTrailingSpace = false)
    {
        return TokenWithTrailing(SyntaxKind.ColonToken, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);
    }

    public static SyntaxToken Semicolon(bool withTrailingSpace = false)
    {
        return TokenWithTrailing(SyntaxKind.SemicolonToken, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);
    }

    public static SyntaxToken Equals(bool withTrailingSpace = true)
    {
        return TokenWithTrailing(SyntaxKind.EqualsToken, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);
    }

    public static SyntaxToken EqualsGreaterThan(bool withTrailingSpace = true)
    {
        return TokenWithTrailing(SyntaxKind.EqualsGreaterThanToken, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);
    }
}