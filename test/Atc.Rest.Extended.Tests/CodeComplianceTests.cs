using SwaggerGenOptionsExtensions = Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptionsExtensions;

namespace Atc.Rest.Extended.Tests;

public class CodeComplianceTests
{
    // ReSharper disable once NotAccessedField.Local
    private readonly ITestOutputHelper testOutputHelper;
    private readonly Assembly sourceAssembly = typeof(AtcRestExtendedAssemblyTypeInitializer).Assembly;
    private readonly Assembly testAssembly = typeof(CodeComplianceTests).Assembly;

    private readonly List<Type> excludeTypes = new()
    {
        // TODO: Add UnitTest and remove from this list!!
        typeof(ApiVersionDocumentFilter),
        typeof(ApiVersionOperationFilter),
        typeof(AuthorizeResponseOperationFilter),
        typeof(DefaultResponseOperationFilter),
        typeof(SecurityRequirementsOperationFilter),
        typeof(SwaggerEnumDescriptionsDocumentFilter),
        typeof(ConfigureAuthorizationOptions),
        typeof(ConfigureApiVersioningOptions),
        typeof(VersionErrorResponseProvider),
        typeof(OpenApiBuilderExtensions),
        typeof(RestApiExtendedBuilderExtensions),
        typeof(OperationFilterContextExtensions),
        typeof(FluentValidationExtensions),
        typeof(RestApiExtendedExtensions),
        typeof(SwaggerGenOptionsExtensions),
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