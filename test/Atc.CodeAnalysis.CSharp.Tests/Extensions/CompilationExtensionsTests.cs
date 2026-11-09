namespace Atc.CodeAnalysis.CSharp.Tests.Extensions;

public class CompilationExtensionsTests
{
    private static readonly AssemblyName CoreLibrary = typeof(object).Assembly.GetName();

    [Fact]
    public void References_Should_Throw_When_Compilation_Is_Null()
    {
        // Arrange
        Compilation compilation = null!;

        // Act
        var act = () => compilation.References("System.Runtime");

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void References_Should_Throw_When_AssemblyName_Is_Null()
    {
        // Arrange
        var compilation = CreateCompilation();

        // Act
        var act = () => compilation.References(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void References_Should_Match_Referenced_Assembly_Ignoring_Case()
    {
        // Arrange
        var compilation = CreateCompilation();

        // Act & Assert
        compilation.References(CoreLibrary.Name!).Should().BeTrue();
        compilation.References(CoreLibrary.Name!.ToUpperInvariant()).Should().BeTrue();
    }

    [Theory]
    [InlineData("Microsoft.AspNetCore.Http.Abstractions")]
    [InlineData("System")]
    [InlineData("")]
    public void References_Should_Be_False_When_Not_Referenced(
        string assemblyName)
    {
        // Arrange
        var compilation = CreateCompilation();

        // Act
        var actual = compilation.References(assemblyName);

        // Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReferencesAnyStartingWith_Should_Throw_When_Compilation_Is_Null()
    {
        // Arrange
        Compilation compilation = null!;

        // Act
        var act = () => compilation.ReferencesAnyStartingWith("System");

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ReferencesAnyStartingWith_Should_Throw_When_Prefix_Is_Null()
    {
        // Arrange
        var compilation = CreateCompilation();

        // Act
        var act = () => compilation.ReferencesAnyStartingWith(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData("System", true)]
    [InlineData("system.", true)]
    [InlineData("Microsoft.AspNetCore", false)]
    public void ReferencesAnyStartingWith_Should_Match_Prefix_Ignoring_Case(
        string prefix,
        bool expected)
    {
        // Arrange
        var compilation = CreateCompilation();

        // Act
        var actual = compilation.ReferencesAnyStartingWith(prefix);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void ReferencesAnyStartingWith_Should_Be_False_Without_References()
    {
        // Arrange
        var compilation = CSharpCompilation.Create("Empty");

        // Act
        var actual = compilation.ReferencesAnyStartingWith(string.Empty);

        // Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void VersionOf_Should_Throw_When_Compilation_Is_Null()
    {
        // Arrange
        Compilation compilation = null!;

        // Act
        var act = () => compilation.VersionOf("System.Runtime");

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void VersionOf_Should_Throw_When_AssemblyName_Is_Null()
    {
        // Arrange
        var compilation = CreateCompilation();

        // Act
        var act = () => compilation.VersionOf(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void VersionOf_Should_Return_Version_Of_Referenced_Assembly()
    {
        // Arrange
        var compilation = CreateCompilation();

        // Act
        var actual = compilation.VersionOf(CoreLibrary.Name!.ToLowerInvariant());

        // Assert
        actual.Should().Be(CoreLibrary.Version);
    }

    [Fact]
    public void VersionOf_Should_Return_Null_When_Not_Referenced()
    {
        // Arrange
        var compilation = CreateCompilation();

        // Act
        var actual = compilation.VersionOf("Microsoft.AspNetCore.Http.Abstractions");

        // Assert
        actual.Should().BeNull();
    }

    private static CSharpCompilation CreateCompilation()
        => CSharpCompilation.Create(
            "Test",
            references: [MetadataReference.CreateFromFile(typeof(object).Assembly.Location)]);
}