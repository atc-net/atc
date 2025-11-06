namespace Atc.Rest.Extensions;

/// <summary>
/// Extension methods for <see cref="IEndpointRouteBuilder"/> to map API specification and assembly information endpoints.
/// </summary>
public static class EndpointRouteBuilderExExtensions
{
    private static readonly Dictionary<string, string> YamlCache = new(StringComparer.Ordinal);

    /// <summary>
    /// Maps endpoints for serving OpenAPI specification YAML files from embedded assembly resources.
    /// </summary>
    /// <param name="endpoints">The endpoint route builder.</param>
    /// <param name="assemblyPairs">The list of assembly pairs containing API specifications.</param>
    /// <remarks>
    /// This method creates an endpoint for each assembly's embedded YAML specification and a summary endpoint
    /// at /ApiSpecifications that returns a list of all available specification URLs.
    /// The YAML files are cached in memory for performance.
    /// </remarks>
    [SuppressMessage("Performance", "CA1849:Call async methods when in an async method", Justification = "OK. The async method is a sub-method.")]
    public static void MapApiSpecificationEndpoint(
        this IEndpointRouteBuilder endpoints,
        List<AssemblyPairOptions> assemblyPairs)
    {
        ArgumentNullException.ThrowIfNull(assemblyPairs);

        var yamlEndpoints = new List<string>();
        foreach (var assemblyPair in assemblyPairs)
        {
            var apiAssemblyName = assemblyPair.ApiAssembly.GetName().Name!;
            var resourceStream = assemblyPair.ApiAssembly.GetManifestResourceStream($"{apiAssemblyName}.Resources.ApiSpecification.yaml");
            if (resourceStream is null)
            {
                continue;
            }

            var yamlEndpoint = $"{apiAssemblyName}.ApiSpecification.yaml";
            endpoints.Map(yamlEndpoint, async context =>
            {
                string yaml;
                if (YamlCache.TryGetValue(yamlEndpoint, out var value))
                {
                    yaml = value;
                }
                else
                {
                    Stream? stream = null;
                    try
                    {
                        stream = resourceStream;
                        using var reader = new StreamReader(stream);
                        yaml = await reader.ReadToEndAsync();
                        YamlCache.Add(yamlEndpoint, yaml);
                    }
                    finally
                    {
                        // ReSharper disable once MethodHasAsyncOverload
                        stream?.Dispose();
                    }
                }

                context.Response.ContentType = "application/x-yaml";
                await context.Response.WriteAsync(yaml);
            });

            yamlEndpoints.Add(yamlEndpoint);
        }

        if (yamlEndpoints.Count > 0)
        {
            endpoints
                .MapGet("/ApiSpecifications", async context =>
                {
                    var links = yamlEndpoints
                        .Select(yamlEndpoint => $"{context.Request.Scheme}://{context.Request.Host}/{yamlEndpoint}")
                        .ToList();
                    var response = JsonSerializer.Serialize(links);
                    await context.Response.WriteAsync(response);
                })
                .WithMetadata(new AllowAnonymousAttribute())
                .WithGroupName("API-Management");
        }
    }

    /// <summary>
    /// Maps an endpoint at /management/assembly-informations to serve assembly information.
    /// </summary>
    /// <param name="endpoints">The endpoint route builder.</param>
    public static void MapApiManagementAssemblyInformations(
        this IEndpointRouteBuilder endpoints)
        => endpoints.MapApiAssemblyInformations("/management/assembly-informations");

    /// <summary>
    /// Maps an endpoint to serve assembly information for all loaded assemblies in the current application domain.
    /// </summary>
    /// <param name="endpoints">The endpoint route builder.</param>
    /// <param name="pattern">The URL pattern for the endpoint. Defaults to /assembly-informations if null or empty.</param>
    /// <remarks>
    /// The endpoint is tagged with "API-Management" and allows anonymous access.
    /// Returns a JSON array of assembly information including name, version, and other metadata.
    /// </remarks>
    public static void MapApiAssemblyInformations(
        this IEndpointRouteBuilder endpoints,
        string pattern)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        if (string.IsNullOrEmpty(pattern))
        {
            pattern = "/assembly-informations";
        }

        endpoints
            .MapGet(pattern, async context =>
            {
                var jsonSerializerOptions = JsonSerializerOptionsFactory.Create(
                    new JsonSerializerFactorySettings
                    {
                        UseConverterVersion = true,
                    });

                var assemblyInformations = AppDomain.CurrentDomain.GetAssemblyInformations();
                var response = JsonSerializer.Serialize(assemblyInformations, jsonSerializerOptions);
                await context.Response.WriteAsync(response);
            })
            .WithMetadata(new AllowAnonymousAttribute())
            .WithGroupName("API-Management");
    }
}