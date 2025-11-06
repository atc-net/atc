# Atc.Rest

**Target Framework:** `net9.0`

Foundation library for building ASP.NET Core Web APIs with standardized configuration, middleware, and error handling. Provides a streamlined setup for REST APIs with built-in support for common scenarios like JSON serialization, exception handling, and service registration.

## Why Use This Library?

Atc.Rest eliminates repetitive Web API configuration boilerplate and provides consistent, production-ready defaults for REST APIs. Instead of configuring the same middleware and services in every project, Atc.Rest provides:

- **Simplified Configuration**: Single-line setup with `RestApiOptions`
- **Standardized Error Handling**: ProblemDetails support with customizable exception filters
- **Automatic Service Registration**: Convention-based service discovery and registration
- **JSON Serialization Defaults**: Configurable casing styles, null handling, and enum serialization
- **Application Insights Integration**: Built-in telemetry support
- **Development Tools**: Anonymous access for debugging and detailed error messages

Perfect for:
- Building REST APIs with consistent patterns
- Microservices that need standardized configuration
- APIs requiring ProblemDetails RFC compliance
- Projects using Application Insights for monitoring

## Installation

```bash
dotnet add package Atc.Rest
```

## Target Framework

- .NET 9.0

## Key Features

- Allow anonymous access in debug-mode
- Enable ApplicationInsights telemetry
- Auto service registration using reflection
- Validation service registration
- Enum-as-string serialization
- Ignore null values in JSON responses
- Configurable JSON casing styles (camelCase, PascalCase, etc.)
- HttpContextAccessor registration
- Exception handling with middleware
- ProblemDetails RFC 7807 support
- Detailed exception messages for debugging
- HTTPS enforcement

## Requirements

- [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

## Key Dependencies

- Microsoft.AspNetCore.App (framework reference)
- Microsoft.ApplicationInsights.AspNetCore
- Atc (foundation library)

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
## Contributing

Contributions are welcome! Please see the main [repository README](../../README.md) for contribution guidelines.
