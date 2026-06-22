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

    [Fact]
    public async Task FromSingleItem_ReturnsAsyncEnumerableWithSingleItem()
    {
        // Arrange
        const int item = 42;

        // Act
        var result = new List<int>();
        await foreach (var value in AsyncEnumerableFactory.FromSingleItem(item))
        {
            result.Add(value);
        }

        // Assert
        Assert.Single(result);
        Assert.Equal(item, result.First());
    }

    [Fact]
    public async Task FromSingleItem_ReturnsAsyncEnumerable_WithReferenceType()
    {
        // Arrange
        const string item = "TestString";

        // Act
        var result = new List<string>();
        await foreach (var value in AsyncEnumerableFactory.FromSingleItem(item))
        {
            result.Add(value);
        }

        // Assert
        Assert.Single(result);
        Assert.Equal(item, result.First());
    }

    [Fact]
    public async Task FromSingleItem_CanBeEnumeratedMultipleTimes()
    {
        // Arrange
        var item = 42;
        var asyncEnumerable = AsyncEnumerableFactory.FromSingleItem(item);

        // Act
        var firstEnumeration = new List<int>();
        await foreach (var value in asyncEnumerable)
        {
            firstEnumeration.Add(value);
        }

        var secondEnumeration = new List<int>();
        await foreach (var value in asyncEnumerable)
        {
            secondEnumeration.Add(value);
        }

        // Assert
        Assert.Single(firstEnumeration);
        Assert.Single(secondEnumeration);
        Assert.Equal(item, firstEnumeration.First());
        Assert.Equal(item, secondEnumeration.First());
    }

    [Fact]
    public async Task FromSingleItem_Cancelled_ThrowsOperationCanceledException()
    {
        // Arrange
        using var cts = new CancellationTokenSource();
        await cts.CancelAsync();
        var collected = new List<int>();

        // Act & Assert
        await Assert.ThrowsAsync<OperationCanceledException>(async () =>
        {
            await foreach (var item in AsyncEnumerableFactory.FromSingleItem(42).WithCancellation(cts.Token))
            {
                collected.Add(item);
            }
        });
    }

    [Fact]
    public async Task FromItems_ReturnsAllElements()
    {
        // Arrange
        var items = new[] { 1, 2, 3, 4, 5 };
        var result = new List<int>();

        // Act
        await foreach (var value in AsyncEnumerableFactory.FromItems(items))
        {
            result.Add(value);
        }

        // Assert
        Assert.Equal(items, result);
    }

    [Fact]
    public async Task FromItems_EmptyArray_ReturnsEmpty()
    {
        // Arrange
        var result = new List<int>();

        // Act
        await foreach (var value in AsyncEnumerableFactory.FromItems(Array.Empty<int>()))
        {
            result.Add(value);
        }

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task FromItems_Cancelled_ThrowsOperationCanceledException()
    {
        // Arrange
        var items = new[] { 1, 2, 3 };
        using var cts = new CancellationTokenSource();
        await cts.CancelAsync();
        var collected = new List<int>();

        // Act & Assert
        await Assert.ThrowsAsync<OperationCanceledException>(async () =>
        {
            await foreach (var item in AsyncEnumerableFactory.FromItems(items).WithCancellation(cts.Token))
            {
                collected.Add(item);
            }
        });
    }

    [Fact]
    public async Task FromEnumerable_ReturnsAllElements()
    {
        // Arrange
        var source = new List<string> { "a", "b", "c" };
        var result = new List<string>();

        // Act
        await foreach (var value in AsyncEnumerableFactory.FromEnumerable(source))
        {
            result.Add(value);
        }

        // Assert
        Assert.Equal(source, result);
    }

    [Fact]
    public async Task FromEnumerable_Cancelled_ThrowsOperationCanceledException()
    {
        // Arrange
        var source = new[] { 1, 2, 3 };
        using var cts = new CancellationTokenSource();
        await cts.CancelAsync();
        var collected = new List<int>();

        // Act & Assert
        await Assert.ThrowsAsync<OperationCanceledException>(async () =>
        {
            await foreach (var item in AsyncEnumerableFactory.FromEnumerable(source).WithCancellation(cts.Token))
            {
                collected.Add(item);
            }
        });
    }

    [Fact]
    public async Task FromTask_YieldsSingleResult()
    {
        // Arrange
        var task = Task.FromResult(42);

        // Act
        var result = new List<int>();
        await foreach (var value in AsyncEnumerableFactory.FromTask(task))
        {
            result.Add(value);
        }

        // Assert
        Assert.Single(result);
        Assert.Equal(42, result[0]);
    }

    [Fact]
    public async Task FromTask_Cancelled_ThrowsOperationCanceledException()
    {
        // Arrange
        var task = Task.FromResult(42);
        using var cts = new CancellationTokenSource();
        await cts.CancelAsync();
        var collected = new List<int>();

        // Act & Assert
        await Assert.ThrowsAsync<OperationCanceledException>(async () =>
        {
            await foreach (var item in AsyncEnumerableFactory.FromTask(task).WithCancellation(cts.Token))
            {
                collected.Add(item);
            }
        });
    }
}