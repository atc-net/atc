// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the <see cref="DateTimeOffset"/> class.
/// </summary>
public static class DateTimeOffsetExtensions
{
    /// <summary>
    /// Returns true if the date time offset is between or equal to one of the two values.
    /// </summary>
    /// <param name="dateTimeOffset">DateTime Base, from where the calculation will be preformed.</param>
    /// <param name="startDate">Start date to check for.</param>
    /// <param name="endDate">End date to check for.</param>
    /// <returns>boolean value indicating if the date is between or equal to one of the two values.</returns>
    public static bool IsBetween(
        this DateTimeOffset dateTimeOffset,
        DateTimeOffset startDate,
        DateTimeOffset endDate)
    {
        var ticks = dateTimeOffset.Ticks;
        return ticks >= startDate.Ticks && ticks <= endDate.Ticks;
    }

    /// <summary>
    /// Gets the pretty time difference.
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="decimalPrecision">The decimal precision.</param>
    public static string GetPrettyTimeDiff(
        this DateTimeOffset startDate,
        int decimalPrecision = 3)
        => GetPrettyTimeDiff(startDate, DateTime.Now, decimalPrecision);

    /// <summary>
    /// Gets the pretty time difference.
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <param name="decimalPrecision">The decimal precision.</param>
    public static string GetPrettyTimeDiff(
        this DateTimeOffset startDate,
        DateTimeOffset endDate,
        int decimalPrecision = 3)
    {
        var timeSpan = new TimeSpan(endDate.Ticks - startDate.Ticks);
        return timeSpan.GetPrettyTime(decimalPrecision);
    }

    /// <summary>
    /// Gets the week number from a given date.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>The week number from the given date.</returns>
    public static int GetWeekNumber(this DateTimeOffset date)
        => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.DateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

    /// <summary>
    /// Find the diff between to DateTimes.
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <param name="howToCompare">The how to compare.</param>
    /// <returns>The number between start date and end date, depend on the DiffCompareType.</returns>
    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    public static double DateTimeDiff(
        this DateTimeOffset startDate,
        DateTimeOffset endDate,
        DateTimeDiffCompareType howToCompare)
    {
        double diff;
        try
        {
            var timeSpan = new TimeSpan(endDate.Ticks - startDate.Ticks);
            diff = howToCompare switch
            {
                DateTimeDiffCompareType.Ticks => Convert.ToDouble(timeSpan.Ticks),
                DateTimeDiffCompareType.Milliseconds => Convert.ToDouble(timeSpan.TotalMilliseconds),
                DateTimeDiffCompareType.Seconds => Convert.ToDouble(timeSpan.TotalSeconds),
                DateTimeDiffCompareType.Minutes => Convert.ToDouble(timeSpan.TotalMinutes),
                DateTimeDiffCompareType.Hours => Convert.ToDouble(timeSpan.TotalHours),
                DateTimeDiffCompareType.Days => Convert.ToDouble(timeSpan.TotalDays),
                DateTimeDiffCompareType.Year => Convert.ToDouble(timeSpan.TotalDays / 365),
                DateTimeDiffCompareType.Quartal => Convert.ToDouble(timeSpan.TotalDays / 365 / 4),
                _ => Convert.ToDouble(timeSpan.TotalDays),
            };
        }
        catch
        {
            diff = -1;
        }

        return diff;
    }

    /// <summary>
    /// Resets to start of current hour.
    /// </summary>
    /// <param name="dateTimeOffset">The date time offset.</param>
    /// <returns>The dateTimeOffset with the seconds and milliseconds as 0.</returns>
    public static DateTimeOffset ResetToStartOfCurrentHour(
        this DateTimeOffset dateTimeOffset)
        => new(
            dateTimeOffset.Year,
            dateTimeOffset.Month,
            dateTimeOffset.Day,
            dateTimeOffset.Hour,
            0,
            0,
            dateTimeOffset.Offset);

    /// <summary>
    /// Sets the hour and minutes.
    /// </summary>
    /// <param name="dateTimeOffset">The date time offset.</param>
    /// <param name="hour">The hour.</param>
    /// <param name="minutes">The minutes.</param>
    /// <returns>The dateTimeOffset with the specified hour and minutes.</returns>
    public static DateTimeOffset SetHourAndMinutes(
        this DateTimeOffset dateTimeOffset,
        int hour,
        int minutes)
        => new(
            dateTimeOffset.Year,
            dateTimeOffset.Month,
            dateTimeOffset.Day,
            hour,
            minutes,
            0,
            dateTimeOffset.Offset);

    /// <summary>Converts the DateTimeOffset to a unix time - seconds starting from 1-1-1970.</summary>
    /// <param name="dateTimeOffset">The date time offset.</param>
    /// <returns>The long value from a DateTimeOffset.</returns>
    /// <code><![CDATA[long unixTime = DateTimeOffset.ToUnixTime(value);]]></code>
    /// <example><![CDATA[
    /// DateTimeOffset dateTimeOffset = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
    /// long unixTime = dateTimeOffset.ToUnixTime();
    /// ]]></example>
    public static long ToUnixTime(this DateTimeOffset dateTimeOffset)
        => dateTimeOffset.ToUnixTimeSeconds();

