using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Atc.Console.Spectre.Logging;
using Atc.Helpers;
using Atc.Serialization;

// ReSharper disable InvertIf
// ReSharper disable MemberCanBeMadeStatic.Global
namespace Atc.Console.Spectre.Tests.SampleIntegrationTests
{
    public class SampleIntegrationTestBase
    {
        private static JsonSerializerOptions? jsonSerializerOptions;

        public SampleIntegrationTestBase()
        {
            jsonSerializerOptions ??= JsonSerializerOptionsFactory.Create(useCamelCase: false);
        }

        public static FileInfo GetCliExecutableFilePath()
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

            return new FileInfo(
                Path.Join(
                    rootPath!.FullName,
                    @$"sample\{cliProjectName}\bin\Debug\net5.0\{cliProjectName}.exe"));
        }

        public static FileInfo GetCliAppSettingsFilePath()
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

            return new FileInfo(
                Path.Join(
                    rootPath!.FullName,
                    @$"sample\{cliProjectName}\bin\Debug\net5.0\appsettings.json"));
        }

        public Task<Tuple<bool, string>> ExecuteCli(string arguments)
        {
            if (arguments is null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            var cliFile = GetCliExecutableFilePath();
            return ProcessHelper.Execute(cliFile, arguments);
        }

        public void PrepareCliAppSettings(ConsoleLoggerConfiguration config)
        {
            if (config is null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            var appSettingsFile = GetCliAppSettingsFilePath();

            var json = JsonSerializer.Serialize(config, jsonSerializerOptions);
            var jsonPart = json.Replace(Environment.NewLine, $"{Environment.NewLine}  ", StringComparison.Ordinal);

            var sbJson = new StringBuilder();
            sbJson.AppendLine("{");
            sbJson.AppendLine("  \"ConsoleLogger\": " + jsonPart);
            sbJson.AppendLine("}");

            var jsonOutput = sbJson.ToString();
            File.WriteAllTextAsync(appSettingsFile.FullName, jsonOutput);
        }
    }
}