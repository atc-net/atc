namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxTokenFactoryKeywordsTests
{
    [Fact]
    public void AbstractKeyword_Should_Create_Abstract_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.AbstractKeyword();

        // Assert
        Assert.Equal(SyntaxKind.AbstractKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void PublicKeyword_Should_Create_Public_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.PublicKeyword();

        // Assert
        Assert.Equal(SyntaxKind.PublicKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void PrivateKeyword_Should_Create_Private_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.PrivateKeyword();

        // Assert
        Assert.Equal(SyntaxKind.PrivateKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void PartialKeyword_Should_Create_Partial_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.PartialKeyword();

        // Assert
        Assert.Equal(SyntaxKind.PartialKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void OverrideKeyword_Should_Create_Override_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.OverrideKeyword();

        // Assert
        Assert.Equal(SyntaxKind.OverrideKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void InternalKeyword_Should_Create_Internal_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.InternalKeyword();

        // Assert
        Assert.Equal(SyntaxKind.InternalKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void ProtectedKeyword_Should_Create_Protected_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.ProtectedKeyword();

        // Assert
        Assert.Equal(SyntaxKind.ProtectedKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void StaticKeyword_Should_Create_Static_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.StaticKeyword();

        // Assert
        Assert.Equal(SyntaxKind.StaticKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void AsyncKeyword_Should_Create_Async_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.AsyncKeyword();

        // Assert
        Assert.Equal(SyntaxKind.AsyncKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void ReadOnlyKeyword_Should_Create_ReadOnly_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.ReadOnlyKeyword();

        // Assert
        Assert.Equal(SyntaxKind.ReadOnlyKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void NewKeyword_Should_Create_New_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.NewKeyword();

        // Assert
        Assert.Equal(SyntaxKind.NewKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void DefaultKeyword_Should_Create_Default_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.DefaultKeyword();

        // Assert
        Assert.Equal(SyntaxKind.DefaultKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void ImplicitKeyword_Should_Create_Implicit_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.ImplicitKeyword();

        // Assert
        Assert.Equal(SyntaxKind.ImplicitKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void OperatorKeyword_Should_Create_Operator_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.OperatorKeyword();

        // Assert
        Assert.Equal(SyntaxKind.OperatorKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void StringKeyword_Should_Create_String_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.StringKeyword();

        // Assert
        Assert.Equal(SyntaxKind.StringKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void IntKeyword_Should_Create_Int_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.IntKeyword();

        // Assert
        Assert.Equal(SyntaxKind.IntKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void DoubleKeyword_Should_Create_Double_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.DoubleKeyword();

        // Assert
        Assert.Equal(SyntaxKind.DoubleKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void VoidKeyword_Should_Create_Void_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.VoidKeyword();

        // Assert
        Assert.Equal(SyntaxKind.VoidKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void ObjectKeyword_Should_Create_Object_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.ObjectKeyword();

        // Assert
        Assert.Equal(SyntaxKind.ObjectKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Fact]
    public void ByteKeyword_Should_Create_Byte_Keyword_With_Trailing_Space_By_Default()
    {
        // Act
        var result = SyntaxTokenFactory.ByteKeyword();

        // Assert
        Assert.Equal(SyntaxKind.ByteKeyword, result.Kind());
        Assert.NotEmpty(result.TrailingTrivia);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void AbstractKeyword_With_TrailingSpace_Parameter(
        bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.AbstractKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.AbstractKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void PublicKeyword_With_TrailingSpace_Parameter(
        bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.PublicKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.PublicKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void PrivateKeyword_With_TrailingSpace_Parameter(
        bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.PrivateKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.PrivateKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void PartialKeyword_With_TrailingSpace_Parameter(
        bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.PartialKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.PartialKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void OverrideKeyword_With_TrailingSpace_Parameter(
        bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.OverrideKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.OverrideKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void InternalKeyword_With_TrailingSpace_Parameter(
        bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.InternalKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.InternalKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ProtectedKeyword_With_TrailingSpace_Parameter(
        bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.ProtectedKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.ProtectedKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void StaticKeyword_With_TrailingSpace_Parameter(
        bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.StaticKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.StaticKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void AsyncKeyword_With_TrailingSpace_Parameter(
        bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.AsyncKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.AsyncKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ReadOnlyKeyword_With_TrailingSpace_Parameter(
        bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.ReadOnlyKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.ReadOnlyKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void NewKeyword_With_TrailingSpace_Parameter(bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.NewKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.NewKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void DefaultKeyword_With_TrailingSpace_Parameter(
        bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.DefaultKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.DefaultKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ImplicitKeyword_With_TrailingSpace_Parameter(
        bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.ImplicitKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.ImplicitKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void OperatorKeyword_With_TrailingSpace_Parameter(
        bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.OperatorKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.OperatorKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void StringKeyword_With_TrailingSpace_Parameter(
        bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.StringKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.StringKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void IntKeyword_With_TrailingSpace_Parameter(bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.IntKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.IntKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void DoubleKeyword_With_TrailingSpace_Parameter(
        bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.DoubleKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.DoubleKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void VoidKeyword_With_TrailingSpace_Parameter(bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.VoidKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.VoidKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ObjectKeyword_With_TrailingSpace_Parameter(
        bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.ObjectKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.ObjectKeyword, result.Kind());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ByteKeyword_With_TrailingSpace_Parameter(bool withTrailingSpace)
    {
        var result = SyntaxTokenFactory.ByteKeyword(withTrailingSpace);
        Assert.Equal(SyntaxKind.ByteKeyword, result.Kind());
    }
}