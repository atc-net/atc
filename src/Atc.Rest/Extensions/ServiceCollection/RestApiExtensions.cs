// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault
// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class RestApiExtensions
{
    public static IServiceCollection AddRestApi<TStartup>(this IServiceCollection services)
    {
        return services.AddRestApi<TStartup>(_ => { }, new RestApiOptions());
    }

    public static IServiceCollection AddRestApi<TStartup>(
        this IServiceCollection services,
        RestApiOptions restApiOptions)
    {
        return services.AddRestApi<TStartup>(_ => { }, restApiOptions);
    }

    // ReSharper disable once UnusedTypeParameter
    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    [SuppressMessage("Major Code Smell", "S2326:Unused type parameters should be removed", Justification = "OK. Due to pattern for base class.")]
    public static IServiceCollection AddRestApi<TStartup>(
        this IServiceCollection services,
        Action<IMvcBuilder> setupMvcAction,
        RestApiOptions restApiOptions)
    {
        ArgumentNullException.ThrowIfNull(setupMvcAction);
        ArgumentNullException.ThrowIfNull(restApiOptions);

        if (restApiOptions.UseHttpContextAccessor)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IRequestContext, RequestContext>();
        }

        services.ConfigureOptions<ConfigureApiBehaviorOptions>();

        if (restApiOptions.UseApplicationInsights)
        {
            services.AddApplicationInsightsTelemetry();
            services.AddCallingIdentityTelemetryInitializer();
        }

        HandleAssemblyPairs(services, restApiOptions);

        if (restApiOptions.ErrorHandlingExceptionFilter.Enable)
        {
            services.AddSingleton<ErrorHandlingExceptionFilterAttribute>();
        }

        var mvc = services
            .AddControllers(mvcOptions =>
            {
                if (restApiOptions.ErrorHandlingExceptionFilter.Enable)
                {
                    mvcOptions.Filters.AddService<ErrorHandlingExceptionFilterAttribute>();
                }

                mvcOptions.OutputFormatters.RemoveType<StringOutputFormatter>();
                mvcOptions.RequireHttpsPermanent = restApiOptions.UseRequireHttpsPermanent;
            })
            .AddJsonOptions(jsonOptions =>
            {
                switch (restApiOptions.JsonSerializerCasingStyle)
                {
                    case CasingStyle.CamelCase:
                        jsonOptions.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                        jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                        break;
                    case CasingStyle.PascalCase:
                        jsonOptions.JsonSerializerOptions.DictionaryKeyPolicy = null;
                        jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
                        break;
                    default:
                        throw new SwitchCaseDefaultException(restApiOptions.JsonSerializerCasingStyle);
                }

                jsonOptions.JsonSerializerOptions.DefaultIgnoreCondition = restApiOptions.UseJsonSerializerOptionsIgnoreNullValues
                        ? JsonIgnoreCondition.WhenWritingNull
                        : JsonIgnoreCondition.Never;
                jsonOptions.JsonSerializerOptions.WriteIndented = false;
                jsonOptions.JsonSerializerOptions.AllowTrailingCommas = false;

                if (restApiOptions.UseEnumAsStringInSerialization)
                {
                    jsonOptions.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                }
            });

        services.AddSingleton(restApiOptions);
        services.AddAnonymousAccessForDevelopment();

        setupMvcAction(mvc);

        return services;
    }

    private static void HandleAssemblyPairs(IServiceCollection services, RestApiOptions restApiOptions)
    {
        ArgumentNullException.ThrowIfNull(restApiOptions);

        if (restApiOptions.AssemblyPairs.Count == 0)
        {
            return;
        }

        if (restApiOptions.UseAutoRegistrateServices)
        {
            foreach (var assemblyPairOptions in restApiOptions.AssemblyPairs)
            {
                services.AutoRegistrateServices(
                    assemblyPairOptions.ApiAssembly,
                    assemblyPairOptions.DomainAssembly);
            }
        }

        if (!restApiOptions.UseValidateServiceRegistrations)
        {
            return;
        }

        foreach (var assemblyPairOptions in restApiOptions.AssemblyPairs)
        {
            services.ValidateServiceRegistrations(assemblyPairOptions.ApiAssembly);
        }
    }
}