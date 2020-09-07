using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Atc.Rest.Options;
using FluentValidation.AspNetCore;

// ReSharper disable once InvertIf
// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class FluentValidationExtensions
    {
        public static void AddFluentValidation<TStartup>(
            this IServiceCollection services,
            bool useAutoRegistrateServices,
            List<AssemblyPairOptions> assemblyPairs)
        {
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
        }
    }
}