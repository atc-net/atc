namespace Atc.Tests.Extensions.Reflection;

public class MethodInfoExtensionsTests
{
    [Theory]
    [InlineData(false, typeof(NumericAlphaComparer))]
    [InlineData(true, typeof(TupleEqualityComparer<int, int>))]
    public void IsOverride(
        bool expected,
        Type type)
    {
        // Arrange
        var methodInfo = type.GetMethodByName("GetHashCode");

        // Act
        var actual = methodInfo.IsOverride();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, typeof(CreditCardAttribute))]
    [InlineData(true, typeof(EmailAddressAttribute))]
    public void HasDeclaringTypeValidationAttributes(
        bool expected,
        Type type)
    {
        // Arrange
        var methodInfo = type.GetMethodByName("IsValid");

        // Act
        var actual = methodInfo.HasDeclaringTypeValidationAttributes();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, typeof(ConcurrentHashSet<>), "TryAdd")]
    public void HasGenericParameters(
        bool expected,
        Type type,
        string methodName)
    {
        // Arrange
        var methodInfo = type.GetMethodByName(methodName);

        // Act
        var actual = methodInfo.HasGenericParameters();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForExtensionsMethodInfo.BeautifyNameData), MemberType = typeof(TestMemberDataForExtensionsMethodInfo))]
    public void BeautifyName(
        string expected,
        MethodInfo methodInfo)
    {
        // Act
        var actual = methodInfo.BeautifyName();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestMemberDataForExtensionsMethodInfo.BeautifyNameWithParametersData), MemberType = typeof(TestMemberDataForExtensionsMethodInfo))]
    public void BeautifyName_WithParameters(
        string expected,
        MethodInfo methodInfo,
        bool useFullName,
        bool useHtmlFormat,
        bool includeReturnType)
    {
        // Act
        var actual = methodInfo.BeautifyName(useFullName, useHtmlFormat, includeReturnType);

        // Assert
        Assert.Equal(expected, actual);
    }
}