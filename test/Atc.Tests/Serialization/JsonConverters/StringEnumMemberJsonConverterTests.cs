namespace Atc.Tests.Serialization.JsonConverters;

public sealed class StringEnumMemberJsonConverterTests
{
    [Theory]
    [InlineData(ChargePointState.BusyNonCharging, "busy-non-charging")]
    [InlineData(ChargePointState.TestWithoutEnumMember, "testWithoutEnumMember")]
    public void Read_ShouldReturnExpectedChargePointState(
        ChargePointState expected,
        string enumValue)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new StringEnumMemberJsonConverter<ChargePointState>();
        var json = $"\"{enumValue.Replace("\\", "\\\\", StringComparison.Ordinal)}\"";
        var utf8JsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));

        utf8JsonReader.Read();

        // Act
        var result = jsonConverter.Read(ref utf8JsonReader, typeof(ChargePointState), jsonSerializerOptions);

        // Assert
        if (OperatingSystem.IsWindows())
        {
            Assert.Equal(expected, result);
        }
    }

    [Theory]
    [InlineData("busy-non-charging", ChargePointState.BusyNonCharging)]
    [InlineData("testWithoutEnumMember", ChargePointState.TestWithoutEnumMember)]
    public void Write_ShouldWriteChargePointStateToUtf8JsonWriter(
        string expected,
        ChargePointState chargePointState)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new StringEnumMemberJsonConverter<ChargePointState>();
        var memoryStream = new MemoryStream();
        using var utf8JsonWriter = new Utf8JsonWriter(memoryStream);

        // Act
        jsonConverter.Write(utf8JsonWriter, chargePointState, jsonSerializerOptions);

        // Assert
        utf8JsonWriter.Flush();
        var result = Encoding.UTF8.GetString(memoryStream.ToArray());

        if (OperatingSystem.IsWindows())
        {
            Assert.Equal($"\"{expected}\"", result.Replace("\\\\", "\\", StringComparison.Ordinal));
        }
    }

    [Theory]
    [InlineData("\"in-progress\"", TestSessionState.InProgress)]
    [InlineData("\"done\"", TestSessionState.Completed)]
    [InlineData("\"completed\"", TestSessionState.Completed)]
    [InlineData("\"Completed\"", TestSessionState.Completed)]
    [InlineData("\"cancelled-by-user\"", TestSessionState.Cancelled)]
    public void Read_HonoursJsonStringEnumMemberName(
        string json,
        TestSessionState expected)
        => Assert.Equal(
            expected,
            JsonSerializer.Deserialize<TestSessionState>(
                json,
                new JsonSerializerOptions { Converters = { new StringEnumMemberJsonConverter<TestSessionState>() } }));

    [Theory]
    [InlineData(TestSessionState.InProgress, "\"in-progress\"")]
    [InlineData(TestSessionState.Completed, "\"done\"")]
    [InlineData(TestSessionState.Cancelled, "\"Cancelled-by-user\"")]
    [InlineData(TestSessionState.Pending, "\"Pending\"")]
    public void Write_UsesJsonStringEnumMemberNameExactly(
        TestSessionState value,
        string expected)
        => Assert.Equal(
            expected,
            JsonSerializer.Serialize(
                value,
                new JsonSerializerOptions { Converters = { new StringEnumMemberJsonConverter<TestSessionState>() } }));

    [Theory]
    [InlineData(TestSessionState.InProgress, "\"in-progress\"")]
    [InlineData(TestSessionState.Cancelled, "\"cancelled-by-user\"")]
    [InlineData(TestSessionState.Pending, "\"pending\"")]
    public void Write_CamelCasePolicy_AppliesToNamesWithoutJsonStringEnumMemberName(
        TestSessionState value,
        string expected)
        => Assert.Equal(
            expected,
            JsonSerializer.Serialize(
                value,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters = { new StringEnumMemberJsonConverter<TestSessionState>() },
                }));

    [Theory]
    [InlineData("\"something-new\"")]
    [InlineData("42")]
    public void Read_ThrowsJsonException_ForUnknownValues(string json)
        => Assert.Throws<JsonException>(() =>
            JsonSerializer.Deserialize<TestSessionState>(
                json,
                new JsonSerializerOptions { Converters = { new StringEnumMemberJsonConverter<TestSessionState>() } }));
}