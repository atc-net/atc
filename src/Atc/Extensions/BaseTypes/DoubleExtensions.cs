// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the <see cref="double"/> class.
/// </summary>
public static class DoubleExtensions
{
    /// <summary>
    /// The double epsilon.
    /// </summary>
    public const double DoubleEpsilon = double.Epsilon;

    /// <summary>
    /// Compare two values. Return <see langword="true" /> if they are equals.
    /// </summary>
    /// <param name="a">The first value.</param>
    /// <param name="b">The second value.</param>
    /// <returns>
    /// <see langword="true" /> if the two values are equals, <see langword="false" /> otherwise.
    /// </returns>
    public static bool IsEqual(this double a, double b)
    {
        return Math.Abs(a - b) < double.Epsilon;
    }

    /// <summary>
    /// Compare two values. Return <see langword="true" /> if they are equals.
    /// </summary>
    /// <param name="a">The first value.</param>
    /// <param name="b">The second value.</param>
    /// <returns>
    /// <see langword="true" /> if the two values are equals, <see langword="false" /> otherwise.
    /// </returns>
    public static bool IsEqual(this double? a, double? b)
    {
        if (a is null || b is null)
        {
            return a is null && b is null;
        }

        return IsEqual((double)a, (double)b);
    }

    /// <summary>
    /// Compares two double values for equality with a specified precision.
    /// </summary>
    /// <param name="a">The first double value.</param>
    /// <param name="b">The second double value.</param>
    /// <param name="decimalPrecision">The number of decimal places to consider for comparison.</param>
    /// <returns><see langword="true"/> if the values are equal up to the specified precision; otherwise, <see langword="false"/>.</returns>
    public static bool IsEqual(this double a, double b, int decimalPrecision)
    {
        return ((decimal)a).IsEqual((decimal)b, decimalPrecision);
    }

    /// <summary>
    /// Compares two nullable double values for equality with a specified precision.
    /// </summary>
    /// <param name="a">The first nullable double value.</param>
    /// <param name="b">The second nullable double value.</param>
    /// <param name="decimalPrecision">The number of decimal places to consider for comparison.</param>
    /// <returns><see langword="true"/> if both values are null or equal up to the specified precision; otherwise, <see langword="false"/>.</returns>
    public static bool IsEqual(this double? a, double? b, int decimalPrecision)
    {
        if (a is null || b is null)
        {
            return a is null && b is null;
        }

        return ((decimal)a).IsEqual((decimal)b, decimalPrecision);
    }

    /// <summary>
    /// Determines whether two double values are approximately equal within a calculated tolerance.
    /// </summary>
    /// <param name="value1">The first value to compare.</param>
    /// <param name="value2">The second value to compare.</param>
    /// <returns><see langword="true"/> if the values are within a calculated tolerance of each other; otherwise, <see langword="false"/>.</returns>
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
    /// Determines whether the first value is greater than or approximately equal to the second value.
    /// </summary>
    /// <param name="value1">The first value to compare.</param>
    /// <param name="value2">The second value to compare.</param>
    /// <returns><see langword="true"/> if value1 is greater than value2 or approximately equal; otherwise, <see langword="false"/>.</returns>
    public static bool GreaterThanOrClose(this double value1, double value2)
    {
        return (value1 > value2) || AreClose(value1, value2);
    }

    /// <summary>
    /// Determines whether the specified double value is approximately zero.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns><see langword="true"/> if the absolute value is less than epsilon; otherwise, <see langword="false"/>.</returns>
    public static bool IsZero(this double value)
    {
        return Math.Abs(value) < DoubleEpsilon;
    }

    /// <summary>
    /// Rounds a double value using currency rounding rules and returns it as an integer.
    /// </summary>
    /// <param name="value">The double value to round.</param>
    /// <returns>The rounded value as an integer.</returns>
    public static int CurrencyRoundingAsInteger(this double value)
    {
        return (int)CurrencyRounding(value, 0);
    }

    /// <summary>
    /// Rounds a double value using the currency decimal digits of the current UI culture.
    /// </summary>
    /// <param name="value">The double value to round.</param>
    /// <returns>The rounded double value.</returns>
    public static double CurrencyRounding(this double value)
    {
        return CurrencyRounding(value, Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyDecimalDigits);
    }

    /// <summary>
    /// Rounds a double value to a specified number of decimal digits using midpoint rounding away from zero.
    /// </summary>
    /// <param name="value">The double value to round.</param>
    /// <param name="digits">The number of decimal digits to round to (negative values are treated as 0).</param>
    /// <returns>The rounded double value.</returns>
    public static double CurrencyRounding(this double value, int digits)
    {
        if (digits < 0)
        {
            digits = 0;
        }

        return Math.Round(value, digits, MidpointRounding.AwayFromZero);
    }

    /// <summary>
    /// Rounds a double value to 2 decimal places.
    /// </summary>
    /// <param name="value">The double value to round.</param>
    /// <returns>The value rounded to 2 decimal places.</returns>
    public static double RoundOff2(this double value)
    {
        return RoundOff(value, 2);
    }

    /// <summary>
    /// Rounds a double value to 10 decimal places.
    /// </summary>
    /// <param name="value">The double value to round.</param>
    /// <returns>The value rounded to 10 decimal places.</returns>
    public static double RoundOff10(this double value)
    {
        return RoundOff(value, 10);
    }

    /// <summary>
    /// Rounds a double value to a specified number of decimal places.
    /// </summary>
    /// <param name="value">The double value to round.</param>
    /// <param name="numberOfDecimals">The number of decimal places to round to.</param>
    /// <returns>The rounded double value.</returns>
    public static double RoundOff(this double value, int numberOfDecimals)
    {
        return Math.Round(value, numberOfDecimals);
    }

    /// <summary>
    /// Rounds a percentage value to 2 decimal places.
    /// </summary>
    /// <param name="percent">The percentage value to round.</param>
    /// <returns>The percentage value rounded to 2 decimal places.</returns>
    public static double RoundOffPercent(this double percent)
    {
        return RoundOff(percent, 2);
    }

    /// <summary>
    /// Counts the number of decimal places in the double value.
    /// </summary>
    /// <param name="value">The double value to analyze.</param>
    /// <returns>The number of decimal places in the value.</returns>
    public static int CountDecimalPoints(this double value)
    {
        var precision = 0;

        while (Math.Abs((value * Math.Pow(10, precision)) - Math.Round(value * Math.Pow(10, precision))) > double.Epsilon)
        {
            precision++;
        }

        return precision;
    }
}