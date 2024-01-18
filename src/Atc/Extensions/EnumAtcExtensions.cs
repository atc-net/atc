// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Provides extension methods for atc enum types.
/// </summary>
public static class EnumAtcExtensions
{
    /// <summary>
    /// Gets the opposite direction of the specified ArrowDirectionType.
    /// </summary>
    /// <param name="arrowDirectionType">The ArrowDirectionType to find the opposite for.</param>
    /// <returns>The opposite ArrowDirectionType. Returns ArrowDirectionType.None if no opposite is defined.</returns>
    public static ArrowDirectionType Opposite(
        this ArrowDirectionType arrowDirectionType)
        => arrowDirectionType switch
        {
            ArrowDirectionType.Left => ArrowDirectionType.Right,
            ArrowDirectionType.Up => ArrowDirectionType.Down,
            ArrowDirectionType.Right => ArrowDirectionType.Left,
            ArrowDirectionType.Down => ArrowDirectionType.Up,
            _ => ArrowDirectionType.None,
        };

    /// <summary>
    /// Gets the opposite direction of the specified CardinalDirectionType.
    /// </summary>
    /// <param name="cardinalDirectionType">The CardinalDirectionType to find the opposite for.</param>
    /// <returns>The opposite CardinalDirectionType. Returns CardinalDirectionType.None if no opposite is defined.</returns>
    public static CardinalDirectionType Opposite(
        this CardinalDirectionType cardinalDirectionType)
        => cardinalDirectionType switch
        {
            CardinalDirectionType.North => CardinalDirectionType.South,
            CardinalDirectionType.NorthNorthEast => CardinalDirectionType.SouthSouthWest,
            CardinalDirectionType.NorthEast => CardinalDirectionType.SouthWest,
            CardinalDirectionType.EastNorthEast => CardinalDirectionType.WestSouthWest,
            CardinalDirectionType.East => CardinalDirectionType.West,
            CardinalDirectionType.EastSouthEast => CardinalDirectionType.WestNorthWest,
            CardinalDirectionType.SouthEast => CardinalDirectionType.NorthWest,
            CardinalDirectionType.SouthSouthEast => CardinalDirectionType.NorthNorthWest,
            CardinalDirectionType.South => CardinalDirectionType.North,
            CardinalDirectionType.SouthSouthWest => CardinalDirectionType.NorthNorthEast,
            CardinalDirectionType.SouthWest => CardinalDirectionType.NorthEast,
            CardinalDirectionType.WestSouthWest => CardinalDirectionType.EastNorthEast,
            CardinalDirectionType.West => CardinalDirectionType.East,
            CardinalDirectionType.WestNorthWest => CardinalDirectionType.EastSouthEast,
            CardinalDirectionType.NorthWest => CardinalDirectionType.SouthEast,
            CardinalDirectionType.NorthNorthWest => CardinalDirectionType.SouthSouthEast,
            _ => CardinalDirectionType.None,
        };

    /// <summary>
    /// Gets the opposite state of the specified ForwardReverseType.
    /// </summary>
    /// <param name="forwardReverseType">The ForwardReverseType to find the opposite for.</param>
    /// <returns>The opposite ForwardReverseType. Returns ForwardReverseType.None if no opposite is defined.</returns>
    public static ForwardReverseType Opposite(
        this ForwardReverseType forwardReverseType)
        => forwardReverseType switch
        {
            ForwardReverseType.Forward => ForwardReverseType.Reverse,
            ForwardReverseType.Reverse => ForwardReverseType.Forward,
            _ => ForwardReverseType.None,
        };

    /// <summary>
    /// Gets the opposite state of the specified InsertRemoveType.
    /// </summary>
    /// <param name="insertRemoveType">The InsertRemoveType to find the opposite for.</param>
    /// <returns>The opposite InsertRemoveType. Returns InsertRemoveType.None if no opposite is defined.</returns>
    public static InsertRemoveType Opposite(
        this InsertRemoveType insertRemoveType)
        => insertRemoveType switch
        {
            InsertRemoveType.Insert => InsertRemoveType.Remove,
            InsertRemoveType.Remove => InsertRemoveType.Insert,
            _ => InsertRemoveType.None,
        };

    /// <summary>
    /// Gets the opposite state of the specified LeftRightType.
    /// </summary>
    /// <param name="leftRightType">The LeftRightType to find the opposite for.</param>
    /// <returns>The opposite LeftRightType. Returns LeftRightType.None if no opposite is defined.</returns>
    public static LeftRightType Opposite(
        this LeftRightType leftRightType)
        => leftRightType switch
        {
            LeftRightType.Left => LeftRightType.Right,
            LeftRightType.Right => LeftRightType.Left,
            _ => LeftRightType.None,
        };

    /// <summary>
    /// Gets the opposite state of the specified OnOffType.
    /// </summary>
    /// <param name="onOffType">The OnOffType to find the opposite for.</param>
    /// <returns>The opposite OnOffType. Returns OnOffType.None if no opposite is defined.</returns>
    public static OnOffType Opposite(
        this OnOffType onOffType)
        => onOffType switch
        {
            OnOffType.On => OnOffType.Off,
            OnOffType.Off => OnOffType.On,
            _ => OnOffType.None,
        };

    /// <summary>
    /// Gets the opposite state of the specified SortDirectionType.
    /// </summary>
    /// <param name="sortDirectionType">The SortDirectionType to find the opposite for.</param>
    /// <returns>The opposite SortDirectionType. Returns SortDirectionType.None if no opposite is defined.</returns>
    public static SortDirectionType Opposite(
        this SortDirectionType sortDirectionType)
        => sortDirectionType switch
        {
            SortDirectionType.Ascending => SortDirectionType.Descending,
            SortDirectionType.Descending => SortDirectionType.Ascending,
            _ => SortDirectionType.None,
        };

    /// <summary>
    /// Gets the opposite state of the specified UpDownType.
    /// </summary>
    /// <param name="yesNoType">The UpDownType to find the opposite for.</param>
    /// <returns>The opposite UpDownType. Returns UpDownType.None if no opposite is defined.</returns>
    public static UpDownType Opposite(
        this UpDownType yesNoType)
        => yesNoType switch
        {
            UpDownType.Up => UpDownType.Down,
            UpDownType.Down => UpDownType.Up,
            _ => UpDownType.None,
        };

    /// <summary>
    /// Gets the opposite state of the specified YesNoType.
    /// </summary>
    /// <param name="yesNoType">The YesNoType to find the opposite for.</param>
    /// <returns>The opposite YesNoType. Returns YesNoType.None if no opposite is defined.</returns>
    public static YesNoType Opposite(
        this YesNoType yesNoType)
        => yesNoType switch
        {
            YesNoType.Yes => YesNoType.No,
            YesNoType.No => YesNoType.Yes,
            _ => YesNoType.None,
        };
}