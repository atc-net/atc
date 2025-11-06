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
        // TODO: AddFluentValidation is obsolete
        // - this should be change to use AddFluentValidationAutoValidation instead and tested!
        // https://github.com/FluentValidation/FluentValidation/issues/1965
#pragma warning disable CS0618 // Type or member is obsolete
        services
            .AddControllers()
            .AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<TStartup>();

                if (useAutoRegistrateServices)
                {
                    foreach (var assemblyPairOptions in assemblyPairs)
                    {
                        var apiValidationTypes = assemblyPairOptions.ApiAssembly.GetValidationTypes();
                        if (apiValidationTypes.Length > 0)
                        {
                            options.RegisterValidatorsFromAssemblyContaining(apiValidationTypes[0]);
                        }

                        var domainValidationTypes = assemblyPairOptions.DomainAssembly.GetValidationTypes();
                        if (domainValidationTypes.Length > 0)
                        {
                            options.RegisterValidatorsFromAssemblyContaining(domainValidationTypes[0]);
                        }
                    }
                }
            });
#pragma warning restore CS0618 // Type or member is obsolete
    }
}