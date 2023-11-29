// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
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

    private static bool IsImplementationTypeRegistered(IServiceCollection services, Type type)
    {
        return services.Any(item => item.ImplementationType == type);
    }
}