using System.Reflection;

// ReSharper disable CheckNamespace
namespace System
{
    public static class TypeExtensions
    {
        public static string GetApiName(this Type type, bool removeLastVerb = false)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return type.Assembly.GetApiName(removeLastVerb);
        }
    }
}