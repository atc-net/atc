# Atc.Rest.HealthChecks

**Target Framework:** `net9.0`, `net10.0`

Health check implementations and utilities for ASP.NET Core applications. Provides factories and helpers for creating JSON-formatted health check endpoints with detailed resource status information.

## Why Use This Library?

Building robust health check endpoints requires consistent formatting and detailed status information. Atc.Rest.HealthChecks simplifies this by providing:

- **JSON Health Check Responses**: Factory methods for JSON-formatted health checks
- **Resource Health Tracking**: Track individual service/resource health status
- **Detailed Diagnostics**: Include timing, status, and error details for each check
- **IReadOnlyDictionary Conversion**: Helper extensions for health check data
- **Production-Ready Endpoints**: Standardized health check responses

Perfect for:
- Microservices requiring health endpoints
- Kubernetes/container orchestration health probes
- Load balancer health checks
- Monitoring and observability solutions
- API management platforms

## Installation

```bash
dotnet add package Atc.Rest.HealthChecks
```

## Target Framework

- .NET 9.0

## Key Features

- `HealthCheckOptionsFactory` for creating JSON health check endpoints
- `ResourceHealthCheck` class for tracking individual resource status
- Extension methods for converting health data to IReadOnlyDictionary
- Integration with Microsoft.Extensions.Diagnostics.HealthChecks
- Support for custom health check implementations

## Requirements

- [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

## Key Dependencies

- Microsoft.AspNetCore.App (framework reference)
- Microsoft.Extensions.Diagnostics.HealthChecks
- Atc (foundation library)

## Code documentation

[References](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.Rest.HealthChecks/Index.md)

[References extended](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.Rest.HealthChecks/IndexExtended.md)

## Examples

### The `Startup.cs` class in an API

```csharp
using Microsoft.Extensions.Diagnostics.HealthChecks;

public class Startup
{
    private readonly JsonSerializerOptions jsonSerializerOptions;

    public Startup()
    {
        jsonSerializerOptions = Atc.Serialization.JsonSerializerOptionsFactory.Create();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddHealthChecks()
                .AddCheck<MyHealthCheck>(
                    name: "MyHealthCheck",
                    failureStatus: HealthStatus.Unhealthy,
                    timeout: TimeSpan.FromSeconds(30));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHealthChecks(
                "/health",
                HealthCheckOptionsFactory.CreateJson(
                    "ApplicationName.Api",
                    jsonSerializerOptions));
        });
    }
}
```

### The `MyHealthCheck` class

```csharp
public class MyHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        var data = new List<ResourceHealthCheck>();

        CheckSomeServices(data);

        if (data.All(x => x.Status == HealthStatus.Healthy))
        {
            return Task.FromResult(
                HealthCheckResult.Healthy(
                    "ApplicationName is healthy.",
                    data: data.ToIReadOnlyDictionary()));
        }

        return Task.FromResult(
            HealthCheckResult.Unhealthy(
                "ApplicationName is unhealthy.",
                exception: null,
                data: data.ToIReadOnlyDictionary()));
    }

    private void CheckSomeServices(
        ICollection<ResourceHealthCheck> data)
    {
        var sw = Stopwatch.StartNew();

        // Perform first HealthCheck and add a healthCheck to the data dictionary
        data.Add(
            new ResourceHealthCheck(
                "Service1",
                HealthStatus.Healthy,
                "Service1 is running.",
                sw.Elapsed));

        // Perform second HealthCheck and add a healthCheck to the data dictionary
        sw.Reset();
        data.Add(
            new ResourceHealthCheck(
                "Service2",
                HealthStatus.Unhealthy,
                "Service2 is not running.",
                sw.Elapsed));

        sw.Stop();
    }
}
```
## Contributing

Contributions are welcome! Please see the main [repository README](../../README.md) for contribution guidelines.
