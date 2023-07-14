// ReSharper disable ConvertToConstant.Local
namespace Atc.Tests.Extensions;

public class ObjectExtensionsTests
{
    [Fact]
    public void GetTypeName()
    {
        // Arrange
        var sut = new LogKeyValueItem();

        // Act
        var actual = sut.GetTypeName();

        // Assert
        Assert.Equal("LogKeyValueItem", actual);
    }

    [Fact]
    public void GetTypeFullName()
    {
        // Arrange
        var sut = new LogKeyValueItem();

        // Act
        var actual = sut.GetTypeFullName();

        // Assert
        Assert.Equal("Atc.Data.Models.LogKeyValueItem", actual);
    }

    [Fact]
    public void GetPropertyValue()
    {
        // Arrange
        var sut = new LogKeyValueItem(
            LogCategoryType.Debug,
            "MyKey",
            "MyValue",
            "MyDescription");

        // Act
        var actualLogCategory = sut.GetPropertyValue("LogCategory");
        var actualKey = sut.GetPropertyValue("Key");
        var actualValue = sut.GetPropertyValue("Value");
        var actualDescription = sut.GetPropertyValue("Description");

        // Assert
        Assert.Equal(LogCategoryType.Debug, actualLogCategory);
        Assert.Equal("MyKey", actualKey);
        Assert.Equal("MyValue", actualValue);
        Assert.Equal("MyDescription", actualDescription);
    }

    [Fact]
    public void Clone()
    {
        // Arrange
        var sut = new LogKeyValueItem(
            LogCategoryType.Debug,
            "MyKey",
            "MyValue",
            "MyDescription");

        // Act
        var actual = sut.Clone();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(JsonSerializer.Serialize(sut), JsonSerializer.Serialize(actual));
    }

    [Fact]
    public void Clone_CloneStrategyType()
    {
        // Arrange
        var cloneStrategy = CloneStrategyType.Json;
        var sut = new LogKeyValueItem(
            LogCategoryType.Debug,
            "MyKey",
            "MyValue",
            "MyDescription");

        // Act
        var actual = sut.Clone(cloneStrategy);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(JsonSerializer.Serialize(sut), JsonSerializer.Serialize(actual));
    }
}