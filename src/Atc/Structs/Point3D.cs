// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents an x-, y-, and z-coordinate point in 3-D space.
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Auto)]
public struct Point3D : IEquatable<Point3D>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Point3D"/> struct.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    public Point3D(double x, double y)
        : this()
    {
        X = x;
        Y = y;
        Z = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Point3D"/> struct.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="z">The z.</param>
    public Point3D(double x, double y, double z)
        : this()
    {
        X = x;
        Y = y;
        Z = z;
    }

    /// <summary>
    /// Gets the X.
    /// </summary>
    /// <value>
    /// The X.
    /// </value>
    public double X { get; }

    /// <summary>
    /// Gets the Y.
    /// </summary>
    /// <value>
    /// The Y.
    /// </value>
    public double Y { get; }

    /// <summary>
    /// Gets the Z.
    /// </summary>
    /// <value>
    /// The Z.
    /// </value>
    public double Z { get; }

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.
    /// </value>
    public bool IsDefault => X.IsEqual(0) && Y.IsEqual(0) && Z.IsEqual(0);

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="point1">The point1.</param>
    /// <param name="point2">The point2.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator ==(Point3D point1, Point3D point2)
        => point1.Equals(point2);

    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="point1">The point1.</param>
    /// <param name="point2">The point2.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator !=(Point3D point1, Point3D point2)
        => !point1.Equals(point2);

    /// <summary>
    /// Equals the specified other.
    /// </summary>
    /// <param name="other">The other.</param>
    public bool Equals(Point3D other)
        => X.AreClose(other.X) && Y.AreClose(other.Y) && Z.AreClose(other.Z);

    /// <inheritdoc />
    public override bool Equals(object obj)
        => obj is Point3D x && Equals(x);

    /// <inheritdoc />
    public override int GetHashCode()
        => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();

    /// <inheritdoc />
    [SuppressMessage("Design", "MA0076:Do not use implicit culture-sensitive ToString in interpolated strings", Justification = "OK.")]
    public override string ToString()
    {
        return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}, {nameof(Z)}: {Z}";
    }
}