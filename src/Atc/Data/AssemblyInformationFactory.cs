namespace Atc.Data;

/// <summary>
/// Factory for creating <see cref="AssemblyInformation"/> instances from <see cref="Assembly"/> objects.
/// </summary>
public static class AssemblyInformationFactory
{
    /// <summary>
    /// Creates an <see cref="AssemblyInformation"/> instance from the specified assembly.
    /// </summary>
    /// <param name="assembly">The assembly to extract information from.</param>
    /// <returns>An <see cref="AssemblyInformation"/> object containing assembly metadata.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="assembly"/> is null.</exception>
    public static AssemblyInformation Create(
        Assembly assembly)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        var assemblyName = assembly.GetName();
        var isDebugBuild = IsAssemblyCompliedToDebug(assembly);
        string? targetFrameworkName = null;
        string? targetFrameworkDisplayName = null;
        string? copyright = null;

        try
        {
            object[] customAttributes = assembly.GetCustomAttributes(inherit: true);
            if (customAttributes.FirstOrDefault(x => x is TargetFrameworkAttribute) is TargetFrameworkAttribute tfa)
            {
                targetFrameworkName = tfa.FrameworkName;
                targetFrameworkDisplayName = tfa.FrameworkDisplayName;
            }

            if (customAttributes.FirstOrDefault(x => x is AssemblyCopyrightAttribute) is AssemblyCopyrightAttribute aca)
            {
                copyright = aca.Copyright;
            }
        }
        catch (FileNotFoundException)
        {
            // Skip
        }

        return new AssemblyInformation(
            assembly.FullName!,
            assemblyName.Name!,
            assemblyName.Version!,
            isDebugBuild,
            targetFrameworkName,
            targetFrameworkDisplayName,
            copyright,
            assembly.Location);
    }

    private static bool IsAssemblyCompliedToDebug(ICustomAttributeProvider assembly)
    {
        try
        {
            object[] attributes = assembly.GetCustomAttributes(typeof(DebuggableAttribute), false);
            if (attributes.Length != 1)
            {
                return false;
            }

            return attributes[0] is DebuggableAttribute { IsJITTrackingEnabled: true };
        }
        catch (IOException)
        {
            return false;
        }
    }
}