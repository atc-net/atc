// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the <see cref="long"/> class.
/// </summary>
public static class LongExtensions
{
    /// <summary>Converts a unix time to a DateTimeOffset.</summary>
    /// <param name="valueInSeconds">A long containing the value (in seconds) to convert.</param>
    /// <returns>The DateTimeOffset value from a long in seconds.</returns>
    /// <code><![CDATA[DateTimeOffset dateTimeOffset = value.FromUnixTime(value);]]></code>
    /// <example><![CDATA[
    /// long unixTime = 0; // Equivalent to 1-1-1970
    /// DateTimeOffset dateTimeOffset = unixTime.FromUnixTime();
    /// ]]></example>
    public static DateTimeOffset FromUnixTime(this long valueInSeconds)
        => DateTimeOffset.FromUnixTimeSeconds(valueInSeconds);

    /// <summary>Converts a unix time to a DateTimeOffset.</summary>
    /// <param name="valueInMs">A long containing the value (in ms) to convert.</param>
    /// <returns>The DateTimeOffset value from a long in ms.</returns>
    /// <code><![CDATA[DateTimeOffset dateTimeOffset = value.FromUnixTimeMs(value);]]></code>
    /// <example><![CDATA[
    /// long unixTime = 0; // Equivalent to 1-1-1970
    /// DateTimeOffset dateTimeOffset = unixTime.FromUnixTimeMs();
    /// ]]></example>
    public static DateTimeOffset FromUnixTimeMs(this long valueInMs)
        => valueInMs >= 1000
            ? DateTimeOffset.FromUnixTimeSeconds(valueInMs / 1000)
            : DateTimeOffset.FromUnixTimeSeconds(valueInMs);
}