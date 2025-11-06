// ReSharper disable once CheckNamespace
namespace System.Reflection;

/// <summary>
/// Extension methods for <see cref="Assembly"/> that provide API-specific naming functionality.
/// </summary>
public static class AssemblyExtensions
{
    /// <summary>
    /// Gets a human-readable API name from the assembly, replacing "Api" with "API" for proper casing.
    /// </summary>
    /// <param name="assembly">The assembly.</param>
    /// <param name="removeLastVerb">If true, removes the last word from the beautified assembly name.</param>
    /// <returns>A formatted API name derived from the assembly name.</returns>
    /// <example>
    /// For an assembly named "MyService.Api", this returns "My Service API".
    /// If <paramref name="removeLastVerb"/> is true, it returns "My Service".
    /// </example>
    public static string GetApiName(this Assembly assembly, bool removeLastVerb = false)
    {
        ArgumentNullException.ThrowIfNull(assembly);

        var assemblyName = assembly.GetBeautifiedName().Replace("Api", "API", StringComparison.Ordinal);

        return removeLastVerb
            ? assemblyName.Substring(0, assemblyName.LastIndexOf(' '))
            : assemblyName;
    }
}