    /// <summary>
    /// To the iso8601 date.
    /// </summary>
    /// <param name="dateTimeOffset">The date time offset.</param>
    public static string ToIso8601Date(this DateTimeOffset dateTimeOffset)
        => dateTimeOffset.ToString(GlobalizationConstants.DateTimeIso8601, GlobalizationConstants.EnglishCultureInfo);

    /// <summary>
    /// To the iso8601 UTC date.
    /// </summary>
    /// <param name="dateTimeOffset">The date time offset.</param>
    public static string ToIso8601UtcDate(this DateTimeOffset dateTimeOffset)
        => dateTimeOffset
            .ToUniversalTime()
            .ToString(GlobalizationConstants.DateTimeIso8601, GlobalizationConstants.EnglishCultureInfo);

    /// <summary>
    /// Converts a DateTime to a string using the long date pattern
    /// of the current UI culture.
    /// </summary>
    /// <param name="dateTimeOffset">The DateTimeOffset to format.</param>
    /// <returns>A string representation of the DateTime using the
    /// long date pattern of the current UI culture.</returns>
    public static string ToLongDateStringUsingCurrentUiCulture(
        this DateTimeOffset dateTimeOffset)
        => dateTimeOffset.ToLongDateString(CultureInfo.CurrentUICulture.DateTimeFormat);

    /// <summary>
    /// Converts a DateTime to a string using the long date pattern of the provided DateTimeFormatInfo.
    /// </summary>
    /// <param name="dateTimeOffset">The DateTimeOffset to format.</param>
    /// <param name="dateTimeFormatInfo">The DateTimeFormatInfo specifying the format to use.</param>
    /// <returns>
    /// A string representation of the DateTime using the long date pattern
    /// of the provided DateTimeFormatInfo.
    /// </returns>
    public static string ToLongDateString(
        this DateTimeOffset dateTimeOffset,
        DateTimeFormatInfo dateTimeFormatInfo)
    {
        if (dateTimeFormatInfo == null)
        {
            throw new ArgumentNullException(nameof(dateTimeFormatInfo));
        }

        return dateTimeOffset.ToString(
            dateTimeFormatInfo.LongDatePattern,
            dateTimeFormatInfo);
    }

    /// <summary>
    /// Converts a DateTime to a string using the long time pattern
    /// of the current UI culture.
    /// </summary>
    /// <param name="dateTimeOffset">The DateTimeOffset to format.</param>
    /// <returns>A string representation of the DateTime using the
    /// long time pattern of the current UI culture.</returns>
    public static string ToLongTimeStringUsingCurrentUiCulture(
        this DateTimeOffset dateTimeOffset)
        => dateTimeOffset.ToLongTimeString(CultureInfo.CurrentUICulture.DateTimeFormat);

    /// <summary>
    /// Converts a DateTime to a string using the long time pattern of the provided DateTimeFormatInfo.
    /// </summary>
    /// <param name="dateTimeOffset">The DateTimeOffset to format.</param>
    /// <param name="dateTimeFormatInfo">The DateTimeFormatInfo specifying the format to use.</param>
    /// <returns>
    /// A string representation of the DateTime using the long time pattern of the provided DateTimeFormatInfo.
    /// </returns>
    public static string ToLongTimeString(
        this DateTimeOffset dateTimeOffset,
        DateTimeFormatInfo dateTimeFormatInfo)
    {
        if (dateTimeFormatInfo == null)
        {
            throw new ArgumentNullException(nameof(dateTimeFormatInfo));
        }

        return dateTimeOffset.ToString(
            dateTimeFormatInfo.LongTimePattern,
            dateTimeFormatInfo);
    }

    /// <summary>
    /// Converts a DateTime to a string using the short date pattern
    /// of the current UI culture.
    /// </summary>
    /// <param name="dateTimeOffset">The DateTimeOffset to format.</param>
    /// <returns>A string representation of the DateTime using the
    /// short date pattern of the current UI culture.</returns>
    public static string ToShortDateStringUsingCurrentUiCulture(
        this DateTimeOffset dateTimeOffset)
        => dateTimeOffset.ToShortDateString(CultureInfo.CurrentUICulture.DateTimeFormat);

    /// <summary>
    /// Converts a <see cref="DateTimeOffset"/> to a string using the short date pattern of the specified culture.
    /// </summary>
    /// <param name="dateTimeOffset">The DateTimeOffset to format.</param>
    /// <param name="cultureInfo">The culture whose short date pattern is used.</param>
    /// <returns>A string representation of the date using the short date pattern of <paramref name="cultureInfo"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="cultureInfo"/> is null.</exception>
    public static string ToShortDateStringUsingSpecificCulture(
        this DateTimeOffset dateTimeOffset,
        CultureInfo cultureInfo)
    {
        ArgumentNullException.ThrowIfNull(cultureInfo);
        return dateTimeOffset.ToShortDateString(cultureInfo.DateTimeFormat);
    }

