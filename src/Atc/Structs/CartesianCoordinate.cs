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
    ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.
    /// </value>
    public bool IsDefault => Latitude.IsEqual(0) && Longitude.IsEqual(0);

    /// <summary>
    /// Equals the specified other.
    /// </summary>
    /// <param name="other">The other.</param>
    public bool Equals(CartesianCoordinate other) =>
        Latitude.AreClose(other.Latitude) &&
        Longitude.AreClose(other.Longitude);

    /// <inheritdoc />
    public override readonly string ToString()
        => $"{nameof(Latitude)}: {Latitude}, {nameof(Longitude)}: {Longitude}";

    /// <summary>
    /// To the string short.
    /// </summary>
    /// <returns>Return a short format of x and y.</returns>
    public readonly string ToStringShort()
        => $"{Latitude}, {Longitude}";
}