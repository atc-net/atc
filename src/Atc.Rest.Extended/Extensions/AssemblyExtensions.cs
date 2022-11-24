// ReSharper disable CheckNamespace
namespace System.Reflection;

public static class AssemblyExtensions
{
    public static Type[] GetValidationTypes(
        this Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(assembly);

        var types = assembly
            .GetExportedTypes()
            .Where(x => typeof(AbstractValidator<>).IsSubClassOfRawGeneric(x))
            .ToArray();
        return types;
    }
}