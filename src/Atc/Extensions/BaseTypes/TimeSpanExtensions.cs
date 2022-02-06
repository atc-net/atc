// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the <see cref="TimeSpan"/> class.
/// </summary>
public static class TimeSpanExtensions
{
    /// <summary>
    /// Minimums the specified t1.
    /// </summary>
    /// <param name="t1">The t1.</param>
    /// <param name="t2">The t2.</param>
    public static TimeSpan Min(this TimeSpan t1, TimeSpan t2)
    {
        return t1 < t2 ? t1 : t2;
    }

    /// <summary>
    /// Maximums the specified t1.
    /// </summary>
    /// <param name="t1">The t1.</param>
    /// <param name="t2">The t2.</param>
    public static TimeSpan Max(this TimeSpan t1, TimeSpan t2)
    {
        return t1 > t2 ? t1 : t2;
    }

    /// <summary>
    /// Removes the millisecond part of the timeSpan.
    /// </summary>
    /// <param name="timeSpan">The timeSpan.</param>
    public static TimeSpan RemoveMilliseconds(this TimeSpan timeSpan)
    {
        return timeSpan.Subtract(TimeSpan.FromMilliseconds(timeSpan.Milliseconds));
    }

    /// <summary>
    /// Determines whether the seconds part of the datetime is zero.
    /// </summary>
    /// <param name="timeSpan">The timeSpan.</param>
    /// <returns>
    ///   <c>true</c> if [is seconds is zero] otherwise, <c>false</c>.
    /// </returns>
    public static bool SecondsNotZero(this TimeSpan timeSpan)
    {
        return timeSpan.TotalSeconds > 0;
    }

    /// <summary>
    /// Gets the pretty time.
    /// </summary>
    /// <param name="timeSpan">The timeSpan.</param>
    /// <param name="decimalPrecision">The decimal precision.</param>
    [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "OK.")]
    public static string GetPrettyTime(this TimeSpan timeSpan, int decimalPrecision = 3)
    {
        if ((int)timeSpan.TotalDays > 0)
        {
            return $"{timeSpan.TotalDays.ToString("N" + decimalPrecision, Thread.CurrentThread.CurrentUICulture)} days";
        }

        if ((int)timeSpan.TotalHours > 0)
        {
            return $"{timeSpan.TotalHours.ToString("N" + decimalPrecision, Thread.CurrentThread.CurrentUICulture)} hours";
        }

        if ((int)timeSpan.TotalMinutes > 0)
        {
            return $"{timeSpan.TotalMinutes.ToString("N" + decimalPrecision, Thread.CurrentThread.CurrentUICulture)} min";
        }

        // ReSharper disable once ConvertIfStatementToReturnStatement
        if ((int)timeSpan.TotalSeconds > 0)
        {
            return $"{timeSpan.TotalSeconds.ToString("N" + decimalPrecision, Thread.CurrentThread.CurrentUICulture)} sec";
        }

        return $"{timeSpan.TotalMilliseconds.ToString("N" + decimalPrecision, Thread.CurrentThread.CurrentUICulture)} ms";
    }
}