namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

public static class SyntaxNameEqualsFactory
{
    public static NameEqualsSyntax Create(string value)
    {
        return SyntaxFactory.NameEquals(
            SyntaxFactory.IdentifierName(
                SyntaxFactory.Identifier(
                    SyntaxFactory.TriviaList(),
                    value,
                    new SyntaxTriviaList(SyntaxFactory.Space))));
    }
}