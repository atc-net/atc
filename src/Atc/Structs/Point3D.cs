// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents an x-, y-, and z-coordinate point in 3-D space.
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Auto)]
public record struct Point3D(double X = 0, double Y = 0, double Z = 0)
{
    /// <summary>
    /// Gets a value indicating whether this instance represents the default (origin) position at coordinates (0, 0, 0).
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if X, Y, and Z are all approximately zero; otherwise, <see langword="false" />.
    /// </value>
    public readonly bool IsDefault => X.IsEqual(0) && Y.IsEqual(0) && Z.IsEqual(0);

    /// <inheritdoc />
    public override readonly string ToString()
        => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}, {nameof(Z)}: {Z}";

    /// <summary>
    /// Returns a short string representation of the point in the format "x, y, z".
    /// </summary>
    /// <returns>A comma-separated string containing the X, Y, and Z coordinates.</returns>
    public readonly string ToStringShort()
        => $"{X}, {Y}, {Z}";
}