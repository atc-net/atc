namespace Atc.Rest.HealthCheck.Extensions;

public static class HealthReportEntryExtensions
{
    public static Models.HealthCheck ToHealthCheck(
        this KeyValuePair<string, HealthReportEntry> healthReportEntry)
    {
        var resourceHealthChecks = new List<ResourceHealthCheck>();
        foreach (var item in healthReportEntry.Value.Data)
        {
            switch (item.Value)
            {
                case ResourceHealthCheck resourceHealthCheck:
                    resourceHealthChecks.Add(resourceHealthCheck);
                    break;
                case string stringContent:
                    resourceHealthChecks.Add(
                        new ResourceHealthCheck(
                            item.Key,
                            healthReportEntry.Value.Status,
                            stringContent,
                            TimeSpan.Zero));
                    break;
            }
        }

        return new Models.HealthCheck(
                healthReportEntry.Key,
                resourceHealthChecks,
                healthReportEntry.Value.Status,
                healthReportEntry.Value.Duration);
    }

    public static IList<Models.HealthCheck> ToHealthChecks(
        this IReadOnlyDictionary<string, HealthReportEntry> healthReportEntries)
        => healthReportEntries
            .Select(x => x.ToHealthCheck())
            .ToList();
}