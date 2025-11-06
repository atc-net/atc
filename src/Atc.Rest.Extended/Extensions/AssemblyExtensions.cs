// ReSharper disable CheckNamespace
namespace System.Reflection;

/// <summary>
/// Extension methods for <see cref="Assembly"/> related to FluentValidation.
/// </summary>
public static class AssemblyExtensions
{
    /// <summary>
    /// Gets all types from the assembly that are validators (inherit from <see cref="AbstractValidator{T}"/>).
    /// </summary>
    /// <param name="assembly">The assembly to search for validator types.</param>
    /// <returns>An array of types that are validators.</returns>
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