namespace Atc.CodeAnalysis.CSharp.Tests;

public class EquatableArrayTests
{
    [Fact]
    public void Constructor_Should_Treat_Default_ImmutableArray_As_Empty()
    {
        // Act
        var actual = new EquatableArray<string>(default);

        // Assert
        actual.IsEmpty.Should().BeTrue();
        actual.Length.Should().Be(0);
        actual.AsImmutableArray().IsDefault.Should().BeFalse();
    }

    [Fact]
    public void Default_Instance_Should_Behave_As_Empty()
    {
        // Arrange
        var actual = default(EquatableArray<string>);

        // Assert
        actual.IsEmpty.Should().BeTrue();
        actual.Length.Should().Be(0);
        actual.Count.Should().Be(0);
        actual.AsImmutableArray().IsDefault.Should().BeFalse();
        actual.GetHashCode().Should().Be(EquatableArray<string>.Empty.GetHashCode());
        actual.Equals(EquatableArray<string>.Empty).Should().BeTrue();
        (actual == EquatableArray<string>.Empty).Should().BeTrue();
        actual.Should().BeEmpty();
    }

    [Fact]
    public void Empty_Should_Have_No_Elements()
    {
        // Act
        var actual = EquatableArray<int>.Empty;

        // Assert
        actual.IsEmpty.Should().BeTrue();
        actual.Length.Should().Be(0);
    }

    [Fact]
    public void Length_And_Count_Should_Return_Number_Of_Elements()
    {
        // Arrange
        var sut = new EquatableArray<int>(ImmutableArray.Create(1, 2, 3));

        // Assert
        sut.Length.Should().Be(3);
        sut.Count.Should().Be(3);
        sut.IsEmpty.Should().BeFalse();
    }

    [Fact]
    public void Indexer_Should_Return_Element_At_Index()
    {
        // Arrange
        var sut = new EquatableArray<string>(ImmutableArray.Create("a", "b", "c"));

        // Act & Assert
        sut[0].Should().Be("a");
        sut[2].Should().Be("c");
    }

    [Fact]
    public void Indexer_Should_Throw_When_Index_Is_Out_Of_Range()
    {
        // Arrange
        var sut = new EquatableArray<string>(ImmutableArray.Create("a"));

        // Act
        var act = () => sut[1];

        // Assert
        act.Should().Throw<IndexOutOfRangeException>();
    }

    [Fact]
    public void AsImmutableArray_Should_Return_The_Wrapped_Array()
    {
        // Arrange
        var values = ImmutableArray.Create(1, 2, 3);
        var sut = new EquatableArray<int>(values);

        // Act
        var actual = sut.AsImmutableArray();

        // Assert
        (actual == values).Should().BeTrue();
    }

    [Fact]
    public void Equals_Should_Be_True_For_Same_Elements_In_Different_Arrays()
    {
        // Arrange
        var left = new EquatableArray<string>(ImmutableArray.Create("a", "b"));
        var right = new EquatableArray<string>(ImmutableArray.Create("a", "b"));

        // Act & Assert
        left.Equals(right).Should().BeTrue();
        left.Equals((object)right).Should().BeTrue();
        left.GetHashCode().Should().Be(right.GetHashCode());
    }

    [Fact]
    public void Equals_Should_Compare_Records_By_Value()
    {
        // Arrange
        var left = new EquatableArray<Item>(ImmutableArray.Create(new Item("x", 1)));
        var right = new EquatableArray<Item>(ImmutableArray.Create(new Item("x", 1)));

        // Act & Assert
        left.Equals(right).Should().BeTrue();
        left.GetHashCode().Should().Be(right.GetHashCode());
    }

    [Theory]
    [InlineData(new[] { "a", "b" }, new[] { "a", "c" })]
    [InlineData(new[] { "a", "b" }, new[] { "b", "a" })]
    [InlineData(new[] { "a", "b" }, new[] { "a" })]
    [InlineData(new[] { "a" }, new string[0])]
    public void Equals_Should_Be_False_For_Different_Elements(
        string[] leftValues,
        string[] rightValues)
    {
        // Arrange
        var left = new EquatableArray<string>(leftValues.ToImmutableArray());
        var right = new EquatableArray<string>(rightValues.ToImmutableArray());

        // Act & Assert
        left.Equals(right).Should().BeFalse();
        right.Equals(left).Should().BeFalse();
    }

    [Fact]
    public void Equals_Should_Be_False_For_Other_Object_Types()
    {
        // Arrange
        var sut = new EquatableArray<string>(ImmutableArray.Create("a"));

        // Act & Assert
        sut.Equals(null).Should().BeFalse();
        sut.Equals("a").Should().BeFalse();
        sut.Equals((object)ImmutableArray.Create("a")).Should().BeFalse();
    }

    [Fact]
    public void Equals_And_GetHashCode_Should_Allow_Null_Elements()
    {
        // Arrange
        var left = new EquatableArray<string>(ImmutableArray.Create("a", null!, "c"));
        var right = new EquatableArray<string>(ImmutableArray.Create("a", null!, "c"));
        var other = new EquatableArray<string>(ImmutableArray.Create("a", "b", "c"));

        // Act & Assert
        left.Equals(right).Should().BeTrue();
        left.GetHashCode().Should().Be(right.GetHashCode());
        left.Equals(other).Should().BeFalse();
        other.Equals(left).Should().BeFalse();
    }

    [Fact]
    public void Equality_Operators_Should_Compare_By_Value()
    {
        // Arrange
        var left = new EquatableArray<int>(ImmutableArray.Create(1, 2));
        var same = new EquatableArray<int>(ImmutableArray.Create(1, 2));
        var different = new EquatableArray<int>(ImmutableArray.Create(2, 1));

        // Act & Assert
        (left == same).Should().BeTrue();
        (left != same).Should().BeFalse();
        (left == different).Should().BeFalse();
        (left != different).Should().BeTrue();
    }

    [Fact]
    public void Implicit_Conversion_Should_Wrap_ImmutableArray()
    {
        // Arrange
        var values = ImmutableArray.Create(1, 2, 3);

        // Act
        EquatableArray<int> actual = values;

        // Assert
        actual.Length.Should().Be(3);
        (actual == new EquatableArray<int>(values)).Should().BeTrue();
    }

    [Fact]
    public void Implicit_Conversion_Should_Treat_Default_ImmutableArray_As_Empty()
    {
        // Arrange
        var values = default(ImmutableArray<int>);

        // Act
        EquatableArray<int> actual = values;

        // Assert
        actual.IsEmpty.Should().BeTrue();
    }

    [Fact]
    public void GetEnumerator_Should_Return_Elements_In_Order()
    {
        // Arrange
        var sut = new EquatableArray<string>(ImmutableArray.Create("a", "b"));

        // Act
        var enumerator = sut.GetEnumerator();

        // Assert
        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be("a");
        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be("b");
        enumerator.MoveNext().Should().BeFalse();
    }

    [Fact]
    public void Should_Enumerate_As_IEnumerable()
    {
        // Arrange
        var sut = new EquatableArray<int>(ImmutableArray.Create(1, 2, 3));

        // Act
        IEnumerable<int> enumerable = sut;
        IReadOnlyList<int> list = sut;

        // Assert
        enumerable.Should().Equal(1, 2, 3);
        list.Count.Should().Be(3);
        list[1].Should().Be(2);
        ((System.Collections.IEnumerable)sut).Cast<int>().Should().Equal(1, 2, 3);
    }

    private sealed record Item(
        string Name,
        int Value);
}