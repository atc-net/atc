// ReSharper disable CheckNamespace
namespace System.Reflection;

public static class AssemblyExtensions
{
    public static Type[] GetValidationTypes(this Assembly assembly)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        var types = assembly
            .GetExportedTypes()
            .Where(x => typeof(AbstractValidator<>).IsSubClassOfRawGeneric(x))
            .ToArray();
        return types;
    }
}