using System;
using Atc.Console.Spectre.Extensions;
using Atc.Console.Spectre.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Atc.Console.Spectre.Factories
{
    public static class ServiceCollectionFactory
    {
        public static ServiceCollection Create(
            bool addConsoleLogger = true,
            bool autoRegisterCliCommandSettings = true)
        {
            var serviceCollection = new ServiceCollection();

            if (addConsoleLogger)
            {
                serviceCollection.AddConsoleLogging();
            }

            if (autoRegisterCliCommandSettings)
            {
                serviceCollection.AutoRegisterCliCommandSettings();
            }

            return serviceCollection;
        }

        public static ServiceCollection Create(
            ConsoleLoggerConfiguration consoleLoggerConfiguration,
            bool autoRegisterCliCommandSettings = true)
        {
            if (consoleLoggerConfiguration is null)
            {
                throw new ArgumentNullException(nameof(consoleLoggerConfiguration));
            }

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddConsoleLogging(consoleLoggerConfiguration);

            if (autoRegisterCliCommandSettings)
            {
                serviceCollection.AutoRegisterCliCommandSettings();
            }

            return serviceCollection;
        }
    }
}