using System.Diagnostics;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace System.Reflection
{
    /// <summary>
    /// Extensions for the <see cref="Assembly"/> class.
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Diagnostics a assembly to find out, is this complied a debug assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns><c>true</c> if assembly is a debug compilation, <c>false</c> if the assembly is a release compilation.</returns>
        public static bool IsDebugBuild(this Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            return assembly.GetCustomAttributes(false)
                .OfType<DebuggableAttribute>()
                .Select(att => att.IsJITTrackingEnabled)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the name of the exported type by.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="typeName">Name of the type.</param>
        public static Type? GetExportedTypeByName(this Assembly assembly, string typeName)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            if (typeName == null)
            {
                throw new ArgumentNullException(nameof(typeName));
            }

            return assembly
                .GetExportedTypes()
                .FirstOrDefault(x => x.Name.Equals(typeName, StringComparison.Ordinal));
        }

        /// <summary>
        /// Gets the name of the pretty.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public static string GetPrettyName(this Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            return assembly.GetName().Name!.Replace(".", " ", StringComparison.Ordinal);
        }
    }
}