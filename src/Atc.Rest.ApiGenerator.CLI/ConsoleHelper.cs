using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Atc.Data.Models;
using McMaster.Extensions.CommandLineUtils;

namespace Atc.Rest.ApiGenerator.CLI
{
    public static class ConsoleHelper
    {
        public static void WriteHeader()
        {
            Console.WriteLine();
            Colorful.Console.WriteAscii(" ATC-API Generator", Color.CornflowerBlue);
        }

        public static void WriteHelp(CommandLineApplication configCmd, string message)
        {
            WriteHeader();
            Console.WriteLine(message);
            Console.WriteLine();
            configCmd.ShowHelp();
        }

        public static void WriteLogItems(List<LogKeyValueItem> logItems)
        {
            if (logItems == null)
            {
                throw new ArgumentNullException(nameof(logItems));
            }

            foreach (var logItem in logItems)
            {
                var message = "#".Equals(logItem.Value, StringComparison.Ordinal)
                    ? $"{logItem.Key} # {logItem.LogCategory}: {logItem.Description}"
                    : $"{logItem.Key} # {logItem.LogCategory}: {logItem.Value} - {logItem.Description}";
                switch (logItem.LogCategory)
                {
                    case LogCategoryType.Error:
                        Colorful.Console.WriteLine(message, Color.Red);
                        break;
                    case LogCategoryType.Warning:
                        Colorful.Console.WriteLine(message, Color.Yellow);
                        break;
                    case LogCategoryType.Information:
                        Colorful.Console.WriteLine(message, Color.LightSkyBlue);
                        break;
                }
            }
        }

        public static int WriteLogItemsAndExit(List<LogKeyValueItem> logItems, string area)
        {
            WriteLogItems(logItems);
            Console.WriteLine();
            if (logItems.Any(x => x.LogCategory == LogCategoryType.Error))
            {
                Colorful.Console.WriteLine($"{area} has errors.", Color.Red);
                return ExitStatusCodes.Failure;
            }

            Console.WriteLine();
            Colorful.Console.WriteLine($"{area} is OK.", Color.DarkGreen);
            return ExitStatusCodes.Success;
        }
    }
}