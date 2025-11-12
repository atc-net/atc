// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents an x- and y-coordinate point in 2-D grid.
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Auto)]
public record struct GridCell(
    int X = 0,
    int Y = 0)
{
    /// <summary>
    /// Gets a value indicating whether this instance represents the default (origin) position at coordinates (0, 0).
    /// </summary>
    /// <returns>
    ///   <see langword="true" /> if both X and Y are zero; otherwise, <see langword="false" />.
    /// </returns>
    public readonly bool IsDefault => X == 0 && Y == 0;

    /// <inheritdoc />
    public override readonly string ToString()
        => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";

    /// <summary>
    /// Returns a short string representation of the grid cell in the format "x, y".
    /// </summary>
    /// <returns>A comma-separated string containing the X and Y coordinates.</returns>
    public readonly string ToStringShort()
        => $"{X}, {Y}";
}