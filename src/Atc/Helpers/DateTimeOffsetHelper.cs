namespace Atc.Helpers;

/// <summary>
/// DateTimeOffsetHelper.
/// </summary>
public static class DateTimeOffsetHelper
{
    private const int DateLength = 10;
    private const int MaxTimeLengthFor24Hours = 5;
    private const int MaxTimeLengthFor12Hours = 8;

    /// <summary>
    /// Tries to parse a string representation of a <c>DateTimeOffset</c> using
    /// the current UI culture's date and time format.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="result">
    /// When this method returns, contains the parsed <c>DateTimeOffset</c>,
    /// if the parse operation was successful; otherwise, contains the default <c>DateTimeOffset</c>.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParseUsingCurrentUiCulture(
        string value,
        out DateTimeOffset result)
    {
        result = default;
        if (string.IsNullOrWhiteSpace(value) ||
            value.Length < DateLength)
        {
            return false;
        }

        if (!DateTimeOffset.TryParse(
                value,
                Thread.CurrentThread.CurrentUICulture.DateTimeFormat,
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
    /// When this method returns, contains the parsed <c>DateTimeOffset</c>,
    /// if the parse operation was successful; otherwise, contains the default <c>DateTimeOffset</c>.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParseShortDateUsingCurrentUiCulture(
        string value,
        out DateTimeOffset result)
    {
        result = default;
        if (string.IsNullOrWhiteSpace(value) ||
            value.Length > DateLength)
        {
            return false;
        }

        if (!DateTimeOffset.TryParse(
                value,
                Thread.CurrentThread.CurrentUICulture.DateTimeFormat,
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
    /// When this method returns, contains the parsed <c>DateTimeOffset</c>,
    /// if the parse operation was successful; otherwise, contains the default <c>DateTimeOffset</c>.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParseShortTimeUsingCurrentUiCulture(
        string value,
        out DateTimeOffset result)
    {
        result = default;

        var use24Hours = !(Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortTimePattern.StartsWith("h:", StringComparison.Ordinal) ||
                           Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortTimePattern.StartsWith("h.", StringComparison.Ordinal));

        var maxLength = use24Hours ? MaxTimeLengthFor24Hours : MaxTimeLengthFor12Hours;

        if (string.IsNullOrWhiteSpace(value) ||
            value.Length > maxLength)
        {
            return false;
        }

        var dateTimeOffsetValue = $"{DateTimeOffset.Now.ToShortDateStringUsingCurrentUiCulture()} {value}";
        if (!DateTimeOffset.TryParse(
                dateTimeOffsetValue,
                Thread.CurrentThread.CurrentUICulture.DateTimeFormat,
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
    /// When this method returns, contains the parsed <c>DateTimeOffset</c>,
    /// if the parse operation was successful; otherwise, contains the default <c>DateTimeOffset</c>.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParseShortTimeUsingCurrentUiCultureUtc(
        string value,
        out DateTimeOffset result)
    {
        result = default;

        var use24Hours = !(Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortTimePattern.StartsWith("h:", StringComparison.Ordinal) ||
                           Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortTimePattern.StartsWith("h.", StringComparison.Ordinal));

        var maxLength = use24Hours ? MaxTimeLengthFor24Hours : MaxTimeLengthFor12Hours;

        if (string.IsNullOrWhiteSpace(value) ||
            value.Length > maxLength)
        {
            return false;
        }

        var dateTimeOffsetValue = $"{DateTimeOffset.UtcNow.ToShortDateStringUsingCurrentUiCulture()} {value}";
        if (!DateTimeOffset.TryParse(
                dateTimeOffsetValue,
                Thread.CurrentThread.CurrentUICulture.DateTimeFormat,
                DateTimeStyles.None,
                out var res))
        {
            return false;
        }

        result = res;
        return true;
    }
}