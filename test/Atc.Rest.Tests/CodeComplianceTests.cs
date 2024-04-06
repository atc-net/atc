namespace Atc.Rest.Tests;

public class CodeComplianceTests
{
    // ReSharper disable once NotAccessedField.Local
    private readonly ITestOutputHelper testOutputHelper;
    private readonly Assembly sourceAssembly = typeof(AtcRestAssemblyTypeInitializer).Assembly;
    private readonly Assembly testAssembly = typeof(CodeComplianceTests).Assembly;

    private readonly List<Type> excludeTypes = new()
    {
        // TODO: Add UnitTest and remove from this list!!
        typeof(EndpointRouteBuilderExExtensions),
        typeof(ExceptionTelemetryMiddleware),
        typeof(RequestResponseLoggerMiddleware),
        typeof(RequestResponseLogModel),
        typeof(HttpResponseMessageExtensions),
        typeof(KeepAliveMiddleware),
        typeof(RequestCorrelationMiddleware),
        typeof(AllowAnonymousAccessForDevelopmentHandler),
        typeof(ConfigureApiBehaviorOptions),
        typeof(RestApiOptions),
        typeof(Accept4xxResponseAsSuccessInitializer),
        typeof(CallingIdentityTelemetryInitializer),
        typeof(RestApiBuilderExtensions),
        typeof(AnonymousAccessExtensions),
        typeof(HttpContextExExtensions),
        typeof(ErrorHandlingExceptionFilterAttribute),
        typeof(RestApiExtensions),
        typeof(ServiceCollectionExtensions),
        typeof(HttpRequestExExtensions),
        typeof(ResultFactory),
        typeof(AuthorizationOptions),
        typeof(ProblemDetailsHelper),

        // UnitTests are made, but CodeCompliance test cannot detect this
        typeof(FormFileExtensions),
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