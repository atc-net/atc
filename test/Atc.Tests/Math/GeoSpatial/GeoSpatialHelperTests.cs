using System.Diagnostics.CodeAnalysis;
using Atc.Math.GeoSpatial;
using Atc.Structs;
using Xunit;

namespace Atc.Tests.Math.GeoSpatial
{
    public class GeoSpatialHelperTests
    {
        [Theory]
        [InlineData(0.0, 0.0, 0.0, 0.0, 0.0, DistanceMeasurementType.Kilometers)]
        public void Distance_CartesianCoordinate(double expected, double latitude1, double longitude1, double latitude2, double longitude2, DistanceMeasurementType measurement)
        {
            // Arrange
            var coordinate1 = new CartesianCoordinate(latitude1, longitude1);
            var coordinate2 = new CartesianCoordinate(latitude2, longitude2);

            // Act
            var actual = GeoSpatialHelper.Distance(coordinate1, coordinate2, measurement);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0.0, 0.0, 0.0, 0.0, 0.0, DistanceMeasurementType.Kilometers)]
        [SuppressMessage("Major Code Smell", "S2234:Parameters should be passed in the correct order", Justification = "OK.")]
        public void Distance(double expected, double latitude1, double longitude1, double latitude2, double longitude2, DistanceMeasurementType measurement)
        {
            // Act
            var actual = GeoSpatialHelper.Distance(latitude1, longitude1, latitude2, longitude2, measurement);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}