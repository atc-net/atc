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
    /// Gets the opposite state of the specified LeftTopRightBottomType.
    /// </summary>
    /// <param name="leftTopRightBottomType">The LeftTopRightBottomType to find the opposite for.</param>
    /// <returns>The opposite LeftTopRightBottomType. Returns LeftTopRightBottomType.None if no opposite is defined.</returns>
    public static LeftTopRightBottomType Opposite(
        this LeftTopRightBottomType leftTopRightBottomType)
        => leftTopRightBottomType switch
        {
            LeftTopRightBottomType.Left => LeftTopRightBottomType.Right,
            LeftTopRightBottomType.Top => LeftTopRightBottomType.Bottom,
            LeftTopRightBottomType.Right => LeftTopRightBottomType.Left,
            LeftTopRightBottomType.Bottom => LeftTopRightBottomType.Top,
            _ => LeftTopRightBottomType.None,
        };

    /// <summary>
    /// Gets the opposite state of the specified LeftUpRightDownType.
    /// </summary>
    /// <param name="leftUpRightDownType">The LeftUpRightDownType to find the opposite for.</param>
    /// <returns>The opposite LeftUpRightDownType. Returns LeftUpRightDownType.None if no opposite is defined.</returns>
    public static LeftUpRightDownType Opposite(
        this LeftUpRightDownType leftUpRightDownType)
        => leftUpRightDownType switch
        {
            LeftUpRightDownType.Left => LeftUpRightDownType.Right,
            LeftUpRightDownType.Up => LeftUpRightDownType.Down,
            LeftUpRightDownType.Right => LeftUpRightDownType.Left,
            LeftUpRightDownType.Down => LeftUpRightDownType.Up,
            _ => LeftUpRightDownType.None,
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
    /// <param name="upDownType">The UpDownType to find the opposite for.</param>
    /// <returns>The opposite UpDownType. Returns UpDownType.None if no opposite is defined.</returns>
    public static UpDownType Opposite(
        this UpDownType upDownType)
        => upDownType switch
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

    /// <summary>
    /// Converts a CardinalDirectionType to an ArrowDirectionType.
    /// </summary>
    /// <param name="cardinalDirectionType">The CardinalDirectionType to convert.</param>
    /// <returns>
    /// ArrowDirectionType corresponding to the given CardinalDirectionType:
    /// - West is converted to ArrowDirectionType.Left
    /// - North is converted to ArrowDirectionType.Up
    /// - East is converted to ArrowDirectionType.Right
    /// - South is converted to ArrowDirectionType.Down
    /// - If no match, then default is ArrowDirectionType.None.
    /// </returns>
    public static ArrowDirectionType ToArrowDirectionType(
        this CardinalDirectionType cardinalDirectionType)
        => cardinalDirectionType switch
        {
            CardinalDirectionType.West => ArrowDirectionType.Left,
            CardinalDirectionType.North => ArrowDirectionType.Up,
            CardinalDirectionType.East => ArrowDirectionType.Right,
            CardinalDirectionType.South => ArrowDirectionType.Down,
            _ => ArrowDirectionType.None,
        };

    /// <summary>
    /// Converts a LeftTopRightBottomType to an ArrowDirectionType.
    /// </summary>
    /// <param name="leftTopRightBottomType">The LeftTopRightBottomType to convert.</param>
    /// <returns>
    /// ArrowDirectionType corresponding to the given LeftTopRightBottomType:
    /// - Left is converted to ArrowDirectionType.Left
    /// - Top is converted to ArrowDirectionType.Up
    /// - Right is converted to ArrowDirectionType.Right
    /// - Bottom is converted to ArrowDirectionType.Down
    /// - If no match, then default is ArrowDirectionType.None
    /// </returns>
    public static ArrowDirectionType ToArrowDirectionType(
        this LeftTopRightBottomType leftTopRightBottomType)
        => leftTopRightBottomType switch
        {
            LeftTopRightBottomType.Left => ArrowDirectionType.Left,
            LeftTopRightBottomType.Top => ArrowDirectionType.Up,
            LeftTopRightBottomType.Right => ArrowDirectionType.Right,
            LeftTopRightBottomType.Bottom => ArrowDirectionType.Down,
            _ => ArrowDirectionType.None,
        };

    /// <summary>
    /// Converts a LeftUpRightDownType to an ArrowDirectionType.
    /// </summary>
    /// <param name="leftUpRightDownType">The LeftUpRightDownType to convert.</param>
    /// <returns>
    /// ArrowDirectionType corresponding to the given LeftUpRightDownType:
    /// - Left is converted to ArrowDirectionType.Left
    /// - Up is converted to ArrowDirectionType.Up
    /// - Right is converted to ArrowDirectionType.Right
    /// - Down is converted to ArrowDirectionType.Down
    /// - If no match, then default is ArrowDirectionType.None
    /// </returns>
    public static ArrowDirectionType ToArrowDirectionType(
        this LeftUpRightDownType leftUpRightDownType)
        => leftUpRightDownType switch
        {
            LeftUpRightDownType.Left => ArrowDirectionType.Left,
            LeftUpRightDownType.Up => ArrowDirectionType.Up,
            LeftUpRightDownType.Right => ArrowDirectionType.Right,
            LeftUpRightDownType.Down => ArrowDirectionType.Down,
            _ => ArrowDirectionType.None,
        };

    /// <summary>
    /// Converts a ArrowDirectionType to an CardinalDirectionType.
    /// </summary>
    /// <param name="arrowDirectionType">The ArrowDirectionType to convert.</param>
    /// <returns>
    /// CardinalDirectionType corresponding to the given ArrowDirectionType:
    /// - Left is converted to CardinalDirectionType.West
    /// - Up is converted to CardinalDirectionType.North
    /// - Right is converted to CardinalDirectionType.East
    /// - Down is converted to CardinalDirectionType.South
    /// - If no match, then default is CardinalDirectionType.None
    /// </returns>
    public static CardinalDirectionType ToCardinalDirectionType(
        this ArrowDirectionType arrowDirectionType)
        => arrowDirectionType switch
        {
            ArrowDirectionType.Left => CardinalDirectionType.West,
            ArrowDirectionType.Up => CardinalDirectionType.North,
            ArrowDirectionType.Right => CardinalDirectionType.East,
            ArrowDirectionType.Down => CardinalDirectionType.South,
            _ => CardinalDirectionType.None,
        };

    /// <summary>
    /// Converts a LeftTopRightBottomType to an CardinalDirectionType.
    /// </summary>
    /// <param name="leftTopRightBottomType">The LeftTopRightBottomType to convert.</param>
    /// <returns>
    /// CardinalDirectionType corresponding to the given LeftTopRightBottomType:
    /// - Left is converted to CardinalDirectionType.West
    /// - Top is converted to CardinalDirectionType.North
    /// - Right is converted to CardinalDirectionType.East
    /// - Bottom is converted to CardinalDirectionType.South
    /// - If no match, then default is CardinalDirectionType.None
    /// </returns>
    public static CardinalDirectionType ToCardinalDirectionType(
        this LeftTopRightBottomType leftTopRightBottomType)
        => leftTopRightBottomType switch
        {
            LeftTopRightBottomType.Left => CardinalDirectionType.West,
            LeftTopRightBottomType.Top => CardinalDirectionType.North,
            LeftTopRightBottomType.Right => CardinalDirectionType.East,
            LeftTopRightBottomType.Bottom => CardinalDirectionType.South,
            _ => CardinalDirectionType.None,
        };

    /// <summary>
    /// Converts a LeftUpRightDownType to an CardinalDirectionType.
    /// </summary>
    /// <param name="leftUpRightDownType">The LeftUpRightDownType to convert.</param>
    /// <returns>
    /// CardinalDirectionType corresponding to the given LeftUpRightDownType:
    /// - Left is converted to CardinalDirectionType.West
    /// - Top is converted to CardinalDirectionType.North
    /// - Right is converted to CardinalDirectionType.East
    /// - Bottom is converted to CardinalDirectionType.South
    /// - If no match, then default is CardinalDirectionType.None
    /// </returns>
    public static CardinalDirectionType ToCardinalDirectionType(
        this LeftUpRightDownType leftUpRightDownType)
        => leftUpRightDownType switch
        {
            LeftUpRightDownType.Left => CardinalDirectionType.West,
            LeftUpRightDownType.Up => CardinalDirectionType.North,
            LeftUpRightDownType.Right => CardinalDirectionType.East,
            LeftUpRightDownType.Down => CardinalDirectionType.South,
            _ => CardinalDirectionType.None,
        };

    /// <summary>
    /// Converts a ArrowDirectionType to an LeftTopRightBottomType.
    /// </summary>
    /// <param name="arrowDirectionType">The ArrowDirectionType to convert.</param>
    /// <returns>
    /// LeftTopRightBottomType corresponding to the given ArrowDirectionType:
    /// - Left is converted to LeftTopRightBottomType.Left
    /// - Up is converted to LeftTopRightBottomType.Top
    /// - Right is converted to LeftTopRightBottomType.Right
    /// - Down is converted to LeftTopRightBottomType.Bottom
    /// - If no match, then default is LeftTopRightBottomType.None
    /// </returns>
    public static LeftTopRightBottomType ToLeftTopRightBottomType(
        this ArrowDirectionType arrowDirectionType)
        => arrowDirectionType switch
        {
            ArrowDirectionType.Left => LeftTopRightBottomType.Left,
            ArrowDirectionType.Up => LeftTopRightBottomType.Top,
            ArrowDirectionType.Right => LeftTopRightBottomType.Right,
            ArrowDirectionType.Down => LeftTopRightBottomType.Bottom,
            _ => LeftTopRightBottomType.None,
        };

    /// <summary>
    /// Converts a CardinalDirectionType to an LeftTopRightBottomType.
    /// </summary>
    /// <param name="cardinalDirectionType">The CardinalDirectionType to convert.</param>
    /// <returns>
    /// LeftTopRightBottomType corresponding to the given CardinalDirectionType:
    /// - West is converted to LeftTopRightBottomType.Left
    /// - Up is converted to LeftTopRightBottomType.Top
    /// - Right is converted to LeftTopRightBottomType.Right
    /// - Down is converted to LeftTopRightBottomType.Bottom
    /// - If no match, then default is LeftTopRightBottomType.None
    /// </returns>
    public static LeftTopRightBottomType ToLeftTopRightBottomType(
        this CardinalDirectionType cardinalDirectionType)
        => cardinalDirectionType switch
        {
            CardinalDirectionType.West => LeftTopRightBottomType.Left,
            CardinalDirectionType.North => LeftTopRightBottomType.Top,
            CardinalDirectionType.East => LeftTopRightBottomType.Right,
            CardinalDirectionType.South => LeftTopRightBottomType.Bottom,
            _ => LeftTopRightBottomType.None,
        };

    /// <summary>
    /// Converts a LeftRightType to an LeftTopRightBottomType.
    /// </summary>
    /// <param name="leftRightType">The LeftRightType to convert.</param>
    /// <returns>
    /// LeftTopRightBottomType corresponding to the given LeftRightType:
    /// - Left is converted to LeftTopRightBottomType.Left
    /// - Right is converted to LeftTopRightBottomType.Right
    /// - If no match, then default is LeftTopRightBottomType.None
    /// </returns>
    public static LeftTopRightBottomType ToLeftTopRightBottomType(
        this LeftRightType leftRightType)
        => leftRightType switch
        {
            LeftRightType.Left => LeftTopRightBottomType.Left,
            LeftRightType.Right => LeftTopRightBottomType.Right,
            _ => LeftTopRightBottomType.None,
        };

    /// <summary>
    /// Converts a LeftUpRightDownType to an LeftTopRightBottomType.
    /// </summary>
    /// <param name="leftUpRightDownType">The LeftUpRightDownType to convert.</param>
    /// <returns>
    /// LeftTopRightBottomType corresponding to the given LeftUpRightDownType:
    /// - Left is converted to LeftTopRightBottomType.Left
    /// - Up is converted to LeftTopRightBottomType.Top
    /// - Right is converted to LeftTopRightBottomType.Right
    /// - Down is converted to LeftTopRightBottomType.Bottom
    /// - If no match, then default is LeftTopRightBottomType.None
    /// </returns>
    public static LeftTopRightBottomType ToLeftTopRightBottomType(
        this LeftUpRightDownType leftUpRightDownType)
        => leftUpRightDownType switch
        {
            LeftUpRightDownType.Left => LeftTopRightBottomType.Left,
            LeftUpRightDownType.Up => LeftTopRightBottomType.Top,
            LeftUpRightDownType.Right => LeftTopRightBottomType.Right,
            LeftUpRightDownType.Down => LeftTopRightBottomType.Bottom,
            _ => LeftTopRightBottomType.None,
        };

    /// <summary>
    /// Converts a UpDownType to an LeftTopRightBottomType.
    /// </summary>
    /// <param name="upDownType">The UpDownType to convert.</param>
    /// <returns>
    /// LeftTopRightBottomType corresponding to the given UpDownType:
    /// - Up is converted to LeftTopRightBottomType.Top
    /// - Down is converted to LeftTopRightBottomType.Bottom
    /// - If no match, then default is LeftTopRightBottomType.None
    /// </returns>
    public static LeftTopRightBottomType ToLeftTopRightBottomType(
        this UpDownType upDownType)
        => upDownType switch
        {
            UpDownType.Up => LeftTopRightBottomType.Top,
            UpDownType.Down => LeftTopRightBottomType.Bottom,
            _ => LeftTopRightBottomType.None,
        };

    /// <summary>
    /// Converts a ArrowDirectionType to an LeftUpRightDownType.
    /// </summary>
    /// <param name="arrowDirectionType">The ArrowDirectionType to convert.</param>
    /// <returns>
    /// LeftUpRightDownType corresponding to the given ArrowDirectionType:
    /// - Left is converted to LeftUpRightDownType.Left
    /// - Up is converted to LeftUpRightDownType.Up
    /// - Right is converted to LeftUpRightDownType.Right
    /// - Down is converted to LeftUpRightDownType.Down
    /// - If no match, then default is LeftUpRightDownType.None
    /// </returns>
    public static LeftUpRightDownType ToLeftUpRightDownType(
        this ArrowDirectionType arrowDirectionType)
        => arrowDirectionType switch
        {
            ArrowDirectionType.Left => LeftUpRightDownType.Left,
            ArrowDirectionType.Up => LeftUpRightDownType.Up,
            ArrowDirectionType.Right => LeftUpRightDownType.Right,
            ArrowDirectionType.Down => LeftUpRightDownType.Down,
            _ => LeftUpRightDownType.None,
        };

    /// <summary>
    /// Converts a CardinalDirectionType to an LeftUpRightDownType.
    /// </summary>
    /// <param name="cardinalDirectionType">The CardinalDirectionType to convert.</param>
    /// <returns>
    /// LeftUpRightDownType corresponding to the given CardinalDirectionType:
    /// - Left is converted to LeftUpRightDownType.Left
    /// - Up is converted to LeftUpRightDownType.Up
    /// - Right is converted to LeftUpRightDownType.Right
    /// - Down is converted to LeftUpRightDownType.Down
    /// - If no match, then default is LeftUpRightDownType.None
    /// </returns>
    public static LeftUpRightDownType ToLeftUpRightDownType(
        this CardinalDirectionType cardinalDirectionType)
        => cardinalDirectionType switch
        {
            CardinalDirectionType.West => LeftUpRightDownType.Left,
            CardinalDirectionType.North => LeftUpRightDownType.Up,
            CardinalDirectionType.East => LeftUpRightDownType.Right,
            CardinalDirectionType.South => LeftUpRightDownType.Down,
            _ => LeftUpRightDownType.None,
        };

    /// <summary>
    /// Converts a LeftRightType to an LeftUpRightDownType.
    /// </summary>
    /// <param name="leftRightType">The LeftRightType to convert.</param>
    /// <returns>
    /// LeftUpRightDownType corresponding to the given LeftRightType:
    /// - Left is converted to LeftUpRightDownType.Left
    /// - Right is converted to LeftUpRightDownType.Right
    /// - If no match, then default is LeftUpRightDownType.None
    /// </returns>
    public static LeftUpRightDownType ToLeftUpRightDownType(
        this LeftRightType leftRightType)
        => leftRightType switch
        {
            LeftRightType.Left => LeftUpRightDownType.Left,
            LeftRightType.Right => LeftUpRightDownType.Right,
            _ => LeftUpRightDownType.None,
        };

    /// <summary>
    /// Converts a LeftTopRightBottomType to an LeftUpRightDownType.
    /// </summary>
    /// <param name="leftTopRightBottomType">The LeftTopRightBottomType to convert.</param>
    /// <returns>
    /// LeftUpRightDownType corresponding to the given LeftTopRightBottomType:
    /// - Left is converted to LeftUpRightDownType.Left
    /// - Top is converted to LeftUpRightDownType.Up
    /// - Right is converted to LeftUpRightDownType.Right
    /// - Bottom is converted to LeftUpRightDownType.Down
    /// - If no match, then default is LeftUpRightDownType.None
    /// </returns>
    public static LeftUpRightDownType ToLeftUpRightDownType(
        this LeftTopRightBottomType leftTopRightBottomType)
        => leftTopRightBottomType switch
        {
            LeftTopRightBottomType.Left => LeftUpRightDownType.Left,
            LeftTopRightBottomType.Top => LeftUpRightDownType.Up,
            LeftTopRightBottomType.Right => LeftUpRightDownType.Right,
            LeftTopRightBottomType.Bottom => LeftUpRightDownType.Down,
            _ => LeftUpRightDownType.None,
        };

    /// <summary>
    /// Converts a UpDownType to an LeftUpRightDownType.
    /// </summary>
    /// <param name="upDownType">The UpDownType to convert.</param>
    /// <returns>
    /// LeftUpRightDownType corresponding to the given UpDownType:
    /// - Up is converted to LeftUpRightDownType.Up
    /// - Down is converted to LeftUpRightDownType.Down
    /// - If no match, then default is LeftUpRightDownType.None
    /// </returns>
    public static LeftUpRightDownType ToLeftUpRightDownType(
        this UpDownType upDownType)
        => upDownType switch
        {
            UpDownType.Up => LeftUpRightDownType.Up,
            UpDownType.Down => LeftUpRightDownType.Down,
            _ => LeftUpRightDownType.None,
        };

    /// <summary>
    /// Converts a UpDownType to an SortDirectionType.
    /// </summary>
    /// <param name="upDownType">The UpDownType to convert.</param>
    /// <returns>
    /// SortDirectionType corresponding to the given UpDownType:
    /// - Up is converted to SortDirectionType.Ascending
    /// - Down is converted to SortDirectionType.Descending
    /// - If no match, then default is SortDirectionType.None
    /// </returns>
    public static SortDirectionType ToSortDirectionType(
        this UpDownType upDownType)
        => upDownType switch
        {
            UpDownType.Up => SortDirectionType.Ascending,
            UpDownType.Down => SortDirectionType.Descending,
            _ => SortDirectionType.None,
        };

    /// <summary>
    /// Converts a SortDirectionType to an UpDownType.
    /// </summary>
    /// <param name="sortDirectionType">The SortDirectionType to convert.</param>
    /// <returns>
    /// UpDownType corresponding to the given SortDirectionType:
    /// - Ascending is converted to UpDownType.Up
    /// - Descending is converted to UpDownType.Down
    /// - If no match, then default is UpDownType.None
    /// </returns>
    public static UpDownType ToUpDownType(
        this SortDirectionType sortDirectionType)
        => sortDirectionType switch
        {
            SortDirectionType.Ascending => UpDownType.Up,
            SortDirectionType.Descending => UpDownType.Down,
            _ => UpDownType.None,
        };
}