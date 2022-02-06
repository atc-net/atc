// ReSharper disable ArrangeRedundantParentheses
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
namespace Atc.Math.GeoSpatial;

/// <summary>
/// UniversalTransverseMercatorConverter
/// </summary>
[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:Field names should not contain underscore", Justification = "OK.")]
public class UniversalTransverseMercatorConverter
{
    // Factor Scale and False Easting
    private const double UTM_FAKTOR = 0.9996;
    private const double UTM_FALSE_EASTING = 500000;

    // Big half-axle
    private const double WGS84_HALBACHSE = 6378137.000;

    // Flattening WGS84 = 298,257223563 (1 / x)
    private const double WGS84_ABPLATTUNG = 3.35281066474748E-03;

    // Polar curvature
    private const double WGS84_POL = WGS84_HALBACHSE / (1 - WGS84_ABPLATTUNG);

    // Numeric eccentricities
    private const double WGS84_EXZENT2 = ((2 * WGS84_ABPLATTUNG) - (WGS84_ABPLATTUNG * WGS84_ABPLATTUNG)) /
                                         ((1 - WGS84_ABPLATTUNG) * (1 - WGS84_ABPLATTUNG));

    private const double WGS84_EXZENT4 = WGS84_EXZENT2 * WGS84_EXZENT2;
    private const double WGS84_EXZENT6 = WGS84_EXZENT4 * WGS84_EXZENT2;
    private const double WGS84_EXZENT8 = WGS84_EXZENT4 * WGS84_EXZENT4;

    private double a;
    private double eccSquared;

    /// <summary>
    /// Initializes a new instance of the <see cref="UniversalTransverseMercatorConverter"/> class.
    /// </summary>
    /// <param name="referenceEllipsoidType">Type of the reference ellipsoid.</param>
    public UniversalTransverseMercatorConverter(ReferenceEllipsoidType referenceEllipsoidType = ReferenceEllipsoidType.Wgs84)
    {
        this.SetEllipsoide(referenceEllipsoidType);
    }

    /// <summary>
    /// To UTM.
    /// </summary>
    /// <param name="coordinate">The coordinate.</param>
    public UniversalTransverseMercatorResult ToUtm(CartesianCoordinate coordinate)
    {
        return this.ToUtm(coordinate.Latitude, coordinate.Longitude);
    }

    /// <summary>
    /// To UTM.
    /// </summary>
    /// <param name="latitude">The latitude (also know as Y or Easting).</param>
    /// <param name="longitude">The longitude (also know as X or Northing).</param>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1407:Arithmetic expressions should declare precedence", Justification = "OK.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1312:Variable names should begin with lower-case letter", Justification = "OK. By design.")]
    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    public UniversalTransverseMercatorResult ToUtm(double latitude, double longitude)
    {
        int zoneNumber;
        var longitudeTemp = longitude;
        var latitudeRadian = MathHelper.DegreesToRadians(latitude);
        var longitudeRadian = MathHelper.DegreesToRadians(longitudeTemp);

        //// !!! Bug in C# switch pattern matching for double vs int !!!

        // ReSharper disable MergeIntoPattern
        // ReSharper disable ConvertIfStatementToSwitchStatement
        // ReSharper disable ConvertIfStatementToSwitchExpression
        if (longitudeTemp >= 8 && longitudeTemp <= 13 && latitude > 54.5 && latitude < 58)
        {
            zoneNumber = 32;
        }
        else if (latitude >= 56.0 && latitude < 64.0 && longitudeTemp >= 3.0 && longitudeTemp < 12.0)
        {
            zoneNumber = 32;
        }
        else
        {
            zoneNumber = (int)((longitudeTemp + 180) / 6) + 1;
            if (latitude >= 72.0 && latitude < 84.0)
            {
                if (longitudeTemp >= 0.0 && longitudeTemp < 9.0)
                {
                    zoneNumber = 31;
                }
                else if (longitudeTemp >= 9.0 && longitudeTemp < 21.0)
                {
                    zoneNumber = 33;
                }
                else if (longitudeTemp >= 21.0 && longitudeTemp < 33.0)
                {
                    zoneNumber = 35;
                }
                else if (longitudeTemp >= 33.0 && longitudeTemp < 42.0)
                {
                    zoneNumber = 37;
                }
            }
        }

        // ReSharper restore ConvertIfStatementToSwitchExpression
        // ReSharper restore ConvertIfStatementToSwitchStatement
        // ReSharper restore MergeIntoPattern
        var longitudeOrigin = (zoneNumber - 1) * 6 - 180 + 3; //// +3 puts origin in middle of zone
        var longitudeOriginRadian = MathHelper.DegreesToRadians(longitudeOrigin);
        string utmZone = GetUtmLetterDesignator(latitude);
        var eccPrimeSquared = this.eccSquared / (1 - this.eccSquared);

        var N = this.a / System.Math.Sqrt(1 - this.eccSquared * System.Math.Sin(latitudeRadian) * System.Math.Sin(latitudeRadian));
        var T = System.Math.Tan(latitudeRadian) * System.Math.Tan(latitudeRadian);
        var C = eccPrimeSquared * System.Math.Cos(latitudeRadian) * System.Math.Cos(latitudeRadian);
        var A = System.Math.Cos(latitudeRadian) * (longitudeRadian - longitudeOriginRadian);

        var M = this.a * ((1 - this.eccSquared / 4 - 3 * this.eccSquared * this.eccSquared / 64
                           - 5 * this.eccSquared * this.eccSquared * this.eccSquared / 256) * latitudeRadian
            - (3 * this.eccSquared / 8 + 3 * this.eccSquared * this.eccSquared / 32 + 45 * this.eccSquared * this.eccSquared * this.eccSquared / 1024) * System.Math.Sin(2 * latitudeRadian)
            + (15 * this.eccSquared * this.eccSquared / 256 + 45 * this.eccSquared * this.eccSquared * this.eccSquared / 1024) *
            System.Math.Sin(4 * latitudeRadian) - 35 * this.eccSquared * this.eccSquared * this.eccSquared / 3072 * System.Math.Sin(6 * latitudeRadian));

        var utmEasting = 0.9996 * N * (A + (1 - T + C) * A * A * A / 6
                                         + (5 - 18 * T + T * T + 72 * C - 58 * eccPrimeSquared) * A * A * A * A * A / 120)
                         + 500000.0;

        var utmNorthing = 0.9996 * (M + N * System.Math.Tan(latitudeRadian) * (A * A / 2 + (5 - T + 9 * C + 4 * C * C) * A * A * A * A / 24
            + (61 - 58 * T + T * T + 600 * C - 330 * eccPrimeSquared) * A * A * A * A * A * A / 720));

        if (latitude < 0)
        {
            utmNorthing += 10000000.0;
        }

        return new UniversalTransverseMercatorResult(zoneNumber, utmZone, utmEasting, utmNorthing);
    }

    /// <summary>
    /// To WGS84.
    /// </summary>
    /// <param name="utmZoneNumber">The utm zone number.</param>
    /// <param name="utmZoneLetter">The utm zone letter.</param>
    /// <param name="utmEasting">The utm easting.</param>
    /// <param name="utmNorthing">The utm northing.</param>
    /// <param name="maxDecimalPrecision">The maximum decimal precision.</param>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1407:Arithmetic expressions should declare precedence", Justification = "OK.")]
    public CartesianCoordinate ToWgs84(int utmZoneNumber, string utmZoneLetter, double utmEasting, double utmNorthing, int maxDecimalPrecision = 8)
    {
        if (utmZoneLetter is null)
        {
            throw new ArgumentNullException(nameof(utmZoneLetter));
        }

        // Coefficients for calculating the latitude from given meridian arc length
        var coefficient0Radian = WGS84_POL * MathHelper.DegreesToRadians(
            1 - 3 * WGS84_EXZENT2 / 4 + 45 * WGS84_EXZENT4 / 64 -
            175 * WGS84_EXZENT6 / 256 + 11025 * WGS84_EXZENT8 / 16384);
        var coefficient2Degrees = MathHelper.RadiansToDegrees(
            3 * WGS84_EXZENT2 / 8 - 3 * WGS84_EXZENT4 / 16 + 213 * WGS84_EXZENT6 / 2048 -
            255 * WGS84_EXZENT8 / 4096);

        var coefficient4Degrees = MathHelper.RadiansToDegrees(21 * WGS84_EXZENT4 / 256 - 21 * WGS84_EXZENT6 / 256 +
                                                              533 * WGS84_EXZENT8 / 8192);

        var coefficientDegrees =
            MathHelper.RadiansToDegrees(151 * WGS84_EXZENT6 / 6144 - 453 * WGS84_EXZENT8 / 12288);

        // Northern / Southern Hemisphere
        var b = utmZoneLetter[0];
        if (b < 'N' && !string.IsNullOrEmpty(utmZoneLetter))
        {
            utmNorthing -= 10E+06;
        }

        // Latitude (Rad)
        var sig = (utmNorthing / UTM_FAKTOR) / coefficient0Radian;
        var sigRad = MathHelper.DegreesToRadians(sig);
        var flatitude = sig + coefficient2Degrees * System.Math.Sin(2 * sigRad) +
                        coefficient4Degrees * System.Math.Sin(4 * sigRad) + coefficientDegrees * System.Math.Sin(6 * sigRad);
        var latitudeRadian = MathHelper.DegreesToRadians(flatitude);

        var tangens1 = System.Math.Tan(latitudeRadian);
        var tangens2 = tangens1 * tangens1;
        var tangens4 = tangens2 * tangens2;
        var cosinus1 = System.Math.Cos(latitudeRadian);
        var cosinus2 = cosinus1 * cosinus1;

        var eta = WGS84_EXZENT2 * cosinus2;

        // Transverse curvature
        var qkhm1 = WGS84_POL / System.Math.Sqrt(1 + eta);
        var qkhm2 = System.Math.Pow(qkhm1, 2);
        var qkhm3 = System.Math.Pow(qkhm1, 3);
        var qkhm4 = System.Math.Pow(qkhm1, 4);
        var qkhm5 = System.Math.Pow(qkhm1, 5);
        var qkhm6 = System.Math.Pow(qkhm1, 6);

        // Difference to the reference meridian
        var merid = (utmZoneNumber - 30) * 6 - 3;
        var dlongitude1 = (utmEasting - UTM_FALSE_EASTING) / UTM_FAKTOR;
        var dlongitude2 = System.Math.Pow(dlongitude1, 2);
        var dlongitude3 = System.Math.Pow(dlongitude1, 3);
        var dlongitude4 = System.Math.Pow(dlongitude1, 4);
        var dlongitude5 = System.Math.Pow(dlongitude1, 5);
        var dlongitude6 = System.Math.Pow(dlongitude1, 6);

        // Factors for latitude calculation
        var bfakt2 = -tangens1 * (1 + eta) / (2 * qkhm2);
        var bfakt4 = tangens1 * (5 + 3 * tangens2 + 6 * eta * (1 - tangens2)) / (24 * qkhm4);
        var bfakt6 = -tangens1 * (61 + 90 * tangens2 + 45 * tangens4) / (720 * qkhm6);

        // Factors for longitude calculation
        var lfakt1 = 1 / (qkhm1 * cosinus1);
        var lfakt3 = -(1 + 2 * tangens2 + eta) / (6 * qkhm3 * cosinus1);
        var lfakt5 = (5 + 28 * tangens2 + 24 * tangens4) / (120 * qkhm5 * cosinus1);

        // WGS84
        var latitude = flatitude + MathHelper.RadiansToDegrees(
            bfakt2 * dlongitude2 + bfakt4 * dlongitude4 + bfakt6 * dlongitude6);
        var longitude = merid + MathHelper.RadiansToDegrees(lfakt1 * dlongitude1 + lfakt3 * dlongitude3 + lfakt5 * dlongitude5);

        return new CartesianCoordinate(
            MathHelper.TruncateToMaxPrecision(latitude, maxDecimalPrecision),
            MathHelper.TruncateToMaxPrecision(longitude, maxDecimalPrecision));
    }

    private void SetEllipsoide(ReferenceEllipsoidType referenceEllipsoidType)
    {
        switch (referenceEllipsoidType)
        {
            case ReferenceEllipsoidType.Airy:
                this.a = 6377563;
                this.eccSquared = 0.00667054;
                break;
            case ReferenceEllipsoidType.AustralianNational:
            case ReferenceEllipsoidType.SouthAmerican1969:
                this.a = 6378160;
                this.eccSquared = 0.006694542;
                break;
            case ReferenceEllipsoidType.Bessel1841:
                this.a = 6377397;
                this.eccSquared = 0.006674372;
                break;
            case ReferenceEllipsoidType.Bessel1841Nambia:
                this.a = 6377484;
                this.eccSquared = 0.006674372;
                break;
            case ReferenceEllipsoidType.Clarke1866:
                this.a = 6378206;
                this.eccSquared = 0.006768658;
                break;
            case ReferenceEllipsoidType.Clarke1880:
                this.a = 6378249;
                this.eccSquared = 0.006803511;
                break;
            case ReferenceEllipsoidType.Everest:
                this.a = 6377276;
                this.eccSquared = 0.006637847;
                break;
            case ReferenceEllipsoidType.Fischer1960Mercury:
                this.a = 6378166;
                this.eccSquared = 0.006693422;
                break;
            case ReferenceEllipsoidType.Fischer1968:
                this.a = 6378150;
                this.eccSquared = 0.006693422;
                break;
            case ReferenceEllipsoidType.Grs1967:
                this.a = 6378160;
                this.eccSquared = 0.006694605;
                break;
            case ReferenceEllipsoidType.Grs1980:
            case ReferenceEllipsoidType.Wgs84:
            case ReferenceEllipsoidType.Euref89:
            case ReferenceEllipsoidType.Etrs89:
                this.a = 6378137;
                this.eccSquared = 0.00669438;
                break;
            case ReferenceEllipsoidType.Helmert1906:
                this.a = 6378200;
                this.eccSquared = 0.006693422;
                break;
            case ReferenceEllipsoidType.Hough:
                this.a = 6378270;
                this.eccSquared = 0.00672267;
                break;
            case ReferenceEllipsoidType.International:
            case ReferenceEllipsoidType.Ed50:
                this.a = 6378388;
                this.eccSquared = 0.00672267;
                break;
            case ReferenceEllipsoidType.Krassovsky:
                this.a = 6378245;
                this.eccSquared = 0.006693422;
                break;
            case ReferenceEllipsoidType.ModifiedAiry:
                this.a = 6377340;
                this.eccSquared = 0.00667054;
                break;
            case ReferenceEllipsoidType.ModifiedEverest:
                this.a = 6377304;
                this.eccSquared = 0.006637847;
                break;
            case ReferenceEllipsoidType.ModifiedFischer1960:
                this.a = 6378155;
                this.eccSquared = 0.006693422;
                break;
            case ReferenceEllipsoidType.Wgs60:
                this.a = 6378165;
                this.eccSquared = 0.006693422;
                break;
            case ReferenceEllipsoidType.Wgs66:
                this.a = 6378145;
                this.eccSquared = 0.006694542;
                break;
            case ReferenceEllipsoidType.Wgs72:
                this.a = 6378135;
                this.eccSquared = 0.006694318;
                break;
            default:
                throw new SwitchCaseDefaultException(referenceEllipsoidType);
        }
    }

    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1131:Use readable conditions", Justification = "OK. Bug in C# pattern matching for double.")]
    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    private static string GetUtmLetterDesignator(double latitude)
    {
        //// !!! Bug in C# switch pattern matching for double vs int !!!

        // ReSharper disable MergeIntoPattern
        // ReSharper disable ConvertIfStatementToSwitchStatement
        // ReSharper disable ConvertIfStatementToSwitchExpression
        if (84 >= latitude && latitude >= 72)
        {
            return "X";
        }

        if (72 > latitude && latitude >= 64)
        {
            return "W";
        }

        if (64 > latitude && latitude >= 56)
        {
            return "V";
        }

        if (56 > latitude && latitude >= 48)
        {
            return "U";
        }

        if (48 > latitude && latitude >= 40)
        {
            return "T";
        }

        if (40 > latitude && latitude >= 32)
        {
            return "S";
        }

        if (32 > latitude && latitude >= 24)
        {
            return "R";
        }

        if (24 > latitude && latitude >= 16)
        {
            return "Q";
        }

        if (16 > latitude && latitude >= 8)
        {
            return "P";
        }

        if (8 > latitude && latitude >= 0)
        {
            return "N";
        }

        if (0 > latitude && latitude >= -8)
        {
            return "M";
        }

        if (-8 > latitude && latitude >= -16)
        {
            return "L";
        }

        if (-16 > latitude && latitude >= -24)
        {
            return "K";
        }

        if (-24 > latitude && latitude >= -32)
        {
            return "J";
        }

        if (-32 > latitude && latitude >= -40)
        {
            return "H";
        }

        if (-40 > latitude && latitude >= -48)
        {
            return "G";
        }

        if (-48 > latitude && latitude >= -56)
        {
            return "F";
        }

        if (-56 > latitude && latitude >= -64)
        {
            return "E";
        }

        if (-64 > latitude && latitude >= -72)
        {
            return "D";
        }

        if (-72 > latitude && latitude >= -80)
        {
            return "C";
        }

        return "Z";

        // ReSharper restore ConvertIfStatementToSwitchExpression
        // ReSharper restore ConvertIfStatementToSwitchStatement
        // ReSharper restore MergeIntoPattern
    }
}