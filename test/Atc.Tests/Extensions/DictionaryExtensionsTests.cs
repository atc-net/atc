namespace Atc.Tests.Extensions;

public sealed class DictionaryExtensionsTests
{
    [Fact]
    public void GetOrAddTest()
    {
        // Arrange
        var dict = new Dictionary<string, int>(StringComparer.Ordinal);

        // Act
        var value = dict.GetOrAdd("key", 42);

        // Assert
        Assert.Equal(42, value);
        Assert.Equal(42, dict["key"]);

        // Act
        value = dict.GetOrAdd("key", 43);

        // Assert
        Assert.Equal(42, value);
        Assert.Equal(42, dict["key"]);
    }

    [Fact]
    public void GetOrAddFactoryTest()
    {
        // Arrange
        var dict = new Dictionary<string, int>(StringComparer.Ordinal);

        // Act
        var value = dict.GetOrAdd("key", _ => 42);

        // Assert
        Assert.Equal(42, value);
        Assert.Equal(42, dict["key"]);

        // Act
        value = dict.GetOrAdd("key", _ => 43);

        // Assert
        Assert.Equal(42, value);
        Assert.Equal(42, dict["key"]);
    }

    [Fact]
    public void TryUpdateTest()
    {
        // Arrange
        var dict = new Dictionary<string, int>(StringComparer.Ordinal) { ["key"] = 42 };

        // Act
        var result = dict.TryUpdate("key", 43);

        // Assert
        Assert.True(result);
        Assert.Equal(43, dict["key"]);

        // Act
        result = dict.TryUpdate("key2", 43);

        // Assert
        Assert.False(result);
        Assert.Equal(43, dict["key"]);
    }

    [Fact]
    public void TryUpdateFactoryTest()
    {
        // Arrange
        var dict = new Dictionary<string, int>(StringComparer.Ordinal) { ["key"] = 42 };

        // Act
        var result = dict.TryUpdate("key", (_, value) => value + 1);

        // Assert
        Assert.True(result);
        Assert.Equal(43, dict["key"]);

        // Act
        result = dict.TryUpdate("key2", (_, value) => value + 1);

        // Assert
        Assert.False(result);
        Assert.False(dict.TryGetValue("key2", out _));
        Assert.Equal(43, dict["key"]);
    }
}