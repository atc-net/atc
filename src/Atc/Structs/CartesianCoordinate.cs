namespace Atc.Structs;

/// <summary>
/// Represents an latitude- and longitude-coordinate.
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Auto)]
public record struct CartesianCoordinate(double Latitude = 0, double Longitude = 0)
{
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if this instance is default; otherwise, <see langword="false" />.
    /// </value>
    [JsonIgnore]
    public readonly bool IsDefault => Latitude.IsEqual(0) && Longitude.IsEqual(0);

    /// <summary>
    /// Determines whether the specified <see cref="CartesianCoordinate"/> is equal to the current instance
    /// using approximate floating-point comparison.
    /// </summary>
    /// <param name="other">The coordinate to compare with the current instance.</param>
    /// <returns>
    /// <see langword="true"/> if the latitude and longitude values are approximately equal; otherwise, <see langword="false"/>.
    /// </returns>
    public readonly bool Equals(CartesianCoordinate other) =>
        Latitude.AreClose(other.Latitude) &&
        Longitude.AreClose(other.Longitude);

    /// <inheritdoc />
    public override readonly int GetHashCode()
        => HashCode.Combine(Latitude, Longitude);

    /// <inheritdoc />
    public override readonly string ToString()
        => $"{nameof(Latitude)}: {Latitude}, {nameof(Longitude)}: {Longitude}";

    /// <summary>
    /// Returns a short string representation of the coordinate in the format "latitude, longitude".
    /// </summary>
    /// <returns>A comma-separated string containing the latitude and longitude values.</returns>
    public readonly string ToStringShort()
        => $"{Latitude}, {Longitude}";
}