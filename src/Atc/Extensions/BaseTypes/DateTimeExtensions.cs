// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the <see cref="DateTime"/> class.
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Returns true if the date is between or equal to one of the two values.
    /// </summary>
    /// <param name="date">DateTime Base, from where the calculation will be preformed.</param>
    /// <param name="startDate">Start date to check for.</param>
    /// <param name="endDate">End date to check for.</param>
    /// <returns>boolean value indicating if the date is between or equal to one of the two values.</returns>
    public static bool IsBetween(
        this DateTime date,
        DateTime startDate,
        DateTime endDate)
    {
        var ticks = date.Ticks;
        return ticks >= startDate.Ticks && ticks <= endDate.Ticks;
    }

    /// <summary>
    /// Gets the pretty time difference.
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="decimalPrecision">The decimal precision.</param>
    public static string GetPrettyTimeDiff(
        this DateTime startDate,
        int decimalPrecision = 3)
        => GetPrettyTimeDiff(startDate, DateTime.Now, decimalPrecision);

    /// <summary>
    /// Gets the pretty time difference.
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <param name="decimalPrecision">The decimal precision.</param>
    public static string GetPrettyTimeDiff(
        this DateTime startDate,
        DateTime endDate,
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
    public static int GetWeekNumber(this DateTime date)
        => CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

    /// <summary>
    /// Find the diff between to DateTimes.
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <param name="howToCompare">The how to compare.</param>
    /// <returns>The number between start date and end date, depend on the DiffCompareType.</returns>
    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    public static double DateTimeDiff(
        this DateTime startDate,
        DateTime endDate,
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
    /// To the iso8601 date.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <example>
    /// string isoDate = DateTime.UtcNow.ToIso8601Date();.
    /// </example>
    public static string ToIso8601Date(this DateTime dateTime)
        => dateTime.ToString(GlobalizationConstants.DateTimeIso8601, GlobalizationConstants.EnglishCultureInfo);

    /// <summary>
    /// To the iso8601 UTC date.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    public static string ToIso8601UtcDate(this DateTime dateTime)
        => dateTime
            .ToUniversalTime()
            .ToString(GlobalizationConstants.DateTimeIso8601, GlobalizationConstants.EnglishCultureInfo);

    /// <summary>
    /// Converts a DateTime to a string using the long date pattern
    /// of the current UI culture.
    /// </summary>
    /// <param name="dateTime">The DateTime to format.</param>
    /// <returns>A string representation of the DateTime using the
    /// long date pattern of the current UI culture.</returns>
    public static string ToLongDateStringUsingCurrentUiCulture(
        this DateTime dateTime)
        => dateTime.ToLongDateString(Thread.CurrentThread.CurrentUICulture.DateTimeFormat);

    /// <summary>
    /// Converts a DateTime to a string using the long date pattern of a specific culture.
    /// </summary>
    /// <param name="dateTime">The DateTime to format.</param>
    /// <param name="cultureInfo">The culture whose date format to use.</param>
    /// <returns>A string representation of the DateTime using the long date pattern of the specified culture.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="cultureInfo"/> is null.</exception>
    public static string ToLongDateStringUsingSpecificCulture(
        this DateTime dateTime,
        CultureInfo cultureInfo)
    {
        if (cultureInfo is null)
        {
            throw new ArgumentNullException(nameof(cultureInfo));
        }

        return dateTime.ToLongDateString(cultureInfo.DateTimeFormat);
    }

    /// <summary>
    /// Converts a DateTime to a string using the long date pattern of the provided DateTimeFormatInfo.
    /// </summary>
    /// <param name="dateTime">The DateTime to format.</param>
    /// <param name="dateTimeFormatInfo">The DateTimeFormatInfo specifying the format to use.</param>
    /// <returns>
    /// A string representation of the DateTime using the long date pattern
    /// of the provided DateTimeFormatInfo.
    /// </returns>
    public static string ToLongDateString(
        this DateTime dateTime,
        DateTimeFormatInfo dateTimeFormatInfo)
    {
        if (dateTimeFormatInfo == null)
        {
            throw new ArgumentNullException(nameof(dateTimeFormatInfo));
        }

        return dateTime.ToString(
            dateTimeFormatInfo.LongDatePattern,
            dateTimeFormatInfo);
    }

    /// <summary>
    /// Converts a DateTime to a string using the long time pattern
    /// of the current UI culture.
    /// </summary>
    /// <param name="dateTime">The DateTime to format.</param>
    /// <returns>A string representation of the DateTime using the
    /// long time pattern of the current UI culture.</returns>
    public static string ToLongTimeStringUsingCurrentUiCulture(
        this DateTime dateTime)
        => dateTime.ToLongTimeString(Thread.CurrentThread.CurrentUICulture.DateTimeFormat);

    /// <summary>
    /// Converts a DateTime to a string using the long time pattern of a specific culture.
    /// </summary>
    /// <param name="dateTime">The DateTime to format.</param>
    /// <param name="cultureInfo">The culture whose time format to use.</param>
    /// <returns>A string representation of the DateTime using the long time pattern of the specified culture.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="cultureInfo"/> is null.</exception>
    public static string ToLongTimeStringUsingSpecificCulture(
        this DateTime dateTime,
        CultureInfo cultureInfo)
    {
        if (cultureInfo is null)
        {
            throw new ArgumentNullException(nameof(cultureInfo));
        }

        return dateTime.ToLongTimeString(cultureInfo.DateTimeFormat);
    }

    /// <summary>
    /// Converts a DateTime to a string using the long time pattern of the provided DateTimeFormatInfo.
    /// </summary>
    /// <param name="dateTime">The DateTime to format.</param>
    /// <param name="dateTimeFormatInfo">The DateTimeFormatInfo specifying the format to use.</param>
    /// <returns>
    /// A string representation of the DateTime using the long time pattern of the provided DateTimeFormatInfo.
    /// </returns>
    public static string ToLongTimeString(
        this DateTime dateTime,
        DateTimeFormatInfo dateTimeFormatInfo)
    {
        if (dateTimeFormatInfo == null)
        {
            throw new ArgumentNullException(nameof(dateTimeFormatInfo));
        }

        return dateTime.ToString(
            dateTimeFormatInfo.LongTimePattern,
            dateTimeFormatInfo);
    }

    /// <summary>
    /// Converts a DateTime to a string using the short date pattern
    /// of the current UI culture.
    /// </summary>
    /// <param name="dateTime">The DateTime to format.</param>
    /// <returns>A string representation of the DateTime using the
    /// short date pattern of the current UI culture.</returns>
    public static string ToShortDateStringUsingCurrentUiCulture(
        this DateTime dateTime)
        => dateTime.ToShortDateString(Thread.CurrentThread.CurrentUICulture.DateTimeFormat);

    /// <summary>
    /// Converts a DateTime to a string using the short date pattern of a specific culture.
    /// </summary>
    /// <param name="dateTime">The DateTime to format.</param>
    /// <param name="cultureInfo">The culture whose date format to use.</param>
    /// <returns>A string representation of the DateTime using the short date pattern of the specified culture.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="cultureInfo"/> is null.</exception>
    public static string ToShortDateStringUsingSpecificCulture(
        this DateTime dateTime,
        CultureInfo cultureInfo)
    {
        if (cultureInfo is null)
        {
            throw new ArgumentNullException(nameof(cultureInfo));
        }

        return dateTime.ToShortDateString(cultureInfo.DateTimeFormat);
    }

    /// <summary>
    /// Converts a DateTime to a string using the short date pattern of the provided DateTimeFormatInfo.
    /// </summary>
    /// <param name="dateTime">The DateTime to format.</param>
    /// <param name="dateTimeFormatInfo">The DateTimeFormatInfo specifying the format to use.</param>
    /// <returns>
    /// A string representation of the DateTime using the short date pattern of the provided DateTimeFormatInfo.
    /// </returns>
    public static string ToShortDateString(
        this DateTime dateTime,
        DateTimeFormatInfo dateTimeFormatInfo)
    {
        if (dateTimeFormatInfo == null)
        {
            throw new ArgumentNullException(nameof(dateTimeFormatInfo));
        }

        return dateTime.ToString(
            dateTimeFormatInfo.ShortDatePattern,
            dateTimeFormatInfo);
    }

    /// <summary>
    /// Converts a DateTime to a string using the short time pattern
    /// of the current UI culture.
    /// </summary>
    /// <param name="dateTime">The DateTime to format.</param>
    /// <returns>A string representation of the DateTime using the
    /// short time pattern of the current UI culture.</returns>
    public static string ToShortTimeStringUsingCurrentUiCulture(
        this DateTime dateTime)
        => dateTime.ToShortTimeString(Thread.CurrentThread.CurrentUICulture.DateTimeFormat);

    /// <summary>
    /// Converts a DateTime to a string using the short time pattern of a specific culture.
    /// </summary>
    /// <param name="dateTime">The DateTime to format.</param>
    /// <param name="cultureInfo">The culture whose time format to use.</param>
    /// <returns>A string representation of the DateTime using the short time pattern of the specified culture.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="cultureInfo"/> is null.</exception>
    public static string ToShortTimeStringUsingSpecificCulture(
        this DateTime dateTime,
        CultureInfo cultureInfo)
    {
        if (cultureInfo is null)
        {
            throw new ArgumentNullException(nameof(cultureInfo));
        }

        return dateTime.ToShortTimeString(cultureInfo.DateTimeFormat);
    }

    /// <summary>
    /// Converts a DateTime to a string using the short time pattern of the provided DateTimeFormatInfo.
    /// </summary>
    /// <param name="dateTime">The DateTime to format.</param>
    /// <param name="dateTimeFormatInfo">The DateTimeFormatInfo specifying the format to use.</param>
    /// <returns>
    /// A string representation of the DateTime using the short time pattern of the provided DateTimeFormatInfo.
    /// </returns>
    public static string ToShortTimeString(
        this DateTime dateTime,
        DateTimeFormatInfo dateTimeFormatInfo)
    {
        if (dateTimeFormatInfo == null)
        {
            throw new ArgumentNullException(nameof(dateTimeFormatInfo));
        }

        return dateTime.ToString(
            dateTimeFormatInfo.ShortTimePattern,
            dateTimeFormatInfo);
    }
}