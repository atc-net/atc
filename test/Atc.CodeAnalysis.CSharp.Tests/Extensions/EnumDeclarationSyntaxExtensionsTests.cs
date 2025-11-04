namespace Atc.CodeAnalysis.CSharp.Tests.Extensions;

public class EnumDeclarationSyntaxExtensionsTests
{
    [Fact]
    public void AddSuppressMessageAttribute_Should_Throw_When_EnumDeclaration_Is_Null()
    {
        // Arrange
        EnumDeclarationSyntax enumDeclaration = null!;
        var suppressMessage = new SuppressMessageAttribute("Design", "CA1000");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            enumDeclaration.AddSuppressMessageAttribute(suppressMessage));
    }

    [Fact]
    public void AddSuppressMessageAttribute_Should_Throw_When_SuppressMessage_Is_Null()
    {
        // Arrange
        var enumDeclaration = SyntaxFactory.EnumDeclaration("TestEnum");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            enumDeclaration.AddSuppressMessageAttribute(null!));
    }

    [Fact]
    public void AddSuppressMessageAttribute_Should_Throw_When_Justification_Is_Null()
    {
        // Arrange
        var enumDeclaration = SyntaxFactory.EnumDeclaration("TestEnum");
        var suppressMessage = new SuppressMessageAttribute("Design", "CA1000");

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
            enumDeclaration.AddSuppressMessageAttribute(suppressMessage));
        Assert.Contains("Justification is invalid", exception.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void AddSuppressMessageAttribute_Should_Add_Attribute_With_Justification()
    {
        // Arrange
        var enumDeclaration = SyntaxFactory.EnumDeclaration("TestEnum");
        var suppressMessage = new SuppressMessageAttribute("Design", "CA1000")
        {
            Justification = "Test justification",
        };

        // Act
        var result = enumDeclaration.AddSuppressMessageAttribute(suppressMessage);

        // Assert
        Assert.NotNull(result);
        var attributeLists = result.AttributeLists;
        Assert.Single(attributeLists);
        var attribute = attributeLists[0].Attributes[0];
        Assert.Equal("SuppressMessage", attribute.Name.ToString(), StringComparer.Ordinal);
        Assert.NotNull(attribute.ArgumentList);
        Assert.Equal(3, attribute.ArgumentList.Arguments.Count);
    }

    [Fact]
    public void AddFlagAttribute_Should_Throw_When_EnumDeclaration_Is_Null()
    {
        // Arrange
        EnumDeclarationSyntax enumDeclaration = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            enumDeclaration.AddFlagAttribute());
    }

    [Fact]
    public void AddFlagAttribute_Should_Add_Flags_Attribute()
    {
        // Arrange
        var enumDeclaration = SyntaxFactory.EnumDeclaration("TestEnum");

        // Act
        var result = enumDeclaration.AddFlagAttribute();

        // Assert
        Assert.NotNull(result);
        var attributeLists = result.AttributeLists;
        Assert.Single(attributeLists);
        var attribute = attributeLists[0].Attributes[0];
        Assert.Equal("Flags", attribute.Name.ToString(), StringComparer.Ordinal);
    }

    [Fact]
    public void HasAttributeOfAttributeType_Should_Throw_When_AttributeType_Is_Null()
    {
        // Arrange
        var enumDeclaration = SyntaxFactory.EnumDeclaration("TestEnum");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            enumDeclaration.HasAttributeOfAttributeType(null!));
    }

    [Fact]
    public void HasAttributeOfAttributeType_Should_Return_False_When_No_Attributes()
    {
        // Arrange
        var enumDeclaration = SyntaxFactory.EnumDeclaration("TestEnum");

        // Act
        var result = enumDeclaration.HasAttributeOfAttributeType(typeof(FlagsAttribute));

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void HasAttributeOfAttributeType_Should_Return_True_When_Attribute_Exists()
    {
        // Arrange
        var enumDeclaration = SyntaxFactory.EnumDeclaration("TestEnum")
            .AddAttributeLists(
                SyntaxFactory.AttributeList(
                    SyntaxFactory.SingletonSeparatedList(
                        SyntaxFactory.Attribute(SyntaxFactory.IdentifierName("Flags")))));

        // Act
        var result = enumDeclaration.HasAttributeOfAttributeType(typeof(FlagsAttribute));

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasAttributeOfAttributeType_Direct()
    {
        // Arrange
        var enumDeclaration = SyntaxFactory.EnumDeclaration("TestEnum")
            .AddFlagAttribute();
        var attributeType = typeof(FlagsAttribute);

        // Act
        var result = enumDeclaration.HasAttributeOfAttributeType(attributeType);

        // Assert
        Assert.True(result);
    }
}