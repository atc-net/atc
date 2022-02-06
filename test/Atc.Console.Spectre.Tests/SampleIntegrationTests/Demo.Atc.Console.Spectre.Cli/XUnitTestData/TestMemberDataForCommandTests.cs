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

    private static IEnumerable<object[]> LogCommandRenderLogLevel
    {
        get
        {
            var tests = new List<object[]>();

            var config = new ConsoleLoggerConfiguration
            {
                MinimumLogLevel = LogLevel.Trace,
                RenderingMode = ConsoleRenderingMode.LogLevel,
                UseShortNameForLogLevel = true,
                UseFixedWidthSpacing = true,
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
                UseShortNameForLogLevel = false,
                UseFixedWidthSpacing = true,
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

            config = new ConsoleLoggerConfiguration
            {
                MinimumLogLevel = LogLevel.Trace,
                RenderingMode = ConsoleRenderingMode.LogLevel,
                UseShortNameForLogLevel = true,
                UseFixedWidthSpacing = false,
            };

            foreach (var logLevelName in LogLevelNames)
            {
                var expected = $"{logLevelName.Item2}: Hello";
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
                UseShortNameForLogLevel = false,
                UseFixedWidthSpacing = false,
            };

            foreach (var logLevelName in LogLevelNames)
            {
                var expected = $"{logLevelName.Item1}: Hello";
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
                const string expected = "Demo.Atc.Console.Spectre.Cli.Commands.LogCommand: Hello";
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
                UseShortNameForLogLevel = true,
                UseFixedWidthSpacing = true,
            };

            foreach (var logLevelName in LogLevelNames)
            {
                var spaces = string.Empty.PadRight(9 - logLevelName.Item2.Length);
                var expected1 = $"{logLevelName.Item2}:{spaces}Demo.Atc.Console.Spectre.Cli.Commands.LogCommand";
                const string expected2 = "          Hello";
                var arguments = $"log --logLevel {logLevelName.Item1} Hello";
                var test = new object[]
                {
                    new[] { expected1, expected2 },
                    arguments,
                    config,
                };

                tests.Add(test);
            }

            config = new ConsoleLoggerConfiguration
            {
                MinimumLogLevel = LogLevel.Trace,
                RenderingMode = ConsoleRenderingMode.LogLevelAndCategoryName,
                UseShortNameForLogLevel = false,
                UseFixedWidthSpacing = true,
            };

            foreach (var logLevelName in LogLevelNames)
            {
                var spaces = string.Empty.PadRight(12 - logLevelName.Item1.Length);
                var expected1 = $"{logLevelName.Item1}:{spaces}Demo.Atc.Console.Spectre.Cli.Commands.LogCommand";
                const string expected2 = "             Hello";
                var arguments = $"log --logLevel {logLevelName.Item1} Hello";
                var test = new object[]
                {
                    new[] { expected1, expected2 },
                    arguments,
                    config,
                };

                tests.Add(test);
            }

            config = new ConsoleLoggerConfiguration
            {
                MinimumLogLevel = LogLevel.Trace,
                RenderingMode = ConsoleRenderingMode.LogLevelAndCategoryName,
                UseShortNameForLogLevel = true,
                UseFixedWidthSpacing = false,
            };

            foreach (var logLevelName in LogLevelNames)
            {
                var expected1 = $"{logLevelName.Item2}: Demo.Atc.Console.Spectre.Cli.Commands.LogCommand";
                const string expected2 = "       Hello";
                var arguments = $"log --logLevel {logLevelName.Item1} Hello";
                var test = new object[]
                {
                    new[] { expected1, expected2 },
                    arguments,
                    config,
                };

                tests.Add(test);
            }

            config = new ConsoleLoggerConfiguration
            {
                MinimumLogLevel = LogLevel.Trace,
                RenderingMode = ConsoleRenderingMode.LogLevelAndCategoryName,
                UseShortNameForLogLevel = false,
                UseFixedWidthSpacing = false,
            };

            foreach (var logLevelName in LogLevelNames)
            {
                var expected1 = $"{logLevelName.Item1}: Demo.Atc.Console.Spectre.Cli.Commands.LogCommand";
                const string expected2 = "       Hello";
                var arguments = $"log --logLevel {logLevelName.Item1} Hello";
                var test = new object[]
                {
                    new[] { expected1, expected2 },
                    arguments,
                    config,
                };

                tests.Add(test);
            }

            return tests;
        }
    }

    private static List<Tuple<string, string>> LogLevelNames
        => new List<Tuple<string, string>>
        {
            Tuple.Create(nameof(LogLevel.Trace), "trace"),
            Tuple.Create(nameof(LogLevel.Debug), "debug"),
            Tuple.Create(nameof(LogLevel.Information), "info"),
            Tuple.Create(nameof(LogLevel.Warning), "warn"),
            Tuple.Create(nameof(LogLevel.Error), "error"),
            Tuple.Create(nameof(LogLevel.Critical), "critical"),
        };
}