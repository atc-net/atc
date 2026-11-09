namespace Atc.Tests.Serialization.JsonConverters;

public sealed class StringEnumMemberJsonConverterFactoryTests
{
    [Fact]
    public void NonNullableEnum_IsStrict()
    {
        // Arrange
        var options = new JsonSerializerOptions { Converters = { new StringEnumMemberJsonConverterFactory() } };

        // Act & Assert
        Assert.Equal(TestSessionState.Completed, JsonSerializer.Deserialize<TestSessionState>("\"done\"", options));
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<TestSessionState>("\"something-new\"", options));
    }

    [Fact]
    public void NullableEnum_IsLenientByDefault()
    {
        // Arrange
        var options = new JsonSerializerOptions { Converters = { new StringEnumMemberJsonConverterFactory() } };

        // Act & Assert
        Assert.Null(JsonSerializer.Deserialize<TestSessionState?>("\"something-new\"", options));
        Assert.Equal(TestSessionState.InProgress, JsonSerializer.Deserialize<TestSessionState?>("\"in-progress\"", options));
    }

    [Fact]
    public void NullableEnum_IsStrict_WhenLeniencyIsTurnedOff()
    {
        // Arrange
        var options = new JsonSerializerOptions { Converters = { new StringEnumMemberJsonConverterFactory(lenientForNullable: false) } };

        // Act & Assert
        Assert.Null(JsonSerializer.Deserialize<TestSessionState?>("null", options));
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<TestSessionState?>("\"something-new\"", options));
    }

    [Fact]
    public void UnknownValues_AreReported()
    {
        // Arrange
        string? reported = null;
        var options = new JsonSerializerOptions
        {
            Converters = { new StringEnumMemberJsonConverterFactory(onUnknownValue: (_, value) => reported = value) },
        };

        // Act
        JsonSerializer.Deserialize<TestSessionState?>("\"something-new\"", options);

        // Assert
        Assert.Equal("something-new", reported);
    }

    [Theory]
    [InlineData(typeof(TestSessionState), true)]
    [InlineData(typeof(TestSessionState?), true)]
    [InlineData(typeof(string), false)]
    [InlineData(typeof(int?), false)]
    public void CanConvert(
        Type type,
        bool expected)
    {
        // Arrange
        var factory = new StringEnumMemberJsonConverterFactory();

        // Act
        var result = factory.CanConvert(type);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(typeof(TestSessionState), typeof(StringEnumMemberJsonConverter<TestSessionState>))]
    [InlineData(typeof(TestSessionState?), typeof(LenientStringEnumMemberJsonConverter<TestSessionState>))]
    public void CreateConverter(
        Type typeToConvert,
        Type expectedConverterType)
    {
        // Arrange
        var factory = new StringEnumMemberJsonConverterFactory();

        // Act
        var result = factory.CreateConverter(typeToConvert, new JsonSerializerOptions());

        // Assert
        Assert.IsType(expectedConverterType, result);
    }
}