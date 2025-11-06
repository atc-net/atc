// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the <see cref="AppDomain"/> class.
/// </summary>
public static class AppDomainExtensions
{
    /// <summary>
    /// Gets all exported types from non-dynamic assemblies in the application domain.
    /// </summary>
    /// <param name="appDomain">The application domain to search.</param>
    /// <returns>An array of all exported types from non-dynamic assemblies.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="appDomain"/> is null.</exception>
    public static Type[] GetAllExportedTypes(
        this AppDomain appDomain)
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
    /// Searches for an exported type by name across all non-dynamic assemblies in the application domain.
    /// </summary>
    /// <param name="appDomain">The application domain to search.</param>
    /// <param name="typeName">The name of the type to find.</param>
    /// <returns>The type if found; otherwise, null.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="appDomain"/> or <paramref name="typeName"/> is null.</exception>
    public static Type? GetExportedTypeByName(
        this AppDomain appDomain,
        string typeName)
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
            if (type is not null)
            {
                return type;
            }
        }

        return null;
    }

    /// <summary>
    /// Gets the type of a specific property from an exported type by name.
    /// </summary>
    /// <param name="appDomain">The application domain to search.</param>
    /// <param name="typeName">The name of the type containing the property.</param>
    /// <param name="propertyName">The name of the property whose type to retrieve.</param>
    /// <returns>The property type if found; otherwise, null.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="appDomain"/>, <paramref name="typeName"/>, or <paramref name="propertyName"/> is null.</exception>
    public static Type? GetExportedPropertyTypeByName(
        this AppDomain appDomain,
        string typeName,
        string propertyName)
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
    /// <returns>The array of <see cref="Assembly"/>.</returns>
    public static Assembly[] GetCustomAssemblies(
        this AppDomain appDomain)
    {
        if (appDomain is null)
        {
            throw new ArgumentNullException(nameof(appDomain));
        }

        return appDomain
            .GetAssemblies()
            .Where(x => !x.FullName!.StartsWith("System", StringComparison.Ordinal) &&
                        !x.FullName.StartsWith("Microsoft", StringComparison.Ordinal) &&
                        !x.FullName.StartsWith("netstandard", StringComparison.Ordinal) &&
                        !x.FullName.StartsWith("mscorlib", StringComparison.Ordinal) &&
                        !x.FullName.StartsWith("Presentation", StringComparison.Ordinal) &&
                        !x.FullName.StartsWith("WindowsBase", StringComparison.Ordinal) &&
                        !x.FullName.StartsWith("vshost", StringComparison.Ordinal))
            .ToArray();
    }

    /// <summary>
    /// Gets assembly information for all non-dynamic assemblies in the application domain.
    /// </summary>
    /// <param name="appDomain">The application domain to query.</param>
    /// <returns>An array of <see cref="AssemblyInformation"/> objects sorted by full name.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="appDomain"/> is null.</exception>
    public static AssemblyInformation[] GetAssemblyInformations(
        this AppDomain appDomain)
    {
        if (appDomain is null)
        {
            throw new ArgumentNullException(nameof(appDomain));
        }

        return appDomain
            .GetAssemblies()
            .Where(x => !x.IsDynamic)
            .Select(AssemblyInformationFactory.Create)
            .OrderBy(x => x.FullName, StringComparer.Ordinal)
            .ToArray();
    }

    /// <summary>
    /// Gets assembly information for system assemblies in the application domain.
    /// </summary>
    /// <param name="appDomain">The application domain to query.</param>
    /// <returns>An array of <see cref="AssemblyInformation"/> for system assemblies.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="appDomain"/> is null.</exception>
    public static AssemblyInformation[] GetAssemblyInformationsBySystem(
        this AppDomain appDomain)
    {
        if (appDomain is null)
        {
            throw new ArgumentNullException(nameof(appDomain));
        }

        var sa = AssemblyHelper.GetSystemName().Split('.');
        return sa.Length < 1
            ? Array.Empty<AssemblyInformation>()
            : appDomain.GetAssemblyInformationsByStartsWith(sa[0]);
    }

    /// <summary>
    /// Gets assembly information for assemblies whose full name starts with the specified value.
    /// </summary>
    /// <param name="appDomain">The application domain to query.</param>
    /// <param name="value">The prefix to match against assembly full names.</param>
    /// <returns>An array of <see cref="AssemblyInformation"/> for matching assemblies sorted by name.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="appDomain"/> is null.</exception>
    public static AssemblyInformation[] GetAssemblyInformationsByStartsWith(
        this AppDomain appDomain,
        string value)
    {
        if (appDomain is null)
        {
            throw new ArgumentNullException(nameof(appDomain));
        }

        return appDomain
            .GetAssemblies()
            .Where(x => x.FullName!.StartsWith(value, StringComparison.Ordinal))
            .Select(AssemblyInformationFactory.Create)
            .OrderBy(x => x.Name, StringComparer.Ordinal)
            .ToArray();
    }

    /// <summary>
    /// Attempts to load the specified assembly file if it is not already loaded in the application domain.
    /// </summary>
    /// <remarks>
    /// The assembly is loaded into memory without holding a direct reference to the file,
    /// avoiding file locking issues.
    /// </remarks>
    /// <param name="appDomain">The application domain to check and load into.</param>
    /// <param name="dllFileName">The name of the assembly file (DLL) to load.</param>
    /// <returns><see langword="true"/> if the assembly was already loaded or successfully loaded; otherwise, <see langword="false"/>.</returns>
    [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    public static bool TryLoadAssemblyIfNeeded(
        this AppDomain appDomain,
        string dllFileName)
    {
        var assemblies = GetCustomAssemblies(appDomain);

        var isLoaded = assemblies.Any(x => !string.IsNullOrEmpty(x.Location) &&
                                           x.Location.Contains(dllFileName, StringComparison.OrdinalIgnoreCase));

        if (isLoaded)
        {
            return true;
        }

        var dllFile = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dllFileName));
        if (!dllFile.Exists)
        {
            return false;
        }

        try
        {
            AssemblyHelper.Load(dllFile);
            return true;
        }
        catch
        {
            return false;
        }
    }
}