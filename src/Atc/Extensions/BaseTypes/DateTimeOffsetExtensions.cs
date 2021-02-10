using Atc;

// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    /// Extensions for the <see cref="DateTimeOffset"/> class.
    /// </summary>
    public static class DateTimeOffsetExtensions
    {
        /// <summary>
        /// Returns true if the date time offset is between or equal to one of the two values.
        /// </summary>
        /// <param name="date">DateTime Base, from where the calculation will be preformed.</param>
        /// <param name="startDate">Start date to check for.</param>
        /// <param name="endDate">End date to check for.</param>
        /// <returns>boolean value indicating if the date is between or equal to one of the two values.</returns>
        public static bool IsBetween(this DateTimeOffset date, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            var ticks = date.Ticks;
            return ticks >= startDate.Ticks && ticks <= endDate.Ticks;
        }

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