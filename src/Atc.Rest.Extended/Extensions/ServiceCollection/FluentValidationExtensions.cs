// ReSharper disable once InvertIf
// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for configuring FluentValidation in the service collection.
/// </summary>
public static class FluentValidationExtensions
{
    /// <summary>
    /// Adds FluentValidation to the service collection and registers validators from the startup assembly and optionally from API/domain assemblies.
    /// </summary>
    /// <typeparam name="TStartup">The startup type used to locate validators.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> instance.</param>
    /// <param name="useAutoRegistrateServices">If true, automatically registers validators from assembly pairs.</param>
    /// <param name="assemblyPairs">The list of assembly pairs containing API and domain assemblies with validators.</param>
    public static void AddFluentValidation<TStartup>(
        this IServiceCollection services,
        bool useAutoRegistrateServices,
        List<AssemblyPairOptions> assemblyPairs)
    {
        services
            .AddControllers();

        services
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters()
            .AddValidatorsFromAssemblyContaining<TStartup>();

        if (useAutoRegistrateServices)
        {
            ArgumentNullException.ThrowIfNull(assemblyPairs);

            foreach (var assemblyPairOptions in assemblyPairs)
            {
                services.AddValidatorsFromAssembly(assemblyPairOptions.ApiAssembly);
                services.AddValidatorsFromAssembly(assemblyPairOptions.DomainAssembly);
            }
        }
    }
}