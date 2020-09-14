// ReSharper disable once CheckNamespace
namespace System
{
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
        /// Removes the millisecond part of the timespan.
        /// </summary>
        /// <param name="timespan">The timespan.</param>
        public static TimeSpan RemoveMilliseconds(this TimeSpan timespan)
        {
            return timespan.Subtract(TimeSpan.FromMilliseconds(timespan.Milliseconds));
        }

        /// <summary>
        /// Determines whether the seconds part of the datetime is zero.
        /// </summary>
        /// <param name="timespan">The timespan.</param>
        /// <returns>
        ///   <c>true</c> if [is seconds is zero] otherwise, <c>false</c>.
        /// </returns>
        public static bool SecondsNotZero(this TimeSpan timespan)
        {
            return timespan.TotalSeconds > 0;
        }
    }
}