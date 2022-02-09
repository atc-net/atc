# Atc.Rest

This library can be used to simplify a base setup for creating a Web-API in a .NET solution with feature-options:

- Allow anonymous access in debug-mode
- Enable ApplicationInsights
- Enable auto service registrering of services
- Enable validation service registration
- Enable Enum-As-String in serialization
- Enable ignore-null-values in serialization
- Set `CasingStyle` in serialization
- Enable HttpContextAccessor
- Enable exception handling
- Enable exception format as `ProblemDetails`
- Enable full detailed exception message with stack information
- Enforce Https over Http

### Requirements

* [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Code documentation

[References](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.Rest/Index.md)

[References extended](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.Rest/IndexExtended.md)

## `services.AddRestApi` and `app.ConfigureRestApi` examples

### Using - minimal setup

Example with a minimal setup in the `Startup.cs`

```csharp
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
        restApiOptions = new RestApiOptions
        restApiOptions.AddAssemblyPairs(
            Assembly.GetAssembly(typeof(ApiRegistration)),
            Assembly.GetAssembly(typeof(DomainRegistration)));
    }

    public IConfiguration Configuration { get; }

    private readonly RestApiOptions restApiOptions;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRestApi<Startup>(restApiOptions);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.ConfigureRestApi(env, restApiOptions);
    }
}
```

### Using - specified features setup

Example with specified features in the `Startup.cs`

```csharp
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
        restApiOptions = new RestApiOptions
        {
            // Base
            AllowAnonymousAccessForDevelopment = true,
            UseApplicationInsights = true,
            UseAutoRegistrateServices = true,
            UseValidateServiceRegistrations = true,
            UseHttpContextAccessor = true,
            ErrorHandlingExceptionFilter = new RestApiOptionsErrorHandlingExceptionFilter
            {
                Enable = true,
                UseProblemDetailsAsResponseBody = true,
                IncludeExceptionDetails = true,
            },
            UseRequireHttpsPermanent = true,
            UseEnumAsStringInSerialization = true,
            UseJsonSerializerOptionsIgnoreNullValues = true,
            JsonSerializerCasingStyle = CasingStyle.CamelCase,
        };

        restApiOptions.AddAssemblyPairs(
            Assembly.GetAssembly(typeof(ApiRegistration)),
            Assembly.GetAssembly(typeof(DomainRegistration)));
    }

    public IConfiguration Configuration { get; }

    private readonly RestApiOptions restApiOptions;

    public void ConfigureServices(IServiceCollection services)
    {
        if (!restApiOptions.UseAutoRegistrateServices)
        {
            // Manual ConfigureServices
            services.ConfigureServices();
        }

        services.AddRestApi<Startup>(restApiOptions);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.ConfigureRestApi(env, restApiOptions);
    }
}
```