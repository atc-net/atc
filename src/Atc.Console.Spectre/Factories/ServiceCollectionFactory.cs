namespace Atc.Console.Spectre.Factories;

/// <summary>
/// Factory for creating preconfigured <see cref="ServiceCollection"/> instances for Spectre.Console CLI applications.
/// </summary>
public static class ServiceCollectionFactory
{
    /// <summary>
    /// Creates a new <see cref="ServiceCollection"/> with optional console logging and automatic command settings registration.
    /// </summary>
    /// <param name="addConsoleLogger">If true, adds console logging with default configuration.</param>
    /// <param name="autoRegisterCliCommandSettings">If true, automatically registers all CLI command settings from loaded assemblies.</param>
    /// <returns>A configured <see cref="ServiceCollection"/> instance.</returns>
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

    /// <summary>
    /// Creates a new <see cref="ServiceCollection"/> with custom console logger configuration and optional automatic command settings registration.
    /// </summary>
    /// <param name="consoleLoggerConfiguration">The custom console logger configuration to use.</param>
    /// <param name="autoRegisterCliCommandSettings">If true, automatically registers all CLI command settings from loaded assemblies.</param>
    /// <returns>A configured <see cref="ServiceCollection"/> instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="consoleLoggerConfiguration"/> is null.</exception>
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