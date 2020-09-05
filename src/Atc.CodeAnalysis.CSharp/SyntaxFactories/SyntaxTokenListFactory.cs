using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxTokenListFactory
    {
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

        public static SyntaxTokenList PrivateReadonlyKeyword(bool withTrailingSpace = true)
        {
            return SyntaxFactory.TokenList(
                SyntaxTokenFactory.PrivateKeyword(),
                SyntaxTokenFactory.ReadOnlyKeyword(withTrailingSpace));
        }
    }
}