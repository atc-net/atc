namespace Atc.CodeAnalysis.CSharp.Tests.Extensions;

public class SyntaxNodeExtensionsTests
{
    [Fact]
    public void Select_Should_Throw_When_SyntaxNode_Is_Null()
    {
        // Arrange
        SyntaxNode syntaxNode = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            syntaxNode.Select<ClassDeclarationSyntax>());
    }

    [Fact]
    public void Select_Should_Return_Empty_When_No_Matches()
    {
        // Arrange
        var syntaxNode = SyntaxFactory.CompilationUnit();

        // Act
        var result = syntaxNode.Select<ClassDeclarationSyntax>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Select_Should_Return_Matching_Nodes()
    {
        // Arrange
        var classDeclaration = SyntaxFactory.ClassDeclaration("TestClass");
        var syntaxNode = SyntaxFactory.CompilationUnit()
            .AddMembers(classDeclaration);

        // Act
        var result = syntaxNode.Select<ClassDeclarationSyntax>();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("TestClass", result.First().Identifier.Text, StringComparer.Ordinal);
    }

    [Fact]
    public void SelectToArray_Should_Throw_When_SyntaxNode_Is_Null()
    {
        // Arrange
        SyntaxNode syntaxNode = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            syntaxNode.SelectToArray<ClassDeclarationSyntax>());
    }

    [Fact]
    public void SelectToArray_Should_Return_Empty_Array_When_No_Matches()
    {
        // Arrange
        var syntaxNode = SyntaxFactory.CompilationUnit();

        // Act
        var result = syntaxNode.SelectToArray<ClassDeclarationSyntax>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void SelectToArray_Should_Return_Matching_Nodes_As_Array()
    {
        // Arrange
        var classDeclaration = SyntaxFactory.ClassDeclaration("TestClass");
        var syntaxNode = SyntaxFactory.CompilationUnit()
            .AddMembers(classDeclaration);

        // Act
        var result = syntaxNode.SelectToArray<ClassDeclarationSyntax>();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("TestClass", result[0].Identifier.Text, StringComparer.Ordinal);
    }

    [Fact]
    public void GetUsedUsingStatements_Should_Throw_When_SyntaxNode_Is_Null()
    {
        // Arrange
        SyntaxNode syntaxNode = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            syntaxNode.GetUsedUsingStatements());
    }

    [Fact]
    public void GetUsedUsingStatements_Should_Return_Empty_When_No_Usings()
    {
        // Arrange
        var syntaxNode = SyntaxFactory.CompilationUnit();

        // Act
        var result = syntaxNode.GetUsedUsingStatements();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void GetUsedUsingStatements_Should_Return_All_Using_Statements()
    {
        // Arrange
        var syntaxNode = SyntaxFactory
            .CompilationUnit()
            .AddUsings(
                SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System")),
                SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Linq")));

        // Act
        var result = syntaxNode.GetUsedUsingStatements();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.Contains("System", result, StringComparer.Ordinal);
        Assert.Contains("System.Linq", result, StringComparer.Ordinal);
    }

    [Fact]
    public void GetUsedUsingStatementsWithoutAlias_Should_Throw_When_SyntaxNode_Is_Null()
    {
        // Arrange
        SyntaxNode syntaxNode = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            syntaxNode.GetUsedUsingStatementsWithoutAlias());
    }

    [Fact]
    public void GetUsedUsingStatementsWithoutAlias_Should_Return_Empty_When_No_Usings()
    {
        // Arrange
        var syntaxNode = SyntaxFactory.CompilationUnit();

        // Act
        var result = syntaxNode.GetUsedUsingStatementsWithoutAlias();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void GetUsedUsingStatementsWithoutAlias_Should_Exclude_Aliased_Usings()
    {
        // Arrange
        var syntaxNode = SyntaxFactory
            .CompilationUnit()
            .AddUsings(
                SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System")),
                SyntaxFactory.UsingDirective(
                    SyntaxFactory.NameEquals("MyAlias"),
                    SyntaxFactory.ParseName("System.Collections.Generic")));

        // Act
        var result = syntaxNode.GetUsedUsingStatementsWithoutAlias();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Contains("System", result, StringComparer.Ordinal);
    }
}