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
            SyntaxObjectCreationExpressionFactory.Create("System", (string)null!));
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

    [Fact]
    public void Create_With_ArgumentList_Should_Throw_When_IdentifierName_Is_Null()
    {
        // Arrange
        var argumentList = SyntaxFactory.ArgumentList();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxObjectCreationExpressionFactory.Create((string)null!, argumentList));
    }

    [Fact]
    public void Create_With_ArgumentList_Should_Throw_When_ArgumentList_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxObjectCreationExpressionFactory.Create("TestClass", (ArgumentListSyntax)null!));
    }

    [Fact]
    public void Create_With_ArgumentList_Should_Create_Object_Creation_Expression_With_Arguments()
    {
        // Arrange
        const string identifierName = "TestClass";
        var argumentList = SyntaxFactory.ArgumentList();

        // Act
        var result = SyntaxObjectCreationExpressionFactory.Create(identifierName, argumentList);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(identifierName, result.Type.ToString(), StringComparer.Ordinal);
        Assert.NotNull(result.ArgumentList);
    }

    [Fact]
    public void Create_With_Namespace_And_ArgumentList_Should_Create_Expression_With_Arguments()
    {
        // Arrange
        const string namespaceName = "System";
        const string identifierName = "Exception";
        var argumentList = SyntaxFactory.ArgumentList();

        // Act
        var result = SyntaxObjectCreationExpressionFactory.Create(namespaceName, identifierName, argumentList);

        // Assert
        Assert.NotNull(result);
        var typeName = result.Type.ToString();
        Assert.Contains(namespaceName, typeName, StringComparison.Ordinal);
        Assert.Contains(identifierName, typeName, StringComparison.Ordinal);
        Assert.NotNull(result.ArgumentList);
    }

    [Fact]
    public void CreateGeneric_With_TypeArgumentList_Should_Create_Generic_Expression()
    {
        // Arrange
        const string identifierName = "List";
        var typeArgumentList = SyntaxFactory.TypeArgumentList(
            SyntaxFactory.SeparatedList<TypeSyntax>(new[]
            {
                SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.StringKeyword)),
            }));

        // Act
        var result = SyntaxObjectCreationExpressionFactory.CreateGeneric(identifierName, typeArgumentList);

        // Assert
        Assert.NotNull(result);
        Assert.Contains("List", result.Type.ToString(), StringComparison.Ordinal);
        Assert.Contains("string", result.Type.ToString(), StringComparison.Ordinal);
    }

    [Fact]
    public void CreateGeneric_With_TypeArgumentName_Should_Create_Generic_Expression()
    {
        // Arrange
        const string identifierName = "List";
        const string typeArgumentName = "MyType";

        // Act
        var result = SyntaxObjectCreationExpressionFactory.CreateGeneric(identifierName, typeArgumentName);

        // Assert
        Assert.NotNull(result);
        Assert.Contains(identifierName, result.Type.ToString(), StringComparison.Ordinal);
        Assert.Contains(typeArgumentName, result.Type.ToString(), StringComparison.Ordinal);
    }

    [Fact]
    public void CreateGeneric_With_TypeArgumentList_And_ArgumentList_Should_Create_Generic_Expression_With_Arguments()
    {
        // Arrange
        const string identifierName = "Dictionary";
        var typeArgumentList = SyntaxFactory.TypeArgumentList(
            SyntaxFactory.SeparatedList<TypeSyntax>(new[]
            {
                SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.StringKeyword)),
                SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.IntKeyword)),
            }));
        var argumentList = SyntaxFactory.ArgumentList();

        // Act
        var result = SyntaxObjectCreationExpressionFactory.CreateGeneric(identifierName, typeArgumentList, argumentList);

        // Assert
        Assert.NotNull(result);
        Assert.Contains(identifierName, result.Type.ToString(), StringComparison.Ordinal);
        Assert.NotNull(result.ArgumentList);
    }

    [Fact]
    public void CreateGeneric_With_TypeArgumentName_And_ArgumentList_Should_Create_Generic_Expression_With_Arguments()
    {
        // Arrange
        const string identifierName = "List";
        const string typeArgumentName = "MyType";
        var argumentList = SyntaxFactory.ArgumentList();

        // Act
        var result = SyntaxObjectCreationExpressionFactory.CreateGeneric(identifierName, typeArgumentName, argumentList);

        // Assert
        Assert.NotNull(result);
        Assert.Contains(identifierName, result.Type.ToString(), StringComparison.Ordinal);
        Assert.Contains(typeArgumentName, result.Type.ToString(), StringComparison.Ordinal);
        Assert.NotNull(result.ArgumentList);
    }
}