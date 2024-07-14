namespace Atc.Tests.Serialization.JsonConverters;

public class JsonStringEnumMemberConverterTests
{
    [Theory]
    [InlineData(ChargePointState.BusyNonCharging, "busy-non-charging")]
    [InlineData(ChargePointState.TestWithoutEnumMember, "testWithoutEnumMember")]
    public void Read_ShouldReturnExpectedChargePointState(ChargePointState expected, string enumValue)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new JsonStringEnumMemberConverter<ChargePointState>();
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
    public void Write_ShouldWriteChargePointStateToUtf8JsonWriter(string expected, ChargePointState chargePointState)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        var jsonConverter = new JsonStringEnumMemberConverter<ChargePointState>();
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
}