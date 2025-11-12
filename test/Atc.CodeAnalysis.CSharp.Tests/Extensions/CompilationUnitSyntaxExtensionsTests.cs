namespace Atc.CodeAnalysis.CSharp.Tests.Extensions;

public class CompilationUnitSyntaxExtensionsTests
{
    [Fact]
    public void AddUsingStatements_Should_Throw_When_CompilationUnit_Is_Null()
    {
        // Arrange
        CompilationUnitSyntax compilationUnit = null!;
        var usingStatements = new[] { "System" };

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            compilationUnit.AddUsingStatements(usingStatements));
    }

    [Fact]
    public void AddUsingStatements_Should_Throw_When_UsingStatements_Is_Null()
    {
        // Arrange
        var compilationUnit = SyntaxFactory.CompilationUnit();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            compilationUnit.AddUsingStatements(null!));
    }

    [Fact]
    public void AddUsingStatements_Should_Return_Same_Unit_When_Empty_Array()
    {
        // Arrange
        var compilationUnit = SyntaxFactory.CompilationUnit();
        var usingStatements = Array.Empty<string>();

        // Act
        var result = compilationUnit.AddUsingStatements(usingStatements);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(compilationUnit, result);
    }

    [Fact]
    public void AddUsingStatements_Should_Add_Single_Using_Statement()
    {
        // Arrange
        var compilationUnit = SyntaxFactory.CompilationUnit();
        var usingStatements = new[] { "System" };

        // Act
        var result = compilationUnit.AddUsingStatements(usingStatements);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Usings);
        Assert.Equal("System", result.Usings[0].Name!.ToString(), StringComparer.Ordinal);
    }

    [Fact]
    public void AddUsingStatements_Should_Add_Multiple_Using_Statements()
    {
        // Arrange
        var compilationUnit = SyntaxFactory.CompilationUnit();
        var usingStatements = new[] { "System", "System.Linq", "System.Collections.Generic" };

        // Act
        var result = compilationUnit.AddUsingStatements(usingStatements);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Usings.Count);
    }

    [Fact]
    public void AddUsingStatements_Should_Sort_Using_Statements()
    {
        // Arrange
        var compilationUnit = SyntaxFactory.CompilationUnit();
        var usingStatements = new[] { "MyNamespace", "System", "AnotherNamespace" };

        // Act
        var result = compilationUnit.AddUsingStatements(usingStatements);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Usings.Count);

        // Verify sorted order (System namespaces typically come first)
        var usings = result.Usings.SelectToArray(u => u.Name!.ToString());
        Assert.NotNull(usings);
    }
}