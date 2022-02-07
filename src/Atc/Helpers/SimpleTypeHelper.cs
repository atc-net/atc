// ReSharper disable MemberCanBePrivate.Global
namespace Atc.Helpers;

/// <summary>
/// PrimitiveTypeHelper.
/// </summary>
public static class SimpleTypeHelper
{
    /// <summary>
    /// The primitive types.
    /// </summary>
    public static readonly Type[] PrimitiveTypes =
    {
        typeof(bool),
        typeof(byte),
        typeof(char),
        typeof(double),
        typeof(float),
        typeof(int),
        typeof(long),
        typeof(sbyte),
        typeof(short),
        typeof(uint),
        typeof(ulong),
        typeof(ushort),
    };

    /// <summary>
    /// The simple types.
    /// </summary>
    public static readonly Type[] SimpleTypes =
    {
        typeof(bool),
        typeof(byte),
        typeof(char),
        typeof(DateTime),
        typeof(DateTimeOffset),
        typeof(decimal),
        typeof(double),
        typeof(float),
        typeof(Guid),
        typeof(int),
        typeof(long),
        typeof(object),
        typeof(sbyte),
        typeof(short),
        typeof(string),
        typeof(uint),
        typeof(ulong),
        typeof(ushort),
        typeof(void),

        typeof(bool?),
        typeof(byte?),
        typeof(char?),
        typeof(DateTime?),
        typeof(DateTimeOffset?),
        typeof(decimal?),
        typeof(double?),
        typeof(float?),
        typeof(Guid?),
        typeof(int?),
        typeof(long?),
        typeof(sbyte?),
        typeof(short?),
        typeof(uint?),
        typeof(ulong?),
        typeof(ushort?),
    };

    /// <summary>
    /// The beautify simple type lookup.
    /// </summary>
    [SuppressMessage("Minor Code Smell", "S2386:Mutable fields should not be \"public static\"", Justification = "OK.")]
    [SuppressMessage("Minor Bug", "S3887:Mutable, non-private fields should not be \"readonly\"", Justification = "OK.")]
    public static readonly Dictionary<Type, string> BeautifySimpleTypeLookup = new Dictionary<Type, string>
    {
        { typeof(bool), "bool" },
        { typeof(byte), "byte" },
        { typeof(char), "char" },
        { typeof(DateTime), "DateTime" },
        { typeof(DateTimeOffset), "DateTimeOffset" },
        { typeof(decimal), "decimal" },
        { typeof(double), "double" },
        { typeof(float), "float" },
        { typeof(Guid), "Guid" },
        { typeof(int), "int" },
        { typeof(long), "long" },
        { typeof(object), "object" },
        { typeof(sbyte), "sbyte" },
        { typeof(short), "short" },
        { typeof(string), "string" },
        { typeof(uint), "uint" },
        { typeof(ulong), "ulong" },
        { typeof(ushort), "ushort" },
        { typeof(void), "void" },
        { typeof(bool?), "bool?" },
        { typeof(byte?), "byte?" },
        { typeof(char?), "char?" },
        { typeof(DateTime?), "DateTime?" },
        { typeof(DateTimeOffset?), "DateTimeOffset?" },
        { typeof(decimal?), "decimal?" },
        { typeof(double?), "double?" },
        { typeof(float?), "float?" },
        { typeof(Guid?), "Guid?" },
        { typeof(int?), "int?" },
        { typeof(long?), "long?" },
        { typeof(sbyte?), "sbyte?" },
        { typeof(short?), "short?" },
        { typeof(uint?), "uint?" },
        { typeof(ulong?), "ulong?" },
        { typeof(ushort?), "ushort?" },
    };

    /// <summary>
    /// The beautify simple type array lookup.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "OK.")]
    [SuppressMessage("Minor Code Smell", "S2386:Mutable fields should not be \"public static\"", Justification = "OK.")]
    [SuppressMessage("Minor Bug", "S3887:Mutable, non-private fields should not be \"readonly\"", Justification = "OK.")]
    public static readonly Dictionary<Type, string> BeautifySimpleTypeArrayLookup = new Dictionary<Type, string>
    {
        { typeof(bool[]), "bool[]" },
        { typeof(byte[]), "byte[]" },
        { typeof(char[]), "char[]" },
        { typeof(DateTime[]), "DateTime[]" },
        { typeof(DateTimeOffset[]), "DateTimeOffset[]" },
        { typeof(decimal[]), "decimal[]" },
        { typeof(double[]), "double[]" },
        { typeof(float[]), "float[]" },
        { typeof(Guid[]), "Guid[]" },
        { typeof(int[]), "int[]" },
        { typeof(long[]), "long[]" },
        { typeof(object[]), "object[]" },
        { typeof(sbyte[]), "sbyte[]" },
        { typeof(short[]), "short[]" },
        { typeof(string[]), "string[]" },
        { typeof(uint[]), "uint[]" },
        { typeof(ulong[]), "ulong[]" },
        { typeof(ushort[]), "ushort[]" },
    };

