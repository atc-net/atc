using Atc;

// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    /// Extensions for the <see cref="DateTimeOffset"/> class.
    /// </summary>
    public static class DateTimeOffsetExtensions
    {
        /// <summary>Converts the DateTimeOffset to a unix time - seconds stating from 1-1-1970.</summary>
        /// <param name="dateTimeOffset">The date time offset.</param>
        /// <returns>The long value from a DateTimeOffset.</returns>
        /// <code><![CDATA[long unixTime = DateTimeOffset.ToUnixTime(value);]]></code>
        /// <example><![CDATA[
        /// DateTimeOffset dateTimeOffset = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
        /// long unixTime = dateTimeOffset.ToUnixTime();
        /// ]]></example>
        public static long ToUnixTime(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.ToUnixTimeSeconds();
        }

        /// <summary>
        /// Converts to ISO 8601 date.
        /// </summary>
        /// <param name="dateTimeOffset">The date time offset.</param>
        public static string ToIso8601Date(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.ToString(GlobalizationConstants.DateTimeIso8601, GlobalizationConstants.EnglishCultureInfo);
        }
    }
}