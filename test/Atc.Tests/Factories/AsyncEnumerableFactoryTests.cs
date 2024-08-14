// ReSharper disable PossibleMultipleEnumeration
namespace Atc.Tests.Factories;

public class AsyncEnumerableFactoryTests
{
    [Fact]
    public async Task Empty_ReturnsEmptySequence()
    {
        // Arrange
        var result = new List<int>();

        // Act
        await foreach (var item in AsyncEnumerableFactory.Empty<int>())
        {
            result.Add(item);
        }

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task Empty_ReturnsEmptySequence_ForReferenceType()
    {
        // Arrange
        var result = new List<string>();

        // Act
        await foreach (var item in AsyncEnumerableFactory.Empty<string>())
        {
            result.Add(item);
        }

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task Empty_ReturnsEmptySequence_WhenEnumeratedMultipleTimes()
    {
        // Arrange & Act
        var emptyEnumerable = AsyncEnumerableFactory.Empty<int>();
        var firstResult = new List<int>();
        var secondResult = new List<int>();

        await foreach (var item in emptyEnumerable)
        {
            firstResult.Add(item);
        }

        await foreach (var item in emptyEnumerable)
        {
            secondResult.Add(item);
        }

        // Assert
        Assert.Empty(firstResult);
        Assert.Empty(secondResult);
    }

    [Fact]
    public async Task Empty_ReturnsEmptySequence_WithDifferentTypes()
    {
        // Arrange
        var intResult = new List<int>();

        // Act & Assert
        await foreach (var item in AsyncEnumerableFactory.Empty<int>())
        {
            intResult.Add(item);
        }

        var stringResult = new List<string>();
        await foreach (var item in AsyncEnumerableFactory.Empty<string>())
        {
            stringResult.Add(item);
        }

        var customTypeResult = new List<LogKeyValueItem>();
        await foreach (var item in AsyncEnumerableFactory.Empty<LogKeyValueItem>())
        {
            customTypeResult.Add(item);
        }

        Assert.Empty(intResult);
        Assert.Empty(stringResult);
        Assert.Empty(customTypeResult);
    }
}