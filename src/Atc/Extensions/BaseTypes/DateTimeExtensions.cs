using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Threading;
using Atc.Enums;

namespace Atc.Extensions.BaseTypes
{
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
        public static bool IsBetween(this DateTime date, DateTime startDate, DateTime endDate)
        {
            var ticks = date.Ticks;
            return ticks >= startDate.Ticks && ticks <= endDate.Ticks;
        }

        /// <summary>
        /// Gets the pretty time difference.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="decimalPrecision">The decimal precision.</param>
        public static string GetPrettyTimeDiff(this DateTime startDate, int decimalPrecision = 3)
        {
            return GetPrettyTimeDiff(startDate, DateTime.Now, decimalPrecision);
        }

        /// <summary>
        /// Gets the pretty time difference.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="decimalPrecision">The decimal precision.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "OK.")]
        public static string GetPrettyTimeDiff(this DateTime startDate, DateTime endDate, int decimalPrecision = 3)
        {
            TimeSpan timeSpan = new TimeSpan(endDate.Ticks - startDate.Ticks);
            if ((int)timeSpan.TotalDays > 0)
            {
                return $"{timeSpan.TotalDays.ToString("N" + decimalPrecision, Thread.CurrentThread.CurrentUICulture)} days";
            }

            if ((int)timeSpan.TotalHours > 0)
            {
                return $"{timeSpan.TotalHours.ToString("N" + decimalPrecision, Thread.CurrentThread.CurrentUICulture)} hours";
            }

            if ((int)timeSpan.TotalMinutes > 0)
            {
                return $"{timeSpan.TotalMinutes.ToString("N" + decimalPrecision, Thread.CurrentThread.CurrentUICulture)} min";
            }

            // ReSharper disable once ConvertIfStatementToReturnStatement
            if ((int)timeSpan.TotalSeconds > 0)
            {
                return $"{timeSpan.TotalSeconds.ToString("N" + decimalPrecision, Thread.CurrentThread.CurrentUICulture)} sec";
            }

            return $"{timeSpan.TotalMilliseconds.ToString("N" + decimalPrecision, Thread.CurrentThread.CurrentUICulture)} ms";
        }

        /// <summary>
        /// Gets the week number from a given date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The week number from the given date.</returns>
        public static int GetWeekNumber(this DateTime date)
        {
            return CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        /// <summary>
        /// Find the diff between to DateTimes.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="howToCompare">The how to compare.</param>
        /// <returns>The number between start date and end date, depend on the DiffCompareType.</returns>
        [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
        public static double DateTimeDiff(this DateTime startDate, DateTime endDate, DateTimeDiffCompareType howToCompare)
        {
            double diff;
            try
            {
                TimeSpan timeSpan = new TimeSpan(endDate.Ticks - startDate.Ticks);
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
        /// <example>
        /// string isoDate = DateTime.UtcNow.ToIso8601Date();.
        /// </example>
        public static string ToIso8601Date(this DateTime dateTime)
        {
            return dateTime.ToString(GlobalizationConstants.DateTimeIso8601, GlobalizationConstants.EnglishCultureInfo);
        }

        /// <summary>
        /// To the iso8601 UTC date.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        public static string ToIso8601UtcDate(this DateTime dateTime)
        {
            return dateTime.ToUniversalTime().ToString(GlobalizationConstants.DateTimeIso8601, GlobalizationConstants.EnglishCultureInfo);
        }
    }
}