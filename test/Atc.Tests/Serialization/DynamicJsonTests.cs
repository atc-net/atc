// ReSharper disable ConditionIsAlwaysTrueOrFalse
#pragma warning disable IDE0042
#pragma warning disable MA0003
namespace Atc.Tests.Serialization;

[SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
public class DynamicJsonTests
{
    private const string JsonPropertyValue = """
                                             {
                                               "property": "value"
                                             }
                                             """;

    [Fact]
    public void CanInitializeFromJson()
    {
        // Act
        var dynamicJson = new DynamicJson(JsonPropertyValue);

        // Assert
        Assert.Equal("value", dynamicJson.GetValue("property"));
    }

    [Fact]
    public void ThrowsOnInvalidJson()
    {
        // Arrange
        const string json = "this is not valid JSON";

        // Act & Assert
        Assert.Throws<FormatException>(() => new DynamicJson(json));
    }

    [Fact]
    public void CanGetValueFromPath()
    {
        // Arrange
        const string json = """
                            {
                              "property": {
                                  "nestedProperty": "value"
                                }
                            }
                            """;

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
        var dynamicJson = new DynamicJson(JsonPropertyValue);

        // Act
        var actual = dynamicJson.GetValue("noneExistentProperty");

        // Assert
        Assert.Null(actual);
    }

    [Fact]
    public void CanSetValueAtPath()
    {
        // Arrange
        var dynamicJson = new DynamicJson(JsonPropertyValue);

        // Act
        dynamicJson.SetValue("property", "newValue");

        // Assert
        Assert.Equal("newValue", dynamicJson.GetValue("property"));
    }

    [Theory]
    [InlineData("property", "newValue", true, true, null)]
    [InlineData("newProperty", "newValue", true, true, null)]
    [InlineData("newProperty", "newValue", false, true, null)]
    [InlineData("nested.property", "nestedValue", true, true, null)]
    public void SetValue_WithParameters(
        string path,
        object value,
        bool createKeyIfNotExist,
        bool expectedIsSucceeded,
        string? expectedErrorMessage)
    {
        // Arrange
        var dynamicJson = new DynamicJson(JsonPropertyValue);

        // Act
        var result = dynamicJson.SetValue(path, value, createKeyIfNotExist);

        // Assert
        Assert.Equal(expectedIsSucceeded, result.IsSucceeded);
        Assert.Equal(expectedErrorMessage, result.ErrorMessage);
    }

    [Fact]
    public void CanCreateKeyAndSetValue()
    {
        // Arrange
        var dynamicJson = new DynamicJson(JsonPropertyValue);

        // Act
        dynamicJson.SetValue("newProperty", "newValue", createKeyIfNotExist: true);

        // Assert
        Assert.Equal("newValue", dynamicJson.GetValue("newProperty"));
    }

    [Fact]
    public void CanRemovePath()
    {
        // Arrange
        const string json = """
                            {
                              "property": {
                                  "nestedProperty": "value"
                                }
                            }
                            """;

        var dynamicJson = new DynamicJson(json);

        // Act
        var result = dynamicJson.RemovePath("property.nestedProperty");

        // Assert
        Assert.True(result.IsSucceeded);
        Assert.Null(result.ErrorMessage);
    }

    [Fact]
    public void CannotRemoveNonexistentPath()
    {
        // Arrange
        var dynamicJson = new DynamicJson(JsonPropertyValue);

        // Act
        var result = dynamicJson.RemovePath("nonexistentProperty");

        // Assert
        Assert.False(result.IsSucceeded);
        Assert.Equal("The path does not exist: nonexistentProperty", result.ErrorMessage);
    }

    [Fact]
    public void ThrowsOnNullPath()
    {
        // Arrange
        var dynamicJson = new DynamicJson(JsonPropertyValue);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => dynamicJson.RemovePath(null!));
    }

    [Fact]
    public void CanConvertToJson()
    {
        // Arrange
        var dynamicJson = new DynamicJson(JsonPropertyValue);

        // Act
        var outputJson = dynamicJson.ToJson();

        // Assert
        Assert.Equal(JsonPropertyValue, outputJson);
    }

    [Fact]
    public void CanConvertToJson_CustomSerializerOptions()
    {
        // Arrange
        var dynamicJson = new DynamicJson(JsonPropertyValue);
        var customOptions = JsonSerializerOptionsFactory.Create();

        // Act
        var outputJson = dynamicJson.ToJson(customOptions);

        // Assert
        Assert.Equal(JsonPropertyValue, outputJson);
    }

    [Fact]
    public void CanConvertToJson_CustomSerializerOptions_OrderByKey()
    {
        // Arrange
        const string expectedJson = """
                                    {
                                      "property1": "valueOne",
                                      "property2": "valueTwo"
                                    }
                                    """;

        const string json = """
                            {
                              "property2": "valueTwo",
                              "property1": "valueOne"
                            }
                            """;

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
        const string expectedJson = """
                                    {
                                      "property1": "valueOne",
                                      "property2": "valueTwo"
                                    }
                                    """;

        const string json = """
                            {
                              "property2": "valueTwo",
                              "property1": "valueOne"
                            }
                            """;

        var dynamicJson = new DynamicJson(json);

        // Act
        var outputJson = dynamicJson.ToJson(orderByKey: true);

        // Assert
        Assert.Equal(expectedJson, outputJson);
    }

    [Fact]
    public void CreateJsonScenario1()
    {
        // Arrange
        const string expectedJson = """
                                    {
                                      "Property0": "StrValue1",
                                      "Property1": {
                                        "Property2": "StrValue2",
                                        "Property3": "StrValue3",
                                        "Property4": {
                                          "Items": [
                                            {
                                              "Id": 1,
                                              "Name": "ItemName1"
                                            },
                                            {
                                              "Id": 2,
                                              "Name": "ItemName2",
                                              "Metadata": {
                                                "MetadataItem1": "StrMetadataItem1",
                                                "MetadataItem2": 42,
                                                "MetadataItem3": true
                                              }
                                            }
                                          ]
                                        }
                                      }
                                    }
                                    """;
        const string json = "{}";
        var dynamicJson = new DynamicJson(json);

        // Act
        dynamicJson.SetValue("Property0", "StrValue1");
        dynamicJson.SetValue("Property1.Property2", "StrValue2");
        dynamicJson.SetValue("Property1.Property3", "StrValue3");

        dynamicJson.SetValue("Property1.Property4.Items[0].Id", 1);
        dynamicJson.SetValue("Property1.Property4.Items[0].Name", "ItemName1");

        dynamicJson.SetValue("Property1.Property4.Items[1].Id", 2);
        dynamicJson.SetValue("Property1.Property4.Items[1].Name", "ItemName2");
        dynamicJson.SetValue("Property1.Property4.Items[1].Metadata.MetadataItem1", "StrMetadataItem1");
        dynamicJson.SetValue("Property1.Property4.Items[1].Metadata.MetadataItem2", 42);
        dynamicJson.SetValue("Property1.Property4.Items[1].Metadata.MetadataItem3", true);

        // Assert
        var jsonResult = dynamicJson.ToJson();
        Assert.Equal(expectedJson, jsonResult);
    }

    [Fact]
    public void UpdateJsonScenario1()
    {
        // Arrange
        const string expectedJson = """
                                    {
                                      "Property0": "StrValue1",
                                      "Property1": {
                                        "Property2": "StrValue2",
                                        "Property3": "StrValue3",
                                        "Property4": {
                                          "Items": [
                                            {
                                              "Id": 1,
                                              "Name": "ItemName1"
                                            },
                                            {
                                              "Id": 2,
                                              "Name": "ItemName2",
                                              "Metadata": {
                                                "MetadataItem1": "StrMetadataItem1",
                                                "MetadataItem2": 42,
                                                "MetadataItem3": true
                                              }
                                            }
                                          ]
                                        }
                                      }
                                    }
                                    """;
        const string json = """
                            {
                              "Property0": "StrValue1x",
                              "Property1": {
                                "Property2": "StrValue2x",
                                "Property3": "StrValue3x",
                                "Property4": {
                                  "Items": [
                                    {
                                      "Id": 11,
                                      "Name": "ItemName1x"
                                    }
                                  ]
                                }
                              }
                            }
                            """;

        var dynamicJson = new DynamicJson(json);

        // Act
        dynamicJson.SetValue("Property0", "StrValue1");
        dynamicJson.SetValue("Property1.Property2", "StrValue2");
        dynamicJson.SetValue("Property1.Property3", "StrValue3");

        dynamicJson.SetValue("Property1.Property4.Items[0].Id", 1);
        dynamicJson.SetValue("Property1.Property4.Items[0].Name", "ItemName1");

        dynamicJson.SetValue("Property1.Property4.Items[1].Id", 2);
        dynamicJson.SetValue("Property1.Property4.Items[1].Name", "ItemName2");
        dynamicJson.SetValue("Property1.Property4.Items[1].Metadata.MetadataItem1", "StrMetadataItem1");
        dynamicJson.SetValue("Property1.Property4.Items[1].Metadata.MetadataItem2", 42);
        dynamicJson.SetValue("Property1.Property4.Items[1].Metadata.MetadataItem3", true);

        // Assert
        var jsonResult = dynamicJson.ToJson();
        Assert.Equal(expectedJson, jsonResult);
    }
}