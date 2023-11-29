// ReSharper disable CheckNamespace
namespace System;

public static class TypeExtensions
{
    public static string GetApiName(this Type type, bool removeLastVerb = false)
    {
        ArgumentNullException.ThrowIfNull(type);

        return type.Assembly.GetApiName(removeLastVerb);
    }
}