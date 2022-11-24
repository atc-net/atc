// ReSharper disable InvertIf
namespace Atc.Rest.Extended.Options;

internal class ConfigureSwaggerOptions :
    IConfigureOptions<SwaggerUIOptions>,
    IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider versionDescriptionProvider;
    private readonly RestApiExtendedOptions restApiOptions;

    public ConfigureSwaggerOptions(
        IApiVersionDescriptionProvider versionDescriptionProvider,
        RestApiExtendedOptions restApiOptions)
    {
        this.versionDescriptionProvider = versionDescriptionProvider ?? throw new ArgumentNullException(nameof(versionDescriptionProvider));
        this.restApiOptions = restApiOptions ?? throw new ArgumentNullException(nameof(restApiOptions));
    }

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
                            Title = Assembly.GetEntryAssembly()!.GetApiName(),
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