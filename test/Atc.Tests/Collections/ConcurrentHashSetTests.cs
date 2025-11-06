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