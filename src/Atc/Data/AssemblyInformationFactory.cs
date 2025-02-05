namespace Atc.Data;

public static class AssemblyInformationFactory
{
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