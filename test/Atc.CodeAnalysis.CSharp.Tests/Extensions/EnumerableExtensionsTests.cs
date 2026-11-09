namespace Atc.CodeAnalysis.CSharp.Tests.Extensions;

public class EnumerableExtensionsTests
{
    [Fact]
    public void ToEquatableArray_Should_Throw_When_Source_Is_Null()
    {
        // Arrange
        IEnumerable<string> source = null!;

        // Act
        var act = () => source.ToEquatableArray();

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ToEquatableArray_Should_Copy_Elements_In_Order()
    {
        // Arrange
        IEnumerable<string> source = new List<string> { "a", "b", "c" };

        // Act
        var actual = source.ToEquatableArray();

        // Assert
        actual.Should().Equal("a", "b", "c");
    }

    [Fact]
    public void ToEquatableArray_Should_Be_Equal_For_Same_Elements()
    {
        // Arrange
        IEnumerable<int> first = new List<int> { 1, 2 };
        IEnumerable<int> second = new[] { 1, 2 };

        // Act
        var left = first.ToEquatableArray();
        var right = second.ToEquatableArray();

        // Assert
        (left == right).Should().BeTrue();
    }

    [Fact]
    public void ToEquatableArray_Should_Return_Empty_For_Empty_Source()
    {
        // Arrange
        var source = Enumerable.Empty<string>();

        // Act
        var actual = source.ToEquatableArray();

        // Assert
        actual.IsEmpty.Should().BeTrue();
    }
}