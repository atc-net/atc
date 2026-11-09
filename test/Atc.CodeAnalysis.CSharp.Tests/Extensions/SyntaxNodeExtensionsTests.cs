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

    [Fact]
    public void IsPartialClassWithAttribute_Should_Throw_When_SyntaxNode_Is_Null()
    {
        // Arrange
        SyntaxNode syntaxNode = null!;

        // Act
        var act = () => syntaxNode.IsPartialClassWithAttribute();

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData("[Foo] public partial class C { }", true)]
    [InlineData("[Foo, Bar] partial class C { }", true)]
    [InlineData("[Foo] public sealed partial class C { }", true)]
    [InlineData("public partial class C { }", false)]
    [InlineData("[Foo] public class C { }", false)]
    [InlineData("[Foo] public partial struct S { }", false)]
    [InlineData("[Foo] public partial record R;", false)]
    [InlineData("[Foo] public partial interface I { }", false)]
    public void IsPartialClassWithAttribute_Should_Return_Expected_Result(
        string code,
        bool expected)
    {
        // Arrange
        var syntaxNode = ParseFirstMember(code);

        // Act
        var actual = syntaxNode.IsPartialClassWithAttribute();

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void IsPartialClassWithAttribute_Should_Be_False_For_Other_Nodes()
    {
        // Arrange
        var syntaxNode = SyntaxFactory.ParseCompilationUnit("[Foo] public partial class C { }");

        // Act
        var actual = syntaxNode.IsPartialClassWithAttribute();

        // Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void IsPartialClassWithAttribute_With_AttributeName_Should_Throw_When_SyntaxNode_Is_Null()
    {
        // Arrange
        SyntaxNode syntaxNode = null!;

        // Act
        var act = () => syntaxNode.IsPartialClassWithAttribute("Foo");

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void IsPartialClassWithAttribute_With_AttributeName_Should_Throw_When_AttributeName_Is_Null()
    {
        // Arrange
        var syntaxNode = ParseFirstMember("[Foo] public partial class C { }");

        // Act
        var act = () => syntaxNode.IsPartialClassWithAttribute(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData("[Foo] public partial class C { }", "Foo", true)]
    [InlineData("[Foo] public partial class C { }", "FooAttribute", true)]
    [InlineData("[FooAttribute] public partial class C { }", "Foo", true)]
    [InlineData("[FooAttribute] public partial class C { }", "FooAttribute", true)]
    [InlineData("[My.Namespace.Foo] public partial class C { }", "Foo", true)]
    [InlineData("[global::My.Namespace.FooAttribute] public partial class C { }", "Foo", true)]
    [InlineData("[global::Foo] public partial class C { }", "Foo", true)]
    [InlineData("[Bar][Foo(1)] public partial class C { }", "Foo", true)]
    [InlineData("[Foo<int>] public partial class C { }", "Foo", true)]
    [InlineData("[Bar] public partial class C { }", "Foo", false)]
    [InlineData("[FooBar] public partial class C { }", "Foo", false)]
    [InlineData("[foo] public partial class C { }", "Foo", false)]
    [InlineData("[Foo] public class C { }", "Foo", false)]
    [InlineData("[Foo] public partial struct S { }", "Foo", false)]
    [InlineData("public partial class C { }", "Foo", false)]
    [InlineData("[Attribute] public partial class C { }", "Attribute", true)]
    public void IsPartialClassWithAttribute_With_AttributeName_Should_Return_Expected_Result(
        string code,
        string attributeName,
        bool expected)
    {
        // Arrange
        var syntaxNode = ParseFirstMember(code);

        // Act
        var actual = syntaxNode.IsPartialClassWithAttribute(attributeName);

        // Assert
        actual.Should().Be(expected);
    }

    private static SyntaxNode ParseFirstMember(string code)
        => SyntaxFactory
            .ParseCompilationUnit(code)
            .Members[0];
}