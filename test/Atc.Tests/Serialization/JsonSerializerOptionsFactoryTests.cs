namespace Atc.Tests.Serialization;

public class JsonSerializerOptionsFactoryTests
{
    [Fact]
    public void Create_WithDefaultParameters()
    {
        // Act
        var actual = JsonSerializerOptionsFactory.Create();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(JsonNamingPolicy.CamelCase, actual.PropertyNamingPolicy);
        Assert.Equal(JsonIgnoreCondition.WhenWritingNull, actual.DefaultIgnoreCondition);
        Assert.True(actual.PropertyNameCaseInsensitive);
        Assert.True(actual.WriteIndented);
    }

    [Fact]
    public void Create_WithCustomParameters()
    {
        // Act
        var actual = JsonSerializerOptionsFactory.Create(
            useCamelCase: false,
            ignoreNullValues: false,
            propertyNameCaseInsensitive: false,
            writeIndented: false);

        // Assert
        Assert.NotNull(actual);
        Assert.Null(actual.PropertyNamingPolicy);
        Assert.Equal(JsonIgnoreCondition.Never, actual.DefaultIgnoreCondition);
        Assert.False(actual.PropertyNameCaseInsensitive);
        Assert.False(actual.WriteIndented);
    }

    [Fact]
    public void Create_WithSettings()
    {
        // Arrange
        var settings = new JsonSerializerFactorySettings
        {
            UseCamelCase = true,
            IgnoreNullValues = true,
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
            UseConverterEnumAsString = true,
            UseConverterTimespan = true,
        };

        // Act
        var actual = JsonSerializerOptionsFactory.Create(settings);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(JsonNamingPolicy.CamelCase, actual.PropertyNamingPolicy);
        Assert.Equal(JsonIgnoreCondition.WhenWritingNull, actual.DefaultIgnoreCondition);
        Assert.True(actual.PropertyNameCaseInsensitive);
        Assert.True(actual.WriteIndented);
        Assert.Contains(actual.Converters, c => c is JsonStringEnumConverter);
        Assert.Contains(actual.Converters, c => c is TimeSpanJsonConverter);
    }

    [Fact]
    public void Create_WithNullSettings_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => JsonSerializerOptionsFactory.Create(null!));
    }
}