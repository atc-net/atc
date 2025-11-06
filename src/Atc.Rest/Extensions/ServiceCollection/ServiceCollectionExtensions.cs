// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/> to auto-register and validate service registrations.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Automatically registers services by matching interfaces from one assembly with implementations from another.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="interfaceAssembly">The assembly containing service interfaces.</param>
    /// <param name="implementationAssembly">The assembly containing service implementations.</param>
    /// <remarks>
    /// This method scans both assemblies and registers each interface with its matching implementation as a transient service.
    /// Only the first matching implementation for each interface is registered.
    /// </remarks>
    public static void AutoRegistrateServices(
        this IServiceCollection services,
        Assembly interfaceAssembly,
        Assembly implementationAssembly)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(interfaceAssembly);
        ArgumentNullException.ThrowIfNull(implementationAssembly);

        var implementationInterfaces = interfaceAssembly
            .DefinedTypes
            .Where(x => x.IsInterface)
            .ToArray();

        var implementationTypes = implementationAssembly
            .DefinedTypes
            .ToArray();

        foreach (var implementationInterface in implementationInterfaces)
        {
            foreach (var implementationType in implementationTypes)
            {
                if (implementationType
                        .GetInterfaces()
                        .FirstOrDefault(x => string.Equals(x.FullName, implementationInterface.FullName, StringComparison.Ordinal)) is null)
                {
                    continue;
                }

                if (!IsImplementationTypeRegistered(services, implementationType))
                {
                    services.AddTransient(implementationInterface, implementationType);
                }

                break;
            }
        }
    }

    /// <summary>
    /// Validates that all interfaces in the specified assembly have been registered in the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="apiAssembly">The assembly containing interfaces to validate.</param>
    /// <exception cref="ItemNotFoundException">Thrown when one or more interfaces are not registered in the service collection.</exception>
    public static void ValidateServiceRegistrations(
        this IServiceCollection services,
        Assembly apiAssembly)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(apiAssembly);

        var notRegistered = apiAssembly
            .DefinedTypes
            .Where(x => x.IsInterface)
            .Where(typeInfo => services
                .All(x => x.ServiceType != typeInfo))
            .ToList();

        if (notRegistered.Count <= 0)
        {
            return;
        }

        var missingRegistrations = notRegistered.Select(typeInfo => typeInfo.Name).ToArray();
        throw new ItemNotFoundException($"Missing registrations for {apiAssembly.GetName().Name}: {string.Join(", ", missingRegistrations)}");
    }

    private static bool IsImplementationTypeRegistered(
        IServiceCollection services,
        Type type)
    {
        return services.Any(item => item.ImplementationType == type);
    }
}