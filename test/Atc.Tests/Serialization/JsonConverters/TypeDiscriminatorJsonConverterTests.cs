namespace Atc.Tests.Serialization.JsonConverters;

public sealed class TypeDiscriminatorJsonConverterTests
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void SerializeAndDeserialize(bool useCamelCase)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create(useCamelCase: useCamelCase);

        var data = new List<VehicleBase>
        {
            new Car("CB12345"),
            new Car("XY12345") { HasSunroof = true },
            new Motorcycle("QQ123"),
        };

        // Act
        var actualJson = JsonSerializer.Serialize(data, jsonSerializerOptions);
        var actualData = JsonSerializer.Deserialize<List<VehicleBase>>(actualJson, jsonSerializerOptions);

        // Assert
        actualData.Should().BeEquivalentTo(data);
    }
}