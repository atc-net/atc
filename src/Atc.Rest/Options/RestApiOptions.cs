// ReSharper disable ConstantNullCoalescingCondition
namespace Atc.Rest.Options;

public class RestApiOptions
{
    public bool AllowAnonymousAccessForDevelopment { get; set; } = true;

    public AuthorizationOptions? Authorization { get; set; } = new();

    public bool UseApplicationInsights { get; set; } = true;

    public bool UseAutoRegistrateServices { get; set; } = true;

    public bool UseEnumAsStringInSerialization { get; set; } = true;

    public bool UseHttpContextAccessor { get; set; } = true;

    public RestApiOptionsErrorHandlingExceptionFilter ErrorHandlingExceptionFilter { get; set; } = new();

    public bool UseRequireHttpsPermanent { get; set; } = true;

    public bool UseJsonSerializerOptionsIgnoreNullValues { get; set; } = true;

    public CasingStyle JsonSerializerCasingStyle { get; set; } = CasingStyle.CamelCase;

    public bool UseValidateServiceRegistrations { get; set; } = true;

    public bool EnableRequestResponseLogger { get; set; }

    public RequestResponseLoggerOptions RequestResponseLoggerOptions { get; set; } = new();

    [SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "OK.")]
    public List<AssemblyPairOptions> AssemblyPairs { get; set; } = new();

    public void AddAssemblyPairs(Assembly? apiAssembly, Assembly? domainAssembly)
    {
        ArgumentNullException.ThrowIfNull(apiAssembly);
        ArgumentNullException.ThrowIfNull(domainAssembly);

        AssemblyPairs ??= new List<AssemblyPairOptions>();
        AssemblyPairs.Add(new AssemblyPairOptions(apiAssembly, domainAssembly));
    }
}