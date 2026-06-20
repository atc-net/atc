// ReSharper disable StringLiteralTypo
namespace Atc.Tests.Math.GeoSpatial;

public class UniversalTransverseMercatorConverterTests
{
    [Theory]
    [ClassData(typeof(TestClassDataForGeoSpatialToUtm))]
    public void ToUtm_CartesianCoordinate(
        string description,
        CartesianCoordinate input,
        UniversalTransverseMercatorResult expected)
    {
        // Arrange
        var converter = new UniversalTransverseMercatorConverter(); // Default is WGS84

        // Act
        var actual = converter.ToUtm(input);

        // Assert
        actual.Should().NotBeNull(description);
        actual.ZoneLetter.Should().Be(expected.ZoneLetter, $"ZoneLetter on ({description})");
        actual.ZoneNumber.Should().Be(expected.ZoneNumber, $"ZoneNumber on ({description})");
        actual.UtmEasting.Should().Be(expected.UtmEasting, $"UtmEasting on ({description})");
        actual.UtmNorthing.Should().Be(expected.UtmNorthing, $"UtmNorthing on ({description})");
    }

    [Theory]
    [ClassData(typeof(TestClassDataForGeoSpatialToUtm))]
    public void ToUtm(
        string description,
        CartesianCoordinate input,
        UniversalTransverseMercatorResult expected)
    {
        // Arrange
        var converter = new UniversalTransverseMercatorConverter(); // Default is WGS84

        // Act
        var actual = converter.ToUtm(input.Latitude, input.Longitude);

        // Assert
        actual.Should().NotBeNull(description);
        actual.ZoneLetter.Should().Be(expected.ZoneLetter, $"ZoneLetter on ({description})");
        actual.ZoneNumber.Should().Be(expected.ZoneNumber, $"ZoneNumber on ({description})");
        actual.UtmEasting.Should().Be(expected.UtmEasting, $"UtmEasting on ({description})");
        actual.UtmNorthing.Should().Be(expected.UtmNorthing, $"UtmNorthing on ({description})");
    }

    [Fact]
    public void ToWgs84_EmptyZoneLetter_DoesNotThrow()
    {
        // utmZoneLetter[0] was accessed before the IsNullOrEmpty guard, causing
        // IndexOutOfRangeException when an empty string was passed.
        var converter = new UniversalTransverseMercatorConverter();
        var exception = Record.Exception(() => converter.ToWgs84(32, string.Empty, 691875, 6098907));
        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(TestClassDataForGeoSpatialToWgs84))]
    public void ToWgs84(
        string description,
        UniversalTransverseMercatorResult input,
        int maxDecimalPrecision,
        CartesianCoordinate expected)
    {
        // Arrange
        var converter = new UniversalTransverseMercatorConverter();

        // Act
        var actual = converter.ToWgs84(input.ZoneNumber, input.ZoneLetter, input.UtmEasting, input.UtmNorthing, maxDecimalPrecision);

        // Assert
        actual.Should().NotBeNull(description);
        actual.Latitude.Should().Be(expected.Latitude, $"Latitude on ({description})");
        actual.Longitude.Should().Be(expected.Longitude, $"Longitude on ({description})");
    }
}