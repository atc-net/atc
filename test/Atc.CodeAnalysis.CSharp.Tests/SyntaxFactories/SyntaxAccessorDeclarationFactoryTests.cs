namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxAccessorDeclarationFactoryTests
{
    [Fact]
    public void Get_Should_Return_Get_Accessor_With_Semicolon_By_Default()
    {
        // Act
        var result = SyntaxAccessorDeclarationFactory.Get();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(SyntaxKind.GetAccessorDeclaration, result.Kind());
        Assert.False(result.SemicolonToken.IsMissing);
    }

    [Fact]
    public void Get_Should_Return_Get_Accessor_Without_Semicolon_When_False()
    {
        // Act
        var result = SyntaxAccessorDeclarationFactory.Get(withSemicolon: false);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(SyntaxKind.GetAccessorDeclaration, result.Kind());
        Assert.True(result.SemicolonToken.IsMissing);
    }

    [Fact]
    public void Set_Should_Return_Set_Accessor_With_Semicolon_By_Default()
    {
        // Act
        var result = SyntaxAccessorDeclarationFactory.Set();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(SyntaxKind.SetAccessorDeclaration, result.Kind());
        Assert.False(result.SemicolonToken.IsMissing);
    }

    [Fact]
    public void Set_Should_Return_Set_Accessor_Without_Semicolon_When_False()
    {
        // Act
        var result = SyntaxAccessorDeclarationFactory.Set(withSemicolon: false);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(SyntaxKind.SetAccessorDeclaration, result.Kind());
        Assert.True(result.SemicolonToken.IsMissing);
    }
}