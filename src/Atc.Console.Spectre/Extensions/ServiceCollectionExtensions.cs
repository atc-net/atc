namespace Atc.Console.Spectre.Extensions;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/> to configure console logging and command settings.
/// </summary>
[SuppressMessage("Log Injection", "S4792:Configuring loggers is security-sensitive", Justification = "OK.")]
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds console logging to the service collection using default configuration.
    /// </summary>
    /// <param name="serviceCollection">The service collection to configure.</param>
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

    /// <summary>
    /// Adds console logging to the service collection using custom configuration.
    /// </summary>
    /// <param name="serviceCollection">The service collection to configure.</param>
    /// <param name="consoleLoggerConfiguration">The custom console logger configuration.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="consoleLoggerConfiguration"/> is null.</exception>
    public static void AddConsoleLogging(
        this IServiceCollection serviceCollection,
        ConsoleLoggerConfiguration consoleLoggerConfiguration)
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

    /// <summary>
    /// Automatically registers all <see cref="global::Spectre.Console.Cli.CommandSettings"/> types from loaded assemblies as singletons.
    /// </summary>
    /// <param name="serviceCollection">The service collection to configure.</param>
    public static void AutoRegisterCliCommandSettings(this IServiceCollection serviceCollection)
    {
        var assemblies = AppDomain.CurrentDomain.GetCustomAssemblies();
        foreach (var assembly in assemblies)
        {
            var commandSettingTypes = assembly.GetTypesInheritingFromType(typeof(global::Spectre.Console.Cli.CommandSettings));
            foreach (var commandSettingType in commandSettingTypes)
            {
                serviceCollection.AddSingleton(commandSettingType);
            }
        }
    }
}