// ReSharper disable InvertIf
// ReSharper disable MemberCanBeMadeStatic.Global

using Demo.Atc.Console.Spectre.Cli;

namespace Atc.Console.Spectre.Tests.SampleIntegrationTests;

public class SampleIntegrationTestBase : IntegrationTestCliBase
{
    private static JsonSerializerOptions? jsonSerializerOptions;

    public SampleIntegrationTestBase()
    {
        jsonSerializerOptions ??= JsonSerializerOptionsFactory.Create(useCamelCase: false);
    }

    public static Task<(bool IsSuccessful, string Output)> ExecuteCli(string arguments)
    {
        if (arguments is null)
        {
            throw new ArgumentNullException(nameof(arguments));
        }

        var cliFile = GetExecutableFileForCli(typeof(Program), "sample");
        return ProcessHelper.Execute(cliFile, arguments, timeoutInSec: 30);
    }

    public static void PrepareCliAppSettings(ConsoleLoggerConfiguration config)
    {
        if (config is null)
        {
            throw new ArgumentNullException(nameof(config));
        }

        var appSettingsFile = GetAppSettingsFileForCli(typeof(Program), "sample");

        var json = JsonSerializer.Serialize(config, jsonSerializerOptions);
        var jsonPart = json.Replace(Environment.NewLine, $"{Environment.NewLine}  ", StringComparison.Ordinal);

        var sbJson = new StringBuilder();
        sbJson.AppendLine("{");
        sbJson.AppendLine("  \"ConsoleLogger\": " + jsonPart);
        sbJson.AppendLine("}");

        var jsonOutput = sbJson.ToString();
        File.WriteAllText(appSettingsFile.FullName, jsonOutput);
    }
}