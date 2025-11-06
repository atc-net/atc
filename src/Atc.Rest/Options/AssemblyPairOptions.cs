namespace Atc.Rest.Options;

/// <summary>
/// Represents a pair of assemblies for API and domain layer service registration.
/// </summary>
/// <remarks>
/// This class is used to group an API assembly (containing interfaces) with its corresponding
/// domain assembly (containing implementations) for automatic service registration.
/// It also facilitates loading embedded OpenAPI specification resources.
/// </remarks>
public class AssemblyPairOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AssemblyPairOptions"/> class.
    /// </summary>
    /// <param name="apiAssembly">The assembly containing API contracts and interfaces.</param>
    /// <param name="domainAssembly">The assembly containing domain implementations.</param>
    public AssemblyPairOptions(
        Assembly apiAssembly,
        Assembly domainAssembly)
    {
        ApiAssembly = apiAssembly ?? throw new ArgumentNullException(nameof(apiAssembly));
        DomainAssembly = domainAssembly ?? throw new ArgumentNullException(nameof(domainAssembly));
    }

    /// <summary>
    /// Gets the API assembly containing interfaces and API specifications.
    /// </summary>
    public Assembly ApiAssembly { get; }

    /// <summary>
    /// Gets the domain assembly containing service implementations.
    /// </summary>
    public Assembly DomainAssembly { get; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{nameof(ApiAssembly)}: {ApiAssembly?.FullName}, {nameof(DomainAssembly)}: {DomainAssembly?.FullName}";
    }
}