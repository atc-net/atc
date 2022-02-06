namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxBaseListFactoryTests
{
    [Fact]
    public void CreateOneSimpleBaseType()
    {
        // Arrange
        var expected = SyntaxFactory.BaseList(
            SyntaxFactory.SingletonSeparatedList<BaseTypeSyntax>(
                SyntaxFactory.SimpleBaseType(
                    SyntaxFactory.ParseTypeName("int"))));

        // Act
        var actual = SyntaxBaseListFactory.CreateOneSimpleBaseType("int");

        // Assert
        Assert.Equal(expected.ToFullString(), actual.ToFullString());
    }

    [Fact]
    public void CreateTwoSimpleBaseTypes()
    {
        // Arrange
        var expected = SyntaxFactory.BaseList(
            SyntaxFactory.SeparatedList<BaseTypeSyntax>(
                new SyntaxNodeOrToken[]
                {
                    SyntaxFactory.SimpleBaseType(
                        SyntaxFactory.ParseTypeName("int")),
                    SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.CommaToken,  new SyntaxTriviaList(SyntaxFactory.Space)),
                    SyntaxFactory.SimpleBaseType(
                        SyntaxFactory.ParseTypeName("bool")),
                }));

        // Act
        var actual = SyntaxBaseListFactory.CreateTwoSimpleBaseTypes("int", "bool");

        // Assert
        Assert.Equal(expected.ToFullString(), actual.ToFullString());
    }
}