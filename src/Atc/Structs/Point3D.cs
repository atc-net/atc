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
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.
    /// </value>
    public readonly bool IsDefault => X.IsEqual(0) && Y.IsEqual(0) && Z.IsEqual(0);

    /// <inheritdoc />
    public override readonly string ToString()
        => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}, {nameof(Z)}: {Z}";

    /// <summary>
    /// To the string short.
    /// </summary>
    /// <returns>Return a short format of x, y, and z.</returns>
    public readonly string ToStringShort()
        => $"{X}, {Y}, {Z}";
}