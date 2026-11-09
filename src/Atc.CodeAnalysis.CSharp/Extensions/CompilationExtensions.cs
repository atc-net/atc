// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis;

/// <summary>
/// Extension methods for <see cref="Compilation"/>, to ask which assemblies a project references,
/// for example to let a source generator emit code only when a framework is present.
/// </summary>
public static class CompilationExtensions
{
    /// <summary>
    /// Determines whether the compilation references an assembly with the given name. The match is case-insensitive.
    /// </summary>
    /// <param name="compilation">The compilation to inspect.</param>
    /// <param name="assemblyName">The simple assembly name, for example <c>Microsoft.AspNetCore.Http.Abstractions</c>.</param>
    /// <returns><see langword="true"/> when the assembly is referenced; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="compilation"/> or <paramref name="assemblyName"/> is null.</exception>
    public static bool References(
        this Compilation compilation,
        string assemblyName)
    {
        if (compilation is null)
        {
            throw new ArgumentNullException(nameof(compilation));
        }

        if (assemblyName is null)
        {
            throw new ArgumentNullException(nameof(assemblyName));
        }

        return compilation.ReferencedAssemblyNames
            .Any(x => string.Equals(x.Name, assemblyName, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Determines whether the compilation references any assembly whose name starts with the given prefix,
    /// for example <c>Microsoft.AspNetCore</c>. The match is case-insensitive.
    /// </summary>
    /// <param name="compilation">The compilation to inspect.</param>
    /// <param name="prefix">The assembly name prefix.</param>
    /// <returns><see langword="true"/> when at least one matching assembly is referenced; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="compilation"/> or <paramref name="prefix"/> is null.</exception>
    public static bool ReferencesAnyStartingWith(
        this Compilation compilation,
        string prefix)
    {
        if (compilation is null)
        {
            throw new ArgumentNullException(nameof(compilation));
        }

        if (prefix is null)
        {
            throw new ArgumentNullException(nameof(prefix));
        }

        return compilation.ReferencedAssemblyNames
            .Any(x => x.Name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets the version of a referenced assembly. The name match is case-insensitive.
    /// </summary>
    /// <param name="compilation">The compilation to inspect.</param>
    /// <param name="assemblyName">The simple assembly name.</param>
    /// <returns>The referenced version, or <see langword="null"/> when the assembly is not referenced.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="compilation"/> or <paramref name="assemblyName"/> is null.</exception>
    public static Version? VersionOf(
        this Compilation compilation,
        string assemblyName)
    {
        if (compilation is null)
        {
            throw new ArgumentNullException(nameof(compilation));
        }

        if (assemblyName is null)
        {
            throw new ArgumentNullException(nameof(assemblyName));
        }

        return compilation.ReferencedAssemblyNames
            .FirstOrDefault(x => string.Equals(x.Name, assemblyName, StringComparison.OrdinalIgnoreCase))?
            .Version;
    }
}