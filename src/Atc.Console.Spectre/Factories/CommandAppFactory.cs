using Atc.Console.Spectre.Factories.Infrastructure;

namespace Atc.Console.Spectre.Factories;

public static class CommandAppFactory
{
    public static CommandApp Create(ServiceCollection serviceCollection)
    {
        return Create(serviceCollection, Encoding.UTF8);
    }

    public static CommandApp Create(ServiceCollection serviceCollection, Encoding encoding)
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

    public static CommandApp<T> CreateWithRootCommand<T>(ServiceCollection serviceCollection)
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