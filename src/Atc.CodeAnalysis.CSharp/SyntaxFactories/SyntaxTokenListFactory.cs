namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="SyntaxTokenList"/> modifier lists.
/// </summary>
public static class SyntaxTokenListFactory
{
    /// <summary>
    /// Creates a token list with the public keyword.
    /// </summary>
    /// <param name="withLeadingLineFeed">If <c>true</c>, adds a leading line feed.</param>
    /// <param name="withTrailingSpace">If <c>true</c>, adds a trailing space.</param>
    /// <returns>A <see cref="SyntaxTokenList"/> containing the public modifier.</returns>
    public static SyntaxTokenList PublicKeyword(bool withLeadingLineFeed = false, bool withTrailingSpace = true)
    {
        if (withLeadingLineFeed)
        {
            return SyntaxFactory.TokenList(
                SyntaxTokenFactory.CarriageReturnLineFeed(),
                SyntaxTokenFactory.PublicKeyword(withTrailingSpace));
        }

        return SyntaxFactory.TokenList(
            SyntaxTokenFactory.PublicKeyword(withTrailingSpace));
    }

    public static SyntaxTokenList PublicStaticKeyword(bool withLeadingLineFeed = false, bool withTrailingSpace = true)
    {
        if (withLeadingLineFeed)
        {
            return SyntaxFactory.TokenList(
                SyntaxTokenFactory.CarriageReturnLineFeed(),
                SyntaxTokenFactory.PublicKeyword(),
                SyntaxTokenFactory.StaticKeyword(withTrailingSpace));
        }

        return SyntaxFactory.TokenList(
            SyntaxTokenFactory.PublicKeyword(),
            SyntaxTokenFactory.StaticKeyword(withTrailingSpace));
    }

    public static SyntaxTokenList PublicOverrideKeyword(bool withLeadingLineFeed = false, bool withTrailingSpace = true)
    {
        if (withLeadingLineFeed)
        {
            return SyntaxFactory.TokenList(
                SyntaxTokenFactory.CarriageReturnLineFeed(),
                SyntaxTokenFactory.PublicKeyword(),
                SyntaxTokenFactory.OverrideKeyword(withTrailingSpace));
        }

        return SyntaxFactory.TokenList(
            SyntaxTokenFactory.PublicKeyword(),
            SyntaxTokenFactory.OverrideKeyword(withTrailingSpace));
    }

    public static SyntaxTokenList PublicAsyncKeyword(bool withLeadingLineFeed = false, bool withTrailingSpace = true)
    {
        if (withLeadingLineFeed)
        {
            return SyntaxFactory.TokenList(
                SyntaxTokenFactory.CarriageReturnLineFeed(),
                SyntaxTokenFactory.PublicKeyword(),
                SyntaxTokenFactory.AsyncKeyword(withTrailingSpace));
        }

        return SyntaxFactory.TokenList(
            SyntaxTokenFactory.PublicKeyword(),
            SyntaxTokenFactory.AsyncKeyword(withTrailingSpace));
    }

    public static SyntaxTokenList InternalStaticKeyword(bool withLeadingLineFeed = false, bool withTrailingSpace = true)
    {
        if (withLeadingLineFeed)
        {
            return SyntaxFactory.TokenList(
                SyntaxTokenFactory.CarriageReturnLineFeed(),
                SyntaxTokenFactory.InternalKeyword(),
                SyntaxTokenFactory.StaticKeyword(withTrailingSpace));
        }

        return SyntaxFactory.TokenList(
            SyntaxTokenFactory.InternalKeyword(),
            SyntaxTokenFactory.StaticKeyword(withTrailingSpace));
    }

    public static SyntaxTokenList ProtectedStaticKeyword(bool withLeadingLineFeed = false, bool withTrailingSpace = true)
    {
        if (withLeadingLineFeed)
        {
            return SyntaxFactory.TokenList(
                SyntaxTokenFactory.CarriageReturnLineFeed(),
                SyntaxTokenFactory.ProtectedKeyword(),
                SyntaxTokenFactory.StaticKeyword(withTrailingSpace));
        }

        return SyntaxFactory.TokenList(
            SyntaxTokenFactory.ProtectedKeyword(),
            SyntaxTokenFactory.StaticKeyword(withTrailingSpace));
    }

    public static SyntaxTokenList ProtectedReadOnlyKeyword(bool withLeadingLineFeed = false, bool withTrailingSpace = true)
    {
        if (withLeadingLineFeed)
        {
            return SyntaxFactory.TokenList(
                SyntaxTokenFactory.CarriageReturnLineFeed(),
                SyntaxTokenFactory.ProtectedKeyword(),
                SyntaxTokenFactory.ReadOnlyKeyword(withTrailingSpace));
        }

        return SyntaxFactory.TokenList(
            SyntaxTokenFactory.ProtectedKeyword(),
            SyntaxTokenFactory.ReadOnlyKeyword(withTrailingSpace));
    }

    public static SyntaxTokenList PrivateReadonlyKeyword(bool withTrailingSpace = true)
    {
        return SyntaxFactory.TokenList(
            SyntaxTokenFactory.PrivateKeyword(),
            SyntaxTokenFactory.ReadOnlyKeyword(withTrailingSpace));
    }

    public static SyntaxTokenList PrivateAsyncKeyword(bool withLeadingLineFeed = false, bool withTrailingSpace = true)
    {
        if (withLeadingLineFeed)
        {
            return SyntaxFactory.TokenList(
                SyntaxTokenFactory.CarriageReturnLineFeed(),
                SyntaxTokenFactory.PrivateKeyword(),
                SyntaxTokenFactory.AsyncKeyword(withTrailingSpace));
        }

        return SyntaxFactory.TokenList(
            SyntaxTokenFactory.PrivateKeyword(),
            SyntaxTokenFactory.AsyncKeyword(withTrailingSpace));
    }
}