using System;
using Atc.Helpers;
using Atc.Structs;

namespace Atc.Math.GeoSpatial
{
    /// <summary>
    /// GeoSpatialHelper
    /// </summary>
    public static class GeoSpatialHelper
    {
        /// <summary>
        /// Calculate distance.
        /// </summary>
        /// <param name="coordinate1">The coordinate1.</param>
        /// <param name="coordinate2">The coordinate2.</param>
        /// <param name="measurement">The measurement.</param>
        public static double Distance(
            CartesianCoordinate coordinate1,
            CartesianCoordinate coordinate2,
            DistanceMeasurementType measurement) =>
            Distance(coordinate1.Longitude, coordinate1.Latitude, coordinate2.Longitude, coordinate2.Latitude, measurement);

        /// <summary>
        /// Calculate distance.
        /// </summary>
        /// <param name="longitude1">The longitude1.</param>
        /// <param name="latitude1">The latitude1.</param>
        /// <param name="longitude2">The longitude2.</param>
        /// <param name="latitude2">The latitude2.</param>
        /// <param name="measurement">The measurement.</param>
        public static double Distance(
            double longitude1,
            double latitude1,
            double longitude2,
            double latitude2,
            DistanceMeasurementType measurement = DistanceMeasurementType.Kilometers)
        {
            double diff = longitude1 - longitude2;
            double distance = (System.Math.Sin(MathHelper.DegreesToRadians(latitude1)) * System.Math.Sin(MathHelper.DegreesToRadians(latitude2))) +
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
}