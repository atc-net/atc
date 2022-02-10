# Atc.Console.Spectre

This library contains extensions to the Spectre.Console library.

## Code documentation

[References](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.Console.Spectre/Index.md)

[References extended](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.Console.Spectre/IndexExtended.md)

## `CommandAppFactory` examples

### Using `Create(..)`

Example with a minimal setup in the `Program.cs` with use `CommandAppFactory.Create`

```csharp
public static class Program
{
    public static Task<int> Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        var consoleLoggerConfiguration = new ConsoleLoggerConfiguration();
        configuration.GetSection("ConsoleLogger").Bind(consoleLoggerConfiguration);

        var serviceCollection = ServiceCollectionFactory.Create(consoleLoggerConfiguration);
        var app = CommandAppFactory.Create(serviceCollection);
        app.Configure(config =>
        {
            config.AddCommand<HelloCommand>("hello")
                .WithDescription("Say hello")
                .WithExample(new[] { "hello Phil" });

            config.AddCommand<LogCommand>("log")
                .WithDescription("Write a log message")
                .WithExample(new[] { "log Hello world" });
        });

        return app.RunAsync(args);
    }
}
```
