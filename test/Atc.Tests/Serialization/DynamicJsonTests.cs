// ReSharper disable ConditionIsAlwaysTrueOrFalse
namespace Atc.Tests.Serialization;

public class DynamicJsonTests
{
    [Fact]
    public void CanInitializeFromJson()
    {
        // Arrange
        var json = "{\"property\":\"value\"}";

        // Act
        var dynamicJson = new DynamicJson(json);

        // Assert
        Assert.Equal("value", dynamicJson.GetValue("property"));
    }

    [Fact]
    public void ThrowsOnInvalidJson()
    {
        // Arrange
        var json = "this is not valid JSON";

        // Act & Assert
        Assert.Throws<FormatException>(() => new DynamicJson(json));
    }

    [Fact]
    public void CanGetValueFromPath()
    {
        // Arrange
        var json = "{\"property\":{\"nestedProperty\":\"value\"}}";
        var dynamicJson = new DynamicJson(json);

        // Atc
        var actual = dynamicJson.GetValue("property.nestedProperty");

        // Assert
        Assert.Equal("value", actual);
    }

    [Fact]
    public void ReturnsNullForNoneExistentPath()
    {
        // Arrange
        var json = "{\"property\":\"value\"}";
        var dynamicJson = new DynamicJson(json);

        // Act
        var actual = dynamicJson.GetValue("noneExistentProperty");

        // Assert
        Assert.Null(actual);
    }

    [Fact]
    public void CanSetValueAtPath()
    {
        // Arrange
        var json = "{\"property\":\"value\"}";
        var dynamicJson = new DynamicJson(json);

        // Act
        dynamicJson.SetValue("property", "newValue");

        // Assert
        Assert.Equal("newValue", dynamicJson.GetValue("property"));
    }

    [Fact]
    public void CanCreateKeyAndSetValue()
    {
        // Arrange
        var json = "{\"property\":\"value\"}";
        var dynamicJson = new DynamicJson(json);

        // Act
        dynamicJson.SetValue("newProperty", "newValue", createKeyIfNotExist: true);

        // Assert
        Assert.Equal("newValue", dynamicJson.GetValue("newProperty"));
    }

    [Fact]
    public void CanRemovePath()
    {
        // Arrange
        var json = "{\"property\":\"value\", \"propertyNested\":{\"property\":\"value\"}}";
        var dynamicJson = new DynamicJson(json);

        // Act
        var result = dynamicJson.RemovePath("propertyNested");

        // Assert
        Assert.True(result.IsSucceeded);
        Assert.Null(result.ErrorMessage);
    }

    [Fact]
    public void CannotRemoveNonexistentPath()
    {
        // Arrange
        var json = "{\"property\":\"value\"}";
        var dynamicJson = new DynamicJson(json);

        // Act
        var result = dynamicJson.RemovePath("nonexistentProperty");

        // Assert
        Assert.False(result.IsSucceeded);
        Assert.Equal("The path does not exist: nonexistentProperty", result.ErrorMessage);
    }

    [Fact]
    public void CanRemovePartialPath()
    {
        // Arrange
        var json = "{\"propertyOne\":\"valueOne\", \"propertyTwo\":\"valueTwo\"}";
        var dynamicJson = new DynamicJson(json);

        // Act
        var result = dynamicJson.RemovePath("property");

        // Assert
        Assert.True(result.IsSucceeded);
        Assert.Null(result.ErrorMessage);
        Assert.Null(dynamicJson.GetValue("propertyOne"));
        Assert.Null(dynamicJson.GetValue("propertyTwo"));
    }

    [Fact]
    public void ThrowsOnNullPath()
    {
        // Arrange
        var json = "{\"property\":\"value\"}";
        var dynamicJson = new DynamicJson(json);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => dynamicJson.RemovePath(null!));
    }

    [Fact]
    public void CanConvertToJson()
    {
        // Arrange
        var expectedJson = $"{{{Environment.NewLine}  \"property\": \"value\"{Environment.NewLine}}}";
        var json = "{\"property\":\"value\"}";
        var dynamicJson = new DynamicJson(json);

        // Act
        var outputJson = dynamicJson.ToJson();

        // Assert
        Assert.Equal(expectedJson, outputJson);
    }

    [Fact]
    public void CanConvertToJson_CustomSerializerOptions()
    {
        // Arrange
        var expectedJson = $"{{{Environment.NewLine}  \"property\": \"value\"{Environment.NewLine}}}";
        var json = "{\"property\":\"value\"}";
        var dynamicJson = new DynamicJson(json);
        var customOptions = JsonSerializerOptionsFactory.Create();

        // Act
        var outputJson = dynamicJson.ToJson(customOptions);

        // Assert
        Assert.Equal(expectedJson, outputJson);
    }

    [Fact]
    public void CanConvertToJson_CustomSerializerOptions_OrderByKey()
    {
        // Arrange
        var expectedJson = $"{{{Environment.NewLine}  \"property\": \"value\"{Environment.NewLine}}}";
        var json = "{\"property\":\"value\"}";
        var dynamicJson = new DynamicJson(json);
        var customOptions = JsonSerializerOptionsFactory.Create();
        var orderByKey = true;

        // Act
        var outputJson = dynamicJson.ToJson(customOptions, orderByKey);

        // Assert
        Assert.Equal(expectedJson, outputJson);
    }

    [Fact]
    public void CanConvertToJsonWithOrder()
    {
        // Arrange
        var expectedJson = $"{{{Environment.NewLine}  \"property1\": \"value1\",{Environment.NewLine}  \"property2\": \"value2\"{Environment.NewLine}}}";
        var json = "{\"property2\":\"value2\",\"property1\":\"value1\"}";
        var dynamicJson = new DynamicJson(json);

        // Act
        var outputJson = dynamicJson.ToJson(orderByKey: true);

        // Assert
        Assert.Equal(expectedJson, outputJson);
    }
}