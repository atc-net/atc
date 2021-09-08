using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Atc.Console.Spectre.Tests.SampleIntegrationTests.Demo.Atc.Console.Spectre.Cli
{
    [Collection(nameof(TestCollection))]
    [Trait("Category", "SkipWhenLiveUnitTesting")]
    [SuppressMessage("Major Code Smell", "S4144:Methods should not have identical implementations", Justification = "OK.")]
    public class CommandTests : SampleIntegrationTestBase
    {
        [Theory]
        [InlineData("Hello, Phil", "hello Phil")]
        [InlineData("Hello, Phil - 4", "hello Phil --count 4")]
        public async Task Hello_Command(string expected, string arguments)
        {
            // Arrange & Act
            var (isCliExecutedCorrectly, output) = await ExecuteCli(arguments);
            var outputLines = output.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            // Assert
            Assert.True(isCliExecutedCorrectly);
            Assert.True(outputLines.Contains(expected, StringComparer.Ordinal));
        }

        [Theory]
        [InlineData("Hallo", "log Hallo")]
        [InlineData("Hallo", "log --logLevel Information Hallo")]
        [InlineData("Hallo", "log --logLevel Warning Hallo")]
        [InlineData("Hallo", "log --logLevel Error Hallo")]
        [InlineData("Hallo", "log --logLevel Critical Hallo")]
        [InlineData("ns=2;s=CTT/SecurityAccess/AccessLevel_CurrentRead_NotUser", "log ns=2;s=CTT/SecurityAccess/AccessLevel_CurrentRead_NotUser")]
        public async Task Log_Command(string expected, string arguments)
        {
            // Arrange & Act
            var (isCliExecutedCorrectly, output) = await ExecuteCli(arguments);
            var outputLines = output.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            // Assert
            Assert.True(isCliExecutedCorrectly);
            Assert.True(outputLines.Contains(expected, StringComparer.Ordinal));
        }
    }
}