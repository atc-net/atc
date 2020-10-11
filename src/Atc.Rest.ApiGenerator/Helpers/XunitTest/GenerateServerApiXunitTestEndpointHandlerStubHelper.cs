using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Atc.Data.Models;
using Atc.Rest.ApiGenerator.Models;

namespace Atc.Rest.ApiGenerator.Helpers.XunitTest
{
    public static class GenerateServerApiXunitTestEndpointHandlerStubHelper
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
            sb.AppendLine("using System.Threading;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine($"using {hostProjectOptions.ProjectName}.Generated.Contracts.Pets;");
            sb.AppendLine();
            GenerateCodeHelper.AppendNamespaceComment(sb, hostProjectOptions.ToolNameAndVersion);
            sb.AppendLine($"namespace {hostProjectOptions.ProjectName}.Tests.Endpoints.Pets.Generated");
            sb.AppendLine("{");
            GenerateCodeHelper.AppendGeneratedCodeAttribute(sb, hostProjectOptions.ToolName, hostProjectOptions.ToolVersion);
            sb.AppendLine(4, $"public class {endpointMethodMetadata.MethodName}HandlerStub : {endpointMethodMetadata.ContractInterfaceHandlerTypeName}");
            sb.AppendLine(4, "{");
            sb.AppendLine(8, endpointMethodMetadata.ContractParameterTypeName == null
                ? $"public Task<{endpointMethodMetadata.ContractResultTypeName}> ExecuteAsync(CancellationToken cancellationToken = default)"
                : $"public Task<{endpointMethodMetadata.ContractResultTypeName}> ExecuteAsync({endpointMethodMetadata.ContractParameterTypeName} parameters, CancellationToken cancellationToken = default)");

            sb.AppendLine(8, "{");
            if (endpointMethodMetadata.ContractParameterTypeName == null)
            {
                if (endpointMethodMetadata.ContractReturnTypeNames.FirstOrDefault(x => x.Item1 == HttpStatusCode.Created) != null)
                {
                    sb.AppendLine(12, $"return Task.FromResult({endpointMethodMetadata.ContractResultTypeName}.Created());");
                }
                else
                {
                    sb.AppendLine(12, "throw new System.NotImplementedException();");
                }
            }
            else
            {
                if (endpointMethodMetadata.ContractReturnTypeNames.FirstOrDefault(x => x.Item1 == HttpStatusCode.OK) != null)
                {
                    string returnTypeName = endpointMethodMetadata.ContractReturnTypeNames.First(x => x.Item1 == HttpStatusCode.OK).Item2;
                    sb.AppendLine(12, $"var data = new {returnTypeName}");
                    sb.AppendLine(12, "{");
                    sb.AppendLine(12, "};");
                    sb.AppendLine();
                    sb.AppendLine(12, $"return Task.FromResult({endpointMethodMetadata.ContractResultTypeName}.Ok(data));");
                }
                else
                {
                    sb.AppendLine(12, "throw new System.NotImplementedException();");
                }
            }

            sb.AppendLine(8, "}");
            sb.AppendLine(4, "}");
            sb.AppendLine("}");

            string pathA = Path.Combine(hostProjectOptions.PathForTestGenerate!.FullName, "Endpoints");
            string pathB = Path.Combine(pathA, endpointMethodMetadata.SegmentName);
            string pathC = Path.Combine(pathB, "Generated");
            var fileName = $"{endpointMethodMetadata.ContractInterfaceHandlerTypeName.Substring(1)}Stub.cs";
            var file = new FileInfo(Path.Combine(pathC, fileName));
            return TextFileHelper.Save(file, sb.ToString());
        }
    }
}