using System.Threading.Tasks;
using Atc.Console.Spectre.Factories;
using Demo.Atc.Console.Spectre.Cli.Commands;

namespace Demo.Atc.Console.Spectre.Cli
{
    public static class Program
    {
        public static Task<int> Main(string[] args)
        {
            var serviceCollection = ServiceCollectionFactory.Create();
            var app = CommandAppFactory.Create(serviceCollection);
            app.Configure(config =>
            {
                config.AddCommand<HelloCommand>("hello")
                    .WithDescription("Say hello")
                    .WithExample(new[] { "hello Phil" })
                    .WithExample(new[] { "hello Phil --count 4" });

                config.AddCommand<LogCommand>("log")
                    .WithDescription("Write a log message")
                    .WithExample(new[] { "log Hello world" })
                    .WithExample(new[] { "log Hello world --logLevel Trace" })
                    .WithExample(new[] { "log Hello world --logLevel Debug" })
                    .WithExample(new[] { "log Hello world --logLevel Information" })
                    .WithExample(new[] { "log Hello world --logLevel Warning" })
                    .WithExample(new[] { "log Hello world --logLevel Error" })
                    .WithExample(new[] { "log Hello world --logLevel Critical" });
            });

            return app.RunAsync(args);
        }
    }
}