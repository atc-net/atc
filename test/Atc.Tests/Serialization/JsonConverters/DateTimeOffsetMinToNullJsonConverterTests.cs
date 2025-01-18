namespace Atc.Tests.Serialization.JsonConverters;

public sealed class DateTimeOffsetMinToNullJsonConverterTests
{
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void SerializeAndDeserialize(bool useConverterDatetimeOffsetMinToNull)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create(
            new JsonSerializerFactorySettings
            {
                UseConverterDatetimeOffsetMinToNull = useConverterDatetimeOffsetMinToNull,
            });

        var data = new List<VehicleBase>
        {
            new Car("CB12345"),
            new Car("XY12345") { HasSunroof = true, RegistrationDate = DateTimeOffset.Now },
            new Car("AB98765") { HasSunroof = true, RegistrationDate = DateTimeOffset.MinValue },
        };

        // Act
        var actualJson = JsonSerializer.Serialize(data, jsonSerializerOptions);
        var actualData = JsonSerializer.Deserialize<List<VehicleBase>>(actualJson, jsonSerializerOptions);

        // Assert
        actualData
            .Should()
            .NotBeNull();

        var vehicle1 = actualData!
            .First(x => x.PlateNumber == "CB12345");

        var vehicle2 = actualData!
            .First(x => x.PlateNumber == "XY12345");

        var vehicle3 = actualData!
            .First(x => x.PlateNumber == "AB98765");

        if (useConverterDatetimeOffsetMinToNull)
        {
            Assert.True(vehicle1.RegistrationDate is null, $"Vehicle1 - UseConverterDatetimeOffsetMinToNull={useConverterDatetimeOffsetMinToNull}");
            Assert.True(vehicle2.RegistrationDate.HasValue, $"Vehicle2 - UseConverterDatetimeOffsetMinToNull={useConverterDatetimeOffsetMinToNull}");
            Assert.True(vehicle3.RegistrationDate is null, $"Vehicle3 - UseConverterDatetimeOffsetMinToNull={useConverterDatetimeOffsetMinToNull}");
        }
        else
        {
            Assert.True(vehicle1.RegistrationDate is null, $"Vehicle1 - UseConverterDatetimeOffsetMinToNull={useConverterDatetimeOffsetMinToNull}");
            Assert.True(vehicle2.RegistrationDate.HasValue, $"Vehicle2 - UseConverterDatetimeOffsetMinToNull={useConverterDatetimeOffsetMinToNull}");
            Assert.True(vehicle3.RegistrationDate is not null, $"Vehicle3 - UseConverterDatetimeOffsetMinToNull={useConverterDatetimeOffsetMinToNull}");
        }
    }
}