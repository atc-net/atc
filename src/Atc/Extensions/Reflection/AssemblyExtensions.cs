// ReSharper disable once CheckNamespace
// ReSharper disable LoopCanBeConvertedToQuery
namespace System.Reflection;

/// <summary>
/// Extensions for the <see cref="Assembly"/> class.
/// </summary>
public static class AssemblyExtensions
{
    /// <summary>
    /// Gets the file version of the assembly.
    /// </summary>
    /// <param name="assembly">The assembly to query.</param>
    /// <returns>The file version, or 1.0.0.0 if the version cannot be determined.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="assembly"/> is null.</exception>
    public static Version GetFileVersion(this Assembly assembly)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        var fileVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
        if (fileVersion is null)
        {
            return new Version(1, 0, 0, 0);
        }

        return Version.TryParse(fileVersion, out var version)
            ? version
            : new Version(1, 0, 0, 0);
    }

    /// <summary>
    /// Diagnostics a assembly to find out, is this complied a debug assembly.
    /// </summary>
    /// <param name="assembly">The assembly.</param>
    /// <returns><see langword="true" /> if assembly is a debug compilation, <see langword="false" /> if the assembly is a release compilation.</returns>
    public static bool IsDebugBuild(this Assembly assembly)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        return assembly.GetCustomAttributes(false)
            .OfType<DebuggableAttribute>()
            .Select(att => att.IsJITTrackingEnabled)
            .FirstOrDefault();
    }

    /// <summary>
    /// Gets an exported type from the assembly by its type name.
    /// </summary>
    /// <param name="assembly">The assembly to search.</param>
    /// <param name="typeName">The name of the type to find.</param>
    /// <returns>The type if found; otherwise, null.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="assembly"/> or <paramref name="typeName"/> is null.</exception>
    public static Type? GetExportedTypeByName(
        this Assembly assembly,
        string typeName)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        if (typeName is null)
        {
            throw new ArgumentNullException(nameof(typeName));
        }

        return assembly
            .GetExportedTypes()
            .FirstOrDefault(x => x.Name.Equals(typeName, StringComparison.Ordinal));
    }

    /// <summary>
    /// Gets a beautified name of the assembly by replacing dots with spaces.
    /// </summary>
    /// <param name="assembly">The assembly to beautify.</param>
    /// <returns>The beautified assembly name with dots replaced by spaces.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="assembly"/> is null.</exception>
    public static string GetBeautifiedName(this Assembly assembly)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        return assembly.GetName().Name!.Replace(".", " ", StringComparison.Ordinal);
    }

    /// <summary>
    /// Gets all types in the assembly that inherit from a specific type.
    /// </summary>
    /// <param name="assembly">The assembly to search.</param>
    /// <param name="type">The base type to search for inherited types.</param>
    /// <returns>An array of types that inherit from the specified type.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="assembly"/> or <paramref name="type"/> is null.</exception>
    public static Type[] GetTypesInheritingFromType(
        this Assembly assembly,
        Type type)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        return assembly
            .GetTypes()
            .Where(x => x.IsInheritedFrom(type))
            .ToArray();
    }

    /// <summary>
    /// Gets all resource managers from the assembly.
    /// </summary>
    /// <param name="assembly">The assembly to search for resource managers.</param>
    /// <returns>An array of resource managers sorted by base name.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="assembly"/> is null.</exception>
    public static ResourceManager[] GetResourceManagers(
        this Assembly assembly)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        var resourceTypes = assembly.GetTypes();
        var resourceManagers = new List<ResourceManager>();

        foreach (var type in resourceTypes)
        {
            var property = type.GetProperty(nameof(ResourceManager), BindingFlags.Public | BindingFlags.Static);
            if (property is null ||
                property.PropertyType != typeof(ResourceManager))
            {
                continue;
            }

            var resourceManager = (ResourceManager)property.GetValue(null)!;
            resourceManagers.Add(resourceManager);
        }

        return resourceManagers
            .OrderBy(x => x.BaseName, StringComparer.Ordinal)
            .ToArray();
    }
}