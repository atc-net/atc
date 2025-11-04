namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxTokenListFactoryTests
{
    [Fact]
    public void PublicKeyword_Should_Create_Public_Token_List_Without_LineFeed_By_Default()
    {
        // Act
        var result = SyntaxTokenListFactory.PublicKeyword();

        // Assert
        Assert.Single(result);
        Assert.Equal(SyntaxKind.PublicKeyword, result[0].Kind());
    }

    [Fact]
    public void PublicKeyword_Should_Create_Public_Token_List_With_LineFeed_When_True()
    {
        // Act
        var result = SyntaxTokenListFactory.PublicKeyword(withLeadingLineFeed: true);

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void PublicStaticKeyword_Should_Create_Public_Static_Token_List()
    {
        // Act
        var result = SyntaxTokenListFactory.PublicStaticKeyword();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(SyntaxKind.PublicKeyword, result[0].Kind());
        Assert.Equal(SyntaxKind.StaticKeyword, result[1].Kind());
    }

    [Fact]
    public void PublicOverrideKeyword_Should_Create_Public_Override_Token_List()
    {
        // Act
        var result = SyntaxTokenListFactory.PublicOverrideKeyword();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(SyntaxKind.PublicKeyword, result[0].Kind());
        Assert.Equal(SyntaxKind.OverrideKeyword, result[1].Kind());
    }

    [Fact]
    public void PublicAsyncKeyword_Should_Create_Public_Async_Token_List()
    {
        // Act
        var result = SyntaxTokenListFactory.PublicAsyncKeyword();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(SyntaxKind.PublicKeyword, result[0].Kind());
        Assert.Equal(SyntaxKind.AsyncKeyword, result[1].Kind());
    }

    [Fact]
    public void InternalStaticKeyword_Should_Create_Internal_Static_Token_List()
    {
        // Act
        var result = SyntaxTokenListFactory.InternalStaticKeyword();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(SyntaxKind.InternalKeyword, result[0].Kind());
        Assert.Equal(SyntaxKind.StaticKeyword, result[1].Kind());
    }

    [Fact]
    public void ProtectedStaticKeyword_Should_Create_Protected_Static_Token_List()
    {
        // Act
        var result = SyntaxTokenListFactory.ProtectedStaticKeyword();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(SyntaxKind.ProtectedKeyword, result[0].Kind());
        Assert.Equal(SyntaxKind.StaticKeyword, result[1].Kind());
    }

    [Fact]
    public void ProtectedReadOnlyKeyword_Should_Create_Protected_ReadOnly_Token_List()
    {
        // Act
        var result = SyntaxTokenListFactory.ProtectedReadOnlyKeyword();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(SyntaxKind.ProtectedKeyword, result[0].Kind());
        Assert.Equal(SyntaxKind.ReadOnlyKeyword, result[1].Kind());
    }

    [Fact]
    public void PrivateReadonlyKeyword_Should_Create_Private_Readonly_Token_List()
    {
        // Act
        var result = SyntaxTokenListFactory.PrivateReadonlyKeyword();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(SyntaxKind.PrivateKeyword, result[0].Kind());
        Assert.Equal(SyntaxKind.ReadOnlyKeyword, result[1].Kind());
    }

    [Fact]
    public void PrivateAsyncKeyword_Should_Create_Private_Async_Token_List()
    {
        // Act
        var result = SyntaxTokenListFactory.PrivateAsyncKeyword();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(SyntaxKind.PrivateKeyword, result[0].Kind());
        Assert.Equal(SyntaxKind.AsyncKeyword, result[1].Kind());
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void PublicKeyword_Direct(bool withLeadingLineFeed, bool useTrailingSpace)
    {
        // Act
        var result = SyntaxTokenListFactory.PublicKeyword(withLeadingLineFeed, useTrailingSpace);

        // Assert
        Assert.NotEqual(default(SyntaxTokenList), result);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void PublicStaticKeyword_Direct(bool withLeadingLineFeed, bool useTrailingSpace)
    {
        // Act
        var result = SyntaxTokenListFactory.PublicStaticKeyword(withLeadingLineFeed, useTrailingSpace);

        // Assert
        Assert.NotEqual(default(SyntaxTokenList), result);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void PublicOverrideKeyword_Direct(bool withLeadingLineFeed, bool useTrailingSpace)
    {
        // Act
        var result = SyntaxTokenListFactory.PublicOverrideKeyword(withLeadingLineFeed, useTrailingSpace);

        // Assert
        Assert.NotEqual(default(SyntaxTokenList), result);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void PublicAsyncKeyword_Direct(bool withLeadingLineFeed, bool useTrailingSpace)
    {
        // Act
        var result = SyntaxTokenListFactory.PublicAsyncKeyword(withLeadingLineFeed, useTrailingSpace);

        // Assert
        Assert.NotEqual(default(SyntaxTokenList), result);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void InternalStaticKeyword_Direct(bool withLeadingLineFeed, bool useTrailingSpace)
    {
        // Act
        var result = SyntaxTokenListFactory.InternalStaticKeyword(withLeadingLineFeed, useTrailingSpace);

        // Assert
        Assert.NotEqual(default(SyntaxTokenList), result);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void ProtectedStaticKeyword_Direct(bool withLeadingLineFeed, bool useTrailingSpace)
    {
        // Act
        var result = SyntaxTokenListFactory.ProtectedStaticKeyword(withLeadingLineFeed, useTrailingSpace);

        // Assert
        Assert.NotEqual(default(SyntaxTokenList), result);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void ProtectedReadOnlyKeyword_Direct(bool withLeadingLineFeed, bool useTrailingSpace)
    {
        // Act
        var result = SyntaxTokenListFactory.ProtectedReadOnlyKeyword(withLeadingLineFeed, useTrailingSpace);

        // Assert
        Assert.NotEqual(default(SyntaxTokenList), result);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void PrivateReadonlyKeyword_Direct(bool withLeadingLineFeed)
    {
        // Act
        var result = SyntaxTokenListFactory.PrivateReadonlyKeyword(withLeadingLineFeed);

        // Assert
        Assert.NotEqual(default(SyntaxTokenList), result);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void PrivateAsyncKeyword_Direct(bool withLeadingLineFeed, bool useTrailingSpace)
    {
        // Act
        var result = SyntaxTokenListFactory.PrivateAsyncKeyword(withLeadingLineFeed, useTrailingSpace);

        // Assert
        Assert.NotEqual(default(SyntaxTokenList), result);
    }
}