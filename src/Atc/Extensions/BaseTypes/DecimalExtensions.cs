// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the <see cref="decimal"/> class.
/// </summary>
public static class DecimalExtensions
{
    /// <summary>
    /// Compare two values. Return <see langword="true" /> if they are equals.
    /// </summary>
    /// <param name="a">The first value.</param>
    /// <param name="b">The second value.</param>
    /// <returns>
    /// <see langword="true" /> if the two values are equals, <see langword="false" /> otherwise.
    /// </returns>
    public static bool IsEqual(
        this decimal a,
        decimal b)
        => decimal.Equals(a, b);

    /// <summary>
    /// Compare two values. Return <see langword="true" /> if they are equals.
    /// </summary>
    /// <param name="a">The first value.</param>
    /// <param name="b">The second value.</param>
    /// <returns>
    /// <see langword="true" /> if the two values are equals, <see langword="false" /> otherwise.
    /// </returns>
    public static bool IsEqual(
        this decimal? a,
        decimal? b)
    {
        if (a is null || b is null)
        {
            return a is null && b is null;
        }

        return ((decimal)a).IsEqual((decimal)b);
    }

    /// <summary>
    /// Compares two decimal values for equality with a specified precision.
    /// </summary>
    /// <param name="a">The first decimal value.</param>
    /// <param name="b">The second decimal value.</param>
    /// <param name="decimalPrecision">The number of decimal places to consider for comparison.</param>
    /// <returns><see langword="true"/> if the values are equal up to the specified precision; otherwise, <see langword="false"/>.</returns>
    public static bool IsEqual(
        this decimal a,
        decimal b,
        int decimalPrecision)
    {
        var sa = a
            .ToString(CultureInfo.InvariantCulture)
            .Replace(',', '.');

        var sb = b
            .ToString(CultureInfo.InvariantCulture)
            .Replace(',', '.');

        var saa = sa.Split('.');
        var sab = sb.Split('.');

        var sad = string.Empty;
        if (saa.Length == 2)
        {
            sad = saa[1];
            if (saa[1].Length > decimalPrecision)
            {
                sad = saa[1][..decimalPrecision];
            }
        }

        var sbd = string.Empty;
        if (sab.Length == 2)
        {
            sbd = sab[1];
            if (sab[1].Length > decimalPrecision)
            {
                sbd = sab[1][..decimalPrecision];
            }
        }

        sa = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", saa[0], sad);
        while (sa.EndsWith('0'))
        {
            sa = sa[..^1];
        }

        sb = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", sab[0], sbd);
        while (sb.EndsWith('0'))
        {
            sb = sb[..^1];
        }

        return sa.Equals(sb, StringComparison.Ordinal);
    }

    /// <summary>
    /// Compares two nullable decimal values for equality with a specified precision.
    /// </summary>
    /// <param name="a">The first nullable decimal value.</param>
    /// <param name="b">The second nullable decimal value.</param>
    /// <param name="decimalPrecision">The number of decimal places to consider for comparison.</param>
    /// <returns><see langword="true"/> if both values are null or equal up to the specified precision; otherwise, <see langword="false"/>.</returns>
    public static bool IsEqual(
        this decimal? a,
        decimal? b,
        int decimalPrecision)
    {
        if (a is null || b is null)
        {
            return a is null && b is null;
        }

        return IsEqual((decimal)a, (decimal)b, decimalPrecision);
    }

    /// <summary>
    /// Rounds a decimal value using currency rounding rules and returns it as an integer.
    /// </summary>
    /// <param name="value">The decimal value to round.</param>
    /// <returns>The rounded value as an integer.</returns>
    public static int CurrencyRoundingAsInteger(this decimal value)
        => (int)CurrencyRounding(value, 0);

    /// <summary>
    /// Rounds a decimal value using the currency decimal digits of the current UI culture.
    /// </summary>
    /// <param name="value">The decimal value to round.</param>
    /// <returns>The rounded decimal value.</returns>
    public static decimal CurrencyRounding(this decimal value)
        => CurrencyRounding(value, Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyDecimalDigits);

    /// <summary>
    /// Rounds a decimal value to a specified number of decimal digits using midpoint rounding away from zero.
    /// </summary>
    /// <param name="value">The decimal value to round.</param>
    /// <param name="digits">The number of decimal digits to round to (negative values are treated as 0).</param>
    /// <returns>The rounded decimal value.</returns>
    public static decimal CurrencyRounding(
        this decimal value,
        int digits)
    {
        if (digits < 0)
        {
            digits = 0;
        }

        return Math.Round(value, digits, MidpointRounding.AwayFromZero);
    }

    /// <summary>
    /// Rounds a decimal value to 2 decimal places.
    /// </summary>
    /// <param name="value">The decimal value to round.</param>
    /// <returns>The value rounded to 2 decimal places.</returns>
    public static decimal RoundOff2(this decimal value)
        => RoundOff(value, 2);

    /// <summary>
    /// Rounds a decimal value to 10 decimal places.
    /// </summary>
    /// <param name="value">The decimal value to round.</param>
    /// <returns>The value rounded to 10 decimal places.</returns>
    public static decimal RoundOff10(this decimal value)
        => RoundOff(value, 10);

    /// <summary>
    /// Rounds a decimal value to a specified number of decimal places.
    /// </summary>
    /// <param name="value">The decimal value to round.</param>
    /// <param name="numberOfDecimals">The number of decimal places to round to.</param>
    /// <returns>The rounded decimal value.</returns>
    public static decimal RoundOff(
        this decimal value,
        int numberOfDecimals)
        => Math.Round(value, numberOfDecimals);

    /// <summary>
    /// Rounds a percentage value to 2 decimal places.
    /// </summary>
    /// <param name="percent">The percentage value to round.</param>
    /// <returns>The percentage value rounded to 2 decimal places.</returns>
    public static decimal RoundOffPercent(this decimal percent)
        => RoundOff(percent, 2);
}