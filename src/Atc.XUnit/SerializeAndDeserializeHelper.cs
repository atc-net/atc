namespace Atc.XUnit;

public static class SerializeAndDeserializeHelper
{
    public static void Assert<T>(object obj)
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();

        // Act
        var objAsJson = JsonSerializer.Serialize(obj, jsonSerializerOptions);
        var objDeserialize = JsonSerializer.Deserialize<T>(objAsJson, jsonSerializerOptions);

        // Assert
        Xunit.Assert.NotNull(objDeserialize);
        Xunit.Assert.StrictEqual(obj, objDeserialize);
    }
}
