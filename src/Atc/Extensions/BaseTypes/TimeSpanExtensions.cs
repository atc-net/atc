// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the <see cref="TimeSpan"/> class.
/// </summary>
public static class TimeSpanExtensions
{
    /// <summary>
    /// Returns the smaller of two TimeSpan values.
    /// </summary>
    /// <param name="t1">The first TimeSpan to compare.</param>
    /// <param name="t2">The second TimeSpan to compare.</param>
    /// <returns>The smaller of the two TimeSpan values.</returns>
    public static TimeSpan Min(
        this TimeSpan t1,
        TimeSpan t2)
        => t1 < t2
            ? t1
            : t2;

    /// <summary>
    /// Returns the larger of two TimeSpan values.
    /// </summary>
    /// <param name="t1">The first TimeSpan to compare.</param>
    /// <param name="t2">The second TimeSpan to compare.</param>
    /// <returns>The larger of the two TimeSpan values.</returns>
    public static TimeSpan Max(
        this TimeSpan t1,
        TimeSpan t2)
        => t1 > t2
            ? t1
            : t2;

    /// <summary>
    /// Removes the millisecond component from the TimeSpan.
    /// </summary>
    /// <param name="timeSpan">The TimeSpan to modify.</param>
    /// <returns>A TimeSpan with the milliseconds set to zero.</returns>
    public static TimeSpan RemoveMilliseconds(this TimeSpan timeSpan)
        => timeSpan.Subtract(TimeSpan.FromMilliseconds(timeSpan.Milliseconds));

    /// <summary>
    /// Determines whether the total seconds of the TimeSpan is greater than zero.
    /// </summary>
    /// <param name="timeSpan">The TimeSpan to check.</param>
    /// <returns><see langword="true"/> if the total seconds is greater than zero; otherwise, <see langword="false"/>.</returns>
    public static bool SecondsNotZero(this TimeSpan timeSpan)
        => timeSpan.TotalSeconds > 0;

    /// <summary>
    /// Converts a TimeSpan to a human-readable string representation with appropriate time units.
    /// </summary>
    /// <param name="timeSpan">The TimeSpan to format.</param>
    /// <param name="decimalPrecision">The number of decimal places to display (default is 3).</param>
    /// <returns>A formatted string representing the time in the most appropriate unit (days, hours, minutes, seconds, or milliseconds).</returns>
    [SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "OK.")]
    public static string GetPrettyTime(
        this TimeSpan timeSpan,
        int decimalPrecision = 3)
    {
        if ((int)timeSpan.TotalDays > 0)
        {
            return $"{timeSpan.TotalDays.ToString("N" + decimalPrecision, CultureInfo.CurrentCulture)} " +
                   $"{DateAndTime.Days.ToLower(CultureInfo.CurrentCulture)}";
        }

        if ((int)timeSpan.TotalHours > 0)
        {
            return $"{timeSpan.TotalHours.ToString("N" + decimalPrecision, CultureInfo.CurrentCulture)} " +
                   $"{DateAndTime.Hours.ToLower(CultureInfo.CurrentCulture)}";
        }

        if ((int)timeSpan.TotalMinutes > 0)
        {
            return $"{timeSpan.TotalMinutes.ToString("N" + decimalPrecision, CultureInfo.CurrentCulture)} " +
                   $"{DateAndTime.MinuteAsAbbreviation.ToLower(CultureInfo.CurrentCulture)}";
        }

        // ReSharper disable once ConvertIfStatementToReturnStatement
        if ((int)timeSpan.TotalSeconds > 0)
        {
            return $"{timeSpan.TotalSeconds.ToString("N" + decimalPrecision, CultureInfo.CurrentCulture)} " +
                   $"{DateAndTime.SecondAsAbbreviation.ToLower(CultureInfo.CurrentCulture)}";
        }

        return $"{timeSpan.TotalMilliseconds.ToString("N" + decimalPrecision, CultureInfo.CurrentCulture)} " +
               $"{DateAndTime.MillisecondAsAbbreviation1.ToLower(CultureInfo.CurrentCulture)}";
    }

    /// <summary>
    /// Converts a TimeSpan to a human-readable string representation with appropriate time units,
    /// using the current UI culture for number formatting and unit label casing.
    /// Use this variant when rendering output for display in a user interface.
    /// </summary>
    /// <param name="timeSpan">The TimeSpan to format.</param>
    /// <param name="decimalPrecision">The number of decimal places to display (default is 3).</param>
    /// <returns>A formatted string representing the time in the most appropriate unit (days, hours, minutes, seconds, or milliseconds).</returns>
    [SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "OK.")]
    public static string GetPrettyTimeUi(
        this TimeSpan timeSpan,
        int decimalPrecision = 3)
    {
        if ((int)timeSpan.TotalDays > 0)
        {
            return $"{timeSpan.TotalDays.ToString("N" + decimalPrecision, CultureInfo.CurrentUICulture)} " +
                   $"{DateAndTime.Days.ToLower(CultureInfo.CurrentUICulture)}";
        }

        if ((int)timeSpan.TotalHours > 0)
        {
            return $"{timeSpan.TotalHours.ToString("N" + decimalPrecision, CultureInfo.CurrentUICulture)} " +
                   $"{DateAndTime.Hours.ToLower(CultureInfo.CurrentUICulture)}";
        }

        if ((int)timeSpan.TotalMinutes > 0)
        {
            return $"{timeSpan.TotalMinutes.ToString("N" + decimalPrecision, CultureInfo.CurrentUICulture)} " +
                   $"{DateAndTime.MinuteAsAbbreviation.ToLower(CultureInfo.CurrentUICulture)}";
        }

        // ReSharper disable once ConvertIfStatementToReturnStatement
        if ((int)timeSpan.TotalSeconds > 0)
        {
            return $"{timeSpan.TotalSeconds.ToString("N" + decimalPrecision, CultureInfo.CurrentUICulture)} " +
                   $"{DateAndTime.SecondAsAbbreviation.ToLower(CultureInfo.CurrentUICulture)}";
        }

        return $"{timeSpan.TotalMilliseconds.ToString("N" + decimalPrecision, CultureInfo.CurrentUICulture)} " +
               $"{DateAndTime.MillisecondAsAbbreviation1.ToLower(CultureInfo.CurrentUICulture)}";
    }
}