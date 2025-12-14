namespace Atc.Tests.Helpers;

public class CSharpTypeHelperTests
{
    [Theory]
    [InlineData(true, "int")]
    [InlineData(true, "long")]
    [InlineData(true, "float")]
    [InlineData(true, "double")]
    [InlineData(true, "decimal")]
    [InlineData(true, "int?")]
    [InlineData(true, "long?")]
    [InlineData(true, "float?")]
    [InlineData(true, "double?")]
    [InlineData(true, "decimal?")]
    [InlineData(false, "bool")]
    [InlineData(false, "string")]
    [InlineData(false, "Guid")]
    [InlineData(false, "DateTime")]
    [InlineData(false, "DateTimeOffset")]
    [InlineData(false, "object")]
    [InlineData(false, "")]
    public void IsNumericType(
        bool expected,
        string typeName)
        => Assert.Equal(expected, CSharpTypeHelper.IsNumericType(typeName));

    [Theory]
    [InlineData(true, "int")]
    [InlineData(true, "long")]
    [InlineData(true, "bool")]
    [InlineData(true, "float")]
    [InlineData(true, "double")]
    [InlineData(true, "decimal")]
    [InlineData(true, "int?")]
    [InlineData(true, "long?")]
    [InlineData(true, "bool?")]
    [InlineData(true, "float?")]
    [InlineData(true, "double?")]
    [InlineData(true, "decimal?")]
    [InlineData(false, "string")]
    [InlineData(false, "Guid")]
    [InlineData(false, "DateTime")]
    [InlineData(false, "DateTimeOffset")]
    [InlineData(false, "object")]
    [InlineData(false, "")]
    public void IsBasicValueType(
        bool expected,
        string typeName)
        => Assert.Equal(expected, CSharpTypeHelper.IsBasicValueType(typeName));

    [Theory]
    [InlineData(true, "int")]
    [InlineData(true, "long")]
    [InlineData(true, "bool")]
    [InlineData(true, "float")]
    [InlineData(true, "double")]
    [InlineData(true, "decimal")]
    [InlineData(true, "Guid")]
    [InlineData(true, "DateTime")]
    [InlineData(true, "DateTimeOffset")]
    [InlineData(true, "int?")]
    [InlineData(true, "long?")]
    [InlineData(true, "bool?")]
    [InlineData(true, "float?")]
    [InlineData(true, "double?")]
    [InlineData(true, "decimal?")]
    [InlineData(true, "Guid?")]
    [InlineData(true, "DateTime?")]
    [InlineData(true, "DateTimeOffset?")]
    [InlineData(false, "string")]
    [InlineData(false, "object")]
    [InlineData(false, "byte")]
    [InlineData(false, "")]
    public void IsExtendedValueType(
        bool expected,
        string typeName)
        => Assert.Equal(expected, CSharpTypeHelper.IsExtendedValueType(typeName));

    [Theory]
    [InlineData(true, "int?")]
    [InlineData(true, "long?")]
    [InlineData(true, "bool?")]
    [InlineData(true, "float?")]
    [InlineData(true, "double?")]
    [InlineData(true, "decimal?")]
    [InlineData(true, "Guid?")]
    [InlineData(true, "DateTime?")]
    [InlineData(true, "DateTimeOffset?")]
    [InlineData(false, "int")]
    [InlineData(false, "long")]
    [InlineData(false, "bool")]
    [InlineData(false, "float")]
    [InlineData(false, "double")]
    [InlineData(false, "decimal")]
    [InlineData(false, "Guid")]
    [InlineData(false, "DateTime")]
    [InlineData(false, "DateTimeOffset")]
    [InlineData(false, "string")]
    [InlineData(false, "")]
    public void IsNullable(
        bool expected,
        string typeName)
        => Assert.Equal(expected, CSharpTypeHelper.IsNullable(typeName));

    [Theory]
    [InlineData("int", "int")]
    [InlineData("int", "int?")]
    [InlineData("long", "long")]
    [InlineData("long", "long?")]
    [InlineData("bool", "bool")]
    [InlineData("bool", "bool?")]
    [InlineData("float", "float")]
    [InlineData("float", "float?")]
    [InlineData("double", "double")]
    [InlineData("double", "double?")]
    [InlineData("decimal", "decimal")]
    [InlineData("decimal", "decimal?")]
    [InlineData("Guid", "Guid")]
    [InlineData("Guid", "Guid?")]
    [InlineData("DateTime", "DateTime")]
    [InlineData("DateTime", "DateTime?")]
    [InlineData("DateTimeOffset", "DateTimeOffset")]
    [InlineData("DateTimeOffset", "DateTimeOffset?")]
    [InlineData("string", "string")]
    [InlineData("", "")]
    public void GetBaseType(
        string expected,
        string typeName)
        => Assert.Equal(expected, CSharpTypeHelper.GetBaseType(typeName));
}