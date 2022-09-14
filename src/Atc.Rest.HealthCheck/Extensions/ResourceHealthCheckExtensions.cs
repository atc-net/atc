namespace Atc.Rest.HealthCheck.Extensions;

public static class ResourceHealthCheckExtensions
{
    public static IReadOnlyDictionary<string, object> ToIReadOnlyDictionary(
        this IEnumerable<ResourceHealthCheck> resourceHealthCheck)
        => resourceHealthCheck.ToDictionary(
            keySelector: _ => Guid.NewGuid().ToString(),
            elementSelector: e => (object)e,
            StringComparer.Ordinal);
}