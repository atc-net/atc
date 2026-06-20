namespace Atc.Rest.HealthChecks.Extensions;

/// <summary>
/// Extension methods for <see cref="ResourceHealthCheck"/>.
/// </summary>
public static class ResourceHealthCheckExtensions
{
    /// <summary>
    /// Converts a collection of resource health checks to a read-only dictionary.
    /// </summary>
    /// <param name="resourceHealthCheck">The collection of resource health checks to convert.</param>
    /// <returns>A read-only dictionary where keys are resource names and values are anonymous objects containing status, duration, and description.</returns>
    public static IReadOnlyDictionary<string, object> ToIReadOnlyDictionary(
        this IEnumerable<ResourceHealthCheck> resourceHealthCheck)
        => resourceHealthCheck
            .GroupBy(e => e.Name, StringComparer.Ordinal)
            .ToDictionary(
                g => g.Key,
                g =>
                {
                    var e = g.First();
                    return (object)new
                    {
                        e.Status,
                        e.Duration,
                        e.Description,
                    };
                },
                StringComparer.Ordinal);
}