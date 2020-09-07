using System.Collections.Generic;

namespace Atc.Rest.ApiGenerator.SyntaxGenerators
{
    public interface ISyntaxGeneratorContractParameters : ISyntaxGeneratorContract
    {
        List<SyntaxGeneratorContractParameter> GenerateSyntaxTrees();
    }
}