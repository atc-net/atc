namespace Atc.XUnit.Tests;

public class TestResultHelperTests
{
    [Fact]
    public void ToExcelTestResultsFromMethodsWithMissingTests()
    {
        // Arrange
        var reportDirectory = Directory.CreateTempSubdirectory("Atc.XUnit.Tests_");
        var methodsWithMissingTests = new[]
        {
            typeof(TestResultHelper).GetMethod(nameof(TestResultHelper.AssertOnTestResults))!,
            typeof(TestResultHelper).GetMethod(nameof(TestResultHelper.AssertOnTestResultsFromMethodsWithMissingTests))!,
        };

        try
        {
            // Act
            TestResultHelper.ToExcelTestResultsFromMethodsWithMissingTests(
                reportDirectory,
                "MyAssembly",
                methodsWithMissingTests);

            // Assert
            var file = new FileInfo(Path.Combine(reportDirectory.FullName, "TestResultsFromMethodsWithMissingTestsFor_MyAssembly.xlsx"));
            file.Exists.Should().BeTrue();

            using var workbook = new XLWorkbook(file.FullName);
            var ws = workbook.Worksheet("Methods with missing tests");
            ws.Cell("A1").GetString().Should().Be("Class");
            ws.Cell("B1").GetString().Should().Be("Method");
            ws.Cell("A2").GetString().Should().Be(typeof(TestResultHelper).BeautifyName(useFullName: true));
            ws.Cell("B2").GetString().Should().Be(methodsWithMissingTests[0].BeautifyName(useFullName: true));
            ws.Cell("A3").IsEmpty().Should().BeTrue();
            ws.Cell("B3").GetString().Should().Be(methodsWithMissingTests[1].BeautifyName(useFullName: true));
            ws.Cell("A4").IsEmpty().Should().BeTrue();
            ws.Cell("B4").IsEmpty().Should().BeTrue();
        }
        finally
        {
            reportDirectory.Delete(recursive: true);
        }
    }
}