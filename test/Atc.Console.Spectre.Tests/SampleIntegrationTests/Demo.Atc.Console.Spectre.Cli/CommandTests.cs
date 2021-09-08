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
        [InlineData("Hello", "log Hello")]
        [InlineData("Hello", "log --logLevel Information Hello")]
        [InlineData("Hello", "log --logLevel Warning Hello")]
        [InlineData("Hello", "log --logLevel Error Hello")]
        [InlineData("Hello", "log --logLevel Critical Hello")]
        [InlineData("ns=2;s=CTT/SecurityAccess/AccessLevel_CurrentRead_NotUser", "log ns=2;s=CTT/SecurityAccess/AccessLevel_CurrentRead_NotUser")]
        [InlineData("{x:[]}", "log {x:[]}")]
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