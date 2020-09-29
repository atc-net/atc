using System;
using System.Drawing;
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
    }
}