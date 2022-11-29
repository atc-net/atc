// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable UseDeconstruction
namespace Atc.Console.Spectre.Tests.SampleIntegrationTests.Demo.Atc.Console.Spectre.Cli.XUnitTestData;

internal static class TestMemberDataForCommandTests
{
    public static IEnumerable<object[]> LogCommand
    {
        get
        {
            var tests = new List<object[]>();
            tests.AddRange(LogCommandBasic);
            tests.AddRange(LogCommandRenderLogLevel);
            tests.AddRange(LogCommandRenderCategoryName);
            tests.AddRange(LogCommandRenderLogLevelCategoryName);
            return tests;
        }
    }

    private static IEnumerable<object[]> LogCommandBasic
        => new List<object[]>
        {
            new object[]
            {
                new[] { "Hello" },
                "log Hello",
                new ConsoleLoggerConfiguration(),
            },
            new object[]
            {
                new[] { "Hello" },
                "log --logLevel Information Hello",
                new ConsoleLoggerConfiguration(),
            },
            new object[]
            {
                new[] { "ns=2;s=CTT/SecurityAccess/AccessLevel_CurrentRead_NotUser" },
                "log ns=2;s=CTT/SecurityAccess/AccessLevel_CurrentRead_NotUser",
                new ConsoleLoggerConfiguration(),
            },
            new object[]
            {
                new[] { "{x:[]}" },
                "log {x:[]}",
                new ConsoleLoggerConfiguration(),
            },
        };

    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    private static IEnumerable<object[]> LogCommandRenderLogLevel
    {
        get
        {
            var tests = new List<object[]>();

            var config = new ConsoleLoggerConfiguration
            {
                MinimumLogLevel = LogLevel.Trace,
                RenderingMode = ConsoleRenderingMode.LogLevel,
                UseTimestamp = false,
                UseShortNameForLogLevel = true,
                IncludeInnerMessageForException = true,
                IncludeExceptionNameForException = true,
                AllowMarkup = false,
                UseTimestampUtc = false,
                TimestampFormat = "yyyy-MM-dd HH:mm:ss",
            };

            foreach (var logLevelName in LogLevelNames)
            {
                var spaces = string.Empty.PadRight(9 - logLevelName.Item2.Length);
                var expected = $"{logLevelName.Item2}:{spaces}Hello";
                var arguments = $"log --logLevel {logLevelName.Item1} Hello";
                var test = new object[]
                {
                    new[] { expected },
                    arguments,
                    config,
                };

                tests.Add(test);
            }

            config = new ConsoleLoggerConfiguration
            {
                MinimumLogLevel = LogLevel.Trace,
                RenderingMode = ConsoleRenderingMode.LogLevel,
                UseTimestamp = false,
                UseShortNameForLogLevel = false,
                IncludeInnerMessageForException = true,
                IncludeExceptionNameForException = true,
                AllowMarkup = false,
                UseTimestampUtc = false,
                TimestampFormat = "yyyy-MM-dd HH:mm:ss",
            };

            foreach (var logLevelName in LogLevelNames)
            {
                var spaces = string.Empty.PadRight(12 - logLevelName.Item1.Length);
                var expected = $"{logLevelName.Item1}:{spaces}Hello";
                var arguments = $"log --logLevel {logLevelName.Item1} Hello";
                var test = new object[]
                {
                    new[] { expected },
                    arguments,
                    config,
                };

                tests.Add(test);
            }

            return tests;
        }
    }

    private static IEnumerable<object[]> LogCommandRenderCategoryName
    {
        get
        {
            var tests = new List<object[]>();

            var config = new ConsoleLoggerConfiguration
            {
                MinimumLogLevel = LogLevel.Trace,
                RenderingMode = ConsoleRenderingMode.CategoryName,
            };

            foreach (var logLevelName in LogLevelNames)
            {
                const string expected = "Demo.Atc.Console.Spectre.Cli.Commands.LogCommand Hello";
                var arguments = $"log --logLevel {logLevelName.Item1} Hello";
                var test = new object[]
                {
                    new[] { expected },
                    arguments,
                    config,
                };

                tests.Add(test);
            }

            return tests;
        }
    }

    private static IEnumerable<object[]> LogCommandRenderLogLevelCategoryName
    {
        get
        {
            var tests = new List<object[]>();
            var config = new ConsoleLoggerConfiguration
            {
                MinimumLogLevel = LogLevel.Trace,
                RenderingMode = ConsoleRenderingMode.LogLevelAndCategoryName,
                UseTimestamp = false,
                UseShortNameForLogLevel = true,
            };

            foreach (var logLevelName in LogLevelNames)
            {
                var spaces = string.Empty.PadRight(9 - logLevelName.Item2.Length);
                var expected = $"{logLevelName.Item2}:{spaces}Demo.Atc.Console.Spectre.Cli.Commands.LogCommand Hello";
                var arguments = $"log --logLevel {logLevelName.Item1} Hello";
                var test = new object[]
                {
                    new[] { expected },
                    arguments,
                    config,
                };

                tests.Add(test);
            }

            config = new ConsoleLoggerConfiguration
            {
                MinimumLogLevel = LogLevel.Trace,
                RenderingMode = ConsoleRenderingMode.LogLevelAndCategoryName,
                UseTimestamp = false,
                UseShortNameForLogLevel = false,
            };

            foreach (var logLevelName in LogLevelNames)
            {
                var spaces = string.Empty.PadRight(12 - logLevelName.Item1.Length);
                var expected = $"{logLevelName.Item1}:{spaces}Demo.Atc.Console.Spectre.Cli.Commands.LogCommand Hello";
                var arguments = $"log --logLevel {logLevelName.Item1} Hello";
                var test = new object[]
                {
                    new[] { expected },
                    arguments,
                    config,
                };

                tests.Add(test);
            }

            return tests;
        }
    }

    private static List<Tuple<string, string>> LogLevelNames
        => new()
        {
            Tuple.Create(nameof(LogLevel.Trace), "trace"),
            Tuple.Create(nameof(LogLevel.Debug), "debug"),
            Tuple.Create(nameof(LogLevel.Information), "info"),
            Tuple.Create(nameof(LogLevel.Warning), "warn"),
            Tuple.Create(nameof(LogLevel.Error), "error"),
            Tuple.Create(nameof(LogLevel.Critical), "critical"),
        };
}