using System.Collections.Generic;

namespace Atc.Rest.ApiGenerator.SyntaxGenerators
{
    public interface ISyntaxGeneratorContractInterfaces : ISyntaxGeneratorContract
    {
        List<SyntaxGeneratorContractInterface> GenerateSyntaxTrees();
    }
}