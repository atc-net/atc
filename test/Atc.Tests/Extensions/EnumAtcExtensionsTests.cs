namespace Atc.Tests.Extensions;

public class EnumAtcExtensionsTests
{
    [Theory]
    [InlineData(ArrowDirectionType.Left, ArrowDirectionType.Right)]
    [InlineData(ArrowDirectionType.Up, ArrowDirectionType.Down)]
    [InlineData(ArrowDirectionType.Right, ArrowDirectionType.Left)]
    [InlineData(ArrowDirectionType.Down, ArrowDirectionType.Up)]
    [InlineData(ArrowDirectionType.None, ArrowDirectionType.None)]
    public void Opposite_ArrowDirectionType(ArrowDirectionType expected, ArrowDirectionType input)
        => Assert.Equal(expected, input.Opposite());

    [Theory]
    [InlineData(CardinalDirectionType.North, CardinalDirectionType.South)]
    [InlineData(CardinalDirectionType.NorthNorthEast, CardinalDirectionType.SouthSouthWest)]
    [InlineData(CardinalDirectionType.NorthEast, CardinalDirectionType.SouthWest)]
    [InlineData(CardinalDirectionType.EastNorthEast, CardinalDirectionType.WestSouthWest)]
    [InlineData(CardinalDirectionType.East, CardinalDirectionType.West)]
    [InlineData(CardinalDirectionType.EastSouthEast, CardinalDirectionType.WestNorthWest)]
    [InlineData(CardinalDirectionType.SouthEast, CardinalDirectionType.NorthWest)]
    [InlineData(CardinalDirectionType.SouthSouthEast, CardinalDirectionType.NorthNorthWest)]
    [InlineData(CardinalDirectionType.South, CardinalDirectionType.North)]
    [InlineData(CardinalDirectionType.SouthSouthWest, CardinalDirectionType.NorthNorthEast)]
    [InlineData(CardinalDirectionType.SouthWest, CardinalDirectionType.NorthEast)]
    [InlineData(CardinalDirectionType.WestSouthWest, CardinalDirectionType.EastNorthEast)]
    [InlineData(CardinalDirectionType.West, CardinalDirectionType.East)]
    [InlineData(CardinalDirectionType.WestNorthWest, CardinalDirectionType.EastSouthEast)]
    [InlineData(CardinalDirectionType.NorthWest, CardinalDirectionType.SouthEast)]
    [InlineData(CardinalDirectionType.NorthNorthWest, CardinalDirectionType.SouthSouthEast)]
    [InlineData(CardinalDirectionType.None, CardinalDirectionType.None)]
    public void Opposite_CardinalDirectionType(CardinalDirectionType expected, CardinalDirectionType input)
        => Assert.Equal(expected, input.Opposite());

    [Theory]
    [InlineData(ForwardReverseType.Forward, ForwardReverseType.Reverse)]
    [InlineData(ForwardReverseType.Reverse, ForwardReverseType.Forward)]
    [InlineData(ForwardReverseType.None, ForwardReverseType.None)]
    public void Opposite_ForwardReverseType(ForwardReverseType expected, ForwardReverseType input)
        => Assert.Equal(expected, input.Opposite());

    [Theory]
    [InlineData(InsertRemoveType.Insert, InsertRemoveType.Remove)]
    [InlineData(InsertRemoveType.Remove, InsertRemoveType.Insert)]
    [InlineData(InsertRemoveType.None, InsertRemoveType.None)]
    public void Opposite_InsertRemoveType(InsertRemoveType expected, InsertRemoveType input)
        => Assert.Equal(expected, input.Opposite());

    [Theory]
    [InlineData(LeftRightType.Left, LeftRightType.Right)]
    [InlineData(LeftRightType.Right, LeftRightType.Left)]
    [InlineData(LeftRightType.None, LeftRightType.None)]
    public void Opposite_LeftRightType(LeftRightType expected, LeftRightType input)
        => Assert.Equal(expected, input.Opposite());

    [Theory]
    [InlineData(LeftTopRightBottomType.Left, LeftTopRightBottomType.Right)]
    [InlineData(LeftTopRightBottomType.Top, LeftTopRightBottomType.Bottom)]
    [InlineData(LeftTopRightBottomType.Right, LeftTopRightBottomType.Left)]
    [InlineData(LeftTopRightBottomType.Bottom, LeftTopRightBottomType.Top)]
    [InlineData(LeftTopRightBottomType.None, LeftTopRightBottomType.None)]
    public void Opposite_LeftTopRightBottomType(LeftTopRightBottomType expected, LeftTopRightBottomType input)
        => Assert.Equal(expected, input.Opposite());

