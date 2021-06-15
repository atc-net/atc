using System;
using System.Collections.Generic;
using System.Linq;

namespace Atc.Helpers
{
    /// <summary>
    /// The MathHelper module contains procedures used to preform math operations.
    /// </summary>
    public static class MathHelper
    {
        /// <summary>Percentages as integer.</summary>
        /// <param name="totalValue">The total value.</param>
        /// <param name="value">The value.</param>
        /// <returns>The calculated percentage.</returns>
        /// <code><![CDATA[int value = MathUtil.PercentageAsInteger(totalValue, value);]]></code>
        /// <example><![CDATA[
        /// double totalValue = 100;
        /// double value = 10;
        /// int procentage = MathUtil.PercentageAsInteger(totalValue, value);
        /// ]]></example>
        public static int PercentageAsInteger(double totalValue, double value)
        {
            return (int)Percentage(totalValue, value, 0);
        }

        /// <summary>Percentages the specified total value.</summary>
        /// <param name="totalValue">The total value.</param>
        /// <param name="value">The value.</param>
        /// <param name="digits">The digits.</param>
        /// <returns>The calculated percentage.</returns>
        /// <code><![CDATA[double value = MathUtil.Percentage(totalValue, value);]]></code>
        /// <example><![CDATA[
        /// double totalValue = 100;
        /// double value = 10;
        /// double procentage = MathUtil.Percentage(totalValue, value);
        /// ]]></example>
        public static double Percentage(double totalValue, double value, int digits = 2)
        {
            if (digits < 0)
            {
                digits = 0;
            }

            double p = 0;
            if (value < totalValue)
            {
                p = System.Math.Round(100 - (value / totalValue * 100), digits, MidpointRounding.AwayFromZero);
            }

            return p;
        }

        /// <summary>
        /// Celsius to fahrenheit.
        /// </summary>
        /// <param name="celsius">The celsius.</param>
        public static double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        /// <summary>
        /// Fahrenheit to celsius.
        /// </summary>
        /// <param name="fahrenheit">The fahrenheit.</param>
        public static double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        /// <summary>
        /// This function converts degrees to radians.
        /// </summary>
        /// <param name="degrees">An angle, measured in degrees.</param>
        public static double DegreesToRadians(double degrees)
        {
            return System.Math.PI / 180 * degrees;
        }

        /// <summary>
        /// This function converts radians to degrees.
        /// </summary>
        /// <param name="radians">An angle, measured in radians.</param>
        public static double RadiansToDegrees(double radians)
        {
            return 180 / System.Math.PI * radians;
        }

        /// <summary>
        /// Returns the specified angle in the same angle between 0 and 360.
        /// </summary>
        /// <param name="degrees">An angle, measured in degrees.</param>
        public static double EnsureDegreesAreBetween0And360(double degrees)
        {
            if (degrees >= 360)
            {
                degrees = EnsureDegreesAreBetween0And360(degrees - 360);
            }

            if (degrees < 0)
            {
                degrees = EnsureDegreesAreBetween0And360(degrees + 360);
            }

            return degrees;
        }

        /// <summary>
        /// Returns the 2 specified angles as the same 2 angles with values between 0 and 360.
        /// </summary>
        /// <param name="degrees">3 angles, measured in degrees.</param>
        public static Point2D EnsureDegreesAreBetween0And360(Point2D degrees)
        {
            if (degrees.X < 0 || degrees.X >= 360)
            {
                degrees = new Point2D(EnsureDegreesAreBetween0And360(degrees.X), degrees.Y);
            }

            if (degrees.Y < 0 || degrees.Y >= 360)
            {
                degrees = new Point2D(degrees.X, EnsureDegreesAreBetween0And360(degrees.Y));
            }

            return degrees;
        }

        /// <summary>
        /// Returns the 3 specified angles as the same 3 angles with values between 0 and 360.
        /// </summary>
        /// <param name="degrees">3 angles, measured in degrees.</param>
        public static Point3D EnsureDegreesAreBetween0And360(Point3D degrees)
        {
            if (degrees.X < 0 || degrees.X >= 360)
            {
                degrees = new Point3D(EnsureDegreesAreBetween0And360(degrees.X), degrees.Y, degrees.Z);
            }

            if (degrees.Y < 0 || degrees.Y >= 360)
            {
                degrees = new Point3D(degrees.X, EnsureDegreesAreBetween0And360(degrees.Y), degrees.Z);
            }

            if (degrees.Z < 0 || degrees.Z >= 360)
            {
                degrees = new Point3D(degrees.X, degrees.Y, EnsureDegreesAreBetween0And360(degrees.Z));
            }

            return degrees;
        }

