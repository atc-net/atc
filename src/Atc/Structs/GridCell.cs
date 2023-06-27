// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents an x- and y-coordinate point in 2-D grid.
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Auto)]
public record struct GridCell(int X = 0, int Y = 0)
{
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.
    /// </returns>
    public readonly bool IsDefault => X == 0 && Y == 0;

    /// <inheritdoc />
    public override readonly string ToString()
    {
        return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
    }

    /// <summary>
    /// To the string short.
    /// </summary>
    /// <returns>Return a short format of x and y.</returns>
    public readonly string ToStringShort()
        => $"{X}, {Y}";
}