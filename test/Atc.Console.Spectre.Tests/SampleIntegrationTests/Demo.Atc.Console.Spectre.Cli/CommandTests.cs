using System;
using System.Linq;
using System.Threading.Tasks;
using Atc.Console.Spectre.Logging;
using Atc.Console.Spectre.Tests.SampleIntegrationTests.Demo.Atc.Console.Spectre.Cli.XUnitTestData;
using Xunit;
using Xunit.Sdk;

namespace Atc.Console.Spectre.Tests.SampleIntegrationTests.Demo.Atc.Console.Spectre.Cli
{
    [Collection(nameof(TestCollection))]
    [Trait("Category", "SkipWhenLiveUnitTesting")]
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
        [MemberData(nameof(TestMemberDataForCommandTests.LogCommand), MemberType = typeof(TestMemberDataForCommandTests))]
        public async Task Log_Command(string[] expectedList, string arguments, ConsoleLoggerConfiguration config)
        {
            // Arrange
            PrepareCliAppSettings(config);

            // Act
            var (isCliExecutedCorrectly, output) = await ExecuteCli(arguments);
            var outputLines = output.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            // Assert
            Assert.True(isCliExecutedCorrectly);
            foreach (var expected in expectedList)
            {
                Assert.True(outputLines.Contains(expected, StringComparer.Ordinal));
            }
        }
    }
}