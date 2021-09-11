using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Atc.Console.Spectre.Logging;
using Atc.Helpers;
using Atc.Serialization;
using Atc.XUnit;

// ReSharper disable InvertIf
// ReSharper disable MemberCanBeMadeStatic.Global
namespace Atc.Console.Spectre.Tests.SampleIntegrationTests
{
    public class SampleIntegrationTestBase : IntegrationTestCliBase
    {
        private static JsonSerializerOptions? jsonSerializerOptions;

        public SampleIntegrationTestBase()
        {
            jsonSerializerOptions ??= JsonSerializerOptionsFactory.Create(useCamelCase: false);
        }

        public Task<(bool isSuccessful, string output)> ExecuteCli(string arguments)
        {
            if (arguments is null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            var cliFile = GetExecutableFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program), "sample");
            return ProcessHelper.Execute(cliFile, arguments);
        }

        public void PrepareCliAppSettings(ConsoleLoggerConfiguration config)
        {
            if (config is null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            var appSettingsFile = GetAppSettingsFileForCli(typeof(global::Demo.Atc.Console.Spectre.Cli.Program), "sample");

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