// ReSharper disable ConstantNullCoalescingCondition
namespace Atc.Rest.Options;

/// <summary>
/// Configuration options for the REST API framework.
/// </summary>
/// <remarks>
/// This class provides comprehensive configuration for REST API services including:
/// <list type="bullet">
/// <item>Authentication and authorization</item>
/// <item>Application Insights telemetry</item>
/// <item>Service auto-registration</item>
/// <item>JSON serialization behavior</item>
/// <item>Error handling and logging</item>
/// <item>HTTPS requirements</item>
/// </list>
/// </remarks>
public class RestApiOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether to allow anonymous access in Development environment.
    /// </summary>
    public bool AllowAnonymousAccessForDevelopment { get; set; } = true;

    /// <summary>
    /// Gets or sets the authorization configuration for JWT authentication.
    /// </summary>
    public AuthorizationOptions? Authorization { get; set; } = new();

    /// <summary>
    /// Gets or sets a value indicating whether to enable Application Insights telemetry.
    /// </summary>
    public bool UseApplicationInsights { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to automatically register services from assembly pairs.
    /// </summary>
    public bool UseAutoRegistrateServices { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to serialize enums as strings instead of integers.
    /// </summary>
    public bool UseEnumAsStringInSerialization { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to register <see cref="IHttpContextAccessor"/> for accessing HTTP context.
    /// </summary>
    public bool UseHttpContextAccessor { get; set; } = true;

    /// <summary>
    /// Gets or sets the error handling exception filter configuration.
    /// </summary>
    public RestApiOptionsErrorHandlingExceptionFilter ErrorHandlingExceptionFilter { get; set; } = new();

    /// <summary>
    /// Gets or sets a value indicating whether to require HTTPS permanently (adds HSTS header).
    /// </summary>
    public bool UseRequireHttpsPermanent { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to ignore null values during JSON serialization.
    /// </summary>
    public bool UseJsonSerializerOptionsIgnoreNullValues { get; set; } = true;

    /// <summary>
    /// Gets or sets the JSON property naming convention (CamelCase or PascalCase).
    /// </summary>
    public CasingStyle JsonSerializerCasingStyle { get; set; } = CasingStyle.CamelCase;

    /// <summary>
    /// Gets or sets a value indicating whether to validate that all interfaces in API assemblies are registered.
    /// </summary>
    public bool UseValidateServiceRegistrations { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to enable request/response logging middleware.
    /// </summary>
    public bool EnableRequestResponseLogger { get; set; }

    /// <summary>
    /// Gets or sets the request/response logger configuration options.
    /// </summary>
    public RequestResponseLoggerOptions RequestResponseLoggerOptions { get; set; } = new();

    /// <summary>
    /// Gets or sets the collection of assembly pairs for service registration and API specification loading.
    /// </summary>
    [SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "OK.")]
    public List<AssemblyPairOptions> AssemblyPairs { get; set; } = new();

    /// <summary>
    /// Adds an assembly pair to the collection for service registration.
    /// </summary>
    /// <param name="apiAssembly">The API assembly containing interfaces.</param>
    /// <param name="domainAssembly">The domain assembly containing implementations.</param>
    public void AddAssemblyPairs(
        Assembly? apiAssembly,
        Assembly? domainAssembly)
    {
        ArgumentNullException.ThrowIfNull(apiAssembly);
        ArgumentNullException.ThrowIfNull(domainAssembly);

        AssemblyPairs ??= new List<AssemblyPairOptions>();
        AssemblyPairs.Add(new AssemblyPairOptions(apiAssembly, domainAssembly));
    }
}