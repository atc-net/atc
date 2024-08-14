// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable AssignNullToNotNullAttribute
namespace Atc.Tests.Extensions;

[SuppressMessage("AsyncUsage", "AsyncFixer01:Unnecessary async/await usage", Justification = "OK for testing")]
[SuppressMessage("AsyncUsage", "AsyncFixer02:Long-running or blocking operations inside an async method", Justification = "OK for testing")]
public class EnumerableExtensionsTests
{
    [Fact]
    public async Task ToAsyncEnumerable_ConvertsIEnumerableToIAsyncEnumerable()
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

    [Fact]
    public async Task ToAsyncEnumerable_ThrowsArgumentNullException_ForNullSource()
    {
        // Arrange
        IEnumerable<int> source = null;

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await foreach (var item in source.ToAsyncEnumerable())
            {
                // Should not get here
            }
        });
    }

    [Fact]
    public async Task CountAsync_ReturnsCorrectCount()
    {
        // Arrange
        var source = Enumerable.Range(1, 5);

        // Act
        var count = await source.CountAsync();

        // Assert
        Assert.Equal(5, count);
    }

    [Fact]
    public async Task CountAsync_ThrowsArgumentNullException_ForNullSource()
    {
        // Arrange
        IEnumerable<int> source = null;

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await source.CountAsync();
        });
    }

    [Fact]
    public async Task ToListAsync_ReturnsCorrectList()
    {
        // Arrange
        var source = Enumerable.Range(1, 5);

        // Act
        var result = await source.ToListAsync();

        // Assert
        Assert.Equal(source.ToList(), result);
    }

    [Fact]
    public async Task ToListAsync_ThrowsArgumentNullException_ForNullSource()
    {
        // Arrange
        IEnumerable<int> source = null;

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await source.ToListAsync();
        });
    }
}