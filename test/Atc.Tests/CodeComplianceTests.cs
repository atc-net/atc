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
        typeof(AssemblyHelper),
        typeof(AppDomainExtensions),
        typeof(X509Certificate2Extensions),
        typeof(SemanticVersion),
        typeof(MathEx),
        typeof(JsonSerializerOptionsFactory),
        typeof(CultureInfoToLcidJsonConverter),
        typeof(CultureInfoToNameJsonConverter),
        typeof(DirectoryInfoToFullNameJsonConverter),
        typeof(FileInfoToFullNameJsonConverter),
        typeof(DateTimeOffsetMinToNullJsonConverter),
        typeof(InterfaceJsonConverter<>),
        typeof(ElementObjectJsonConverter),
        typeof(NumberToStringJsonConverter),
        typeof(TimeSpanJsonConverter),
        typeof(TypeDiscriminatorJsonConverter<>),
        typeof(UnixDateTimeOffsetJsonConverter),
        typeof(UriToAbsoluteUriJsonConverter),
        typeof(VersionJsonConverter),
        typeof(LoggerExtensions),
        typeof(FileHelper),
        typeof(FileHelper<>),
        typeof(ByteExtensions),
        typeof(StackTraceHelper),

        // UnitTests are made, but CodeCompliance test cannot detect this
        typeof(AsyncEnumerableFactory),
        typeof(EnumerableExtensions),
        typeof(EnumAtcExtensions),
        typeof(DynamicJson),
        typeof(EnumHelper),
        typeof(StringCaseFormatter),
        typeof(NumberHelper),
        typeof(InternetBrowserHelper),
        typeof(DictionaryExtensions),
        typeof(DirectoryInfoExtensions),
        typeof(FileInfoExtensions),
        typeof(HttpClientRequestResult<>),
        typeof(IsoCurrencySymbolAttribute),
        typeof(NetworkInformationHelper),
        typeof(DateTimeExtensions),
        typeof(DateTimeOffsetExtensions),
        typeof(ProcessExtensions),
        typeof(StringAttribute),
        typeof(System.TaskExtensions),
        typeof(ThreadExtensions),
        typeof(VersionExtensions),
        typeof(StringEnumMemberJsonConverter<>),
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