        /// <summary>
        /// Returns the sine of the specified angle.
        /// </summary>
        /// <param name="degrees">An angle, measured in degrees.</param>
        public static double Sin(double degrees)
        {
            return System.Math.Sin(DegreesToRadians(degrees));
        }

        /// <summary>
        /// Returns the cosine of the specified angle.
        /// </summary>
        /// <param name="degrees">An angle, measured in degrees.</param>
        public static double Cos(double degrees)
        {
            return System.Math.Cos(DegreesToRadians(degrees));
        }

        /// <summary>
        /// Returns the tangent of the specified angle.
        /// </summary>
        /// <param name="degrees">An angle, measured in degrees.</param>
        public static double Tan(double degrees)
        {
            return System.Math.Tan(DegreesToRadians(degrees));
        }

        /// <summary>
        /// Returns the angle whose sine is the specified number.
        /// </summary>
        /// <param name="value">A number representing a sine, where -1 ≤d≤ 1.</param>
        public static double Asin(double value)
        {
            return RadiansToDegrees(System.Math.Asin(value));
        }

        /// <summary>
        /// Returns the angle whose cosine is the specified number.
        /// </summary>
        /// <param name="value">A number representing a cosine, where -1 ≤d≤ 1.</param>
        public static double Acos(double value)
        {
            return RadiansToDegrees(System.Math.Acos(value));
        }

        /// <summary>
        /// Returns the angle whose tangent is the specified number.
        /// </summary>
        /// <param name="value">A number representing a tangent.</param>
        public static double Atan(double value)
        {
            return RadiansToDegrees(System.Math.Atan(value));
        }

        /// <summary>
        /// Min the specified values.
        /// </summary>
        /// <param name="values">The values.</param>
        public static int Min(int[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return values.Concat(new[] { int.MaxValue }).Min();
        }

        /// <summary>
        /// Min the specified values.
        /// </summary>
        /// <param name="values">The values.</param>
        public static int Min(List<int> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return values.Concat(new[] { int.MaxValue }).Min();
        }

        /// <summary>
        /// Min the specified values.
        /// </summary>
        /// <param name="values">The values.</param>
        public static double Min(double[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return values.Concat(new double[] { int.MaxValue }).Min();
        }

        /// <summary>
        /// Min the specified values.
        /// </summary>
        /// <param name="values">The values.</param>
        public static double Min(List<double> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return values.Concat(new double[] { int.MaxValue }).Min();
        }

        /// <summary>
        /// Maxes the specified values.
        /// </summary>
        /// <param name="values">The values.</param>
        public static int Max(int[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return values.Concat(new[] { int.MinValue }).Max();
        }

        /// <summary>
        /// Maxes the specified values.
        /// </summary>
        /// <param name="values">The values.</param>
        public static int Max(List<int> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return values.Concat(new[] { int.MinValue }).Max();
        }

        /// <summary>
        /// Maxes the specified values.
        /// </summary>
        /// <param name="values">The values.</param>
        public static double Max(double[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return values.Concat(new double[] { int.MinValue }).Max();
        }

        /// <summary>
        /// Maxes the specified values.
        /// </summary>
        /// <param name="values">The values.</param>
        public static double Max(List<double> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return values.Concat(new double[] { int.MinValue }).Max();
        }

        /// <summary>
        /// Determines whether [is equal to zero] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is equal to zero] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEqualToZero(double value)
        {
            return System.Math.Abs(value) <= 0.0000001;
        }

        /// <summary>
        /// Determines whether the specified value1 is equals.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>
        ///   <c>true</c> if the specified value1 is equals; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEquals(double value1, double value2)
        {
            return value1.IsEqual(value2);
        }

        /// <summary>
        /// Truncates to maximum precision.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="decimalPrecision">The decimal precision.</param>
        public static double TruncateToMaxPrecision(double value, int decimalPrecision)
        {
            var str = value.ToString(GlobalizationConstants.EnglishCultureInfo);
            if (!str.Contains('.', StringComparison.Ordinal))
            {
                return value;
            }

            var sa = str.Split('.');
            if (sa[1].Length <= 8)
            {
                return value;
            }

            var decimals = sa[1].Substring(0, decimalPrecision);
            return double.Parse($"{sa[0]}.{decimals}", GlobalizationConstants.EnglishCultureInfo);
        }
    }
}