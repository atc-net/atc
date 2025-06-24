namespace Atc.Rest.HealthChecks.Extensions;

public static class ResourceHealthCheckExtensions
{
    public static IReadOnlyDictionary<string, object> ToIReadOnlyDictionary(
        this IEnumerable<ResourceHealthCheck> resourceHealthCheck)
        => resourceHealthCheck.ToDictionary(
            keySelector: key => key.Name,
            elementSelector: e => (object)new
            {
                e.Status,
                e.Duration,
                e.Description,
            },
            StringComparer.Ordinal);
}