    /// <summary>
    /// Converts a DateTime to a string using the short date pattern of the provided DateTimeFormatInfo.
    /// </summary>
    /// <param name="dateTimeOffset">The DateTimeOffset to format.</param>
    /// <param name="dateTimeFormatInfo">The DateTimeFormatInfo specifying the format to use.</param>
    /// <returns>
    /// A string representation of the DateTime using the short date pattern of the provided DateTimeFormatInfo.
    /// </returns>
    public static string ToShortDateString(
        this DateTimeOffset dateTimeOffset,
        DateTimeFormatInfo dateTimeFormatInfo)
    {
        if (dateTimeFormatInfo == null)
        {
            throw new ArgumentNullException(nameof(dateTimeFormatInfo));
        }

        return dateTimeOffset.ToString(
            dateTimeFormatInfo.ShortDatePattern,
            dateTimeFormatInfo);
    }

    /// <summary>
    /// Converts a DateTime to a string using the short time pattern
    /// of the current UI culture.
    /// </summary>
    /// <param name="dateTimeOffset">The DateTimeOffset to format.</param>
    /// <returns>A string representation of the DateTime using the
    /// short time pattern of the current UI culture.</returns>
    public static string ToShortTimeStringUsingCurrentUiCulture(
        this DateTimeOffset dateTimeOffset)
        => dateTimeOffset.ToShortTimeString(CultureInfo.CurrentUICulture.DateTimeFormat);

    /// <summary>
    /// Converts a DateTime to a string using the short time pattern of the provided DateTimeFormatInfo.
    /// </summary>
    /// <param name="dateTimeOffset">The DateTimeOffset to format.</param>
    /// <param name="dateTimeFormatInfo">The DateTimeFormatInfo specifying the format to use.</param>
    /// <returns>
    /// A string representation of the DateTime using the short time pattern of the provided DateTimeFormatInfo.
    /// </returns>
    public static string ToShortTimeString(
        this DateTimeOffset dateTimeOffset,
        DateTimeFormatInfo dateTimeFormatInfo)
    {
        if (dateTimeFormatInfo == null)
        {
            throw new ArgumentNullException(nameof(dateTimeFormatInfo));
        }

        return dateTimeOffset.ToString(
            dateTimeFormatInfo.ShortTimePattern,
            dateTimeFormatInfo);
    }

    /// <summary>
    /// Returns a new <see cref="DateTimeOffset"/> set to the very start of the same day (00:00:00.000),
    /// preserving the original <see cref="DateTimeOffset.Offset"/>.
    /// </summary>
    /// <param name="dateTimeOffset">The date-time value.</param>
    /// <returns>Midnight at the start of the date, with the same UTC offset.</returns>
    public static DateTimeOffset StartOfDay(this DateTimeOffset dateTimeOffset)
        => new(dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day, 0, 0, 0, dateTimeOffset.Offset);

    /// <summary>
    /// Returns a new <see cref="DateTimeOffset"/> set to the very end of the same day (23:59:59.9999999),
    /// preserving the original <see cref="DateTimeOffset.Offset"/>.
    /// </summary>
    /// <param name="dateTimeOffset">The date-time value.</param>
    /// <returns>The last representable tick of the date, with the same UTC offset.</returns>
    public static DateTimeOffset EndOfDay(this DateTimeOffset dateTimeOffset)
        => new DateTimeOffset(dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day, 0, 0, 0, dateTimeOffset.Offset)
            .AddDays(1)
            .AddTicks(-1);

    /// <summary>
    /// Returns a new <see cref="DateTimeOffset"/> set to the first day of the same month at midnight,
    /// preserving the original <see cref="DateTimeOffset.Offset"/>.
    /// </summary>
    /// <param name="dateTimeOffset">The date-time value.</param>
    /// <returns>The first day of the month, with the same UTC offset.</returns>
    public static DateTimeOffset StartOfMonth(
        this DateTimeOffset dateTimeOffset)
        => new(dateTimeOffset.Year, dateTimeOffset.Month, 1, 0, 0, 0, dateTimeOffset.Offset);

    /// <summary>
    /// Returns a new <see cref="DateTimeOffset"/> set to the last tick of the last day of the same month,
    /// preserving the original <see cref="DateTimeOffset.Offset"/>.
    /// </summary>
    /// <param name="dateTimeOffset">The date-time value.</param>
    /// <returns>The last representable tick of the month, with the same UTC offset.</returns>
    public static DateTimeOffset EndOfMonth(this DateTimeOffset dateTimeOffset)
        => new DateTimeOffset(dateTimeOffset.Year, dateTimeOffset.Month, DateTime.DaysInMonth(dateTimeOffset.Year, dateTimeOffset.Month), 0, 0, 0, dateTimeOffset.Offset)
            .AddDays(1)
            .AddTicks(-1);

    /// <summary>
    /// Determines whether the date falls on a Saturday or Sunday.
    /// </summary>
    /// <param name="dateTimeOffset">The date to test.</param>
    /// <returns><see langword="true"/> if the day of week is <see cref="DayOfWeek.Saturday"/> or <see cref="DayOfWeek.Sunday"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsWeekend(this DateTimeOffset dateTimeOffset)
        => dateTimeOffset.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
}