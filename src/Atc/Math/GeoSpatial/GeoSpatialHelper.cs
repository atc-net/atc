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
        DistanceMeasurementType measurement = DistanceMeasurementType.Kilometers)
    {
        var diff = longitude1 - longitude2;
        var distance = (System.Math.Sin(MathHelper.DegreesToRadians(latitude1)) * System.Math.Sin(MathHelper.DegreesToRadians(latitude2))) +
                       (System.Math.Cos(MathHelper.DegreesToRadians(latitude1)) * System.Math.Cos(MathHelper.DegreesToRadians(latitude2)) * System.Math.Cos(MathHelper.DegreesToRadians(diff)));
        distance = System.Math.Acos(distance);
        distance = MathHelper.RadiansToDegrees(distance);
        distance = distance * 60 * 1.1515;
        switch (measurement)
        {
            case DistanceMeasurementType.Meters:
                distance = distance * 1.609344 * 1000;
                break;
            case DistanceMeasurementType.Feet:
                distance = distance * 1.609344 * 1000 * 3.2808399;
                break;
            case DistanceMeasurementType.Kilometers:
                distance *= 1.609344;
                break;
            case DistanceMeasurementType.StatuteMiles:
                // default
                break;
            case DistanceMeasurementType.NauticalMiles:
                distance *= 0.8684;
                break;
            default:
                throw new SwitchCaseDefaultException(measurement);
        }

        return distance;
    }
}