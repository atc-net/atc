# Atc.Rest.HealthChecks

This library contains features related to ASP-NET HealthChecks.

### Requirements

* [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

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