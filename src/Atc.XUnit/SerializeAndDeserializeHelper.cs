namespace Atc.XUnit;

/// <summary>
/// Provides helper methods for testing JSON serialization and deserialization.
/// </summary>
public static class SerializeAndDeserializeHelper
{
    /// <summary>
    /// Asserts that an object can be serialized to JSON and deserialized back to the original type with equal values.
    /// </summary>
    /// <typeparam name="T">The type to deserialize to.</typeparam>
    /// <param name="obj">The object to serialize and deserialize.</param>
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