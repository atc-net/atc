using Atc.CodeAnalysis.CSharp.Factories;
using SyntaxNodeExtensions = Microsoft.CodeAnalysis.CSharp.Syntax.SyntaxNodeExtensions;

namespace Atc.CodeAnalysis.CSharp.Tests;

public class CodeComplianceTests
{
    // ReSharper disable once NotAccessedField.Local
    private readonly ITestOutputHelper testOutputHelper;
    private readonly Assembly sourceAssembly = typeof(AtcCodeAnalysisCSharpTypeInitializer).Assembly;
    private readonly Assembly testAssembly = typeof(CodeComplianceTests).Assembly;

    private readonly List<Type> excludeTypes = new()
    {
        // TODO: Add UnitTest and remove from this list!!
        typeof(ClassDeclarationSyntaxExtensions),
        typeof(EnumDeclarationSyntaxExtensions),
        typeof(MethodDeclarationSyntaxExtensions),
        typeof(SyntaxNodeExtensions),
        typeof(InterfaceDeclarationSyntaxExtensions),
        typeof(CompilationUnitSyntaxExtensions),
        typeof(SuppressMessageAttributeFactory),
        typeof(SyntaxAccessorDeclarationFactory),
        typeof(SyntaxArgumentListFactory),
        typeof(SyntaxAssignmentExpressionFactory),
        typeof(SyntaxAttributeArgumentFactory),
        typeof(SyntaxAttributeArgumentListFactory),
        typeof(SyntaxAttributeFactory),
        typeof(SyntaxAttributeListFactory),
        typeof(SyntaxClassDeclarationFactory),
        typeof(SyntaxIfStatementFactory),
        typeof(SyntaxInterfaceDeclarationFactory),
        typeof(SyntaxInterpolatedFactory),
        typeof(SyntaxMemberAccessExpressionFactory),
        typeof(SyntaxNameEqualsFactory),
        typeof(SyntaxObjectCreationExpressionFactory),
        typeof(SyntaxParameterFactory),
        typeof(SyntaxParameterListFactory),
        typeof(SyntaxThrowStatementFactory),
        typeof(SyntaxTokenFactory),
        typeof(SyntaxTokenListFactory),
        typeof(SyntaxTypeArgumentListFactory),
        typeof(SyntaxVariableDeclarationFactory),
    };

    public CodeComplianceTests(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void AssertExportedMethodsWithMissingTests_AbstractSyntaxTree()
    {
        // Act & Assert
        CodeComplianceTestHelper.AssertExportedMethodsWithMissingTests(
            DecompilerType.AbstractSyntaxTree,
            sourceAssembly,
            testAssembly,
            excludeTypes);
    }

    [Fact]
    public void AssertExportedMethodsWithMissingTests_MonoReflection()
    {
        // Act & Assert
        CodeComplianceTestHelper.AssertExportedMethodsWithMissingTests(
            DecompilerType.MonoReflection,
            sourceAssembly,
            testAssembly,
            excludeTypes);
    }

    [Fact]
    public void AssertExportedTypesWithMissingComments()
    {
        // Act & Assert
        CodeComplianceDocumentationHelper.AssertExportedTypesWithMissingComments(
            sourceAssembly);
    }

    [Fact]
    public void AssertExportedTypesWithWrongNaming()
    {
        // Act & Assert
        CodeComplianceHelper.AssertExportedTypesWithWrongDefinitions(
            sourceAssembly);
    }
}