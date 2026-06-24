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
    /// Tries to parse a string representation of a <c>DateTimeOffset</c> using the current UI culture's date and time format.
    /// Use this variant when parsing input from a user interface.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="result">
    /// When this method returns, contains the parsed <c>DateTimeOffset</c>,
    /// if the parse operation was successful; otherwise, contains the default <c>DateTimeOffset</c>.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParseUi(
        string value,
        out DateTimeOffset result)
    {
        result = default;
        if (!TryParseUsingSpecificCulture(value, CultureInfo.CurrentUICulture, out var res))
        {
            return false;
        }

        result = res;
        return true;
    }

    /// <summary>
    /// Tries to parse a string representation of a <c>DateTimeOffset</c> using a specific culture's date and time format.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="cultureInfo">The culture info to use for parsing.</param>
    /// <param name="result">
    /// When this method returns, contains the parsed <c>DateTimeOffset</c>,
    /// if the parse operation was successful; otherwise, contains the default <c>DateTimeOffset</c>.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="cultureInfo"/> is null.</exception>
    public static bool TryParseUsingSpecificCulture(
        string value,
        CultureInfo cultureInfo,
        out DateTimeOffset result)
    {
        ArgumentNullException.ThrowIfNull(cultureInfo);

        result = default;
        if (string.IsNullOrWhiteSpace(value) ||
            value.Length < DateLength)
        {
            return false;
        }

        if (!DateTimeOffset.TryParse(
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
    /// Tries to parse a string representation of a short date using the current UI culture's date format.
    /// Use this variant when parsing input from a user interface.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="result">
    /// When this method returns, contains the parsed <c>DateTimeOffset</c>,
    /// if the parse operation was successful; otherwise, contains the default <c>DateTimeOffset</c>.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParseShortDateUi(
        string value,
        out DateTimeOffset result)
    {
        result = default;
        if (!TryParseShortDateUsingSpecificCulture(value, CultureInfo.CurrentUICulture, out var res))
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
    /// When this method returns, contains the parsed <c>DateTimeOffset</c>,
    /// if the parse operation was successful; otherwise, contains the default <c>DateTimeOffset</c>.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="cultureInfo"/> is null.</exception>
    public static bool TryParseShortDateUsingSpecificCulture(
        string value,
        CultureInfo cultureInfo,
        out DateTimeOffset result)
    {
        ArgumentNullException.ThrowIfNull(cultureInfo);

        result = default;
        if (string.IsNullOrWhiteSpace(value) ||
            value.Length > DateLength)
        {
            return false;
        }

        if (!DateTimeOffset.TryParse(
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
    /// Tries to parse a string representation of a short time using the current UI culture's time format (12-hour or 24-hour).
    /// Use this variant when parsing input from a user interface.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="result">
    /// When this method returns, contains the parsed <c>DateTimeOffset</c>,
    /// if the parse operation was successful; otherwise, contains the default <c>DateTimeOffset</c>.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParseShortTimeUi(
        string value,
        out DateTimeOffset result)
    {
        result = default;
        if (!TryParseShortTimeUsingSpecificCulture(value, CultureInfo.CurrentUICulture, out var res))
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
    /// When this method returns, contains the parsed <c>DateTimeOffset</c>,
    /// if the parse operation was successful; otherwise, contains the default <c>DateTimeOffset</c>.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="cultureInfo"/> is null.</exception>
    public static bool TryParseShortTimeUsingSpecificCulture(
        string value,
        CultureInfo cultureInfo,
        out DateTimeOffset result)
    {
        ArgumentNullException.ThrowIfNull(cultureInfo);

        result = default;

        var use24Hours = !(cultureInfo.DateTimeFormat.ShortTimePattern.StartsWith("h:", StringComparison.Ordinal) ||
                           cultureInfo.DateTimeFormat.ShortTimePattern.StartsWith("h.", StringComparison.Ordinal));

        var maxLength = use24Hours ? MaxTimeLengthFor24Hours : MaxTimeLengthFor12Hours;

        if (string.IsNullOrWhiteSpace(value) ||
            value.Length > maxLength)
        {
            return false;
        }

        var dateTimeOffsetValue = $"{DateTimeOffset.Now.ToShortDateStringUsingSpecificCulture(cultureInfo)} {value}";
        if (!DateTimeOffset.TryParse(
                dateTimeOffsetValue,
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
    /// Tries to parse a string representation of a short UTC time using the current UI culture's time format (12-hour or 24-hour).
    /// Use this variant when parsing input from a user interface.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <param name="result">
    /// When this method returns, contains the parsed <c>DateTimeOffset</c>,
    /// if the parse operation was successful; otherwise, contains the default <c>DateTimeOffset</c>.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParseShortTimeUiUtc(
        string value,
        out DateTimeOffset result)
    {
        result = default;
        if (!TryParseShortTimeUsingSpecificCultureUtc(value, CultureInfo.CurrentUICulture, out var res))
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
    /// When this method returns, contains the parsed <c>DateTimeOffset</c> in UTC,
    /// if the parse operation was successful; otherwise, contains the default <c>DateTimeOffset</c>.
    /// </param>
    /// <returns>
    ///   <see langword="true" /> if the parsing was successful; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="cultureInfo"/> is null.</exception>
    public static bool TryParseShortTimeUsingSpecificCultureUtc(
        string value,
        CultureInfo cultureInfo,
        out DateTimeOffset result)
    {
        ArgumentNullException.ThrowIfNull(cultureInfo);

        result = default;

        var use24Hours = !(cultureInfo.DateTimeFormat.ShortTimePattern.StartsWith("h:", StringComparison.Ordinal) ||
                           cultureInfo.DateTimeFormat.ShortTimePattern.StartsWith("h.", StringComparison.Ordinal));

        var maxLength = use24Hours ? MaxTimeLengthFor24Hours : MaxTimeLengthFor12Hours;

        if (string.IsNullOrWhiteSpace(value) ||
            value.Length > maxLength)
        {
            return false;
        }

        var dateTimeOffsetValue = $"{DateTimeOffset.UtcNow.ToShortDateStringUsingSpecificCulture(cultureInfo)} {value}";
        if (!DateTimeOffset.TryParse(
                dateTimeOffsetValue,
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