using TaskExtensions = System.TaskExtensions;

namespace Atc.Tests;

public class CodeComplianceTests
{
    // ReSharper disable once NotAccessedField.Local
    private readonly ITestOutputHelper testOutputHelper;
    private readonly Assembly sourceAssembly = typeof(AtcAssemblyTypeInitializer).Assembly;
    private readonly Assembly testAssembly = typeof(CodeComplianceTests).Assembly;

    private readonly List<Type> excludeTypes = new()
    {
        // TODO: Add UnitTest and remove from this list!!
        typeof(AssemblyHelper),
        typeof(AppDomainExtensions),
        typeof(SemanticVersion),
        typeof(MathEx),
        typeof(JsonTypeDiscriminatorConverter<>),
        typeof(JsonSerializerOptionsFactory),
        typeof(JsonTimeSpanConverter),
        typeof(JsonDateTimeOffsetMinToNullConverter),
        typeof(JsonUnixDateTimeOffsetConverter),
        typeof(LoggerExtensions),
        typeof(FileHelper),
        typeof(FileHelper<>),
        typeof(ByteHelper),
        typeof(ByteExtensions),

        // UnitTests are made, but CodeCompliance test cannot detect this
        typeof(InternetBrowserHelper),
        typeof(FileInfoExtensions),
        typeof(HttpClientRequestResult<>),
        typeof(IsoCurrencySymbolAttribute),
        typeof(NetworkInformationHelper),
        typeof(ProcessExtensions),
        typeof(StringAttribute),
        typeof(TaskExtensions),
        typeof(ThreadExtensions),
        typeof(VersionExtensions),
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
        var excludeTypesForNaming = new List<Type>
        {
            typeof(CharExtensions),
            typeof(ByteExtensions),
            typeof(ByteSizeExtensions), // Extension parameter type should "normal" match the class name-prefix, but because of the code-grouping, it is ok.
        };

        // Act & Assert
        CodeComplianceHelper.AssertExportedTypesWithWrongDefinitions(
            sourceAssembly,
            excludeTypesForNaming);
    }
}