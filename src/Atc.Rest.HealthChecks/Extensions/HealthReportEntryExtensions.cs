namespace Atc.Rest.HealthChecks.Extensions;

/// <summary>
/// Extension methods for <see cref="HealthReportEntry"/>.
/// </summary>
public static class HealthReportEntryExtensions
{
    /// <summary>
    /// Converts a key-value pair of health report entry to a <see cref="HealthCheck"/> instance.
    /// </summary>
    /// <param name="kvp">The key-value pair containing the health check name and entry details.</param>
    /// <returns>A <see cref="HealthCheck"/> instance representing the health report entry.</returns>
    public static HealthCheck ToHealthCheck(
        this KeyValuePair<string, HealthReportEntry> kvp)
    {
        var entry = kvp.Value;

        var data = entry.Data.Count > 0
            ? entry.Data
            : null;

        return new HealthCheck(
            Name: kvp.Key,
            Status: entry.Status,
            Duration: entry.Duration,
            Description: entry.Description,
            Data: data);
    }

    /// <summary>
    /// Converts a collection of health report entries to a list of <see cref="HealthCheck"/> instances.
    /// </summary>
    /// <param name="entries">The dictionary of health report entries to convert.</param>
    /// <returns>A list of <see cref="HealthCheck"/> instances.</returns>
    public static IList<HealthCheck> ToHealthChecks(
        this IReadOnlyDictionary<string, HealthReportEntry> entries)
        => entries
            .Select(ToHealthCheck)
            .ToList();
}