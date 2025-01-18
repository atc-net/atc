// ReSharper disable NotAccessedField.Local
namespace Atc.Tests.Serialization.JsonConverters;

public sealed class ElementObjectJsonConverterTests
{
    private readonly JsonSerializerOptions options;
    private readonly ElementObjectJsonConverter converter;

    public ElementObjectJsonConverterTests()
    {
        options = new JsonSerializerOptions();
        options.Converters.Add(new ElementObjectJsonConverter());
        converter = new ElementObjectJsonConverter();
    }

    [Fact]
    public void CanConvertToObjectFromJsonObject()
    {
        // Arrange
        var json = "{\"property\":\"value\"}";

        // Act
        var result = JsonSerializer.Deserialize<object>(json, options);

        // Assert
        Assert.IsType<Dictionary<string, object>>(result);
        var dictionary = result as Dictionary<string, object>;
        Assert.Equal("value", dictionary!["property"]);
    }

    [Fact]
    public void CanConvertToObjectFromJsonArray()
    {
        // Arrange
        var json = "[1, 2, 3]";

        // Act
        var result = JsonSerializer.Deserialize<object>(json, options);

        // Assert
        Assert.IsType<List<object>>(result);
        var list = result as List<object>;
        Assert.Equal(3, list!.Count);
    }

    [Fact]
    public void CanConvertToObjectFromJsonString()
    {
        // Arrange
        var json = "\"hello\"";

        // Act
        var result = JsonSerializer.Deserialize<object>(json, options);

        // Assert
        Assert.IsType<string>(result);
        Assert.Equal("hello", result);
    }

    [Fact]
    public void CanConvertToObjectFromJsonNumber()
    {
        // Arrange
        var json = "1234.56";

        // Act
        var result = JsonSerializer.Deserialize<object>(json, options);

        // Assert
        Assert.IsType<decimal>(result);
        Assert.Equal(1234.56m, result);
    }

    [Fact]
    public void CanConvertToObjectFromJsonBooleanTrue()
    {
        // Arrange
        var json = "true";

        // Act
        var result = JsonSerializer.Deserialize<object>(json, options);

        // Assert
        Assert.IsType<bool>(result);
        Assert.True((bool)result);
    }

    [Fact]
    public void CanConvertToObjectFromJsonBooleanFalse()
    {
        // Arrange
        var json = "false";

        // Act
        var result = JsonSerializer.Deserialize<object>(json, options);

        // Assert
        Assert.IsType<bool>(result);
        Assert.False((bool)result);
    }

    [Fact]
    public void CanConvertToObjectFromJsonNull()
    {
        // Arrange
        var json = "null";

        // Act
        var result = JsonSerializer.Deserialize<object>(json, options);

        // Assert
        Assert.Null(result);
    }
}