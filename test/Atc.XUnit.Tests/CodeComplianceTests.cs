namespace Atc.XUnit.Tests;

public class CodeComplianceTests
{
    // ReSharper disable once NotAccessedField.Local
    private readonly ITestOutputHelper testOutputHelper;
    private readonly Assembly sourceAssembly = typeof(AtcXUnitAssemblyTypeInitializer).Assembly;
    private readonly Assembly testAssembly = typeof(CodeComplianceTests).Assembly;

    private readonly List<Type> excludeTypes = new()
    {
        // TODO: Add UnitTest and remove from this list!!
        typeof(CodeComplianceDocumentationHelper),
        typeof(CodeComplianceHelper),
        typeof(CodeComplianceTestHelper),
        typeof(DocumentationHelper),
        typeof(MarkdownCodeDocGenerator),
        typeof(TestResultHelper),
        typeof(SerializeAndDeserializeHelper),
        typeof(XUnitLogger),
        typeof(XUnitLoggerProvider),
        typeof(AssemblyLocalizationResourcesHelper),
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

    [Fact]
    public void AssertExportedTypesWithWrongDefinitions_TypeOverload_DoesNotThrow_ForCompliantType()
    {
        // Act & Assert - this type is compliant, so the method should not throw
        CodeComplianceHelper.AssertExportedTypesWithWrongDefinitions(
            typeof(CodeComplianceHelper));
    }

    [Fact]
    public void AssertExportedTypesWithWrongDefinitions_TypeOverload_Throws_OnNullType()
    {
        // Act
        var act = () => CodeComplianceHelper.AssertExportedTypesWithWrongDefinitions(
            type: null!);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("type");
    }
}