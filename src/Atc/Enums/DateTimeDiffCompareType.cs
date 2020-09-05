using System.Diagnostics.CodeAnalysis;
using Atc.Resources;

namespace Atc.Enums
{
    /// <summary>
    /// Enumeration: DateTimeDiffCompareType.
    /// </summary>
    public enum DateTimeDiffCompareType
    {
        /// <summary>
        /// Ticks
        /// </summary>
        [LocalizedDescription("DateTimeDiffCompareTypeTicks", typeof(EnumResources))]
        Ticks,

        /// <summary>
        /// Milliseconds
        /// </summary>
        [LocalizedDescription("DateTimeDiffCompareTypeMilliseconds", typeof(EnumResources))]
        Milliseconds,

        /// <summary>
        /// Seconds
        /// </summary>
        [LocalizedDescription("DateTimeDiffCompareTypeSeconds", typeof(EnumResources))]
        Seconds,

        /// <summary>
        /// Minutes
        /// </summary>
        [LocalizedDescription("DateTimeDiffCompareTypeMinutes", typeof(EnumResources))]
        Minutes,

        /// <summary>
        /// Hours
        /// </summary>
        [LocalizedDescription("DateTimeDiffCompareTypeHours", typeof(EnumResources))]
        Hours,

        /// <summary>
        /// Days
        /// </summary>
        [LocalizedDescription("DateTimeDiffCompareTypeDays", typeof(EnumResources))]
        Days,

        /// <summary>
        /// Year
        /// </summary>
        [LocalizedDescription("DateTimeDiffCompareTypeYear", typeof(EnumResources))]
        Year,

        /// <summary>
        /// Quartal
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Quartal", Justification = "Reviewed.")]
        [LocalizedDescription("DateTimeDiffCompareTypeQuartal", typeof(EnumResources))]
        Quartal
    }
}