namespace Atc.Math.GeoSpatial;

/// <summary>
/// Provides utility methods for geospatial calculations including distance measurements between geographic coordinates.
/// </summary>
public static class GeoSpatialHelper
{
    /// <summary>
    /// Calculates the great-circle distance between two geographic coordinates.
    /// </summary>
    /// <param name="coordinate1">The first coordinate.</param>
    /// <param name="coordinate2">The second coordinate.</param>
    /// <param name="measurement">The unit of measurement for the result.</param>
    /// <returns>The distance between the two coordinates in the specified measurement unit.</returns>
    public static double Distance(
        CartesianCoordinate coordinate1,
        CartesianCoordinate coordinate2,
        DistanceMeasurementType measurement) =>
        Distance(coordinate1.Longitude, coordinate1.Latitude, coordinate2.Longitude, coordinate2.Latitude, measurement);

    /// <summary>
    /// Calculates the great-circle distance between two geographic points using the Haversine formula.
    /// </summary>
    /// <param name="longitude1">The longitude of the first point in degrees.</param>
    /// <param name="latitude1">The latitude of the first point in degrees.</param>
    /// <param name="longitude2">The longitude of the second point in degrees.</param>
    /// <param name="latitude2">The latitude of the second point in degrees.</param>
    /// <param name="measurement">The unit of measurement for the result. Default is kilometers.</param>
    /// <param name="earthRadiusKm">The Earth radius in kilometers used for the calculation. Defaults to the mean Earth radius of 6371 km.</param>
    /// <returns>The great-circle distance between the two points in the specified measurement unit.</returns>
    /// <remarks>
    /// This method assumes a spherical Earth and uses the Haversine formula for calculation.
    /// The result represents the shortest distance over the Earth's surface.
    /// </remarks>
    public static double Distance(
        double longitude1,
        double latitude1,
        double longitude2,
        double latitude2,
        DistanceMeasurementType measurement = DistanceMeasurementType.Kilometers,
        double earthRadiusKm = 6371.0)
    {
        var lat1Rad = MathHelper.DegreesToRadians(latitude1);
        var lat2Rad = MathHelper.DegreesToRadians(latitude2);
        var dLat = MathHelper.DegreesToRadians(latitude2 - latitude1);
        var dLon = MathHelper.DegreesToRadians(longitude2 - longitude1);

        var a = (System.Math.Sin(dLat / 2) * System.Math.Sin(dLat / 2)) +
                (System.Math.Cos(lat1Rad) * System.Math.Cos(lat2Rad) *
                 System.Math.Sin(dLon / 2) * System.Math.Sin(dLon / 2));

        var c = 2 * System.Math.Atan2(System.Math.Sqrt(a), System.Math.Sqrt(1 - a));
        var distanceKm = earthRadiusKm * c;

        return measurement switch
        {
            DistanceMeasurementType.Meters => distanceKm * 1_000,
            DistanceMeasurementType.Feet => distanceKm * 1_000 * 3.2808399,
            DistanceMeasurementType.Kilometers => distanceKm,
            DistanceMeasurementType.StatuteMiles => distanceKm / 1.609344,
            DistanceMeasurementType.NauticalMiles => distanceKm / 1.852,
            _ => throw new SwitchCaseDefaultException(measurement),
        };
    }

    /// <summary>
    /// Calculates the initial bearing (forward azimuth) from one geographic coordinate to another.
    /// The bearing is the angle measured clockwise from true north (0°) to the direction of travel.
    /// </summary>
    /// <param name="coordinate1">The starting coordinate.</param>
    /// <param name="coordinate2">The destination coordinate.</param>
    /// <returns>The initial bearing in degrees (0–360), where 0° is north, 90° east, 180° south, 270° west.</returns>
    public static double Bearing(
        CartesianCoordinate coordinate1,
        CartesianCoordinate coordinate2)
        => Bearing(coordinate1.Longitude, coordinate1.Latitude, coordinate2.Longitude, coordinate2.Latitude);

    /// <summary>
    /// Calculates the initial bearing (forward azimuth) from one geographic point to another.
    /// The bearing is the angle measured clockwise from true north (0°) to the direction of travel.
    /// </summary>
    /// <param name="longitude1">The longitude of the starting point in degrees.</param>
    /// <param name="latitude1">The latitude of the starting point in degrees.</param>
    /// <param name="longitude2">The longitude of the destination point in degrees.</param>
    /// <param name="latitude2">The latitude of the destination point in degrees.</param>
    /// <returns>The initial bearing in degrees (0–360), where 0° is north, 90° east, 180° south, 270° west.</returns>
    public static double Bearing(
        double longitude1,
        double latitude1,
        double longitude2,
        double latitude2)
    {
        var lat1Rad = MathHelper.DegreesToRadians(latitude1);
        var lat2Rad = MathHelper.DegreesToRadians(latitude2);
        var dLonRad = MathHelper.DegreesToRadians(longitude2 - longitude1);

        var y = System.Math.Sin(dLonRad) * System.Math.Cos(lat2Rad);
        var x = (System.Math.Cos(lat1Rad) * System.Math.Sin(lat2Rad)) -
                (System.Math.Sin(lat1Rad) * System.Math.Cos(lat2Rad) * System.Math.Cos(dLonRad));

        var bearingRad = System.Math.Atan2(y, x);
        var bearingDeg = MathHelper.RadiansToDegrees(bearingRad) + 360.0;
        return bearingDeg % 360.0;
    }
}