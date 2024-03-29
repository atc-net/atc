// ReSharper disable once CheckNamespace
namespace System.Reflection;

public static class AssemblyExtensions
{
    public static string GetApiName(this Assembly assembly, bool removeLastVerb = false)
    {
        ArgumentNullException.ThrowIfNull(assembly);

        var assemblyName = assembly.GetBeautifiedName().Replace("Api", "API", StringComparison.Ordinal);

        return removeLastVerb
            ? assemblyName.Substring(0, assemblyName.LastIndexOf(' '))
            : assemblyName;
    }
}