// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Defines the unit of time used for comparing or calculating differences between DateTime values.
/// </summary>
public enum DateTimeDiffCompareType
{
    /// <summary>
    /// Compare using ticks (100 nanosecond intervals).
    /// </summary>
    [LocalizedDescription("DateTimeDiffCompareTypeTicks", typeof(EnumResources))]
    Ticks,

    /// <summary>
    /// Compare using milliseconds.
    /// </summary>
    [LocalizedDescription("DateTimeDiffCompareTypeMilliseconds", typeof(EnumResources))]
    Milliseconds,

    /// <summary>
    /// Compare using seconds.
    /// </summary>
    [LocalizedDescription("DateTimeDiffCompareTypeSeconds", typeof(EnumResources))]
    Seconds,

    /// <summary>
    /// Compare using minutes.
    /// </summary>
    [LocalizedDescription("DateTimeDiffCompareTypeMinutes", typeof(EnumResources))]
    Minutes,

    /// <summary>
    /// Compare using hours.
    /// </summary>
    [LocalizedDescription("DateTimeDiffCompareTypeHours", typeof(EnumResources))]
    Hours,

    /// <summary>
    /// Compare using days.
    /// </summary>
    [LocalizedDescription("DateTimeDiffCompareTypeDays", typeof(EnumResources))]
    Days,

    /// <summary>
    /// Compare using years.
    /// </summary>
    [LocalizedDescription("DateTimeDiffCompareTypeYear", typeof(EnumResources))]
    Year,

    /// <summary>
    /// Compare using quarters (three-month periods).
    /// </summary>
    [LocalizedDescription("DateTimeDiffCompareTypeQuartal", typeof(EnumResources))]
    Quartal,
}