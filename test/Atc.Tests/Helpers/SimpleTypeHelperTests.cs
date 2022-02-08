namespace Atc.Tests.Helpers;

public class SimpleTypeHelperTests
{
    [Theory]
    [InlineData("bool", typeof(bool))]
    [InlineData("byte", typeof(byte))]
    [InlineData("char", typeof(char))]
    [InlineData("DateTime", typeof(DateTime))]
    [InlineData("DateTimeOffset", typeof(DateTimeOffset))]
    [InlineData("decimal", typeof(decimal))]
    [InlineData("double", typeof(double))]
    [InlineData("float", typeof(float))]
    [InlineData("Guid", typeof(Guid))]
    [InlineData("int", typeof(int))]
    [InlineData("long", typeof(long))]
    [InlineData("object", typeof(object))]
    [InlineData("sbyte", typeof(sbyte))]
    [InlineData("short", typeof(short))]
    [InlineData("string", typeof(string))]
    [InlineData("uint", typeof(uint))]
    [InlineData("ulong", typeof(ulong))]
    [InlineData("ushort", typeof(ushort))]
    [InlineData("void", typeof(void))]
    [InlineData("bool?", typeof(bool?))]
    [InlineData("byte?", typeof(byte?))]
    [InlineData("char?", typeof(char?))]
    [InlineData("DateTime?", typeof(DateTime?))]
    [InlineData("DateTimeOffset?", typeof(DateTimeOffset?))]
    [InlineData("decimal?", typeof(decimal?))]
    [InlineData("double?", typeof(double?))]
    [InlineData("float?", typeof(float?))]
    [InlineData("Guid?", typeof(Guid?))]
    [InlineData("int?", typeof(int?))]
    [InlineData("long?", typeof(long?))]
    [InlineData("sbyte?", typeof(sbyte?))]
    [InlineData("short?", typeof(short?))]
    [InlineData("uint?", typeof(uint?))]
    [InlineData("ulong?", typeof(ulong?))]
    [InlineData("ushort?", typeof(ushort?))]
    public void GetBeautifyTypeName(string expected, Type type)
        => Assert.Equal(expected, SimpleTypeHelper.GetBeautifyTypeName(type));

    [Theory]
    [InlineData(typeof(bool))]
    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    public void GetBeautifyTypeNameByRef(Type type)
    {
        // Act
        Exception exception = null;
        try
        {
            SimpleTypeHelper.GetBeautifyTypeNameByRef(type);
        }
        catch (Exception ex)
        {
            exception = ex;
        }

        // Assert
        Assert.NotNull(exception);
        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [InlineData("bool[]", typeof(bool[]))]
    [InlineData("byte[]", typeof(byte[]))]
    [InlineData("char[]", typeof(char[]))]
    [InlineData("DateTime[]", typeof(DateTime[]))]
    [InlineData("DateTimeOffset[]", typeof(DateTimeOffset[]))]
    [InlineData("decimal[]", typeof(decimal[]))]
    [InlineData("double[]", typeof(double[]))]
    [InlineData("float[]", typeof(float[]))]
    [InlineData("Guid[]", typeof(Guid[]))]
    [InlineData("int[]", typeof(int[]))]
    [InlineData("long[]", typeof(long[]))]
    [InlineData("object[]", typeof(object[]))]
    [InlineData("sbyte[]", typeof(sbyte[]))]
    [InlineData("short[]", typeof(short[]))]
    [InlineData("string[]", typeof(string[]))]
    [InlineData("uint[]", typeof(uint[]))]
    [InlineData("ulong[]", typeof(ulong[]))]
    [InlineData("ushort[]", typeof(ushort[]))]

    public void GetBeautifyArrayTypeName(string expected, Type type)
        => Assert.Equal(expected, SimpleTypeHelper.GetBeautifyArrayTypeName(type));

    [Theory]
    [InlineData(true, "bool")]
    [InlineData(true, "byte")]
    [InlineData(true, "char")]
    [InlineData(true, "DateTime")]
    [InlineData(true, "DateTimeOffset")]
    [InlineData(true, "decimal")]
    [InlineData(true, "double")]
    [InlineData(true, "float")]
    [InlineData(true, "Guid")]
    [InlineData(true, "int")]
    [InlineData(true, "long")]
    [InlineData(true, "object")]
    [InlineData(true, "sbyte")]
    [InlineData(true, "short")]
    [InlineData(true, "string")]
    [InlineData(true, "uint")]
    [InlineData(true, "ulong")]
    [InlineData(true, "ushort")]
    [InlineData(true, "void")]
    [InlineData(false, "hallo")]
    public void IsSimpleType(bool expected, string typeName)
        => Assert.Equal(expected, SimpleTypeHelper.IsSimpleType(typeName));

    [Theory]
    [InlineData(true, "bool", StringComparison.Ordinal)]
    [InlineData(true, "bool", StringComparison.OrdinalIgnoreCase)]
    [InlineData(false, "BOOL", StringComparison.Ordinal)]
    [InlineData(true, "BOOL", StringComparison.OrdinalIgnoreCase)]
    public void IsSimpleType_Comparison(bool expected, string typeName, StringComparison comparison)
        => Assert.Equal(expected, SimpleTypeHelper.IsSimpleType(typeName, comparison));
}