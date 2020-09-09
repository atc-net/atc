using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Atc.Rest.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Atc.Rest.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        private static readonly Dictionary<string, string> YamlCache = new Dictionary<string, string>();

        public static void MapApiSpecificationEndpoint(this IEndpointRouteBuilder endpoints, List<AssemblyPairOptions> assemblyPairs)
        {
            if (assemblyPairs == null)
            {
                throw new ArgumentNullException(nameof(assemblyPairs));
            }

            var yamlEndpoints = new List<string>();
            foreach (var assemblyPair in assemblyPairs)
            {
                var apiAssemblyName = assemblyPair.ApiAssembly.GetName().Name!;
                var resourceStream = assemblyPair.ApiAssembly.GetManifestResourceStream($"{apiAssemblyName}.Resources.ApiSpecification.yaml");
                if (resourceStream == null)
                {
                    continue;
                }

                var yamlEndpoint = $"{apiAssemblyName}.ApiSpecification.yaml";
                endpoints.Map(yamlEndpoint, async context =>
                {
                    string yaml;
                    if (YamlCache.ContainsKey(yamlEndpoint))
                    {
                        yaml = YamlCache[yamlEndpoint];
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
                endpoints.MapGet("/ApiSpecifications", async context =>
                {
                    var links = yamlEndpoints
                        .Select(yamlEndpoint => $"{context.Request.Scheme}://{context.Request.Host}/{yamlEndpoint}")
                        .ToList();
                    var response = JsonSerializer.Serialize(links);
                    await context.Response.WriteAsync(response);
                });
            }
        }
    }
}