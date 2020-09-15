using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Atc.Helpers
{
    /// <summary>
    /// DayOfWeekHelper.
    /// </summary>
    public static class DayOfWeekHelper
    {
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="dayOfWeek">The day of week.</param>
        /// <param name="culture">The culture.</param>
        public static string GetDescription(DayOfWeek dayOfWeek, CultureInfo? culture = null)
        {
            string? description = null;
            if (culture == null)
            {
                if (DateTimeFormatInfo.CurrentInfo != null)
                {
                    description = DateTimeFormatInfo.CurrentInfo.GetDayName(dayOfWeek);
                }
            }
            else
            {
                description = culture.DateTimeFormat.GetDayName(dayOfWeek);
            }

            return description?.PascalCase() ?? dayOfWeek.ToString();
        }

        /// <summary>
        /// Gets the descriptions.
        /// </summary>
        /// <param name="culture">The culture.</param>
        public static Dictionary<DayOfWeek, string> GetDescriptions(CultureInfo? culture = null)
        {
            var list = new Dictionary<DayOfWeek, string>
            {
                { DayOfWeek.Sunday, GetDescription(DayOfWeek.Sunday, culture) },
                { DayOfWeek.Monday, GetDescription(DayOfWeek.Monday, culture) },
                { DayOfWeek.Tuesday, GetDescription(DayOfWeek.Tuesday, culture) },
                { DayOfWeek.Wednesday, GetDescription(DayOfWeek.Wednesday, culture) },
                { DayOfWeek.Thursday, GetDescription(DayOfWeek.Thursday, culture) },
                { DayOfWeek.Friday, GetDescription(DayOfWeek.Friday, culture) },
                { DayOfWeek.Saturday, GetDescription(DayOfWeek.Saturday, culture) }
            };
            return list;
        }

        /// <summary>
        /// Tries the parse description.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="dayOfWeek">The day of week.</param>
        /// <param name="culture">The culture.</param>
        [SuppressMessage("Major Bug", "S1751:Loops with at most one iteration should be refactored", Justification = "OK.")]
        public static bool TryParseDescription(string value, out DayOfWeek dayOfWeek, CultureInfo? culture = null)
        {
            dayOfWeek = DayOfWeek.Sunday;
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            var descriptions = GetDescriptions(culture);
            foreach (var pair in descriptions.Where(x => x.Value.Equals(value, StringComparison.OrdinalIgnoreCase)))
            {
                dayOfWeek = pair.Key;
                return true;
            }

            return false;
        }
    }
}