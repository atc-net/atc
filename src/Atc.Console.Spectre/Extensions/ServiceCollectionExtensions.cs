namespace Atc.Console.Spectre.Extensions;

[SuppressMessage("Log Injection", "S4792:Configuring loggers is security-sensitive", Justification = "OK.")]
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
        var assemblies = AppDomain.CurrentDomain.GetCustomAssemblies();
        foreach (var assembly in assemblies)
        {
            var commandSettingTypes = assembly.GetTypesInheritingFromType(typeof(CommandSettings));
            foreach (var commandSettingType in commandSettingTypes)
            {
                serviceCollection.AddSingleton(commandSettingType);
            }
        }
    }
}