using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using OfficeOpenXml;
using Xunit;

namespace Atc.XUnit
{
    /// <summary>
    /// TestResultHelper.
    /// </summary>
    public static class TestResultHelper
    {
        /// <summary>
        /// Asserts the on test results.
        /// </summary>
        /// <param name="testResults">The test results.</param>
        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "OK.")]
        public static void AssertOnTestResults(IReadOnlyCollection<TestResult> testResults)
        {
            Assert.NotNull(testResults);
            if (!testResults.Any(x => x.IsError))
            {
                return;
            }

            var lines = new List<string>();
            foreach (var testResult in testResults)
            {
                if (testResult.IsError)
                {
                    var indentSpaces = testResult.IndentLevel * 3;
                    lines.Add(testResult.Text.PadLeft(testResult.Text.Length + indentSpaces));
                    if (testResult.SubLines is not null)
                    {
                        lines.AddRange(testResult.SubLines
                            .Select(subLine => "- " + subLine)
                            .Select(s => s.PadLeft(s.Length + indentSpaces)));
                    }
                }
                else
                {
                    if (testResult.IndentLevel == default)
                    {
                        lines.Add(testResult.Text);
                    }
                    else
                    {
                        var indentSpaces = testResult.IndentLevel * 3;
                        lines.Add(testResult.Text.PadLeft(testResult.Text.Length + indentSpaces));
                    }
                }
            }

            var sb = new StringBuilder();
            for (var i = 0; i < lines.Count; i++)
            {
                if (i < lines.Count - 1
                    && lines[i].EndsWith(":", StringComparison.Ordinal)
                    && lines[i + 1].EndsWith(":", StringComparison.Ordinal))
                {
                    continue;
                }

                if (i == lines.Count - 1 && lines[i].EndsWith(":", StringComparison.Ordinal))
                {
                    continue;
                }

                sb.AppendLine(lines[i]);
            }

            Assert.True(false, sb.ToString());
        }

        /// <summary>
        /// Asserts the on test results from methods with missing tests.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="methodsWithMissingTests">The methods with missing tests.</param>
        /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
        public static void AssertOnTestResultsFromMethodsWithMissingTests(
            string assemblyName,
            MethodInfo[] methodsWithMissingTests,
            bool useFullName = false)
        {
            if (methodsWithMissingTests is null)
            {
                throw new ArgumentNullException(nameof(methodsWithMissingTests));
            }

            var methodsWithMissingTestsGroups = methodsWithMissingTests
                .OrderBy(x => x.DeclaringType?.FullName)
                .GroupBy(x => x.DeclaringType?.BeautifyName(true), StringComparer.Ordinal)
                .ToArray();

            var testResults = new List<TestResult>
            {
                new TestResult($"Assembly: {assemblyName} ({methodsWithMissingTests.Length})"),
            };

            foreach (var item in methodsWithMissingTestsGroups)
            {
                testResults.Add(new TestResult(false, 1, $"Type: {item.Key} ({item.Count()})"));
                testResults.AddRange(item.Select(methodInfo => new TestResult(true, 2, methodInfo.BeautifyName(useFullName))));
            }

            AssertOnTestResults(testResults);
        }

        /// <summary>
        /// To Excel with the test results from methods with missing tests.
        /// </summary>
        /// <param name="reportDirectory">The report directory.</param>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="methodsWithMissingTests">The methods with missing tests.</param>
        public static void ToExcelTestResultsFromMethodsWithMissingTests(
            DirectoryInfo reportDirectory,
            string assemblyName,
            MethodInfo[] methodsWithMissingTests)
        {
            if (reportDirectory is null)
            {
                throw new ArgumentNullException(nameof(reportDirectory));
            }

            var methodsWithMissingTestsGroups = methodsWithMissingTests
                .OrderBy(x => x.ReflectedType?.FullName)
                .GroupBy(x => x.ReflectedType?.BeautifyName(true), StringComparer.Ordinal)
                .ToArray();

            var file = new FileInfo(Path.Combine(reportDirectory.FullName, $"TestResultsFromMethodsWithMissingTestsFor_{assemblyName}.xlsx"));

            using var p = new ExcelPackage();
            var ws = p.Workbook.Worksheets.Add("Methods with missing tests");

            ws.Cells["A1"].Value = "Class";
            ws.Cells["B1"].Value = "Method";
            var row = 2;
            foreach (var item in methodsWithMissingTestsGroups)
            {
                ws.Cells["A" + row].Value = item.Key;
                foreach (var methodInfo in item)
                {
                    ws.Cells["B" + row].Value = methodInfo.BeautifyName(true);
                    row++;
                }
            }

            ws.Column(1).AutoFit();
            ws.Column(2).AutoFit();

            p.SaveAs(file);
        }

        /// <summary>
        /// Asserts the on test results from methods with wrong definitions.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="methodsWithWrongNaming">The methods with wrong naming.</param>
        /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
        public static void AssertOnTestResultsFromMethodsWithWrongDefinitions(
            string assemblyName,
            Dictionary<MethodInfo, string> methodsWithWrongNaming,
            bool useFullName = false)
        {
            if (methodsWithWrongNaming is null)
            {
                throw new ArgumentNullException(nameof(methodsWithWrongNaming));
            }

            var methodsWithWrongNamingGroups = methodsWithWrongNaming
                .OrderBy(x => x.Key.ReflectedType?.FullName)
                .GroupBy(x => x.Key.ReflectedType?.BeautifyName(true), StringComparer.Ordinal)
                .ToArray();

            var testResults = new List<TestResult>
            {
                new TestResult($"Assembly: {assemblyName} ({methodsWithWrongNaming.Count})"),
            };

            foreach (var item in methodsWithWrongNamingGroups)
            {
                testResults.Add(new TestResult(false, 1, $"Type: {item.Key} ({item.Count()})"));
                testResults.AddRange(item.Select(x => new TestResult(true, 2, $"{x.Key.BeautifyName(useFullName)} # {x.Value}")));
            }

            AssertOnTestResults(testResults);
        }
    }
}