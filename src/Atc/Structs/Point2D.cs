// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents an x- and y-coordinate point in 2-D space.
/// </summary>
[Serializable]
public struct Point2D : IEquatable<Point2D>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Point2D"/> struct.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    public Point2D(double x, double y)
        : this()
    {
        this.X = x;
        this.Y = y;
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
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.
    /// </value>
    public bool IsDefault => this.X.IsEqual(0) && this.Y.IsEqual(0);

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="point1">The point1.</param>
    /// <param name="point2">The point2.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator ==(Point2D point1, Point2D point2)
        => point1.Equals(point2);

    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="point1">The point1.</param>
    /// <param name="point2">The point2.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator !=(Point2D point1, Point2D point2)
        => !point1.Equals(point2);

    /// <summary>
    /// Equals the specified other.
    /// </summary>
    /// <param name="other">The other.</param>
    public bool Equals(Point2D other)
        => this.X.AreClose(other.X) && this.Y.AreClose(other.Y);

    /// <inheritdoc />
    public override bool Equals(object obj)
        => obj is Point2D x && this.Equals(x);

    /// <inheritdoc />
    public override int GetHashCode()
        => this.X.GetHashCode() ^ this.Y.GetHashCode();

    /// <inheritdoc />
    [SuppressMessage("Design", "MA0076:Do not use implicit culture-sensitive ToString in interpolated strings", Justification = "OK.")]
    public override string ToString()
    {
        return $"{nameof(X)}: {this.X}, {nameof(Y)}: {this.Y}";
    }
}