// ReSharper disable CheckNamespace
namespace System;

/// <summary>
/// Extension methods for <see cref="Type"/> that provide API-specific naming functionality.
/// </summary>
public static class TypeExtensions
{
    /// <summary>
    /// Gets a human-readable API name from the type's assembly.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="removeLastVerb">If true, removes the last word from the beautified assembly name.</param>
    /// <returns>A formatted API name derived from the type's assembly name.</returns>
    /// <seealso cref="System.Reflection.AssemblyExtensions.GetApiName"/>
    public static string GetApiName(this Type type, bool removeLastVerb = false)
    {
        ArgumentNullException.ThrowIfNull(type);

        return type.Assembly.GetApiName(removeLastVerb);
    }
}