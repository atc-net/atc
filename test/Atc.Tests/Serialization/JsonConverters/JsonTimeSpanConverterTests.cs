namespace Atc.Tests.Serialization.JsonConverters;

public class JsonTimeSpanConverterTests
{
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void SerializeAndDeserialize(bool useConverterTimespan)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create(
            new JsonSerializerFactorySettings
            {
                UseConverterTimespan = useConverterTimespan,
            });

        var data = new List<VehicleBase>
        {
            new Car("CB12345"),
            new Car("XY12345") { HasSunroof = true, RemainingLifeTime = TimeSpan.FromHours(1) },
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

        if (useConverterTimespan)
        {
            Assert.True(vehicle1.RemainingLifeTime == default, "Vehicle1 - UseConverterTimespan=True");
            Assert.True(vehicle2.RemainingLifeTime == TimeSpan.FromHours(1), "Vehicle2 - UseConverterTimespan=True");
        }
        else
        {
            Assert.True(vehicle1.RemainingLifeTime == default, "Vehicle1 - UseConverterTimespan=False");
            Assert.True(vehicle2.RemainingLifeTime == TimeSpan.FromHours(1), "Vehicle2 - UseConverterTimespan=False");
        }
    }
}