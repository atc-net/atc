using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models
{
    [SuppressMessage("Microsoft.Naming", "CA1720", Justification = "OK.")]
    public static class OpenApiDataTypeConstants
    {
        public const string Array = "array";
        public const string Boolean = "boolean";
        public const string Integer = "integer";
        public const string Number = "number";
        public const string Object = "object";
        public const string String = "string";
    }
}