    /// <summary>
    /// Gets the name of the beautify type.
    /// </summary>
    /// <param name="type">The type.</param>
    public static string? GetBeautifyTypeName(Type type)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        return BeautifySimpleTypeLookup.ContainsKey(type)
            ? BeautifySimpleTypeLookup[type]
            : null;
    }

    /// <summary>
    /// Gets the beautify type name by reference.
    /// </summary>
    /// <param name="type">The type.</param>
    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    public static string? GetBeautifyTypeNameByRef(Type type)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        if (!type.IsByRef)
        {
            // ReSharper disable once LocalizableElement
            throw new ArgumentException("Type is not ByRef", nameof(type));
        }

        if (type.Name.StartsWith(nameof(Boolean), StringComparison.Ordinal))
        {
            return GetBeautifyTypeName(typeof(bool)) + "&";
        }

        if (type.Name.StartsWith(nameof(Byte), StringComparison.Ordinal))
        {
            return GetBeautifyTypeName(typeof(byte)) + "&";
        }

        if (type.Name.StartsWith(nameof(Char), StringComparison.Ordinal))
        {
            return GetBeautifyTypeName(typeof(char)) + "&";
        }

        if (type.Name.StartsWith(nameof(DateTime), StringComparison.Ordinal))
        {
            return GetBeautifyTypeName(typeof(DateTime)) + "&";
        }

        if (type.Name.StartsWith(nameof(DateTimeOffset), StringComparison.Ordinal))
        {
            return GetBeautifyTypeName(typeof(DateTimeOffset)) + "&";
        }

        if (type.Name.StartsWith(nameof(Decimal), StringComparison.Ordinal))
        {
            return GetBeautifyTypeName(typeof(decimal)) + "&";
        }

        if (type.Name.StartsWith(nameof(Double), StringComparison.Ordinal))
        {
            return GetBeautifyTypeName(typeof(double)) + "&";
        }

        if (type.Name.StartsWith(nameof(Single), StringComparison.Ordinal))
        {
            return GetBeautifyTypeName(typeof(float)) + "&";
        }

        if (type.Name.StartsWith(nameof(Guid), StringComparison.Ordinal))
        {
            return GetBeautifyTypeName(typeof(Guid)) + "&";
        }

        if (type.Name.StartsWith(nameof(Int32), StringComparison.Ordinal))
        {
            return GetBeautifyTypeName(typeof(int)) + "&";
        }

        if (type.Name.StartsWith(nameof(Int64), StringComparison.Ordinal))
        {
            return GetBeautifyTypeName(typeof(long)) + "&";
        }

        if (type.Name.StartsWith(nameof(Object), StringComparison.Ordinal))
        {
            return GetBeautifyTypeName(typeof(object)) + "&";
        }

        if (type.Name.StartsWith(nameof(SByte), StringComparison.Ordinal))
        {
            return GetBeautifyTypeName(typeof(sbyte)) + "&";
        }

        if (type.Name.StartsWith(nameof(Int16), StringComparison.Ordinal))
        {
            return GetBeautifyTypeName(typeof(short)) + "&";
        }

        if (type.Name.StartsWith(nameof(String), StringComparison.Ordinal))
        {
            return GetBeautifyTypeName(typeof(string));
        }

        if (type.Name.StartsWith(nameof(UInt32), StringComparison.Ordinal))
        {
            return GetBeautifyTypeName(typeof(uint)) + "&";
        }

        if (type.Name.StartsWith(nameof(UInt64), StringComparison.Ordinal))
        {
            return GetBeautifyTypeName(typeof(ulong)) + "&";
        }

        if (type.Name.StartsWith(nameof(UInt16), StringComparison.Ordinal))
        {
            return GetBeautifyTypeName(typeof(ushort)) + "&";
        }

        return null;
    }

    /// <summary>
    /// Gets the name of the beautify array type.
    /// </summary>
    /// <param name="type">The type.</param>
    public static string? GetBeautifyArrayTypeName(Type type)
    {
        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        if (!type.IsArray)
        {
            // ReSharper disable once LocalizableElement
            throw new ArgumentException("Type is not Array", nameof(type));
        }

        return BeautifySimpleTypeArrayLookup.ContainsKey(type)
            ? BeautifySimpleTypeArrayLookup[type]
            : null;
    }

    /// <summary>
    /// Determines whether the value is nameof a type that is simple / build-in.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="comparison">The string comparison - default is 'Ordinal'.</param>
    public static bool IsSimpleType(string value, StringComparison comparison = StringComparison.Ordinal)
    {
        var item = BeautifySimpleTypeLookup.FirstOrDefault(x => x.Value.Equals(value, comparison));
        return item.Key is not null;
    }
}