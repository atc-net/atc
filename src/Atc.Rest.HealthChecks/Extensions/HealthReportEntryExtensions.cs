namespace Atc.Rest.HealthChecks.Extensions;

public static class HealthReportEntryExtensions
{
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

    public static IList<HealthCheck> ToHealthChecks(
        this IReadOnlyDictionary<string, HealthReportEntry> entries)
        => entries
            .Select(ToHealthCheck)
            .ToList();
}