    [Theory]
    [InlineData(LeftUpRightDownType.Left, LeftUpRightDownType.Right)]
    [InlineData(LeftUpRightDownType.Up, LeftUpRightDownType.Down)]
    [InlineData(LeftUpRightDownType.Right, LeftUpRightDownType.Left)]
    [InlineData(LeftUpRightDownType.Down, LeftUpRightDownType.Up)]
    [InlineData(LeftUpRightDownType.None, LeftUpRightDownType.None)]
    public void Opposite_LeftUpRightDownType(LeftUpRightDownType expected, LeftUpRightDownType input)
        => Assert.Equal(expected, input.Opposite());

    [Theory]
    [InlineData(OnOffType.On, OnOffType.Off)]
    [InlineData(OnOffType.Off, OnOffType.On)]
    [InlineData(OnOffType.None, OnOffType.None)]
    public void Opposite_OnOffType(OnOffType expected, OnOffType input)
        => Assert.Equal(expected, input.Opposite());

    [Theory]
    [InlineData(SortDirectionType.Ascending, SortDirectionType.Descending)]
    [InlineData(SortDirectionType.Descending, SortDirectionType.Ascending)]
    [InlineData(SortDirectionType.None, SortDirectionType.None)]
    public void Opposite_SortDirectionType(SortDirectionType expected, SortDirectionType input)
        => Assert.Equal(expected, input.Opposite());

    [Theory]
    [InlineData(UpDownType.Up, UpDownType.Down)]
    [InlineData(UpDownType.Down, UpDownType.Up)]
    [InlineData(UpDownType.None, UpDownType.None)]
    public void Opposite_UpDownType(UpDownType expected, UpDownType input)
        => Assert.Equal(expected, input.Opposite());

    [Theory]
    [InlineData(YesNoType.Yes, YesNoType.No)]
    [InlineData(YesNoType.No, YesNoType.Yes)]
    [InlineData(YesNoType.None, YesNoType.None)]
    public void Opposite_YesNoType(YesNoType expected, YesNoType input)
        => Assert.Equal(expected, input.Opposite());

    [Theory]
    [InlineData(ArrowDirectionType.Left, CardinalDirectionType.West)]
    [InlineData(ArrowDirectionType.Up, CardinalDirectionType.North)]
    [InlineData(ArrowDirectionType.Right, CardinalDirectionType.East)]
    [InlineData(ArrowDirectionType.Down, CardinalDirectionType.South)]
    [InlineData(ArrowDirectionType.None, CardinalDirectionType.None)]
    public void ToArrowDirectionType_FromCardinalDirectionType(ArrowDirectionType expected, CardinalDirectionType input)
        => Assert.Equal(expected, input.ToArrowDirectionType());

    [Theory]
    [InlineData(ArrowDirectionType.Left, LeftTopRightBottomType.Left)]
    [InlineData(ArrowDirectionType.Up, LeftTopRightBottomType.Top)]
    [InlineData(ArrowDirectionType.Right, LeftTopRightBottomType.Right)]
    [InlineData(ArrowDirectionType.Down, LeftTopRightBottomType.Bottom)]
    [InlineData(ArrowDirectionType.None, LeftTopRightBottomType.None)]
    public void ToArrowDirectionType_FromLeftTopRightBottomType(ArrowDirectionType expected, LeftTopRightBottomType input)
        => Assert.Equal(expected, input.ToArrowDirectionType());

    [Theory]
    [InlineData(ArrowDirectionType.Left, LeftUpRightDownType.Left)]
    [InlineData(ArrowDirectionType.Up, LeftUpRightDownType.Up)]
    [InlineData(ArrowDirectionType.Right, LeftUpRightDownType.Right)]
    [InlineData(ArrowDirectionType.Down, LeftUpRightDownType.Down)]
    [InlineData(ArrowDirectionType.None, LeftUpRightDownType.None)]
    public void ToArrowDirectionType_FromLeftUpRightDownType(ArrowDirectionType expected, LeftUpRightDownType input)
        => Assert.Equal(expected, input.ToArrowDirectionType());

