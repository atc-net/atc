using System.Globalization;
using System.Threading;

// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    /// Extensions for the <see cref="decimal"/> class.
    /// </summary>
    public static class DecimalExtensions
    {
        /// <summary>
        /// Compare two values. Return <c>true</c> if they are equals.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <returns>
        /// <c>true</c> if the two values are equals, <c>false</c> otherwise.
        /// </returns>
        public static bool IsEqual(this decimal a, decimal b)
        {
            return ((double)a).IsEqual((double)b);
        }

        /// <summary>
        /// Compare two values. Return <c>true</c> if they are equals.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <returns>
        /// <c>true</c> if the two values are equals, <c>false</c> otherwise.
        /// </returns>
        public static bool IsEqual(this decimal? a, decimal? b)
        {
            if (a == null || b == null)
            {
                return a == null && b == null;
            }

            return ((double)a).IsEqual((double)b);
        }

        /// <summary>
        /// Determines whether the specified a is equal.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="decimalPrecision">The decimal precision.</param>
        public static bool IsEqual(this decimal a, decimal b, int decimalPrecision)
        {
            var sa = a.ToString(CultureInfo.InvariantCulture).Replace(',', '.');
            var sb = b.ToString(CultureInfo.InvariantCulture).Replace(',', '.');

            var saa = sa.Split('.');
            var sab = sb.Split('.');

            var sad = string.Empty;
            if (saa.Length == 2)
            {
                sad = saa[1];
                if (saa[1].Length > decimalPrecision)
                {
                    sad = saa[1].Substring(0, decimalPrecision);
                }
            }

            var sbd = string.Empty;
            if (sab.Length == 2)
            {
                sbd = sab[1];
                if (sab[1].Length > decimalPrecision)
                {
                    sbd = sab[1].Substring(0, decimalPrecision);
                }
            }

            sa = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", saa[0], sad);
            while (sa.EndsWith("0", StringComparison.Ordinal))
            {
                sa = sa.Substring(0, sa.Length - 1);
            }

            sb = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", sab[0], sbd);
            while (sb.EndsWith("0", StringComparison.Ordinal))
            {
                sb = sb.Substring(0, sb.Length - 1);
            }

            return sa.Equals(sb, StringComparison.Ordinal);
        }

        /// <summary>
        /// Determines whether the specified a is equal.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="decimalPrecision">The decimal precision.</param>
        public static bool IsEqual(this decimal? a, decimal? b, int decimalPrecision)
        {
            if (a == null || b == null)
            {
                return a == null && b == null;
            }

            return IsEqual((decimal)a, (decimal)b, decimalPrecision);
        }

        /// <summary>
        /// Currencies the rounding as integer.
        /// </summary>
        /// <param name="value">The value.</param>
        public static int CurrencyRoundingAsInteger(this decimal value)
        {
            return (int)CurrencyRounding(value, 0);
        }

        /// <summary>
        /// Currencies the rounding.
        /// </summary>
        /// <param name="value">The value.</param>
        public static decimal CurrencyRounding(this decimal value)
        {
            return CurrencyRounding(value, Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyDecimalDigits);
        }

        /// <summary>
        /// Currencies the rounding.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="digits">The digits.</param>
        public static decimal CurrencyRounding(this decimal value, int digits)
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
        public static decimal RoundOff2(this decimal value)
        {
            return RoundOff(value, 2);
        }

        /// <summary>
        /// Rounds the off10.
        /// </summary>
        /// <param name="value">The value.</param>
        public static decimal RoundOff10(this decimal value)
        {
            return RoundOff(value, 10);
        }

        /// <summary>
        /// Rounds the off.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="numberOfDecimals">The number of decimals.</param>
        public static decimal RoundOff(this decimal value, int numberOfDecimals)
        {
            return Math.Round(value, numberOfDecimals);
        }

        /// <summary>
        /// Rounds the off percent.
        /// </summary>
        /// <param name="percent">The percent.</param>
        public static decimal RoundOffPercent(this decimal percent)
        {
            return RoundOff(percent, 2);
        }
    }
}