// ReSharper disable once InvertIf
// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class FluentValidationExtensions
{
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
                            options.RegisterValidatorsFromAssemblyContaining(apiValidationTypes.First());
                        }

                        var domainValidationTypes = assemblyPairOptions.DomainAssembly.GetValidationTypes();
                        if (domainValidationTypes.Length > 0)
                        {
                            options.RegisterValidatorsFromAssemblyContaining(domainValidationTypes.First());
                        }
                    }
                }
            });
#pragma warning restore CS0618 // Type or member is obsolete
    }
}