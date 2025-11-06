# Atc.Rest.Extended

**Target Framework:** `net9.0`

Advanced REST API features extending Atc.Rest with API versioning, FluentValidation, Swagger/OpenAPI documentation, and JWT authentication. This library builds on the foundation of Atc.Rest to provide enterprise-ready API capabilities.

## Why Use This Library?

Atc.Rest.Extended adds production-ready features on top of Atc.Rest, providing everything needed for modern, versioned, and well-documented APIs. Instead of manually configuring multiple libraries, Atc.Rest.Extended provides:

- **API Versioning**: Built-in support for versioning your REST APIs
- **FluentValidation**: Advanced validation beyond data annotations
- **Swagger/OpenAPI**: Automatic API documentation with SwaggerUI
- **JWT Authentication**: Integrated JWT bearer token authentication
- **Extended Configuration**: All Atc.Rest features plus advanced options

Perfect for:
- Enterprise APIs requiring versioning
- APIs needing comprehensive request validation
- Public APIs requiring OpenAPI/Swagger documentation
- Microservices with JWT authentication
- Teams adopting API-first development

## Installation

```bash
dotnet add package Atc.Rest.Extended
```

## Target Framework

- .NET 9.0

## Key Features

- API versioning with Asp.Versioning
- FluentValidation for complex validation rules
- Swagger/OpenAPI specification generation
- SwaggerUI for interactive API documentation
- JWT Bearer authentication support
- All features from Atc.Rest

## Requirements

- [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

## Key Dependencies

- Atc.Rest (base library)
- Asp.Versioning.Mvc.ApiExplorer
- FluentValidation.AspNetCore
- Swashbuckle.AspNetCore
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.ApplicationInsights.AspNetCore

## Code documentation

[References](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.Rest.Extended/Index.md)

[References extended](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.Rest.Extended/IndexExtended.md)

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
        restApiOptions = new RestApiExtendedOptions
        {
            // Base
            AllowAnonymousAccessForDevelopment = true,
            UseApplicationInsights = true,
            UseAutoRegistrateServices = true,
            UseValidateServiceRegistrations = true,
            UseEnumAsStringInSerialization = true,
            UseHttpContextAccessor = true,
            ErrorHandlingExceptionFilter = new RestApiOptionsErrorHandlingExceptionFilter
            {
                Enable = true,
                UseProblemDetailsAsResponseBody = true,
                IncludeExceptionDetails = true,
            },
            UseRequireHttpsPermanent = true,
            UseJsonSerializerOptionsIgnoreNullValues = true,
            JsonSerializerCasingStyle = CasingStyle.CamelCase,

            // Extended
            UseApiVersioning = true,
            UseFluentValidation = true,
            UseOpenApiSpec = true,
        };

        restApiOptions.AddAssemblyPairs(
            Assembly.GetAssembly(typeof(ApiRegistration)),
            Assembly.GetAssembly(typeof(DomainRegistration)));
    }

    public IConfiguration Configuration { get; }

    private readonly RestApiExtendedOptions restApiOptions;

    public void ConfigureServices(IServiceCollection services)
    {
        if (!restApiOptions.UseAutoRegistrateServices)
        {
            // Manual ConfigureServices
            services.ConfigureServices();
        }

        services.ConfigureOptions<ConfigureSwaggerOptions>();
        services.AddRestApi<Startup>(restApiOptions, Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.ConfigureRestApi(env, restApiOptions);
    }
}
```
## Contributing

Contributions are welcome! Please see the main [repository README](../../README.md) for contribution guidelines.
