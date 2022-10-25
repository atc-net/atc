// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents an x- and y-coordinate point in 2-D space.
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Auto)]
public record struct Point2D(double X = 0, double Y = 0)
{
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.
    /// </value>
    public bool IsDefault => X.IsEqual(0) && Y.IsEqual(0);

    /// <inheritdoc />
    public override readonly string ToString()
        => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";

    /// <summary>
    /// To the string short.
    /// </summary>
    /// <returns>Return a short format of x and y.</returns>
    public readonly string ToStringShort()
        => $"{X}, {Y}";
}