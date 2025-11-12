// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable AssignNullToNotNullAttribute
namespace Atc.Tests.Extensions;

[SuppressMessage("AsyncUsage", "AsyncFixer01:Unnecessary async/await usage", Justification = "OK for testing")]
[SuppressMessage("AsyncUsage", "AsyncFixer02:Long-running or blocking operations inside an async method", Justification = "OK for testing")]
public class EnumerableExtensionsTests
{
    [Fact]
    public void SelectToArray_ProjectsAndConvertsToArray()
    {
        // Arrange
        var source = new[] { 1, 2, 3, 4, 5 };

        // Act
        var actual = source.SelectToArray(x => x * 2);

        // Assert
        Assert.Equal(new[] { 2, 4, 6, 8, 10 }, actual);
        Assert.IsType<int[]>(actual);
    }

    [Fact]
    public void SelectToArray_WithComplexTransformation()
    {
        // Arrange
        var source = new[] { "apple", "banana", "cherry" };

        // Act
        var actual = source.SelectToArray(x => x.ToUpperInvariant());

        // Assert
        Assert.Equal(new[] { "APPLE", "BANANA", "CHERRY" }, actual);
    }

    [Fact]
    public void SelectToArray_ThrowsArgumentNullException_ForNullSource()
    {
        // Arrange
        IEnumerable<int>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => source!.SelectToArray(x => x * 2));
    }

    [Fact]
    public void SelectToArray_ThrowsArgumentNullException_ForNullSelector()
    {
        // Arrange
        var source = new[] { 1, 2, 3 };
        Func<int, int>? selector = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => source.SelectToArray(selector!));
    }

    [Fact]
    public void SelectToList_ProjectsAndConvertsToList()
    {
        // Arrange
        var source = new[] { 1, 2, 3, 4, 5 };

        // Act
        var actual = source.SelectToList(x => x * 2);

        // Assert
        Assert.Equal(new List<int> { 2, 4, 6, 8, 10 }, actual);
        Assert.IsType<List<int>>(actual);
    }

    [Fact]
    public void SelectToList_WithComplexTransformation()
    {
        // Arrange
        var source = new[] { "apple", "banana", "cherry" };

        // Act
        var actual = source.SelectToList(x => x.Length);

        // Assert
        Assert.Equal(new List<int> { 5, 6, 6 }, actual);
    }

    [Fact]
    public void SelectToList_ThrowsArgumentNullException_ForNullSource()
    {
        // Arrange
        IEnumerable<int>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => source!.SelectToList(x => x * 2));
    }

    [Fact]
    public void SelectToList_ThrowsArgumentNullException_ForNullSelector()
    {
        // Arrange
        var source = new[] { 1, 2, 3 };
        Func<int, int>? selector = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => source.SelectToList(selector!));
    }

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