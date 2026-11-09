namespace Atc.CodeAnalysis.CSharp.Tests.Extensions;

public class ImmutableArrayExtensionsTests
{
    [Fact]
    public void ToEquatableArray_Should_Wrap_Elements()
    {
        // Arrange
        var source = ImmutableArray.Create("a", "b");

        // Act
        var actual = source.ToEquatableArray();

        // Assert
        actual.Should().Equal("a", "b");
        (actual.AsImmutableArray() == source).Should().BeTrue();
    }

    [Fact]
    public void ToEquatableArray_Should_Treat_Default_Array_As_Empty()
    {
        // Arrange
        var source = default(ImmutableArray<string>);

        // Act
        var actual = source.ToEquatableArray();

        // Assert
        actual.IsEmpty.Should().BeTrue();
        (actual == EquatableArray<string>.Empty).Should().BeTrue();
    }
}