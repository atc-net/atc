using System.Reflection;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace Atc.Console.Spectre.Factories
{
    public static class CommandAppFactory
    {
        public static CommandApp Create(ServiceCollection serviceCollection)
        {
            Thread.CurrentThread.SetCulture(GlobalizationConstants.EnglishCultureInfo);

            var registrar = new Infrastructure.TypeRegistrar(serviceCollection);
            var commandApp = new CommandApp(registrar);

            var appName = Assembly
                .GetExecutingAssembly()
                .GetName()
                .Name;

            commandApp.Configure(config =>
            {
                config.SetApplicationName($"{appName}.exe");
            });

            return commandApp;
        }
    }
}