using Atc.Rest.ApiGenerator.Models;

namespace Atc.Rest.ApiGenerator.SyntaxGenerators
{
    public interface ISyntaxGeneratorContract
    {
        ApiProjectOptions ApiProjectOptions { get; }

        string FocusOnSegmentName { get; }
    }
}