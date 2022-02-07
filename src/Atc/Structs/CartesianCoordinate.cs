namespace Atc.Structs;

/// <summary>
/// Represents an latitude- and longitude-coordinate.
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Auto)]
public struct CartesianCoordinate : IEquatable<CartesianCoordinate>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CartesianCoordinate"/> struct.
    /// </summary>
    /// <param name="latitude">The latitude (also know as Y or Easting).</param>
    /// <param name="longitude">The longitude (also know as X or Northing).</param>
    public CartesianCoordinate(double latitude, double longitude)
        : this()
    {
        this.Latitude = latitude;
        this.Longitude = longitude;
    }

    /// <summary>
    /// Gets latitude (also know as Y or Easting).
    /// </summary>
    /// <value>
    /// The latitude.
    /// </value>
    public double Latitude { get; }

    /// <summary>
    /// Gets the longitude (also know as X or Northing).
    /// </summary>
    /// <value>
    /// The longitude.
    /// </value>
    public double Longitude { get; }

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.
    /// </value>
    public bool IsDefault => this.Latitude.IsEqual(0) && this.Longitude.IsEqual(0);

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="cartesianCoordinate1">The cartesianCoordinate1.</param>
    /// <param name="cartesianCoordinate2">The cartesianCoordinate2.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator ==(CartesianCoordinate cartesianCoordinate1, CartesianCoordinate cartesianCoordinate2)
        => cartesianCoordinate1.Equals(cartesianCoordinate2);

    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="cartesianCoordinate1">The cartesianCoordinate1.</param>
    /// <param name="cartesianCoordinate2">The cartesianCoordinate2.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator !=(CartesianCoordinate cartesianCoordinate1, CartesianCoordinate cartesianCoordinate2)
        => !cartesianCoordinate1.Equals(cartesianCoordinate2);

    /// <summary>
    /// Equals the specified other.
    /// </summary>
    /// <param name="other">The other.</param>
    public bool Equals(CartesianCoordinate other) =>
        this.Latitude.AreClose(other.Latitude) &&
        this.Longitude.AreClose(other.Longitude);

    /// <inheritdoc />
    public override bool Equals(object obj)
        => obj is CartesianCoordinate x && this.Equals(x);

    /// <inheritdoc />
    public override int GetHashCode()
        => this.Latitude.GetHashCode() ^ this.Longitude.GetHashCode();

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{nameof(this.Latitude)}: {this.Latitude}, {nameof(this.Longitude)}: {this.Longitude}";
    }
}