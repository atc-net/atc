// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents an x- and y-coordinate point in 2-D space.
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Auto)]
public record struct Point2D(
    double X = 0,
    double Y = 0)
{
    /// <summary>
    /// Gets a value indicating whether this instance represents the default (origin) position at coordinates (0, 0).
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if both X and Y are exactly zero; otherwise, <see langword="false" />.
    /// </value>
    [SuppressMessage("SonarAnalyzer.CSharp", "S1244:Do not check floating point equality with exact values, use a range instead", Justification = "Intentional: IsDefault checks for exact binary zero, not approximate equality.")]
    public readonly bool IsDefault => X == 0.0 && Y == 0.0;

    /// <inheritdoc />
    public override readonly string ToString()
        => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";

    /// <summary>
    /// Returns a short string representation of the point in the format "x, y".
    /// </summary>
    /// <returns>A comma-separated string containing the X and Y coordinates.</returns>
    public readonly string ToStringShort()
        => $"{X}, {Y}";
}