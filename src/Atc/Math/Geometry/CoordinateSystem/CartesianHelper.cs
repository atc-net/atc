namespace Atc.Math.Geometry.CoordinateSystem;

/// <summary>
/// CoordinateSystemHelper
/// </summary>
public static class CartesianHelper
{
    /// <summary>
    /// Computes the coordinate from polar.
    /// </summary>
    /// <param name="angle">The angle.</param>
    /// <param name="radius">The radius.</param>
    public static Point2D ComputeCoordinateFromPolar(double angle, double radius)
    {
        // Convert angle to radians
        double angleRad = System.Math.PI / 180.0 * (angle - 90);

        // Calculate x and y
        double x = radius * System.Math.Cos(angleRad);
        double y = radius * System.Math.Sin(angleRad);

        return new Point2D(x, y);
    }

    /// <summary>
    /// The Euclidean distance between two points of the plane with Cartesian coordinates (x1,y1) and (x2,y2).
    /// d = Sqrt((x2-x1)^2 + (y2-y1)^2)
    /// </summary>
    /// <param name="pointA">The first point2d</param>
    /// <param name="pointB">The second point2d</param>
    /// <returns>The distance</returns>
    public static double DistanceBetweenTwoPoints(Point2D pointA, Point2D pointB)
    {
        return DistanceBetweenTwoPoints(pointA.X, pointA.Y, pointB.X, pointB.Y);
    }

    /// <summary>
    /// This is the Cartesian version of Pythagoras' theorem. In three-dimensional space, the distance between points (x1,y1,z1) and (x2,y2,z2).
    /// d = Sqrt((x2-x1)^2 + (y2-y1)^2 + (z2-z1)^2)
    /// </summary>
    /// <param name="pointA">The first point</param>
    /// <param name="pointB">The second point</param>
    /// <returns>The distance</returns>
    public static double DistanceBetweenTwoPoints(Point3D pointA, Point3D pointB)
    {
        return DistanceBetweenTwoPoints(pointA.X, pointA.Y, pointA.Z, pointB.X, pointB.Y, pointB.Z);
    }

    /// <summary>
    /// Calculate the distance between two points.
    /// </summary>
    /// <param name="coordinateA">The coordinate a.</param>
    /// <param name="coordinateB">The coordinate b.</param>
    /// <returns>Returns the distance between two points.</returns>
    public static double DistanceBetweenTwoPoints(CartesianCoordinate coordinateA, CartesianCoordinate coordinateB)
    {
        return DistanceBetweenTwoPoints(coordinateA.Longitude, coordinateA.Latitude, coordinateB.Longitude, coordinateB.Latitude);
    }

    /// <summary>
    /// The Euclidean distance between two points of the plane with Cartesian coordinates (x1,y1) and (x2,y2).
    /// d = Sqrt((x2-x1)^2 + (y2-y1)^2)
    /// </summary>
    /// <param name="x1">The point on the x-axis of the first point</param>
    /// <param name="y1">The point on the y-axis of the first point</param>
    /// <param name="x2">The point on the x-axis of the second point</param>
    /// <param name="y2">The point on the y-axis of the second point</param>
    /// <returns>Returns the distance between two points.</returns>
    public static double DistanceBetweenTwoPoints(double x1, double y1, double x2, double y2)
    {
        // Take x2-x1, then square it
        var part1 = System.Math.Pow(x2 - x1, 2);

        // Take y2-y1, then square it
        var part2 = System.Math.Pow(y2 - y1, 2);

        // Add both of the parts together
        var underRadical = part1 + part2;

        // Get the square root of the parts
        return System.Math.Sqrt(underRadical);
    }

    /// <summary>
    /// This is the Cartesian version of Pythagoras' theorem. In three-dimensional space, the distance between points (x1,y1,z1) and (x2,y2,z2).
    /// d = Sqrt((x2-x1)^2 + (y2-y1)^2 + (z2-z1)^2)
    /// </summary>
    /// <param name="x1">The point on the x-axis of the first point</param>
    /// <param name="y1">The point on the y-axis of the first point</param>
    /// <param name="z1">The point on the z-axis of the first point</param>
    /// <param name="x2">The point on the x-axis of the second point</param>
    /// <param name="y2">The point on the y-axis of the second point</param>
    /// <param name="z2">The point on the z-axis of the second point</param>
    /// <returns>Returns the distance between two points.</returns>
    public static double DistanceBetweenTwoPoints(double x1, double y1, double z1, double x2, double y2, double z2)
    {
        // Take x2-x1, then square it
        var part1 = System.Math.Pow(x2 - x1, 2);

        // Take y2-y1, then square it
        var part2 = System.Math.Pow(y2 - y1, 2);

        // Take z2-z1, then square it
        var part3 = System.Math.Pow(z2 - z1, 2);

        // Add both of the parts together
        var underRadical = part1 + part2 + part3;

        // Get the square root of the parts
        return System.Math.Sqrt(underRadical);
    }
}