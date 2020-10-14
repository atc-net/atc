using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Atc.Data.Models;
using Atc.Rest.ApiGenerator.Models;
using Microsoft.OpenApi.Models;

// ReSharper disable UseDeconstruction
// ReSharper disable SwitchStatementMissingSomeEnumCasesNoDefault
namespace Atc.Rest.ApiGenerator.Helpers.XunitTest
{
    public static class GenerateServerApiXunitTestEndpointTestHelper
    {
        public static LogKeyValueItem Generate(HostProjectOptions hostProjectOptions, EndpointMethodMetadata endpointMethodMetadata)
        {
            if (hostProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(hostProjectOptions));
            }

            if (endpointMethodMetadata == null)
            {
                throw new ArgumentNullException(nameof(endpointMethodMetadata));
            }

            var sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.CodeDom.Compiler;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Net;");
            sb.AppendLine("using System.Net.Http;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using FluentAssertions;");
            if (endpointMethodMetadata.IsPaginationUsed())
            {
                sb.AppendLine($"using {hostProjectOptions.ProjectName}.Generated;");
            }

            sb.AppendLine($"using {hostProjectOptions.ProjectName}.Generated.Contracts;");
            sb.AppendLine($"using {hostProjectOptions.ProjectName}.Generated.Contracts.{endpointMethodMetadata.SegmentName};");
            sb.AppendLine("using Xunit;");
            sb.AppendLine();
            GenerateCodeHelper.AppendNamespaceComment(sb, hostProjectOptions.ToolNameAndVersion);
            sb.AppendLine($"namespace {hostProjectOptions.ProjectName}.Tests.Endpoints.{endpointMethodMetadata.SegmentName}.Generated");
            sb.AppendLine("{");
            GenerateCodeHelper.AppendGeneratedCodeAttribute(sb, hostProjectOptions.ToolName, hostProjectOptions.ToolVersion);
            sb.AppendLine(4, $"public class {endpointMethodMetadata.MethodName}Tests : WebApiControllerBaseTest");
            sb.AppendLine(4, "{");
            sb.AppendLine(8, $"public {endpointMethodMetadata.MethodName}Tests(WebApiStartupFactory fixture) : base(fixture) {{ }}");
            foreach (var contractReturnTypeName in endpointMethodMetadata.ContractReturnTypeNames)
            {
                switch (contractReturnTypeName.Item1)
                {
                    case HttpStatusCode.OK:
                        AppendTest200Ok(sb, endpointMethodMetadata, contractReturnTypeName!);
                        break;
                    case HttpStatusCode.Created:
                        AppendTest201Created(sb, endpointMethodMetadata, contractReturnTypeName!);
                        break;
                    case HttpStatusCode.BadRequest:
                        AppendTest400BadRequestInPath(sb, endpointMethodMetadata, endpointMethodMetadata.HttpOperation);
                        AppendTest400BadRequestInHeader(sb, endpointMethodMetadata, endpointMethodMetadata.HttpOperation);
                        AppendTest400BadRequestInQuery(sb, endpointMethodMetadata, endpointMethodMetadata.HttpOperation);
                        AppendTest400BadRequestInBody(sb, endpointMethodMetadata, endpointMethodMetadata.HttpOperation);
                        break;
                }
            }

            sb.AppendLine(4, "}");
            sb.AppendLine("}");

            var pathA = Path.Combine(hostProjectOptions.PathForTestGenerate!.FullName, "Endpoints");
            var pathB = Path.Combine(pathA, endpointMethodMetadata.SegmentName);
            var pathC = Path.Combine(pathB, "Generated");
            var fileName = $"{endpointMethodMetadata.MethodName}Tests.cs";
            var file = new FileInfo(Path.Combine(pathC, fileName));
            return TextFileHelper.Save(file, sb.ToString());
        }

