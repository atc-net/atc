namespace Atc.Tests.Math.Geometry.CoordinateSystem;

public class CartesianHelperTests
{
    [Theory]
    [InlineData(0.0, 0.0, 0.0, 0.0)]
    public void ComputeCoordinateFromPolar(
        double expectedX,
        double expectedY,
        double angle,
        double radius)
    {
        // Act
        var actual = CartesianHelper.ComputeCoordinateFromPolar(angle, radius);

        // Assert
        Assert.Equal(new Point2D(expectedX, expectedY), actual);
    }

    [Theory]
    [InlineData(0.0, 0.0, 0.0, 0.0, 0.0)]
    public void DistanceBetweenTwoPoints_Point2D(
        double expected,
        double x1,
        double y1,
        double x2,
        double y2)
    {
        // Arrange
        Point2D pointA = new Point2D(x1, y1);
        Point2D pointB = new Point2D(x2, y2);

        // Act
        var actual = CartesianHelper.DistanceBetweenTwoPoints(pointA, pointB);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0)]
    public void DistanceBetweenTwoPoints_Point3D(
        double expected,
        double x1,
        double y1,
        double z1,
        double x2,
        double y2,
        double z2)
    {
        // Arrange
        Point3D pointA = new Point3D(x1, y1, z1);
        Point3D pointB = new Point3D(x2, y2, z2);

        // Act
        var actual = CartesianHelper.DistanceBetweenTwoPoints(pointA, pointB);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0.0, 0.0, 0.0, 0.0, 0.0)]
    public void DistanceBetweenTwoPoints_CartesianCoordinate(
        double expected,
        double x1,
        double y1,
        double x2,
        double y2)
    {
        // Arrange
        CartesianCoordinate coordinate1 = new CartesianCoordinate(x1, y1);
        CartesianCoordinate coordinate2 = new CartesianCoordinate(x2, y2);

        // Act
        var actual = CartesianHelper.DistanceBetweenTwoPoints(coordinate1, coordinate2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0.0, 0.0, 0.0, 0.0, 0.0)]
    public void DistanceBetweenTwoPoints_2(
        double expected,
        double x1,
        double y1,
        double x2,
        double y2)
    {
        // Act
        var actual = CartesianHelper.DistanceBetweenTwoPoints(x1, y1, x2, y2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0)]
    public void DistanceBetweenTwoPoints_3(
        double expected,
        double x1,
        double y1,
        double z1,
        double x2,
        double y2,
        double z2)
    {
        // Act
        var actual = CartesianHelper.DistanceBetweenTwoPoints(x1, y1, z1, x2, y2, z2);

        // Assert
        Assert.Equal(expected, actual);
    }
}