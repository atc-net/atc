namespace Atc.Tests.Extensions.Reflection;

public class FieldInfoExtensionsTests
{
    [Theory]
    [InlineData("IsLittleEndian", typeof(BitConverter), "IsLittleEndian")]
    public void BeautifyName(
        string expected,
        Type type,
        string fieldName)
    {
        // Arrange
        var fieldInfo = type.GetField(fieldName);

        // Act
        var actual = fieldInfo!.BeautifyName();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("IsLittleEndian", typeof(BitConverter), "IsLittleEndian", false, false, false)]
    [InlineData("bool IsLittleEndian", typeof(BitConverter), "IsLittleEndian", false, false, true)]
    public void BeautifyName_UseHtmlFormat_IncludeReturnType(
        string expected,
        Type type,
        string fieldName,
        bool useFullName,
        bool useHtmlFormat,
        bool includeReturnType)
    {
        // Arrange
        var fieldInfo = type.GetField(fieldName);

        // Act
        var actual = fieldInfo!.BeautifyName(useFullName, useHtmlFormat, includeReturnType);

        // Assert
        Assert.Equal(expected, actual);
    }
}