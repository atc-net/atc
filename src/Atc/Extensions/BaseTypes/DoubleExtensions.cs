using System.Threading;

// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    /// Extensions for the <see cref="double"/> class.
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// The double epsilon.
        /// </summary>
        public const double DoubleEpsilon = 2.2204460492503131E-15;

        /// <summary>
        /// Compare two values. Return <c>true</c> if they are equals.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <returns>
        /// <c>true</c> if the two values are equals, <c>false</c> otherwise.
        /// </returns>
        public static bool IsEqual(this double a, double b)
        {
            return Math.Abs(a - b) < double.Epsilon;
        }

        /// <summary>
        /// Compare two values. Return <c>true</c> if they are equals.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <returns>
        /// <c>true</c> if the two values are equals, <c>false</c> otherwise.
        /// </returns>
        public static bool IsEqual(this double? a, double? b)
        {
            if (a == null || b == null)
            {
                return a == null && b == null;
            }

            return IsEqual((double)a, (double)b);
        }

        /// <summary>
        /// Determines whether the specified b is equal.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="decimalPrecision">The decimal precision.</param>
        /// <returns>
        ///   <c>true</c> if the specified b is equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEqual(this double a, double b, int decimalPrecision)
        {
            return ((decimal)a).IsEqual((decimal)b, decimalPrecision);
        }

        /// <summary>
        /// Determines whether the specified a is equal.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="decimalPrecision">The decimal precision.</param>
        public static bool IsEqual(this double? a, double? b, int decimalPrecision)
        {
            if (a == null || b == null)
            {
                return a == null && b == null;
            }

            return ((decimal)a).IsEqual((decimal)b, decimalPrecision);
        }

        /// <summary>
        /// Ares the close.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        public static bool AreClose(this double value1, double value2)
        {
            if (value1.IsEqual(value2))
            {
                return true;
            }

            var num1 = (Math.Abs(value1) + Math.Abs(value2) + 10.0) * DoubleEpsilon / 10;
            var num2 = value1 - value2;
            return -num1 < num2 && num1 > num2;
        }

        /// <summary>
        /// Greater the than or close.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        public static bool GreaterThanOrClose(this double value1, double value2)
        {
            return (value1 > value2) || AreClose(value1, value2);
        }

        /// <summary>
        /// Determines whether the specified value is zero.
        /// </summary>
        /// <param name="value">The value.</param>
        public static bool IsZero(this double value)
        {
            return Math.Abs(value) < DoubleEpsilon;
        }

        /// <summary>
        /// Currencies the rounding as integer.
        /// </summary>
        /// <param name="value">The value.</param>
        public static int CurrencyRoundingAsInteger(this double value)
        {
            return (int)CurrencyRounding(value, 0);
        }

        /// <summary>
        /// Currencies the rounding.
        /// </summary>
        /// <param name="value">The value.</param>
        public static double CurrencyRounding(this double value)
        {
            return CurrencyRounding(value, Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyDecimalDigits);
        }

        /// <summary>
        /// Currencies the rounding.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="digits">The digits.</param>
        public static double CurrencyRounding(this double value, int digits)
        {
            if (digits < 0)
            {
                digits = 0;
            }

            return Math.Round(value, digits, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Rounds the off2.
        /// </summary>
        /// <param name="value">The value.</param>
        public static double RoundOff2(this double value)
        {
            return RoundOff(value, 2);
        }

        /// <summary>
        /// Rounds the off10.
        /// </summary>
        /// <param name="value">The value.</param>
        public static double RoundOff10(this double value)
        {
            return RoundOff(value, 10);
        }

        /// <summary>
        /// Rounds the off.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="numberOfDecimals">The number of decimals.</param>
        public static double RoundOff(this double value, int numberOfDecimals)
        {
            return Math.Round(value, numberOfDecimals);
        }

        /// <summary>
        /// Rounds the off percent.
        /// </summary>
        /// <param name="percent">The percent.</param>
        public static double RoundOffPercent(this double percent)
        {
            return RoundOff(percent, 2);
        }

        /// <summary>
        /// Returns the numbers of decimal points in the value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static int CountDecimalPoints(this double value)
        {
            var precision = 0;

            while (value * Math.Pow(10, precision) != Math.Round(value * Math.Pow(10, precision)))
            {
                precision++;
            }

            return precision;
        }
    }
}