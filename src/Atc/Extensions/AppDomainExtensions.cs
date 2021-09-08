using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    /// Extensions for the <see cref="AppDomain"/> class.
    /// </summary>
    public static class AppDomainExtensions
    {
        /// <summary>
        /// Gets all exported types.
        /// </summary>
        /// <param name="appDomain">The application domain.</param>
        public static Type[] GetAllExportedTypes(this AppDomain appDomain)
        {
            if (appDomain is null)
            {
                throw new ArgumentNullException(nameof(appDomain));
            }

            var list = new List<Type>();
            foreach (var assembly in appDomain
                .GetAssemblies()
                .Where(x => !x.IsDynamic))
            {
                list.AddRange(assembly.GetExportedTypes());
            }

            return list.ToArray();
        }

        /// <summary>
        /// Gets the name of the exported type by.
        /// </summary>
        /// <param name="appDomain">The application domain.</param>
        /// <param name="typeName">Name of the type.</param>
        public static Type? GetExportedTypeByName(this AppDomain appDomain, string typeName)
        {
            if (appDomain is null)
            {
                throw new ArgumentNullException(nameof(appDomain));
            }

            if (typeName is null)
            {
                throw new ArgumentNullException(nameof(typeName));
            }

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var assembly in appDomain
                .GetAssemblies()
                .Where(x => !x.IsDynamic))
            {
                var type = assembly.GetExportedTypeByName(typeName);
                if (type != null)
                {
                    return type;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the name of the exported property type by.
        /// </summary>
        /// <param name="appDomain">The application domain.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <param name="propertyName">Name of the property.</param>
        public static Type? GetExportedPropertyTypeByName(this AppDomain appDomain, string typeName, string propertyName)
        {
            if (appDomain is null)
            {
                throw new ArgumentNullException(nameof(appDomain));
            }

            if (typeName is null)
            {
                throw new ArgumentNullException(nameof(typeName));
            }

            if (propertyName is null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            var type = GetExportedTypeByName(appDomain, typeName);
            return type?.GetProperties()
                .FirstOrDefault(x => x.Name.Equals(propertyName, StringComparison.Ordinal))
                ?.PropertyType;
        }

        /// <summary>
        /// Gets the custom assemblies - excluding System, Microsoft etc.
        /// </summary>
        /// <param name="appDomain">The application domain.</param>
        public static Assembly[] GetCustomAssemblies(this AppDomain appDomain)
        {
            if (appDomain is null)
            {
                throw new ArgumentNullException(nameof(appDomain));
            }

            return appDomain
                .GetAssemblies()
                .Where(x => !x.FullName.StartsWith("System", StringComparison.Ordinal) &&
                            !x.FullName.StartsWith("Microsoft", StringComparison.Ordinal) &&
                            !x.FullName.StartsWith("netstandard", StringComparison.Ordinal))
                .ToArray();
        }
    }
}