    [Theory]
    [InlineData(CardinalDirectionType.West, ArrowDirectionType.Left)]
    [InlineData(CardinalDirectionType.North, ArrowDirectionType.Up)]
    [InlineData(CardinalDirectionType.East, ArrowDirectionType.Right)]
    [InlineData(CardinalDirectionType.South, ArrowDirectionType.Down)]
    [InlineData(CardinalDirectionType.None, ArrowDirectionType.None)]
    public void ToCardinalDirectionType_FromArrowDirectionType(CardinalDirectionType expected, ArrowDirectionType input)
        => Assert.Equal(expected, input.ToCardinalDirectionType());

    [Theory]
    [InlineData(CardinalDirectionType.West, LeftTopRightBottomType.Left)]
    [InlineData(CardinalDirectionType.North, LeftTopRightBottomType.Top)]
    [InlineData(CardinalDirectionType.East, LeftTopRightBottomType.Right)]
    [InlineData(CardinalDirectionType.South, LeftTopRightBottomType.Bottom)]
    [InlineData(CardinalDirectionType.None, LeftTopRightBottomType.None)]
    public void ToCardinalDirectionType_FromLeftTopRightBottomType(CardinalDirectionType expected, LeftTopRightBottomType input)
        => Assert.Equal(expected, input.ToCardinalDirectionType());

    [Theory]
    [InlineData(CardinalDirectionType.West, LeftUpRightDownType.Left)]
    [InlineData(CardinalDirectionType.North, LeftUpRightDownType.Up)]
    [InlineData(CardinalDirectionType.East, LeftUpRightDownType.Right)]
    [InlineData(CardinalDirectionType.South, LeftUpRightDownType.Down)]
    [InlineData(CardinalDirectionType.None, LeftUpRightDownType.None)]
    public void ToCardinalDirectionType_FromLeftUpRightDownType(CardinalDirectionType expected, LeftUpRightDownType input)
        => Assert.Equal(expected, input.ToCardinalDirectionType());

    [Theory]
    [InlineData(LeftTopRightBottomType.Left, ArrowDirectionType.Left)]
    [InlineData(LeftTopRightBottomType.Top, ArrowDirectionType.Up)]
    [InlineData(LeftTopRightBottomType.Right, ArrowDirectionType.Right)]
    [InlineData(LeftTopRightBottomType.Bottom, ArrowDirectionType.Down)]
    [InlineData(LeftTopRightBottomType.None, ArrowDirectionType.None)]
    public void ToLeftTopRightBottomType_FromArrowDirectionType(LeftTopRightBottomType expected, ArrowDirectionType input)
        => Assert.Equal(expected, input.ToLeftTopRightBottomType());

    [Theory]
    [InlineData(LeftTopRightBottomType.Left, CardinalDirectionType.West)]
    [InlineData(LeftTopRightBottomType.Top, CardinalDirectionType.North)]
    [InlineData(LeftTopRightBottomType.Right, CardinalDirectionType.East)]
    [InlineData(LeftTopRightBottomType.Bottom, CardinalDirectionType.South)]
    [InlineData(LeftTopRightBottomType.None, CardinalDirectionType.None)]
    public void ToLeftTopRightBottomType_FromCardinalDirectionType(LeftTopRightBottomType expected, CardinalDirectionType input)
        => Assert.Equal(expected, input.ToLeftTopRightBottomType());

    [Theory]
    [InlineData(LeftTopRightBottomType.Left, LeftRightType.Left)]
    [InlineData(LeftTopRightBottomType.Right, LeftRightType.Right)]
    [InlineData(LeftTopRightBottomType.None, LeftRightType.None)]
    public void ToLeftTopRightBottomType_FromLeftRightType(LeftTopRightBottomType expected, LeftRightType input)
        => Assert.Equal(expected, input.ToLeftTopRightBottomType());

    [Theory]
    [InlineData(LeftTopRightBottomType.Left, LeftUpRightDownType.Left)]
    [InlineData(LeftTopRightBottomType.Top, LeftUpRightDownType.Up)]
    [InlineData(LeftTopRightBottomType.Right, LeftUpRightDownType.Right)]
    [InlineData(LeftTopRightBottomType.Bottom, LeftUpRightDownType.Down)]
    [InlineData(LeftTopRightBottomType.None, LeftUpRightDownType.None)]
    public void ToLeftTopRightBottomType_FromLeftUpRightDownType(LeftTopRightBottomType expected, LeftUpRightDownType input)
        => Assert.Equal(expected, input.ToLeftTopRightBottomType());

