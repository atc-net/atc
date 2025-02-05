namespace Atc.Helpers;

/// <summary>
/// DateTimeHelper.
/// </summary>
public static class DateTimeHelper
{
    private const int DateLength = 10;
    private const int MaxTimeLengthFor24Hours = 5;
    private const int MaxTimeLengthFor12Hours = 8;

    /// <summary>
    /// Tries to parse a string representation of a <c>DateTime</c> using
    /// the current UI culture's date and time format.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="result">
    /// When this method returns, contains the parsed <c>DateTime</c>,
    /// if the parse operation was successful; otherwise, contains the default <c>DateTime</c>.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParseUsingCurrentUiCulture(
        string value,
        out DateTime result)
    {
        result = default;
        if (!TryParseUsingSpecificCulture(value, Thread.CurrentThread.CurrentUICulture, out var res))
        {
            return false;
        }

        result = res;
        return true;
    }

    /// <summary>
    /// Tries to parse a string representation of a DateTime using a specific culture's date and time format.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="cultureInfo">The culture info to use for parsing.</param>
    /// <param name="result">
    /// When this method returns, contains the parsed DateTime,
    /// if the parse operation was successful; otherwise, contains the default DateTime.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParseUsingSpecificCulture(
        string value,
        CultureInfo cultureInfo,
        out DateTime result)
    {
        if (cultureInfo is null)
        {
            throw new ArgumentNullException(nameof(cultureInfo));
        }

        result = default;
        if (string.IsNullOrWhiteSpace(value) ||
            value.Length < DateLength)
        {
            return false;
        }

        if (!DateTime.TryParse(
                value,
                cultureInfo.DateTimeFormat,
                DateTimeStyles.None,
                out var res))
        {
            return false;
        }

        result = res;
        return true;
    }

    /// <summary>
    /// Tries to parse a string representation of a short date using
    /// the current UI culture's date format.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="result">
    /// When this method returns, contains the parsed <c>DateTime</c>,
    /// if the parse operation was successful; otherwise, contains the default <c>DateTime</c>.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParseShortDateUsingCurrentUiCulture(
        string value,
        out DateTime result)
    {
        result = default;
        if (!TryParseShortDateUsingSpecificCulture(value, Thread.CurrentThread.CurrentUICulture, out var res))
        {
            return false;
        }

        result = res;
        return true;
    }

    /// <summary>
    /// Tries to parse a string representation of a short date using a specific culture's date format.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="cultureInfo">The culture info to use for parsing.</param>
    /// <param name="result">
    /// When this method returns, contains the parsed DateTime,
    /// if the parse operation was successful; otherwise, contains the default DateTime.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParseShortDateUsingSpecificCulture(
        string value,
        CultureInfo cultureInfo,
        out DateTime result)
    {
        if (cultureInfo is null)
        {
            throw new ArgumentNullException(nameof(cultureInfo));
        }

        result = default;
        if (string.IsNullOrWhiteSpace(value) ||
            value.Length > DateLength)
        {
            return false;
        }

        if (!DateTime.TryParse(
                value,
                cultureInfo.DateTimeFormat,
                DateTimeStyles.None,
                out var res))
        {
            return false;
        }

        result = res;
        return true;
    }

    /// <summary>
    /// Tries to parse a string representation of a short time using the
    /// current UI culture's time format (12-hour or 24-hour).
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="result">
    /// When this method returns, contains the parsed <c>DateTime</c>,
    /// if the parse operation was successful; otherwise, contains the default <c>DateTime</c>.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParseShortTimeUsingCurrentUiCulture(
        string value,
        out DateTime result)
    {
        result = default;
        if (!TryParseShortTimeUsingSpecificCulture(value, Thread.CurrentThread.CurrentUICulture, out var res))
        {
            return false;
        }

        result = res;
        return true;
    }

    /// <summary>
    /// Tries to parse a string representation of a short time using a specific culture's time format (12-hour or 24-hour).
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="cultureInfo">The culture info to use for parsing.</param>
    /// <param name="result">
    /// When this method returns, contains the parsed DateTime,
    /// if the parse operation was successful; otherwise, contains the default DateTime.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParseShortTimeUsingSpecificCulture(
        string value,
        CultureInfo cultureInfo,
        out DateTime result)
    {
        if (cultureInfo is null)
        {
            throw new ArgumentNullException(nameof(cultureInfo));
        }

        result = default;

        var use24Hours = !(cultureInfo.DateTimeFormat.ShortTimePattern.StartsWith("h:", StringComparison.Ordinal) ||
                           cultureInfo.DateTimeFormat.ShortTimePattern.StartsWith("h.", StringComparison.Ordinal));

        var maxLength = use24Hours ? MaxTimeLengthFor24Hours : MaxTimeLengthFor12Hours;

        if (string.IsNullOrWhiteSpace(value) ||
            value.Length > maxLength)
        {
            return false;
        }

        var dateTimeValue = $"{DateTime.Now.ToShortDateStringUsingSpecificCulture(cultureInfo)} {value}";
        if (!DateTime.TryParse(
                dateTimeValue,
                cultureInfo.DateTimeFormat,
                DateTimeStyles.None,
                out var res))
        {
            return false;
        }

        result = res;
        return true;
    }

    /// <summary>
    /// Tries to parse a string representation of a short UTC time using the
    /// current UI culture's time format (12-hour or 24-hour).
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="result">
    /// When this method returns, contains the parsed <c>DateTime</c>,
    /// if the parse operation was successful; otherwise, contains the default <c>DateTime</c>.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParseShortTimeUsingCurrentUiCultureUtc(
        string value,
        out DateTime result)
    {
        result = default;
        if (!TryParseShortTimeUsingSpecificCultureUtc(value, Thread.CurrentThread.CurrentUICulture, out var res))
        {
            return false;
        }

        result = res;
        return true;
    }

    /// <summary>
    /// Tries to parse a string representation of a short UTC time using a specific culture's time format (12-hour or 24-hour).
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="cultureInfo">The culture info to use for parsing.</param>
    /// <param name="result">
    /// When this method returns, contains the parsed DateTime in UTC,
    /// if the parse operation was successful; otherwise, contains the default DateTime.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParseShortTimeUsingSpecificCultureUtc(
        string value,
        CultureInfo cultureInfo,
        out DateTime result)
    {
        if (cultureInfo is null)
        {
            throw new ArgumentNullException(nameof(cultureInfo));
        }

        result = default;

        var use24Hours = !(cultureInfo.DateTimeFormat.ShortTimePattern.StartsWith("h:", StringComparison.Ordinal) ||
                           cultureInfo.DateTimeFormat.ShortTimePattern.StartsWith("h.", StringComparison.Ordinal));

        var maxLength = use24Hours ? MaxTimeLengthFor24Hours : MaxTimeLengthFor12Hours;

        if (string.IsNullOrWhiteSpace(value) ||
            value.Length > maxLength)
        {
            return false;
        }

        var dateTimeValue = $"{DateTime.UtcNow.ToShortDateStringUsingSpecificCulture(cultureInfo)} {value}";
        if (!DateTime.TryParse(
                dateTimeValue,
                cultureInfo.DateTimeFormat,
                DateTimeStyles.None,
                out var res))
        {
            return false;
        }

        result = res;
        return true;
    }
}