        private static void AppendTest200Ok(StringBuilder sb, EndpointMethodMetadata endpointMethodMetadata, Tuple<HttpStatusCode, string, OpenApiSchema> contractReturnTypeName)
        {
            var renderRelativeRefs = RenderRelativeRefs(endpointMethodMetadata);
            if (renderRelativeRefs.Count == 0)
            {
                return;
            }

            sb.AppendLine();
            sb.AppendLine(8, "[Theory]");
            foreach (var renderRelativeRef in renderRelativeRefs)
            {
                sb.AppendLine(8, $"[InlineData(\"{renderRelativeRef}\")]");
            }

            sb.AppendLine(8, $"public async Task {endpointMethodMetadata.MethodName}_Ok(string relativeRef)");
            sb.AppendLine(8, "{");
            if (endpointMethodMetadata.HasContractParameterRequestBody())
            {
                sb.AppendLine(12, "// Arrange");
                AppendNewRequestModel(12, sb, endpointMethodMetadata, HttpStatusCode.OK);

                var headerParameters = endpointMethodMetadata.GetHeaderParameters();
                if (headerParameters.Count > 0)
                {
                    sb.AppendLine();
                    foreach (var headerParameter in headerParameters)
                    {
                        string propertyValueGenerated = PropertyValueGenerator(headerParameter, endpointMethodMetadata.ComponentsSchemas, false, null);
                        sb.AppendLine(
                            12,
                            $"HttpClient.DefaultRequestHeaders.Add(\"{headerParameter.Name}\", \"{propertyValueGenerated}\");");
                    }
                }

                sb.AppendLine();
                sb.AppendLine(12, "// Act");
                sb.AppendLine(12, $"var response = await HttpClient.{endpointMethodMetadata.HttpOperation}Async(relativeRef, ToJson(data));");
            }
            else
            {
                sb.AppendLine(12, "// Act");
                sb.AppendLine(12, $"var response = await HttpClient.{endpointMethodMetadata.HttpOperation}Async(relativeRef);");
            }

            sb.AppendLine();
            sb.AppendLine(12, "// Assert");
            sb.AppendLine(12, "response.Should().NotBeNull();");
            sb.AppendLine(12, "response.StatusCode.Should().Be(HttpStatusCode.OK);");
            if (!string.IsNullOrEmpty(contractReturnTypeName.Item2) && contractReturnTypeName.Item2 != "string")
            {
                sb.AppendLine();
                sb.AppendLine(12, $"var data = await response.DeserializeAsync<{contractReturnTypeName.Item2}>(JsonSerializerOptions);");
                sb.AppendLine(12, "data.Should().NotBeNull();");
            }

            sb.AppendLine(8, "}");
        }

        private static void AppendTest201Created(StringBuilder sb, EndpointMethodMetadata endpointMethodMetadata, Tuple<HttpStatusCode, string, OpenApiSchema> contractReturnTypeName)
        {
            var renderRelativeRefs = RenderRelativeRefs(endpointMethodMetadata);
            if (renderRelativeRefs.Count == 0)
            {
                return;
            }

            sb.AppendLine();
            sb.AppendLine(8, "[Theory]");
            foreach (var renderRelativeRef in renderRelativeRefs)
            {
                sb.AppendLine(8, $"[InlineData(\"{renderRelativeRef}\")]");
            }

            sb.AppendLine(8, $"public async Task {endpointMethodMetadata.MethodName}_Created(string relativeRef)");
            sb.AppendLine(8, "{");
            if (endpointMethodMetadata.HasContractParameterRequestBody())
            {
                sb.AppendLine(12, "// Arrange");
                AppendNewRequestModel(12, sb, endpointMethodMetadata, HttpStatusCode.Created);
                sb.AppendLine();
                sb.AppendLine(12, "// Act");
                sb.AppendLine(12, "var response = await HttpClient.PostAsync(relativeRef, ToJson(data));");
            }
            else
            {
                sb.AppendLine(12, "// Arrange");
                sb.AppendLine(12, "var stringContent = new StringContent(\"\");");
                sb.AppendLine();
                sb.AppendLine(12, "// Act");
                sb.AppendLine(12, "var response = await HttpClient.PostAsync(relativeRef, stringContent);");
            }

            sb.AppendLine();
            sb.AppendLine(12, "// Assert");
            sb.AppendLine(12, "response.Should().NotBeNull();");
            sb.AppendLine(12, "response.StatusCode.Should().Be(HttpStatusCode.Created);");
            if (!string.IsNullOrEmpty(contractReturnTypeName.Item2) && contractReturnTypeName.Item2 != "string")
            {
                sb.AppendLine();
                sb.AppendLine(12, $"var data = await response.DeserializeAsync<{contractReturnTypeName.Item2}>(JsonSerializerOptions);");
                sb.AppendLine(12, "data.Should().NotBeNull();");
            }

            sb.AppendLine(8, "}");
        }

