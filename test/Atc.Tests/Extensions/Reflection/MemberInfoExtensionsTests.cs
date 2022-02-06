namespace Atc.Tests.Extensions.Reflection;

public class MemberInfoExtensionsTests
{
    [Theory]
    [InlineData(false, typeof(TestItem), "Hallo")]
    [InlineData(true, typeof(TestItem), "World")]
    public void HasExcludeFromCodeCoverageAttribute(bool expected, Type type, string methodName)
    {
        // Arrange
        var memberInfo = type.GetMember(methodName).First();

        // Act
        var actual = memberInfo.HasExcludeFromCodeCoverageAttribute();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, typeof(TestItem), "Hallo")]
    [InlineData(true, typeof(TestItem), "World")]
    public void HasIgnoreDisplayAttribute(bool expected, Type type, string methodName)
    {
        // Arrange
        var memberInfo = type.GetMember(methodName).First();

        // Act
        var actual = memberInfo.HasIgnoreDisplayAttribute();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, typeof(TestItem), "Hallo")]
    [InlineData(true, typeof(TestItem), "World")]
    public void HasRequiredAttribute(bool expected, Type type, string methodName)
    {
        // Arrange
        var memberInfo = type.GetMember(methodName).First();

        // Act
        var actual = memberInfo.HasRequiredAttribute();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, typeof(TestItem), "Hallo")]
    [InlineData(false, typeof(TestItem), "World")]
    public void IsPropertyWithSetter(bool expected, Type type, string methodName)
    {
        // Arrange
        var memberInfo = type.GetMember(methodName).First();

        // Act
        var actual = memberInfo.IsPropertyWithSetter();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(typeof(string), typeof(TestItem), "Hallo")]
    [InlineData(typeof(string), typeof(TestItem), "World")]
    [InlineData(typeof(int), typeof(TestItem), "Age")]
    public void GetUnderlyingType(Type expected, Type type, string methodName)
    {
        // Arrange
        var memberInfo = type.GetMember(methodName).First();

        // Act
        var actual = memberInfo.GetUnderlyingType();

        // Assert
        Assert.Equal(expected, actual);
    }
}

[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "OK.")]
[SuppressMessage("Design", "MA0048:File name must match type name", Justification = "OK.")]
internal class TestItem
{
    public string Hallo { get; set; }

    [ExcludeFromCodeCoverage]
    [IgnoreDisplay]
    [Required]
    public string World { get; }

    public int Age { get; set; }
}