using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Atc;
using Atc.Rest;
using Atc.Rest.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;

// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault
// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class RestApiExtensions
    {
        public static IServiceCollection AddRestApi<TStartup>(this IServiceCollection services)
        {
            return services.AddRestApi<TStartup>(mvc => { }, new RestApiOptions());
        }

        public static IServiceCollection AddRestApi<TStartup>(
            this IServiceCollection services,
            RestApiOptions restApiOptions)
        {
            return services.AddRestApi<TStartup>(mvc => { }, restApiOptions);
        }

        // ReSharper disable once UnusedTypeParameter
        [SuppressMessage("Major Code Smell", "S2326:Unused type parameters should be removed", Justification = "OK. Due to pattern for base class.")]
        public static IServiceCollection AddRestApi<TStartup>(
            this IServiceCollection services,
            Action<IMvcBuilder> setupMvcAction,
            RestApiOptions restApiOptions)
        {
            if (setupMvcAction == null)
            {
                throw new ArgumentNullException(nameof(setupMvcAction));
            }

            if (restApiOptions == null)
            {
                throw new ArgumentNullException(nameof(restApiOptions));
            }

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IRequestContext, RequestContext>();
            services.ConfigureOptions<ConfigureApiBehaviorOptions>();

            if (restApiOptions.UseApplicationInsights)
            {
                services.AddApplicationInsightsTelemetry();
                services.AddCallingIdentityTelemetryInitializer();
            }

            HandleAssemblyPairs(services, restApiOptions);

            var mvc = services
                .AddControllers(mvcOptions =>
                {
                    if (restApiOptions.ErrorHandlingExceptionFilter.Enable)
                    {
                        mvcOptions.Filters.Add(
                            new ErrorHandlingExceptionFilterAttribute(
                                restApiOptions.ErrorHandlingExceptionFilter.IncludeExceptionDetails,
                                restApiOptions.ErrorHandlingExceptionFilter.UseProblemDetailsAsResponseBody));
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

                    jsonOptions.JsonSerializerOptions.IgnoreNullValues = restApiOptions.UseJsonSerializerOptionsIgnoreNullValues;
                    jsonOptions.JsonSerializerOptions.WriteIndented = false;
                    jsonOptions.JsonSerializerOptions.AllowTrailingCommas = false;

                    if (restApiOptions.UseEnumAsStringInSerialization)
                    {
                        jsonOptions.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    }
                });

            if (restApiOptions.AllowAnonymousAccessForDevelopment)
            {
                services.AddAnonymousAccessForDevelopment();
            }

            setupMvcAction(mvc);

            return services;
        }

        private static void HandleAssemblyPairs(IServiceCollection services, RestApiOptions restApiOptions)
        {
            if (restApiOptions == null)
            {
                throw new ArgumentNullException(nameof(restApiOptions));
            }

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
}