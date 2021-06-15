using Atc.Helpers;

namespace Atc.Math.Geometry
{
    /// <summary>
    /// The CircleHelper module contains procedures used to preform math operations on a circle.
    /// </summary>
    public static class CircleHelper
    {
        /// <summary>
        /// Areas the specified radius.
        /// </summary>
        /// <param name="radius">The radius.</param>
        public static double Area(double radius)
        {
            return System.Math.PI * System.Math.Pow(radius, 2);
        }

        /// <summary>
        /// Circumferences the specified radius.
        /// </summary>
        /// <param name="radius">The radius.</param>
        public static double Circumference(double radius)
        {
            return 2 * radius * System.Math.PI;
        }

        /// <summary>
        /// Arcs the length.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="angle">The angle.</param>
        public static double ArcLength(double radius, double angle)
        {
            return Circumference(radius) / 360 * angle;
        }

        /// <summary>
        /// Chords the length.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="angle">The angle.</param>
        public static double ChordLength(double radius, double angle)
        {
            return 2 * radius * System.Math.Sin(MathHelper.DegreesToRadians(angle) / 2);
        }
    }
}
