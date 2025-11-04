namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxObjectCreationExpressionFactoryTests
{
    [Fact]
    public void Create_Should_Throw_When_IdentifierName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxObjectCreationExpressionFactory.Create((string)null!));
    }

    [Fact]
    public void Create_Should_Create_Object_Creation_Expression()
    {
        // Arrange
        const string identifierName = "TestClass";

        // Act
        var result = SyntaxObjectCreationExpressionFactory.Create(identifierName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(identifierName, result.Type.ToString(), StringComparer.Ordinal);
    }

    [Fact]
    public void Create_With_Namespace_Should_Throw_When_NamespaceName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxObjectCreationExpressionFactory.Create(null!, "TestClass"));
    }

    [Fact]
    public void Create_With_Namespace_Should_Throw_When_IdentifierName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxObjectCreationExpressionFactory.Create("System", null!));
    }

    [Fact]
    public void Create_With_Namespace_Should_Create_Object_Creation_Expression_With_Namespace()
    {
        // Arrange
        const string namespaceName = "System";
        const string identifierName = "Exception";

        // Act
        var result = SyntaxObjectCreationExpressionFactory.Create(namespaceName, identifierName);

        // Assert
        Assert.NotNull(result);
        var typeName = result.Type.ToString();
        Assert.Contains(namespaceName, typeName, StringComparison.Ordinal);
        Assert.Contains(identifierName, typeName, StringComparison.Ordinal);
    }
}