namespace Atc.Math.Geometry;

/// <summary>
/// The TriangleHelper module contains procedures used to preform math operations on a triangle.
/// </summary>
public static class TriangleHelper
{
    /// <summary>
    /// Determines whether [is sum of the angles A triangle] [the specified angle A].
    /// </summary>
    /// <param name="angleA">The angle A.</param>
    /// <param name="angleB">The angle B.</param>
    /// <param name="angleC">The angle C.</param>
    /// <returns>
    ///   <see langword="true" /> if [is sum of the angles A triangle] [the specified angle A]; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsSumOfTheAnglesATriangle(double? angleA, double? angleB, double? angleC)
    {
        if (angleA is null)
        {
            throw new ArgumentNullException(nameof(angleA));
        }

        if (angleB is null)
        {
            throw new ArgumentNullException(nameof(angleB));
        }

        if (angleC is null)
        {
            throw new ArgumentNullException(nameof(angleC));
        }

        return IsSumOfTheAnglesATriangle((double)angleA, (double)angleB, (double)angleC);
    }

    /// <summary>
    /// Determines whether [is sum of the angles A triangle] [the specified angle A].
    /// </summary>
    /// <param name="angleA">The angle A.</param>
    /// <param name="angleB">The angle B.</param>
    /// <param name="angleC">The angle C.</param>
    /// <returns>
    ///   <see langword="true" /> if [is sum of the angles A triangle] [the specified angle A]; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsSumOfTheAnglesATriangle(double angleA, double angleB, double angleC)
    {
        return (angleA + angleB + angleC).IsEqual(180);
    }

    /// <summary>
    /// Calculate the unspecified side (unspecified with NULL).
    /// </summary>
    /// <param name="sideA">The side A.</param>
    /// <param name="sideB">The side B.</param>
    /// <param name="sideC">The side C.</param>
    public static double Pythagorean(double? sideA, double? sideB, double? sideC)
    {
        var i = Convert.ToInt32(sideA.HasValue) + Convert.ToInt32(sideB.HasValue) + Convert.ToInt32(sideC.HasValue);

        if (i != 2)
        {
            throw new ArithmeticException("One and only one argument have to be null.");
        }

        if (sideA is null && sideB is not null && sideC is not null)
        {
            // Calc sideA
            return System.Math.Sqrt(System.Math.Pow((double)sideC, 2) - System.Math.Pow((double)sideB, 2));
        }

        if (sideA is not null && sideB is null && sideC is not null)
        {
            // Calc sideB
            return System.Math.Sqrt(System.Math.Pow((double)sideC, 2) - System.Math.Pow((double)sideA, 2));
        }

        if (sideA is not null && sideB is not null && sideC is null)
        {
            // Calc sideC
            return System.Math.Sqrt(System.Math.Pow((double)sideA, 2) + System.Math.Pow((double)sideB, 2));
        }

        throw new ArithmeticException("Expected early return - Bad implementation.");
    }
}