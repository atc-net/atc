using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

// ReSharper disable MemberCanBeMadeStatic.Global
namespace Atc.Console.Spectre.Tests.SampleIntegrationTests
{
    public class SampleIntegrationTestBase
    {
        public static string GetCliExecutableFilePath()
        {
            var testAssemblyName = Assembly
                .GetExecutingAssembly()
                .GetName()
                .Name;

            var currentDomainBaseDirectory = AppDomain
                .CurrentDomain
                .BaseDirectory;

            var cliProjectName = typeof(global::Demo.Atc.Console.Spectre.Cli.Program)
                .Assembly
                .GetName()
                .Name;

            var rootPath = new DirectoryInfo(currentDomainBaseDirectory
                .Split(testAssemblyName, StringSplitOptions.RemoveEmptyEntries)
                .First())
                .Parent;

            return Path.Join(rootPath!.FullName, @$"sample\{cliProjectName}\bin\Debug\net5.0\{cliProjectName}.exe");
        }

        [SuppressMessage("Style", "MA0003:Add argument name to improve readability", Justification = "OK.")]
        public async Task<Tuple<bool, string>> ExecuteCli(string arguments)
        {
            var cliFilePath = GetCliExecutableFilePath();
            using var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = cliFilePath,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                },
            };

            try
            {
                process.Start();
                var standardOutput = await process.StandardOutput.ReadToEndAsync();
                var standardError = await process.StandardError.ReadToEndAsync();
                var message = string.IsNullOrEmpty(standardError)
                    ? standardOutput
                    : standardError;

                return Tuple.Create(string.IsNullOrEmpty(standardError), message);
            }
            catch (Exception ex)
            {
                return Tuple.Create(
                    false,
                    ex.GetMessage(
                        includeInnerMessage: true,
                        includeExceptionName: true));
            }
        }
    }
}