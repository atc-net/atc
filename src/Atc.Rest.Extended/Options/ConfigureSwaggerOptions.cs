using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Atc.Rest.Extended.Options
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerUIOptions>
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
}