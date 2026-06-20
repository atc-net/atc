// ReSharper disable InvertIf
namespace Atc.Rest.Extended.Options;

/// <summary>
/// Configures Swagger UI and Swagger generation options with API versioning, security filters, and custom styling.
/// </summary>
internal sealed class ConfigureSwaggerOptions :
    IConfigureOptions<SwaggerUIOptions>,
    IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider versionDescriptionProvider;
    private readonly RestApiExtendedOptions restApiOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
    /// </summary>
    /// <param name="versionDescriptionProvider">The API version description provider.</param>
    /// <param name="restApiOptions">The REST API extended options.</param>
    public ConfigureSwaggerOptions(
        IApiVersionDescriptionProvider versionDescriptionProvider,
        RestApiExtendedOptions restApiOptions)
    {
        this.versionDescriptionProvider = versionDescriptionProvider ?? throw new ArgumentNullException(nameof(versionDescriptionProvider));
        this.restApiOptions = restApiOptions ?? throw new ArgumentNullException(nameof(restApiOptions));
    }

    /// <summary>
    /// Configures Swagger UI options including endpoints, styling, and behavior settings.
    /// </summary>
    /// <param name="options">The <see cref="SwaggerUIOptions"/> to configure.</param>
    public void Configure(SwaggerUIOptions options)
    {
        ConfigureSwaggerEndpointPerApiVersion(options);

        options.EnableValidator();
        options.DocExpansion(DocExpansion.List);
        options.SupportedSubmitMethods(SubmitMethod.Get, SubmitMethod.Post, SubmitMethod.Put, SubmitMethod.Patch, SubmitMethod.Delete);
        options.DefaultModelRendering(ModelRendering.Model);
        options.DisplayRequestDuration();
        options.EnableDeepLinking();
        options.ShowCommonExtensions();
        options.InjectStylesheet("/swagger-ui/style.css");
        options.InjectJavascript("/swagger-ui/main.js");
    }

    /// <summary>
    /// Configures Swagger generation options including API versioning, XML documentation, and security filters.
    /// </summary>
    /// <param name="options">The <see cref="SwaggerGenOptions"/> to configure.</param>
    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    public void Configure(SwaggerGenOptions options)
    {
        options.TagActionsBy(api =>
        {
            if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                return new[] { controllerActionDescriptor.ControllerName };
            }

            if (api.HttpMethod is not null)
            {
                return new[] { api.HttpMethod };
            }

            throw new InvalidOperationException("Unable to determine tag for endpoint.");
        });

        options.OrderActionsBy(apiDesc => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");
        options.IgnoreObsoleteActions();
        options.IgnoreObsoleteProperties();
        options.DefaultResponseForSecuredOperations();
        options.TreatBadRequestAsDefaultResponse();

        options.DocumentFilter<SwaggerEnumDescriptionsDocumentFilter>();

        if (restApiOptions.UseApiVersioning)
        {
            options.ApplyApiVersioningFilters();

            foreach (var description in versionDescriptionProvider.ApiVersionDescriptions)
            {
                try
                {
                    options.SwaggerDoc(
                        description.GroupName,
                        new OpenApiInfo
                        {
                            Title = (Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly()).GetApiName(),
                            Version = description.ApiVersion.ToString(),
                        });
                }
                catch (ArgumentException)
                {
                    // Ignore - This is here for backwards compatibility
                    // Newer generated API's will have its own implementation of IConfigureOptions<SwaggerGenOptions> that will use
                    // use the Info metadata specified in the OpenAPI specifications document
                }
            }
        }

        foreach (var assemblyPairOptions in restApiOptions.AssemblyPairs)
        {
            options.IncludeXmlComments(Path.ChangeExtension(assemblyPairOptions.ApiAssembly.Location, "xml"));
        }

        if (!restApiOptions.AllowAnonymousAccessForDevelopment)
        {
            options.OperationFilter<SecurityRequirementsOperationFilter>();
            options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

            var authOptions = restApiOptions.Authorization;
            if (authOptions?.IsSecurityEnabled() == true &&
                !string.IsNullOrEmpty(authOptions.Instance) &&
                !string.IsNullOrEmpty(authOptions.TenantId))
            {
                var baseUrl = authOptions.Instance.TrimEnd('/');
                var tenant = authOptions.TenantId;
                options.AddSecurityDefinition(
                    "OAuth2",
                    new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows
                        {
                            AuthorizationCode = new OpenApiOAuthFlow
                            {
                                AuthorizationUrl = new Uri($"{baseUrl}/{tenant}/oauth2/v2.0/authorize"),
                                TokenUrl = new Uri($"{baseUrl}/{tenant}/oauth2/v2.0/token"),
                                Scopes = new Dictionary<string, string>(StringComparer.Ordinal)
                                {
                                    [$"api://{authOptions.ClientId}/.default"] = "Default scope",
                                },
                            },
                        },
                    });
            }
        }
    }

    private void ConfigureSwaggerEndpointPerApiVersion(SwaggerUIOptions options)
    {
        if (restApiOptions.UseApiVersioning)
        {
            foreach (var description in versionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
        }
        else
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Default");
        }
    }
}