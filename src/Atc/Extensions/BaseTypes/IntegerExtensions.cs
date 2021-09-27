using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Threading;
using Atc;

// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    /// Extensions for the <see cref="int"/> class.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// Determines whether the specified a is equal.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        ///   <c>true</c> if the specified a is equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEqual(this int? a, int? b)
        {
            if (a is null || b is null)
            {
                return a is null && b is null;
            }

            return a == b;
        }

        /// <summary>
        /// Determines whether the specified number is even.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns><c>true</c> if the specified number is even; otherwise, <c>false</c>.</returns>
        public static bool IsEven(this int number)
        {
            return (number & 1) == 0;
        }

        /// <summary>
        /// Determines whether the specified number is odd.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns><c>true</c> if the specified number is odd; otherwise, <c>false</c>.</returns>
        public static bool IsOdd(this int number)
        {
            return (number & 1) == 1;
        }

        /// <summary>
        /// Determines whether the specified number is prime.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns><c>true</c> if the specified number is prime; otherwise, <c>false</c>.</returns>
        public static bool IsPrime(this int number)
        {
            if (number < 2)
            {
                return false;
            }

            var bound = (int)Math.Sqrt(number);
            for (var i = 2; i <= bound; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether [is binary sequence] [the specified number].
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///   <c>true</c> if [is binary sequence] [the specified number]; otherwise, <c>false</c>.
        /// </returns>
        /// <code><![CDATA[bool value = number.IsBinarySequence();]]></code>
        /// <example><![CDATA[
        /// int number = 8;
        /// bool value = number.IsBinarySequence();
        /// ]]></example>
        public static bool IsBinarySequence(this int number)
        {
            const int numberLimit = int.MaxValue / 2;
            var numberToCheck = 1;
            do
            {
                if (number == numberToCheck)
                {
                    return true;
                }

                numberToCheck *= 2;
            }
            while (numberToCheck <= number && numberToCheck < numberLimit);

            return false;
        }

        /// <summary>
        /// Gets the month name by month number.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <param name="pascalCased">if set to <c>true</c> [pascal cased].</param>
        /// <returns>The name of the month.</returns>
        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "OK.")]
        public static string GetMonthNameByMonthNumber(this int month, bool pascalCased = false)
        {
            if (month < 1 || month > 12)
            {
                return string.Empty;
            }

            var timeBegin = DateTime.Parse("01-JAN-1970", GlobalizationConstants.EnglishCultureInfo);
            var time = timeBegin.AddMonths(month - 1);

            // ReSharper disable once StringLiteralTypo
            var str = time.ToString("MMMM", Thread.CurrentThread.CurrentUICulture);
            if (str.Length <= 0)
            {
                return string.Empty;
            }

            return pascalCased
                ? str.PascalCase()
                : str.ToLower(CultureInfo.CurrentUICulture);
        }

        /// <summary>
        /// Gets the number of weeks by year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>The get number of weeks.</returns>
        public static int GetNumberOfWeeksByYear(this int year)
        {
            return CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(new DateTime(year, 12, 28), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        /// <summary>
        /// Get the date of the first day in the given year and week number.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="weekNumber">The week number.</param>
        /// <returns>The date of the first day in the given year and week number.</returns>
        public static DateTime GetFirstDayOfWeekNumberByYear(this int year, int weekNumber)
        {
            var calendar = CultureInfo.CurrentUICulture.Calendar;
            var firstOfYear = new DateTime(year, 1, 1, calendar);
            var daysOffset = DayOfWeek.Thursday - firstOfYear.DayOfWeek;

            var firstThursday = firstOfYear.AddDays(daysOffset);
            var firstWeek = CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekNumber;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }

            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }

        /// <summary>
        /// Get the date of the last day in the given year and week number.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="weekNumber">The week number.</param>
        /// <returns>The date of the last day in the given year and week number.</returns>
        public static DateTime GetLastDayOfWeekNumberByYear(this int year, int weekNumber)
        {
            return GetFirstDayOfWeekNumberByYear(year, weekNumber).AddDays(6);
        }
    }
}