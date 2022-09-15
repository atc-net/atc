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
        Latitude = latitude;
        Longitude = longitude;
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
    public bool IsDefault => Latitude.IsEqual(0) && Longitude.IsEqual(0);

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
        Latitude.AreClose(other.Latitude) &&
        Longitude.AreClose(other.Longitude);

    /// <inheritdoc />
    public override bool Equals(object obj)
        => obj is CartesianCoordinate x && Equals(x);

    /// <inheritdoc />
    public override int GetHashCode()
        => Latitude.GetHashCode() ^ Longitude.GetHashCode();

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{nameof(Latitude)}: {Latitude}, {nameof(Longitude)}: {Longitude}";
    }
}