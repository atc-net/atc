// ReSharper disable PossibleMultipleEnumeration
namespace Atc.Tests.Extensions;

public class EnumerableExtensionsTests
{
    [Fact]
    public async Task ToAsyncEnumerable()
    {
        // Arrange
        var source = Enumerable.Range(1, 5);

        // Act
        var result = new List<int>();
        await foreach (var item in source.ToAsyncEnumerable())
        {
            result.Add(item);
        }

        // Assert
        Assert.Equal(source, result);
    }
}