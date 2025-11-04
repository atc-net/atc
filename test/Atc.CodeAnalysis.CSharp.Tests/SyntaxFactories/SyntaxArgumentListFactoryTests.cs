namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxArgumentListFactoryTests
{
    [Fact]
    public void CreateWithOneItem()
    {
        // Arrange
        var expected = SyntaxFactory.ArgumentList(
            SyntaxFactory.SingletonSeparatedList(
                SyntaxFactory.Argument(
                    SyntaxFactory.IdentifierName("hallo"))));

        // Act
        var actual = SyntaxArgumentListFactory.CreateWithOneItem("hallo");

        // Assert
        Assert.Equal(expected.ToFullString(), actual.ToFullString());
    }

    [Fact]
    public void CreateWithTwoItems()
    {
        // Arrange
        var expected = SyntaxFactory.ArgumentList(
            SyntaxFactory.SeparatedList<ArgumentSyntax>(
                new SyntaxNodeOrToken[]
                {
                    SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName("foo")),
                    SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.CommaToken,  new SyntaxTriviaList(SyntaxFactory.Space)),
                    SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName("bar")),
                }));

        // Act
        var actual = SyntaxArgumentListFactory.CreateWithTwoItems("foo", "bar");

        // Assert
        Assert.Equal(expected.ToFullString(), actual.ToFullString());
    }

    [Fact]
    public void CreateWithOneArgumentItem()
    {
        // Arrange
        var expected = SyntaxFactory.ArgumentList(
            SyntaxFactory.SeparatedList<ArgumentSyntax>(
                new SyntaxNodeOrToken[]
                {
                    SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName("foo")),
                }));

        // Act
        var actual = SyntaxArgumentListFactory.CreateWithOneArgumentItem(
            SyntaxFactory.Argument(
                SyntaxFactory.IdentifierName("foo")));

        // Assert
        Assert.Equal(expected.ToFullString(), actual.ToFullString());
    }

    [Fact]
    public void CreateWithTwoArgumentItems()
    {
        // Arrange
        var expected = SyntaxFactory.ArgumentList(
            SyntaxFactory.SeparatedList<ArgumentSyntax>(
                new SyntaxNodeOrToken[]
                {
                    SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName("foo")),
                    SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.CommaToken,  new SyntaxTriviaList(SyntaxFactory.Space)),
                    SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName("bar")),
                }));

        // Act
        var actual = SyntaxArgumentListFactory.CreateWithTwoArgumentItems(
            SyntaxFactory.Argument(
                SyntaxFactory.IdentifierName("foo")),
            SyntaxFactory.Argument(
                SyntaxFactory.IdentifierName("bar")));

        // Assert
        Assert.Equal(expected.ToFullString(), actual.ToFullString());
    }

    [Fact]
    public void CreateWithThreeArgumentItems()
    {
        // Arrange
        var expected = SyntaxFactory.ArgumentList(
            SyntaxFactory.SeparatedList<ArgumentSyntax>(
                new SyntaxNodeOrToken[]
                {
                    SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName("foo")),
                    SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.CommaToken,  new SyntaxTriviaList(SyntaxFactory.Space)),
                    SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName("bar")),
                    SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.CommaToken,  new SyntaxTriviaList(SyntaxFactory.Space)),
                    SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName("baz")),
                }));

        // Act
        var actual = SyntaxArgumentListFactory.CreateWithThreeArgumentItems(
            SyntaxFactory.Argument(
                SyntaxFactory.IdentifierName("foo")),
            SyntaxFactory.Argument(
                SyntaxFactory.IdentifierName("bar")),
            SyntaxFactory.Argument(
                SyntaxFactory.IdentifierName("baz")));

        // Assert
        Assert.Equal(expected.ToFullString(), actual.ToFullString());
    }

    [Fact]
    public void CreateWithOneExpressionItem()
    {
        // Arrange
        var expected = SyntaxFactory.ArgumentList(
            SyntaxFactory.SeparatedList<ArgumentSyntax>(
                new SyntaxNodeOrToken[]
                {
                    SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName("foo")),
                }));

        // Act
        var actual = SyntaxArgumentListFactory.CreateWithOneExpressionItem(
            SyntaxFactory.IdentifierName("foo"));

        // Assert
        Assert.Equal(expected.ToFullString(), actual.ToFullString());
    }

    [Fact]
    public void CreateWithTwoExpressionItems()
    {
        // Arrange
        var expected = SyntaxFactory.ArgumentList(
            SyntaxFactory.SeparatedList<ArgumentSyntax>(
                new SyntaxNodeOrToken[]
                {
                    SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName("foo")),
                    SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.CommaToken,  new SyntaxTriviaList(SyntaxFactory.Space)),
                    SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName("bar")),
                }));

        // Act
        var actual = SyntaxArgumentListFactory.CreateWithTwoExpressionItems(
            SyntaxFactory.IdentifierName("foo"),
            SyntaxFactory.IdentifierName("bar"));

        // Assert
        Assert.Equal(expected.ToFullString(), actual.ToFullString());
    }

    [Fact]
    public void CreateWithThreeExpressionItems()
    {
        // Arrange
        var expected = SyntaxFactory.ArgumentList(
            SyntaxFactory.SeparatedList<ArgumentSyntax>(
                new SyntaxNodeOrToken[]
                {
                    SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName("foo")),
                    SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.CommaToken,  new SyntaxTriviaList(SyntaxFactory.Space)),
                    SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName("bar")),
                    SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.CommaToken,  new SyntaxTriviaList(SyntaxFactory.Space)),
                    SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName("baz")),
                }));

        // Act
        var actual = SyntaxArgumentListFactory.CreateWithThreeExpressionItems(
            SyntaxFactory.IdentifierName("foo"),
            SyntaxFactory.IdentifierName("bar"),
            SyntaxFactory.IdentifierName("baz"));

        // Assert
        Assert.Equal(expected.ToFullString(), actual.ToFullString());
    }

    [Fact]
    public void CreateWithOneArgumentItem_Direct()
    {
        // Arrange
        var argument = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("test"));

        // Act
        var result = SyntaxArgumentListFactory.CreateWithOneArgumentItem(argument);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Arguments);
    }

    [Fact]
    public void CreateWithTwoArgumentItems_Direct()
    {
        // Arrange
        var argument1 = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("test1"));
        var argument2 = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("test2"));

        // Act
        var result = SyntaxArgumentListFactory.CreateWithTwoArgumentItems(argument1, argument2);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Arguments.Count);
    }

    [Fact]
    public void CreateWithThreeArgumentItems_Direct()
    {
        // Arrange
        var argument1 = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("test1"));
        var argument2 = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("test2"));
        var argument3 = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("test3"));

        // Act
        var result = SyntaxArgumentListFactory.CreateWithThreeArgumentItems(argument1, argument2, argument3);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Arguments.Count);
    }

    [Fact]
    public void CreateWithOneExpressionItem_Direct()
    {
        // Arrange
        var expression = SyntaxFactory.IdentifierName("test");

        // Act
        var result = SyntaxArgumentListFactory.CreateWithOneExpressionItem(expression);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Arguments);
    }

    [Fact]
    public void CreateWithTwoExpressionItems_Direct()
    {
        // Arrange
        var expression1 = SyntaxFactory.IdentifierName("test1");
        var expression2 = SyntaxFactory.IdentifierName("test2");

        // Act
        var result = SyntaxArgumentListFactory.CreateWithTwoExpressionItems(expression1, expression2);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Arguments.Count);
    }

    [Fact]
    public void CreateWithThreeExpressionItems_Direct()
    {
        // Arrange
        var expression1 = SyntaxFactory.IdentifierName("test1");
        var expression2 = SyntaxFactory.IdentifierName("test2");
        var expression3 = SyntaxFactory.IdentifierName("test3");

        // Act
        var result = SyntaxArgumentListFactory.CreateWithThreeExpressionItems(expression1, expression2, expression3);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Arguments.Count);
    }
}