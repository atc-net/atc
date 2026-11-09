namespace Atc.Tests.Serialization.JsonConverters;

public sealed class LenientStringEnumMemberJsonConverterTests
{
    [Theory]
    [InlineData("\"in-progress\"", TestSessionState.InProgress)]
    [InlineData("\"done\"", TestSessionState.Completed)]
    [InlineData("\"cancelled-by-user\"", TestSessionState.Cancelled)]
    [InlineData("\"Pending\"", TestSessionState.Pending)]
    [InlineData("\"InProgress\"", TestSessionState.InProgress)]
    [InlineData("null", null)]
    [InlineData("\"something-new\"", null)]
    [InlineData("42", null)]
    public void Read(
        string json,
        TestSessionState? expected)
        => Assert.Equal(expected, JsonSerializer.Deserialize<TestSessionState?>(json, Options()));

    [Theory]
    [InlineData("\"done\"", TestSessionState.Completed)]
    [InlineData("\"something-new\"", null)]
    public void Read_FromReader(
        string json,
        TestSessionState? expected)
    {
        // Arrange
        var jsonConverter = new LenientStringEnumMemberJsonConverter<TestSessionState>();
        var utf8JsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));
        utf8JsonReader.Read();

        // Act
        var result = jsonConverter.Read(ref utf8JsonReader, typeof(TestSessionState?), new JsonSerializerOptions());

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Read_ReportsUnknownValues()
    {
        // Arrange
        var unknown = new List<(Type Type, string? Value)>();
        var options = Options((type, value) => unknown.Add((type, value)));

        // Act
        JsonSerializer.Deserialize<TestSessionState?>("\"something-new\"", options);
        JsonSerializer.Deserialize<TestSessionState?>("\"done\"", options);

        // Assert
        Assert.Equal((typeof(TestSessionState), "something-new"), Assert.Single(unknown));
    }

    [Theory]
    [InlineData(TestSessionState.InProgress, "\"in-progress\"")]
    [InlineData(TestSessionState.Completed, "\"done\"")]
    [InlineData(null, "null")]
    public void Write(
        TestSessionState? value,
        string expected)
        => Assert.Equal(expected, JsonSerializer.Serialize(value, Options()));

    [Fact]
    public void Read_UnknownValueInAnObject_KeepsTheRest()
    {
        // Act
        var result = JsonSerializer.Deserialize<Session>(
            "{\"State\":\"something-new\",\"Name\":\"A\"}",
            Options());

        // Assert
        Assert.NotNull(result);
        Assert.Null(result.State);
        Assert.Equal("A", result.Name);
    }

    private static JsonSerializerOptions Options(
        Action<Type, string?>? onUnknownValue = null)
        => new() { Converters = { new LenientStringEnumMemberJsonConverter<TestSessionState>(onUnknownValue) } };

    private sealed record Session(
        TestSessionState? State,
        string? Name);
}