        private static void AppendTest400BadRequestInPath(StringBuilder sb, EndpointMethodMetadata endpointMethodMetadata, OperationType operationType)
        {
            var renderRelativeRefs = RenderRelativeRefsForPath(endpointMethodMetadata, true);
            if (renderRelativeRefs.Count == 0)
            {
                return;
            }

            sb.AppendLine();
            sb.AppendLine(8, "[Theory]");
            foreach (var renderRelativeRef in renderRelativeRefs)
            {
                sb.AppendLine(8, $"[InlineData(\"{renderRelativeRef}\")]");
            }

            sb.AppendLine(8, $"public async Task {endpointMethodMetadata.MethodName}_BadRequest_InPath(string relativeRef)");
            sb.AppendLine(8, "{");
            switch (operationType)
            {
                case OperationType.Get:
                    sb.AppendLine(12, "// Act");
                    sb.AppendLine(12, "var response = await HttpClient.GetAsync(relativeRef);");
                    break;
                case OperationType.Put:
                    sb.AppendLine(12, "// Arrange");
                    sb.AppendLine(12, "var stringContent = new StringContent(\"\");");
                    sb.AppendLine();
                    sb.AppendLine(12, "// Act");
                    sb.AppendLine(12, "var response = await HttpClient.PutAsync(relativeRef, stringContent);");
                    break;
                case OperationType.Post:
                    sb.AppendLine(12, "// Arrange");
                    sb.AppendLine(12, "var stringContent = new StringContent(\"\");");
                    sb.AppendLine();
                    sb.AppendLine(12, "// Act");
                    sb.AppendLine(12, "var response = await HttpClient.PostAsync(relativeRef, stringContent);");
                    break;
                case OperationType.Delete:
                    sb.AppendLine(12, "// Act");
                    sb.AppendLine(12, "var response = await HttpClient.DeleteAsync(relativeRef);");
                    break;
                case OperationType.Patch:
                    sb.AppendLine(12, "// Arrange");
                    sb.AppendLine(12, "var stringContent = new StringContent(\"\");");
                    sb.AppendLine();
                    sb.AppendLine(12, "// Act");
                    sb.AppendLine(12, "var response = await HttpClient.PatchAsync(relativeRef, stringContent);");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operationType), operationType, null);
            }

            sb.AppendLine();
            sb.AppendLine(12, "// Assert");
            sb.AppendLine(12, "response.Should().NotBeNull();");
            sb.AppendLine(12, "response.StatusCode.Should().Be(HttpStatusCode.BadRequest);");
            sb.AppendLine(8, "}");
        }

        private static void AppendTest400BadRequestInHeader(StringBuilder sb, EndpointMethodMetadata endpointMethodMetadata, OperationType operationType)
        {
            // TO-DO: Imp this.
        }

        private static void AppendTest400BadRequestInQuery(StringBuilder sb, EndpointMethodMetadata endpointMethodMetadata, OperationType operationType)
        {
            if (endpointMethodMetadata.GetQueryParameters().Count == 0)
            {
                return;
            }

            var renderRelativeRefs = RenderRelativeRefsForQuery(endpointMethodMetadata, true);
            if (renderRelativeRefs.Count == 0)
            {
                return;
            }

            sb.AppendLine();
            sb.AppendLine(8, "[Theory]");
            foreach (var renderRelativeRef in renderRelativeRefs)
            {
                sb.AppendLine(8, $"[InlineData(\"{renderRelativeRef}\")]");
            }

            sb.AppendLine(8, $"public async Task {endpointMethodMetadata.MethodName}_BadRequest_InQuery(string relativeRef)");
            sb.AppendLine(8, "{");
            switch (operationType)
            {
                case OperationType.Get:
                    sb.AppendLine(12, "// Act");
                    sb.AppendLine(12, "var response = await HttpClient.GetAsync(relativeRef);");
                    break;
                case OperationType.Put:
                    sb.AppendLine(12, "// Arrange");
                    sb.AppendLine(12, "var stringContent = new StringContent(\"\");");
                    sb.AppendLine();
                    sb.AppendLine(12, "// Act");
                    sb.AppendLine(12, "var response = await HttpClient.PutAsync(relativeRef, stringContent);");
                    break;
                case OperationType.Post:
                    sb.AppendLine(12, "// Arrange");
                    sb.AppendLine(12, "var stringContent = new StringContent(\"\");");
                    sb.AppendLine();
                    sb.AppendLine(12, "// Act");
                    sb.AppendLine(12, "var response = await HttpClient.PostAsync(relativeRef, stringContent);");
                    break;
                case OperationType.Delete:
                    sb.AppendLine(12, "// Act");
                    sb.AppendLine(12, "var response = await HttpClient.DeleteAsync(relativeRef);");
                    break;
                case OperationType.Patch:
                    sb.AppendLine(12, "// Arrange");
                    sb.AppendLine(12, "var stringContent = new StringContent(\"\");");
                    sb.AppendLine();
                    sb.AppendLine(12, "// Act");
                    sb.AppendLine(12, "var response = await HttpClient.PatchAsync(relativeRef, stringContent);");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operationType), operationType, null);
            }

            sb.AppendLine();
            sb.AppendLine(12, "// Assert");
            sb.AppendLine(12, "response.Should().NotBeNull();");
            sb.AppendLine(12, "response.StatusCode.Should().Be(HttpStatusCode.BadRequest);");
            sb.AppendLine(8, "}");
        }

        private static void AppendTest400BadRequestInBody(StringBuilder sb, EndpointMethodMetadata endpointMethodMetadata, OperationType operationType)
        {
            // TO-DO: Imp this.
        }

        private static void AppendNewRequestModel(int indentSpaces, StringBuilder sb, EndpointMethodMetadata endpointMethodMetadata, HttpStatusCode httpStatusCode, string variableName = "data")
        {
            var schema = endpointMethodMetadata.ContractParameter?.ApiOperation.RequestBody?.Content.GetSchema();
            if (schema == null)
            {
                return;
            }

            GenerateXunitTestHelper.AppendNewModelOrListOfModel(indentSpaces, sb, endpointMethodMetadata, schema, httpStatusCode, variableName);
        }

        private static List<string> RenderRelativeRefs(EndpointMethodMetadata endpointMethodMetadata, bool useForBadRequest = false)
        {
            var renderRelativeRefs = new List<string>();

            var queryRequiredParameters = endpointMethodMetadata.GetQueryRequiredParameters();
            if (queryRequiredParameters.Count == 0)
            {
                // Create without queryParameters
                renderRelativeRefs.Add(RenderRelativeRef(endpointMethodMetadata, null, useForBadRequest));
            }
            else
            {
                var queryParameters = endpointMethodMetadata.GetQueryParameters();
                var combinationOfQueryParameters = new List<List<OpenApiParameter>>();

                // Add all
                combinationOfQueryParameters.Add(queryParameters);

                foreach (var combination in combinationOfQueryParameters)
                {
                    renderRelativeRefs.Add(RenderRelativeRef(endpointMethodMetadata, combination, useForBadRequest));
                }
            }

            return renderRelativeRefs;
        }

        private static List<string> RenderRelativeRefsForPath(EndpointMethodMetadata endpointMethodMetadata, bool useForBadRequest = false)
        {
            var renderRelativeRefs = new List<string>();

            ////var queryRequiredParameters = endpointMethodMetadata.GetQueryRequiredParameters();
            ////if (queryRequiredParameters.Count == 0)
            ////{
            ////    // Create without queryParameters
            ////    renderRelativeRefs.Add(RenderRelativeRef(endpointMethodMetadata, null, useForBadRequest));
            ////}
            ////else
            ////{
            ////    var queryParameters = endpointMethodMetadata.GetQueryParameters();
            ////    var combinationOfQueryParameters = new List<List<OpenApiParameter>>();

            ////    // Add all
            ////    combinationOfQueryParameters.Add(queryParameters);

            ////    foreach (var combination in combinationOfQueryParameters)
            ////    {
            ////        renderRelativeRefs.Add(RenderRelativeRef(endpointMethodMetadata, combination, useForBadRequest));
            ////    }
            ////}

            return renderRelativeRefs;
        }

        private static List<string> RenderRelativeRefsForQuery(EndpointMethodMetadata endpointMethodMetadata, bool useForBadRequest = false)
        {
            var renderRelativeRefs = new List<string>();

            var queryParameters = endpointMethodMetadata.GetQueryParameters();
            if (queryParameters.Count == 0)
            {
                return renderRelativeRefs;
            }

            // TO-DO: DKA is working on this.
            ////var queryRequiredParameters = endpointMethodMetadata.GetQueryRequiredParameters();
            ////var combinationOfQueryParameters = new List<List<OpenApiParameter>>();

            ////// Add all
            ////combinationOfQueryParameters.Add(queryParameters);

            ////foreach (var combination in combinationOfQueryParameters)
            ////{
            ////    renderRelativeRefs.Add(RenderRelativeRef(endpointMethodMetadata, combination, useForBadRequest));
            ////}

            return renderRelativeRefs;
        }

        private static string RenderRelativeRef(EndpointMethodMetadata endpointMethodMetadata, List<OpenApiParameter>? queryParameters, bool useForBadRequest)
        {
            var route = endpointMethodMetadata.Route;
            if (endpointMethodMetadata.ContractParameter == null)
            {
                return route;
            }

            var routeParameters = endpointMethodMetadata.GetRouteParameters();
            string relativeRefPath = RenderRelativeRefPath(route, routeParameters, endpointMethodMetadata.ComponentsSchemas, useForBadRequest);

            if (queryParameters == null || queryParameters.Count == 0)
            {
                return relativeRefPath;
            }

            string relativeRefQuery = RenderRelativeRefQuery(queryParameters, endpointMethodMetadata.ComponentsSchemas, useForBadRequest);
            return $"{relativeRefPath}{relativeRefQuery}";
        }

        private static string RenderRelativeRefPath(string route, List<OpenApiParameter> routeParameters, IDictionary<string, OpenApiSchema> componentsSchemas, bool useForBadRequest)
        {
            var sa = route.Split('/');
            for (int i = 0; i < sa.Length; i++)
            {
                if (!sa[i].Contains("{", StringComparison.Ordinal))
                {
                    continue;
                }

                var pn = sa[i]
                    .Replace("{", string.Empty, StringComparison.Ordinal)
                    .Replace("}", string.Empty, StringComparison.Ordinal);

                var fromRoute = routeParameters.Find(x => x.Name == pn);
                sa[i] = PropertyValueGenerator(fromRoute, componentsSchemas, useForBadRequest, null);
            }

            return string.Join('/', sa);
        }

        private static string RenderRelativeRefQuery(List<OpenApiParameter> queryParameters, IDictionary<string, OpenApiSchema> componentsSchemas, bool useForBadRequest)
        {
            var sb = new StringBuilder();
            sb.Append('?');
            foreach (var queryParameter in queryParameters)
            {
                var val = PropertyValueGenerator(queryParameter, componentsSchemas, useForBadRequest, null);
                sb.Append($"&{queryParameter.Name}={val}");
            }

            return sb.ToString().Replace("?&", "?", StringComparison.Ordinal);
        }

        private static string PropertyValueGenerator(OpenApiParameter parameter, IDictionary<string, OpenApiSchema> componentsSchemas, bool useForBadRequest, string? customValue)
        {
            // Match on OpenApiSchemaExtensions->GetDataType
            return parameter.Schema.GetDataType() switch
            {
                "double" => ValueTypeTestPropertiesHelper.CreateValueDouble(),
                "long" => ValueTypeTestPropertiesHelper.Number(parameter.Name, useForBadRequest),
                "int" => ValueTypeTestPropertiesHelper.Number(parameter.Name, useForBadRequest),
                "bool" => ValueTypeTestPropertiesHelper.CreateValueBool(),
                "string" => ValueTypeTestPropertiesHelper.CreateValueString(parameter.Name, parameter.Schema.Format, useForBadRequest, 0, customValue),
                "DateTimeOffset" => ValueTypeTestPropertiesHelper.CreateValueDateTimeOffset(useForBadRequest),
                "Guid" => ValueTypeTestPropertiesHelper.CreateValueGuid(useForBadRequest),
                "Uri" => ValueTypeTestPropertiesHelper.CreateValueUri(useForBadRequest),
                _ => PropertyValueGeneratorTypeResolver(parameter, componentsSchemas, useForBadRequest)
            };
        }

        private static string PropertyValueGeneratorTypeResolver(OpenApiParameter parameter, IDictionary<string, OpenApiSchema> componentsSchemas, bool useForBadRequest)
        {
            var name = parameter.Name.EnsureFirstCharacterToUpper();
            var schemaForDataType = componentsSchemas.FirstOrDefault(x => x.Key.Equals(parameter.Schema.GetDataType(), StringComparison.OrdinalIgnoreCase));
            if (schemaForDataType.Key != null)
            {
                if (schemaForDataType.Value.IsSchemaEnumOrPropertyEnum())
                {
                    return ValueTypeTestPropertiesHelper.CreateValueEnum(name, schemaForDataType, useForBadRequest);
                }
            }

            throw new NotSupportedException($"PropertyValueGenerator: {parameter.Name} - {parameter.Schema.GetDataType()}");
        }
    }
}