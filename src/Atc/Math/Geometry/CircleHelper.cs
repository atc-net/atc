namespace Atc.Math.Geometry;

/// <summary>
/// Provides utility methods for performing geometric calculations on circles.
/// </summary>
public static class CircleHelper
{
    /// <summary>
    /// Calculates the area of a circle given its radius.
    /// </summary>
    /// <param name="radius">The radius of the circle.</param>
    /// <returns>The area of the circle (π * r²).</returns>
    public static double Area(double radius)
    {
        return System.Math.PI * System.Math.Pow(radius, 2);
    }

    /// <summary>
    /// Calculates the circumference of a circle given its radius.
    /// </summary>
    /// <param name="radius">The radius of the circle.</param>
    /// <returns>The circumference of the circle (2πr).</returns>
    public static double Circumference(double radius)
    {
        return 2 * radius * System.Math.PI;
    }

    /// <summary>
    /// Calculates the arc length of a circular arc given the radius and central angle.
    /// </summary>
    /// <param name="radius">The radius of the circle.</param>
    /// <param name="angle">The central angle in degrees.</param>
    /// <returns>The length of the arc.</returns>
    public static double ArcLength(
        double radius,
        double angle)
    {
        return Circumference(radius) / 360 * angle;
    }

    /// <summary>
    /// Calculates the chord length of a circular arc given the radius and central angle.
    /// </summary>
    /// <param name="radius">The radius of the circle.</param>
    /// <param name="angle">The central angle in degrees.</param>
    /// <returns>The straight-line distance between the endpoints of the arc.</returns>
    public static double ChordLength(
        double radius,
        double angle)
    {
        return 2 * radius * System.Math.Sin(MathHelper.DegreesToRadians(angle) / 2);
    }
}