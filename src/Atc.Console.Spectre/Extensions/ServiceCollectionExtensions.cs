using System;
using System.Linq;
using System.Reflection;
using Atc.Console.Spectre.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Spectre.Console.Cli;

namespace Atc.Console.Spectre.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddConsoleLogging(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddLogging(logger =>
            {
                var consoleLoggerConfiguration = new ConsoleLoggerConfiguration();
                var consoleLoggerProvider = new ConsoleLoggerProvider(consoleLoggerConfiguration);
                logger.SetMinimumLevel(consoleLoggerConfiguration.MinimumLogLevel);
                logger.AddProvider(consoleLoggerProvider);
            });
        }

        public static void AddConsoleLogging(this IServiceCollection serviceCollection, ConsoleLoggerConfiguration consoleLoggerConfiguration)
        {
            if (consoleLoggerConfiguration is null)
            {
                throw new ArgumentNullException(nameof(consoleLoggerConfiguration));
            }

            serviceCollection.AddLogging(logger =>
            {
                var consoleLoggerProvider = new ConsoleLoggerProvider(consoleLoggerConfiguration);
                logger.SetMinimumLevel(consoleLoggerConfiguration.MinimumLogLevel);
                logger.AddProvider(consoleLoggerProvider);
            });
        }

        public static void AutoRegisterCliCommandSettings(this IServiceCollection serviceCollection)
        {
            var commandSettingTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.IsInheritedFrom(typeof(CommandSettings)))
                .ToArray();

            foreach (var commandSettingType in commandSettingTypes)
            {
                serviceCollection.AddSingleton(commandSettingType);
            }
        }
    }
}