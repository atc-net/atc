namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxTypeArgumentListTests
{
    [Fact]
    public void CreateWithOneItem()
    {
        // Arrange
        var expected = SyntaxFactory.TypeArgumentList(
            SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                SyntaxFactory.IdentifierName("int")));

        // Act
        var actual = SyntaxTypeArgumentListFactory.CreateWithOneItem("int");

        // Assert
        Assert.Equal(expected.ToFullString(), actual.ToFullString());
    }

    [Fact]
    public void CreateWithTwoItems()
    {
        // Arrange
        var expected = SyntaxFactory.TypeArgumentList(
            SyntaxFactory.SeparatedList<TypeSyntax>(
                new SyntaxNodeOrToken[]
                {
                    SyntaxFactory.IdentifierName("int"),
                    SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.CommaToken,  new SyntaxTriviaList(SyntaxFactory.Space)),
                    SyntaxFactory.IdentifierName("bool"),
                }));

        // Act
        var actual = SyntaxTypeArgumentListFactory.CreateWithTwoItems("int", "bool");

        // Assert
        Assert.Equal(expected.ToFullString(), actual.ToFullString());
    }

    [Fact]
    public void CreateWithOneItem_Direct()
    {
        // Arrange
        const string typeName = "MyType";

        // Act
        var result = SyntaxTypeArgumentListFactory.CreateWithOneItem(typeName);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Arguments);
    }

    [Fact]
    public void CreateWithTwoItems_Direct()
    {
        // Arrange
        const string typeName1 = "Type1";
        const string typeName2 = "Type2";

        // Act
        var result = SyntaxTypeArgumentListFactory.CreateWithTwoItems(typeName1, typeName2);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Arguments.Count);
    }
}