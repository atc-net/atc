namespace Atc.Tests;

public class CodeComplianceTests
{
    // ReSharper disable once NotAccessedField.Local
    private readonly ITestOutputHelper testOutputHelper;
    private readonly Assembly sourceAssembly = typeof(AtcAssemblyTypeInitializer).Assembly;
    private readonly Assembly testAssembly = typeof(CodeComplianceTests).Assembly;
    private readonly List<string> supportedCultureNames = new()
    {
        "da-DK",
        "de-DE",
    };

    private readonly List<Type> excludeTypes = new()
    {
        // TODO: Add UnitTest and remove from this list!!
        typeof(FileHelper<>), // AST/MonoReflection limitations with generic class method detection
        typeof(StackTraceHelper), // MonoReflection has limitations detecting property getter/setter test calls
        typeof(FileHelper), // AST/MonoReflection limitations with async methods and default parameters
        typeof(LoggerExtensions), // MonoReflection has limitations with extension method detection
        typeof(CultureInfoToLcidJsonConverter), // JsonConverter override methods with ref parameters
        typeof(CultureInfoToNameJsonConverter), // JsonConverter override methods with ref parameters
        typeof(DirectoryInfoToFullNameJsonConverter), // JsonConverter override methods with ref parameters
        typeof(FileInfoToFullNameJsonConverter), // JsonConverter override methods with ref parameters
        typeof(DateTimeOffsetMinToNullJsonConverter), // JsonConverter override methods with ref parameters
        typeof(InterfaceJsonConverter<>), // JsonConverter override methods with ref parameters
        typeof(ElementObjectJsonConverter), // JsonConverter override methods with ref parameters
        typeof(NumberToStringJsonConverter), // JsonConverter override methods with ref parameters
        typeof(TimeSpanJsonConverter), // JsonConverter override methods with ref parameters
        typeof(TypeDiscriminatorJsonConverter<>), // JsonConverter override methods with ref parameters
        typeof(UnixDateTimeOffsetJsonConverter), // JsonConverter override methods with ref parameters
        typeof(UriToAbsoluteUriJsonConverter), // JsonConverter override methods with ref parameters
        typeof(VersionJsonConverter), // JsonConverter override methods with ref parameters
        typeof(System.TypeExtensions),
        typeof(AsyncEnumerableFactory),
        typeof(ByteExtensions),
        typeof(EnumerableExtensions),
        typeof(StringCaseFormatter), // AST has limitations with IFormatProvider/ICustomFormatter interface method detection
        typeof(DictionaryExtensions), // Both AST & MonoReflection have limitations detecting lambdas with unused parameters (2/4 methods work)
        typeof(DirectoryInfoExtensions), // AST has limitations with params array detection
        typeof(FileInfoExtensions), // MonoReflection has limitations with async state machine detection
        typeof(HttpClientRequestResult<>), // Both AST & MonoReflection have limitations matching method calls on generic type instances back to generic type definitions
        typeof(DateTimeExtensions), // AST has limitations with DateTimeFormatInfo parameter detection
        typeof(DateTimeOffsetExtensions), // AST has limitations with DateTimeFormatInfo parameter detection
        typeof(ProcessExtensions),
        typeof(System.TaskExtensions),
        typeof(ThreadExtensions),
        typeof(StringEnumMemberJsonConverter<>),
        typeof(NumberHelper), // AST has limitations with certain out-parameter patterns; MonoReflection validates 100%
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
            typeof(EnumAtcExtensions),
            typeof(CharExtensions),
            typeof(ByteExtensions),
            typeof(ByteSizeExtensions), // Extension parameter type should "normal" match the class name-prefix, but because of the code-grouping, it is ok.
        };

        // Act & Assert
        CodeComplianceHelper.AssertExportedTypesWithWrongDefinitions(
            sourceAssembly,
            excludeTypesForNaming);
    }

    [Fact]
    public void AssertLocalizationResources()
    {
        // Arrange
        var allowSuffixTermsForKeySuffixWithPlaceholders = new List<string>
        {
            "AsAbbreviation",
        };

        // Act & Assert
        CodeComplianceHelper.AssertLocalizationResources(
            sourceAssembly,
            supportedCultureNames,
            allowSuffixTermsForKeySuffixWithPlaceholders);
    }

    [Fact]
    public void AssertLocalizationResourcesForMissingTranslations()
    {
        // Act & Assert
        CodeComplianceHelper.AssertLocalizationResourcesForMissingTranslations(
            sourceAssembly,
            supportedCultureNames);
    }

    [Fact]
    public void AssertLocalizationResourcesForInvalidKeysSuffixWithPlaceholders()
    {
        // Arrange
        var allowSuffixTermsForKeySuffixWithPlaceholders = new List<string>
        {
            "AsAbbreviation",
        };

        // Act & Assert
        CodeComplianceHelper.AssertLocalizationResourcesForInvalidKeysSuffixWithPlaceholders(
            sourceAssembly,
            supportedCultureNames,
            allowSuffixTermsForKeySuffixWithPlaceholders);
    }
}