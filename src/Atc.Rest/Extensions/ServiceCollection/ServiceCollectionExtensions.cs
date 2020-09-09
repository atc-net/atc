using System;
using System.Linq;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AutoRegistrateServices(
            this IServiceCollection services,
            Assembly apiAssembly,
            Assembly domainAssembly)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (apiAssembly == null)
            {
                throw new ArgumentNullException(nameof(apiAssembly));
            }

            if (domainAssembly == null)
            {
                throw new ArgumentNullException(nameof(domainAssembly));
            }

            var apiInterfaces = apiAssembly
                .DefinedTypes
                .Where(x => x.IsInterface)
                .ToArray();

            foreach (var apiInterface in apiInterfaces)
            {
                var domainTypes = domainAssembly
                    .DefinedTypes
                    .ToArray();

                foreach (var domainType in domainTypes)
                {
                    if (domainType
                        .GetInterfaces()
                        .FirstOrDefault(x => x.FullName == apiInterface.FullName) == null)
                    {
                        continue;
                    }

                    if (!IsImplementationTypeRegistered(services, domainType))
                    {
                        services.AddTransient(apiInterface, domainType);
                    }

                    break;
                }
            }
        }

        public static void ValidateServiceRegistrations(
            this IServiceCollection services,
            Assembly apiAssembly)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (apiAssembly == null)
            {
                throw new ArgumentNullException(nameof(apiAssembly));
            }

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
}