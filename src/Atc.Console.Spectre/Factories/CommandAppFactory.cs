namespace Atc.Console.Spectre.Factories;

/// <summary>
/// Factory for creating preconfigured <see cref="CommandApp"/> instances for Spectre.Console CLI applications.
/// </summary>
public static class CommandAppFactory
{
    /// <summary>
    /// Creates a new <see cref="CommandApp"/> with UTF-8 encoding and English culture.
    /// </summary>
    /// <param name="serviceCollection">The service collection containing registered services and command settings.</param>
    /// <returns>A configured <see cref="CommandApp"/> instance.</returns>
    public static CommandApp Create(ServiceCollection serviceCollection)
        => Create(serviceCollection, Encoding.UTF8);

    /// <summary>
    /// Creates a new <see cref="CommandApp"/> with specified encoding and English culture.
    /// </summary>
    /// <param name="serviceCollection">The service collection containing registered services and command settings.</param>
    /// <param name="encoding">The console output encoding to use.</param>
    /// <returns>A configured <see cref="CommandApp"/> instance.</returns>
    public static CommandApp Create(
        ServiceCollection serviceCollection,
        Encoding encoding)
    {
        SetCultureAndConsoleSettings(encoding);

        var registrar = new TypeRegistrar(serviceCollection);

        var commandApp = new CommandApp(registrar);
        commandApp.Configure(config =>
        {
            config.SetApplicationName(GetAppNameExe());
        });

        return commandApp;
    }

    /// <summary>
    /// Creates a new <see cref="CommandApp{T}"/> with a root command, UTF-8 encoding, and English culture.
    /// </summary>
    /// <typeparam name="T">The type of the root command that implements <see cref="ICommand"/>.</typeparam>
    /// <param name="serviceCollection">The service collection containing registered services and command settings.</param>
    /// <returns>A configured <see cref="CommandApp{T}"/> instance with the specified root command.</returns>
    public static CommandApp<T> CreateWithRootCommand<T>(
        ServiceCollection serviceCollection)
        where T : class, ICommand
    {
        SetCultureAndConsoleSettings(Encoding.UTF8);

        var registrar = new TypeRegistrar(serviceCollection);

        var commandApp = new CommandApp<T>(registrar);
        commandApp.Configure(config =>
        {
            config.SetApplicationName(GetAppNameExe());
        });

        return commandApp;
    }

    private static void SetCultureAndConsoleSettings(Encoding encoding)
    {
        Thread.CurrentThread.SetCulture(GlobalizationConstants.EnglishCultureInfo);
        System.Console.OutputEncoding = encoding;
    }

    private static string GetAppNameExe()
    {
        var appName = Assembly
            .GetEntryAssembly()!
            .GetName()
            .Name;

        return $"{appName}.exe";
    }
}