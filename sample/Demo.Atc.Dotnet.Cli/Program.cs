using System.Threading.Tasks;
using Atc.Console.Spectre.Factories;
using Atc.Console.Spectre.Logging;
using Demo.Atc.Dotnet.Cli.Commands;
using Microsoft.Extensions.Configuration;
using Spectre.Console.Cli;

namespace Demo.Atc.Dotnet.Cli
{
    public static class Program
    {
        public static Task<int> Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var consoleLoggerConfiguration = new ConsoleLoggerConfiguration();
            configuration.GetSection("ConsoleLogger").Bind(consoleLoggerConfiguration);

            var serviceCollection = ServiceCollectionFactory.Create(consoleLoggerConfiguration);
            var app = CommandAppFactory.Create(serviceCollection);
            app.Configure(config =>
            {
                config.AddBranch<CommandSettings>("build", add =>
                {
                    add.AddCommand<BuildDemoConsoleSpectreCliCommand>("demo")
                        .WithDescription("Build the Demo.Atc.Console.Spectre.Cli project")
                        .WithExample(new[] { "build demo" });
                });
            });

            return app.RunAsync(args);
        }
    }
}