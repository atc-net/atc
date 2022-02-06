// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo
namespace Atc.Math.GeoSpatial;

/// <summary>
/// UniversalTransverseMercatorResult
/// </summary>
public class UniversalTransverseMercatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UniversalTransverseMercatorResult"/> class.
    /// </summary>
    /// <param name="zoneNumber">The zone number.</param>
    /// <param name="zoneLetter">The zone letter.</param>
    /// <param name="utmEasting">The utm easting.</param>
    /// <param name="utmNorthing">The utm northing.</param>
    public UniversalTransverseMercatorResult(int zoneNumber, string zoneLetter, double utmEasting, double utmNorthing)
    {
        this.ZoneNumber = zoneNumber;
        this.ZoneLetter = zoneLetter ?? throw new ArgumentNullException(nameof(zoneLetter));
        this.UtmEasting = utmEasting;
        this.UtmNorthing = utmNorthing;
    }

    /// <summary>
    /// Gets the zone number.
    /// </summary>
    /// <value>
    /// The zone number.
    /// </value>
    public int ZoneNumber { get; }

    /// <summary>
    /// Gets the zone letter.
    /// </summary>
    /// <value>
    /// The zone letter.
    /// </value>
    public string ZoneLetter { get; }

    /// <summary>
    /// Gets the utm easting.
    /// </summary>
    /// <value>
    /// The utm easting.
    /// </value>
    public double UtmEasting { get; }

    /// <summary>
    /// Gets the utm northing.
    /// </summary>
    /// <value>
    /// The utm northing.
    /// </value>
    public double UtmNorthing { get; }

    /// <summary>
    /// Gets the zone.
    /// </summary>
    /// <value>
    /// The zone.
    /// </value>
    public string Zone => this.ZoneNumber + this.ZoneLetter;

    /// <summary>
    /// Gets the formatted UTM.
    /// </summary>
    /// <value>
    /// The formatted UTM.
    /// </value>
    public string FormattedUtm => $"{this.UtmEasting.ToString(GlobalizationConstants.EnglishCultureInfo)}, {this.UtmNorthing.ToString(GlobalizationConstants.EnglishCultureInfo)}";

    /// <inheritdoc />
    public override string ToString() => $"{this.Zone} {this.UtmEasting} {this.UtmNorthing}";
}