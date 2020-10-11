using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
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
        public static LogKeyValueItem Generate(
            HostProjectOptions hostProjectOptions,
            EndpointMethodMetadata endpointMethodMetadata)
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
            sb.AppendLine("using System.CodeDom.Compiler;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Net;");
            sb.AppendLine("using System.Net.Http;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using FluentAssertions;");
            sb.AppendLine($"using {hostProjectOptions.ProjectName}.Generated.Contracts.Pets;");
            sb.AppendLine("using Xunit;");
            sb.AppendLine();
            GenerateCodeHelper.AppendNamespaceComment(sb, hostProjectOptions.ToolNameAndVersion);
            sb.AppendLine($"namespace {hostProjectOptions.ProjectName}.Tests.Endpoints.Pets.Generated");
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
                }
            }

            sb.AppendLine(4, "}");
            sb.AppendLine("}");

            string pathA = Path.Combine(hostProjectOptions.PathForTestGenerate!.FullName, "Endpoints");
            string pathB = Path.Combine(pathA, endpointMethodMetadata.SegmentName);
            string pathC = Path.Combine(pathB, "Generated");
            var fileName = $"{endpointMethodMetadata.MethodName}Tests.cs";
            var file = new FileInfo(Path.Combine(pathC, fileName));
            return TextFileHelper.Save(file, sb.ToString());
        }

        private static void AppendTest200Ok(
            StringBuilder sb,
            EndpointMethodMetadata endpointMethodMetadata,
            Tuple<HttpStatusCode, string, OpenApiSchema> contractReturnTypeName)
        {
            var allFromRoute = new List<Tuple<string, string>>();
            var allFromQuery = new List<Tuple<string, string>>();
            if (endpointMethodMetadata.ContractParameter != null)
            {
                allFromRoute = endpointMethodMetadata.ContractParameter.ApiOperation.Parameters.GetAllFromRoute();
                allFromQuery = endpointMethodMetadata.ContractParameter.ApiOperation.Parameters.GetAllFromQuery();
            }

            sb.AppendLine();
            sb.AppendLine(8, "[Theory]");
            for (int i = 0; i < allFromQuery.Count + 1; i++)
            {
                sb.AppendLine(8, $"[InlineData(\"{RenderRelativeRef(endpointMethodMetadata, allFromRoute, allFromQuery, i)}\")]");
            }

            sb.AppendLine(8, $"public async Task {endpointMethodMetadata.MethodName}_Ok(string relativeRef)");
            sb.AppendLine(8, "{");
            sb.AppendLine(12, "// Act");
            sb.AppendLine(12, "var response = await HttpClient.GetAsync(relativeRef);");
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

        private static void AppendTest201Created(
            StringBuilder sb,
            EndpointMethodMetadata endpointMethodMetadata,
            Tuple<HttpStatusCode, string, OpenApiSchema> contractReturnTypeName)
        {
            var allFromRoute = new List<Tuple<string, string>>();
            var allFromQuery = new List<Tuple<string, string>>();
            if (endpointMethodMetadata.ContractParameter != null)
            {
                allFromRoute = endpointMethodMetadata.ContractParameter.ApiOperation.Parameters.GetAllFromRoute();
                allFromQuery = endpointMethodMetadata.ContractParameter.ApiOperation.Parameters.GetAllFromQuery();
            }

            sb.AppendLine();
            sb.AppendLine(8, "[Theory]");
            for (int i = 0; i < allFromQuery.Count + 1; i++)
            {
                sb.AppendLine(8, $"[InlineData(\"{RenderRelativeRef(endpointMethodMetadata, allFromRoute, allFromQuery, i)}\")]");
            }

            sb.AppendLine(8, $"public async Task {endpointMethodMetadata.MethodName}_Created(string relativeRef)");
            sb.AppendLine(8, "{");
            sb.AppendLine(12, "// Arrange");
            sb.AppendLine(12, "var stringContent = new StringContent(\"\");");
            sb.AppendLine();
            sb.AppendLine(12, "// Act");
            sb.AppendLine(12, "var response = await HttpClient.PostAsync(relativeRef, stringContent);");
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

        private static string RenderRelativeRef(
            EndpointMethodMetadata endpointMethodMetadata,
            List<Tuple<string, string>> allFromRoute,
            List<Tuple<string, string>> allFromQuery,
            int workOnQueryParameterIndex)
        {
            var route = endpointMethodMetadata.Route;
            return endpointMethodMetadata.ContractParameter == null
                ? route
                : $"{RenderRelativeRefPath(route, allFromRoute)}{RenderRelativeRefQuery(allFromQuery, workOnQueryParameterIndex)}";
        }

        private static string RenderRelativeRefPath(string route, List<Tuple<string, string>> allFromRoute)
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

                var fromRoute = allFromRoute.Find(x => x.Item1 == pn);

                // Match on OpenApiSchemaExtensions->GetDataType
                sa[i] = fromRoute.Item2 switch
                {
                    "string" => PropertyValueGeneratorString(fromRoute.Item1),
                    "int" => PropertyValueGeneratorNumber(fromRoute.Item1),
                    "long" => PropertyValueGeneratorNumber(fromRoute.Item1),
                    "double" => PropertyValueGeneratorNumber(fromRoute.Item1),
                    _ => throw new NotSupportedException($"RenderRelativeRefPath: {fromRoute.Item2}")
                };
            }

            return string.Join('/', sa);
        }

        private static string RenderRelativeRefQuery(List<Tuple<string, string>> allFromQuery, int workOnQueryParameterIndex)
        {
            if (allFromQuery.Count == 0 || workOnQueryParameterIndex == 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            sb.Append('?');
            for (int i = 0; i < allFromQuery.Count; i++)
            {
                if (i == workOnQueryParameterIndex)
                {
                    break;
                }

                var fromQuery = allFromQuery[i];

                // Match on OpenApiSchemaExtensions->GetDataType
                var val = fromQuery.Item2 switch
                {
                    "string" => PropertyValueGeneratorString(fromQuery.Item1),
                    "int" => PropertyValueGeneratorNumber(fromQuery.Item1),
                    "long" => PropertyValueGeneratorNumber(fromQuery.Item1),
                    "double" => PropertyValueGeneratorDouble(),
                    _ => throw new NotSupportedException($"RenderRelativeRefPath: {fromQuery.Item2}")
                };

                sb.Append($"&{fromQuery.Item1}={val}");
            }

            return sb.ToString().Replace("?&", "?", StringComparison.Ordinal);
        }

        private static string PropertyValueGeneratorString(string name)
        {
            if (name.Equals("Id", StringComparison.OrdinalIgnoreCase) || name.EndsWith("Id", StringComparison.Ordinal))
            {
                return "27";
            }

            return "Hallo";
        }

        private static string PropertyValueGeneratorNumber(string name)
        {
            if (name.Equals("Id", StringComparison.OrdinalIgnoreCase) || name.EndsWith("Id", StringComparison.Ordinal))
            {
                return "27";
            }

            return "42";
        }

        [SuppressMessage("Minor Code Smell", "S3400:Methods should not return constants", Justification = "OK.")]
        private static string PropertyValueGeneratorDouble()
        {
            return "42.2";
        }
    }
}