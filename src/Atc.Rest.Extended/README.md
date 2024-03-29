# Atc.Rest.Extended

This library extends the `Atc.Rest` library with the following features

- Versioning
- Fluent validation (on top on data-annotations validation)
- OpenApi specification (Swagger)

### Requirements

* [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Code documentation

[References](dhttps://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.Rest.Extended/Index.md)

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