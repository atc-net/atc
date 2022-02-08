// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the <see cref="long"/> class.
/// </summary>
public static class LongExtensions
{
    /// <summary>Converts a unix time to a DateTimeOffset.</summary>
    /// <param name="value">A long containing the value to convert.</param>
    /// <returns>The DateTimeOffset value from a long.</returns>
    /// <code><![CDATA[DateTimeOffset dateTimeOffset = value.FromUnixTimeSeconds(value);]]></code>
    /// <example><![CDATA[
    /// long unixTime = 0; // Equivalent to 1-1-1970
    /// DateTimeOffset dateTimeOffset = unixTime.FromUnixTimeSeconds();
    /// ]]></example>
    public static DateTimeOffset FromUnixTime(this long value)
    {
        return DateTimeOffset.FromUnixTimeSeconds(value);
    }
}