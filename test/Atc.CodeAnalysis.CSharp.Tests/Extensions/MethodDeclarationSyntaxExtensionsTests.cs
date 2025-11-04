namespace Atc.CodeAnalysis.CSharp.Tests.Extensions;

public class MethodDeclarationSyntaxExtensionsTests
{
    [Fact]
    public void AddSuppressMessageAttribute_Should_Throw_When_MethodDeclaration_Is_Null()
    {
        // Arrange
        MethodDeclarationSyntax methodDeclaration = null!;
        var suppressMessage = new SuppressMessageAttribute("Design", "CA1000");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            methodDeclaration.AddSuppressMessageAttribute(suppressMessage));
    }

    [Fact]
    public void AddSuppressMessageAttribute_Should_Throw_When_SuppressMessage_Is_Null()
    {
        // Arrange
        var methodDeclaration = SyntaxFactory.MethodDeclaration(
            SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)),
            "TestMethod");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            methodDeclaration.AddSuppressMessageAttribute(null!));
    }

    [Fact]
    public void AddSuppressMessageAttribute_Should_Throw_When_Justification_Is_Null()
    {
        // Arrange
        var methodDeclaration = SyntaxFactory.MethodDeclaration(
            SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)),
            "TestMethod");
        var suppressMessage = new SuppressMessageAttribute("Design", "CA1000");

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
            methodDeclaration.AddSuppressMessageAttribute(suppressMessage));
        Assert.Contains("Justification is invalid", exception.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void AddSuppressMessageAttribute_Should_Add_Attribute_With_Justification()
    {
        // Arrange
        var methodDeclaration = SyntaxFactory.MethodDeclaration(
            SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)),
            "TestMethod");
        var suppressMessage = new SuppressMessageAttribute("Design", "CA1000")
        {
            Justification = "Test justification",
        };

        // Act
        var result = methodDeclaration.AddSuppressMessageAttribute(suppressMessage);

        // Assert
        Assert.NotNull(result);
        var attributeLists = result.AttributeLists;
        Assert.Single(attributeLists);
        var attribute = attributeLists[0].Attributes[0];
        Assert.Equal("SuppressMessage", attribute.Name.ToString(), StringComparer.Ordinal);
        Assert.NotNull(attribute.ArgumentList);
        Assert.Equal(3, attribute.ArgumentList.Arguments.Count);
    }
}