    [Theory]
    [InlineData(LeftTopRightBottomType.Top, UpDownType.Up)]
    [InlineData(LeftTopRightBottomType.Bottom, UpDownType.Down)]
    [InlineData(LeftTopRightBottomType.None, UpDownType.None)]
    public void ToLeftTopRightBottomType_FromUpDownType(LeftTopRightBottomType expected, UpDownType input)
        => Assert.Equal(expected, input.ToLeftTopRightBottomType());

    [Theory]
    [InlineData(LeftUpRightDownType.Left, ArrowDirectionType.Left)]
    [InlineData(LeftUpRightDownType.Up, ArrowDirectionType.Up)]
    [InlineData(LeftUpRightDownType.Right, ArrowDirectionType.Right)]
    [InlineData(LeftUpRightDownType.Down, ArrowDirectionType.Down)]
    [InlineData(LeftUpRightDownType.None, ArrowDirectionType.None)]
    public void ToLeftUpRightDownType_FromArrowDirectionType(LeftUpRightDownType expected, ArrowDirectionType input)
        => Assert.Equal(expected, input.ToLeftUpRightDownType());

    [Theory]
    [InlineData(LeftUpRightDownType.Left, CardinalDirectionType.West)]
    [InlineData(LeftUpRightDownType.Up, CardinalDirectionType.North)]
    [InlineData(LeftUpRightDownType.Right, CardinalDirectionType.East)]
    [InlineData(LeftUpRightDownType.Down, CardinalDirectionType.South)]
    [InlineData(LeftUpRightDownType.None, CardinalDirectionType.None)]
    public void ToLeftUpRightDownType_FromCardinalDirectionType(LeftUpRightDownType expected, CardinalDirectionType input)
        => Assert.Equal(expected, input.ToLeftUpRightDownType());

    [Theory]
    [InlineData(LeftUpRightDownType.Left, LeftRightType.Left)]
    [InlineData(LeftUpRightDownType.Right, LeftRightType.Right)]
    [InlineData(LeftUpRightDownType.None, LeftRightType.None)]
    public void ToLeftUpRightDownType_FromLeftRightType(LeftUpRightDownType expected, LeftRightType input)
        => Assert.Equal(expected, input.ToLeftUpRightDownType());

    [Theory]
    [InlineData(LeftUpRightDownType.Left, LeftTopRightBottomType.Left)]
    [InlineData(LeftUpRightDownType.Up, LeftTopRightBottomType.Top)]
    [InlineData(LeftUpRightDownType.Right, LeftTopRightBottomType.Right)]
    [InlineData(LeftUpRightDownType.Down, LeftTopRightBottomType.Bottom)]
    [InlineData(LeftUpRightDownType.None, LeftTopRightBottomType.None)]
    public void ToLeftUpRightDownType_FromLeftTopRightBottomType(LeftUpRightDownType expected, LeftTopRightBottomType input)
        => Assert.Equal(expected, input.ToLeftUpRightDownType());

    [Theory]
    [InlineData(LeftUpRightDownType.Up, UpDownType.Up)]
    [InlineData(LeftUpRightDownType.Down, UpDownType.Down)]
    [InlineData(LeftUpRightDownType.None, UpDownType.None)]
    public void ToLeftUpRightDownType_FromUpDownType(LeftUpRightDownType expected, UpDownType input)
        => Assert.Equal(expected, input.ToLeftUpRightDownType());

    [Theory]
    [InlineData(SortDirectionType.Ascending, UpDownType.Up)]
    [InlineData(SortDirectionType.Descending, UpDownType.Down)]
    [InlineData(SortDirectionType.None, UpDownType.None)]
    public void ToSortDirectionType_FromUpDownType(SortDirectionType expected, UpDownType input)
        => Assert.Equal(expected, input.ToSortDirectionType());

    [Theory]
    [InlineData(UpDownType.Up, SortDirectionType.Ascending)]
    [InlineData(UpDownType.Down, SortDirectionType.Descending)]
    [InlineData(UpDownType.None, SortDirectionType.None)]
    public void ToUpDownType_FromSortDirectionType(UpDownType expected, SortDirectionType input)
        => Assert.Equal(expected, input.ToUpDownType());
}