namespace Atc.Tests.Collections;

public class ConcurrentHashSetTests
{
    [Fact]
    public void GetEnumerator()
    {
        // Arrange
        var list = new ConcurrentHashSet<int>();

        // Act
        var actual = list.GetEnumerator();

        // Assert
        Assert.Equal(0, actual.Current);
        list.Dispose();
    }

    [Fact]
    public void GetEnumerator_DoesNotThrow_WhenSetIsMutatedDuringEnumeration()
    {
        // Arrange
        using var set = new ConcurrentHashSet<int>();
        for (var i = 0; i < 1000; i++)
        {
            set.TryAdd(i);
        }

        // Act - enumeration iterates a snapshot, so concurrent mutation must not throw.
        var exception = Record.Exception(() =>
        {
            var seed = 1_000;
            foreach (var unused in set)
            {
                set.TryAdd(seed++);
                set.TryRemove(0);
            }
        });

        // Assert
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(true, 27)]
    public void TryAdd(
        bool expected,
        int input)
    {
        // Arrange
        var list = new ConcurrentHashSet<int>();

        // Act
        var actual = list.TryAdd(input);

        // Assert
        Assert.Equal(expected, actual);
        list.Dispose();
    }

    [Theory]
    [InlineData(false, 27)]
    public void TryRemove(
        bool expected,
        int input)
    {
        // Arrange
        var list = new ConcurrentHashSet<int>();

        // Act
        var actual = list.TryRemove(input);

        // Assert
        Assert.Equal(expected, actual);
        list.Dispose();
    }

    [Theory]
    [InlineData(false, 27)]
    public void Contains(
        bool expected,
        int input)
    {
        // Arrange
        var list = new ConcurrentHashSet<int>();

        // Act
        var actual = list.Contains(input);

        // Assert
        Assert.Equal(expected, actual);
        list.Dispose();
    }

    [Fact]
    public void Clear()
    {
        // Arrange
        var list = new ConcurrentHashSet<int>();

        // Act
        list.Clear();

        // Assert
        Assert.Empty(list);
        list.Dispose();
    }

    [Theory]
    [InlineData(0, 27)]
    public void FirstOrDefault(
        int expected,
        int input)
    {
        // Arrange
        var list = new ConcurrentHashSet<int>();

        // Act
        var actual = list.FirstOrDefault(x => x == input);

        // Assert
        Assert.Equal(expected, actual);
        list.Dispose();
    }
}