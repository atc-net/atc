// ReSharper disable once CheckNamespace
namespace System.Reflection;

/// <summary>
/// Extensions for the <see cref="Assembly"/> class.
/// </summary>
public static class AssemblyExtensions
{
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
    /// <returns><c>true</c> if assembly is a debug compilation, <c>false</c> if the assembly is a release compilation.</returns>
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
    /// Gets the name of the exported type by typeName.
    /// </summary>
    /// <param name="assembly">The assembly.</param>
    /// <param name="typeName">Name of the type.</param>
    public static Type? GetExportedTypeByName(this Assembly assembly, string typeName)
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
    /// Gets the beautified name of the assembly.
    /// </summary>
    /// <param name="assembly">The assembly.</param>
    public static string GetBeautifiedName(this Assembly assembly)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        return assembly.GetName().Name!.Replace(".", " ", StringComparison.Ordinal);
    }

    /// <summary>
    /// Gets the types inheriting from a specific type.
    /// </summary>
    /// <param name="assembly">The assembly.</param>
    /// <param name="type">The type from which other types are inheriting.</param>
    public static Type[] GetTypesInheritingFromType(this Assembly assembly, Type type)
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
}