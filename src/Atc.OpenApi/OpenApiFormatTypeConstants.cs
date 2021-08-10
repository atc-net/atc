using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models
{
    [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", Justification = "OK.")]
    public static class OpenApiFormatTypeConstants
    {
        public const string Uuid = "uuid";

        public const string Date = "date";
        public const string Time = "time";
        public const string Timestamp = "timestamp"; // This is a legacy
        public const string DateTime = "date-time";

        public const string Byte = "byte";
        public const string Binary = "binary";
        public const string Int32 = "int32";
        public const string Int64 = "int64";

        public const string Email = "email";
        public const string Uri = "uri";

        public const string Float = "float";
        public const string Double = "double";
    }
}