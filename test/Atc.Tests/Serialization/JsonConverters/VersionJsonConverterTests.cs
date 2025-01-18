namespace Atc.Tests.Serialization.JsonConverters;

public sealed class VersionJsonConverterTests
{
    [Fact]
    public void SerializeAndDeserialize()
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create(
            new JsonSerializerFactorySettings
            {
                UseConverterVersion = true,
            });

        var data = AssemblyHelper.GetAssemblyInformationsByStartsWith("Atc");

        // Act
        var actualJson = JsonSerializer.Serialize(data, jsonSerializerOptions);
        var actualData = JsonSerializer.Deserialize<List<AssemblyInformation>>(actualJson, jsonSerializerOptions);

        // Assert
        actualData
            .Should()
            .NotBeNull();
    }
}