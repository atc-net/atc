namespace Atc.Tests.Serialization.JsonConverters;

public sealed class UnixDateTimeOffsetJsonConverterTests
{
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void SerializeAndDeserialize(bool useConverterUnixDatetimeOffset)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create(
            new JsonSerializerFactorySettings
            {
                UseConverterUnixDatetimeOffset = useConverterUnixDatetimeOffset,
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
        actualData.Should().NotBeNull();

        var vehicle1 = actualData!
            .First(x => x.PlateNumber == "CB12345");

        var vehicle2 = actualData!
            .First(x => x.PlateNumber == "XY12345");

        var vehicle3 = actualData!
            .First(x => x.PlateNumber == "AB98765");

        if (useConverterUnixDatetimeOffset)
        {
            Assert.True(vehicle1.RegistrationDate is null, $"Vehicle1 - UseConverterDatetimeUnixDatetimeOffset={useConverterUnixDatetimeOffset}");
            Assert.True(vehicle2.RegistrationDate.HasValue, $"Vehicle2 - UseConverterDatetimeUnixDatetimeOffset={useConverterUnixDatetimeOffset}");
            Assert.True(vehicle3.RegistrationDate is null, $"Vehicle3 - UseConverterDatetimeUnixDatetimeOffset={useConverterUnixDatetimeOffset}");
        }
        else
        {
            Assert.True(vehicle1.RegistrationDate is null, $"Vehicle1 - UseConverterDatetimeUnixDatetimeOffset={useConverterUnixDatetimeOffset}");
            Assert.True(vehicle2.RegistrationDate.HasValue, $"Vehicle2 - UseConverterDatetimeUnixDatetimeOffset={useConverterUnixDatetimeOffset}");
            Assert.True(vehicle3.RegistrationDate is not null, $"Vehicle3 - UseConverterDatetimeUnixDatetimeOffset={useConverterUnixDatetimeOffset}");
        }
    }
}