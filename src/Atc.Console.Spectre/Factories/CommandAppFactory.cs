using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace Atc.Console.Spectre.Factories
{
    public static class CommandAppFactory
    {
        public static CommandApp Create(ServiceCollection serviceCollection)
        {
            return Create(serviceCollection, Encoding.UTF8);
        }

        public static CommandApp Create(ServiceCollection serviceCollection, Encoding encoding)
        {
            Thread.CurrentThread.SetCulture(GlobalizationConstants.EnglishCultureInfo);
            System.Console.OutputEncoding = encoding;

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