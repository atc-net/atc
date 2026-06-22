namespace Atc.Tests.Math.GeoSpatial;

public class GeoSpatialHelperTests
{
    [Theory]
    [InlineData(0.0, 0.0, 0.0, 0.0, 0.0, DistanceMeasurementType.Kilometers)]
    public void Distance_CartesianCoordinate(
        double expected,
        double latitude1,
        double longitude1,
        double latitude2,
        double longitude2,
        DistanceMeasurementType measurement)
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
    public void Distance(
        double expected,
        double latitude1,
        double longitude1,
        double latitude2,
        double longitude2,
        DistanceMeasurementType measurement)
    {
        // Act
        var actual = GeoSpatialHelper.Distance(latitude1, longitude1, latitude2, longitude2, measurement);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Distance_LondonToParis_IsApproximately341Km()
    {
        // London: lat=51.5074, lon=-0.1278   Paris: lat=48.8566, lon=2.3522
        // Haversine gives ~341 km; the old spherical-law-of-cosines gave ~323 km.
        const double londonLat = 51.5074;
        const double londonLon = -0.1278;
        const double parisLat = 48.8566;
        const double parisLon = 2.3522;

        var km = GeoSpatialHelper.Distance(londonLon, londonLat, parisLon, parisLat, DistanceMeasurementType.Kilometers);

        Assert.InRange(km, 338, 344);
    }

    [Theory]
    [InlineData(0.0, 0.0, 0.0, 0.0, 0.0)]
    public void Bearing_CartesianCoordinate(
        double expected,
        double latitude1,
        double longitude1,
        double latitude2,
        double longitude2)
    {
        // Arrange
        var coordinate1 = new CartesianCoordinate(latitude1, longitude1);
        var coordinate2 = new CartesianCoordinate(latitude2, longitude2);

        // Act
        var actual = GeoSpatialHelper.Bearing(coordinate1, coordinate2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0.0, 0.0, 0.0, 0.0, 0.0)]
    public void Bearing(
        double expected,
        double longitude1,
        double latitude1,
        double longitude2,
        double latitude2)
    {
        // Act
        var actual = GeoSpatialHelper.Bearing(longitude1, latitude1, longitude2, latitude2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Bearing_LondonToParis_IsApproximately148Degrees()
    {
        const double londonLat = 51.5074;
        const double londonLon = -0.1278;
        const double parisLat = 48.8566;
        const double parisLon = 2.3522;

        var actual = GeoSpatialHelper.Bearing(londonLon, londonLat, parisLon, parisLat);

        Assert.InRange(actual, 145, 152);
    }
}