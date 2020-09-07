using System.Collections.Generic;
using Atc.Rest.ApiGenerator.Models;

namespace Atc.Rest.ApiGenerator.SyntaxGenerators
{
    public interface ISyntaxGeneratorContractModels : ISyntaxGeneratorContract
    {
        List<ApiOperationSchemaMap> OperationSchemaMappings { get; }

        List<SyntaxGeneratorContractModel> GenerateSyntaxTrees();
    }
}