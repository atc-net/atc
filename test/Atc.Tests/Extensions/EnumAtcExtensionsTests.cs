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
    [InlineData(LeftTopRightBottomType.Top, LeftTopRightBottomType.Top)]
    [InlineData(LeftTopRightBottomType.Right, LeftTopRightBottomType.Left)]
    [InlineData(LeftTopRightBottomType.Bottom, LeftTopRightBottomType.Bottom)]
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
}