// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the <see cref="AppDomain"/> class.
/// </summary>
public static class AppDomainExtensions
{
    /// <summary>
    /// Gets all exported types.
    /// </summary>
    /// <param name="appDomain">The application domain.</param>
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
    /// Gets the name of the exported type by.
    /// </summary>
    /// <param name="appDomain">The application domain.</param>
    /// <param name="typeName">Name of the type.</param>
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
    /// Gets the name of the exported property type by.
    /// </summary>
    /// <param name="appDomain">The application domain.</param>
    /// <param name="typeName">Name of the type.</param>
    /// <param name="propertyName">Name of the property.</param>
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
    /// Gets the assembly informations.
    /// </summary>
    /// <param name="appDomain">The application domain.</param>
    /// <returns>The array of <see cref="AssemblyInformation"/>.</returns>
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
    /// Gets the assembly informations by system.
    /// </summary>
    /// <param name="appDomain">The application domain.</param>
    /// <returns>The array of <see cref="AssemblyInformation"/>.</returns>
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
    /// Gets the assembly informations by assembly fullname should start with value.
    /// </summary>
    /// <param name="appDomain">The application domain.</param>
    /// <param name="value">The value.</param>
    /// <returns>The array of <see cref="AssemblyInformation"/>.</returns>
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
    /// Load the specified assembly file, with a reference to memory and not the specified file.
    /// </summary>
    /// <remarks>
    /// The assembly is never directly loaded, to avoid
    /// holding a instance as "assembly = Assembly.Load(file)" do.
    /// </remarks>
    /// <param name="appDomain">The application domain.</param>
    /// <param name="dllFileName">The name for the assembly file.</param>
    /// <returns>The Assembly that is loaded.</returns>
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