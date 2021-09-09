using System;
using Microsoft.Extensions.Logging;
using Spectre.Console;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
namespace Atc.Console.Spectre.Logging
{
    public class ConsoleLoggerConfiguration
    {
        public ConsoleLoggerConfiguration()
        {
            ConsoleConfiguration = null;
            ConsoleSettings = null;
            MinimumLogLevel = LogLevel.Information;
            RenderingMode = ConsoleRenderingMode.Default;
            UseShortNameForLogLevel = true;
            UseFixedWidthSpacing = true;
            IncludeInnerMessageForException = true;
            IncludeExceptionNameForException = true;
        }

        public Action<IAnsiConsole>? ConsoleConfiguration { get; set; }

        public AnsiConsoleSettings? ConsoleSettings { get; set; }

        public LogLevel MinimumLogLevel { get; set; }

        public ConsoleRenderingMode RenderingMode { get; set; }

        public bool UseShortNameForLogLevel { get; set; }

        public bool UseFixedWidthSpacing { get; set; }

        public bool IncludeInnerMessageForException { get; set; }

        public bool IncludeExceptionNameForException { get; set; }

        public override string ToString()
        {
            return $"{nameof(MinimumLogLevel)}: {MinimumLogLevel}, {nameof(RenderingMode)}: {RenderingMode}, {nameof(UseShortNameForLogLevel)}: {UseShortNameForLogLevel}, {nameof(UseFixedWidthSpacing)}: {UseFixedWidthSpacing}, {nameof(IncludeInnerMessageForException)}: {IncludeInnerMessageForException}, {nameof(IncludeExceptionNameForException)}: {IncludeExceptionNameForException}";
        }
    }
}