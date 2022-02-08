namespace Atc.DotNet.Tests.XUnitTestData;

public static class TestClassDataForVisualStudioSolutionFileMetadata
{
    public static TheoryData<VisualStudioSolutionFileMetadata, int> GetSolutionFileMetadata
        => new TheoryData<VisualStudioSolutionFileMetadata, int>
        {
            {
                new VisualStudioSolutionFileMetadata
                {
                    FileFormatVersion = new Version(12, 0),
                    VisualStudioVersionNumber = 16,
                    VisualStudioVersion = new Version(16, 0, 31019, 35),
                    MinimumVisualStudioVersion = new Version(10, 0, 40219, 1),
                },
                2019
            },
            {
                new VisualStudioSolutionFileMetadata
                {
                    FileFormatVersion = new Version(12, 0),
                    VisualStudioVersionNumber = 17,
                    VisualStudioVersion = new Version(17, 0, 32112, 339),
                    MinimumVisualStudioVersion = new Version(10, 0, 40219, 1),
                },
                2022
            },
        };
}