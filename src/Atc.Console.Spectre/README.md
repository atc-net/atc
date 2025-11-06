# Atc.Console.Spectre

**Target Framework:** `net9.0`

Extensions and utilities for building beautiful command-line applications using Spectre.Console. Provides factories and helpers that simplify creating CLI apps with logging, dependency injection, and rich terminal output.

## Why Use This Library?

Building professional CLI applications with Spectre.Console requires setting up command apps, dependency injection, and logging. Atc.Console.Spectre streamlines this by providing:

- **CommandAppFactory**: Quick setup for Spectre.Console command applications
- **ServiceCollectionFactory**: Preconfigured dependency injection for CLI apps
- **Logger Integration**: Built-in console logger with Microsoft.Extensions.Logging
- **Configuration Helpers**: Easy setup for console logger configuration
- **Reduced Boilerplate**: Start building commands faster with less setup code

Perfect for:
- Building developer tools and CLI utilities
- Creating interactive console applications
- Command-line interfaces for automation scripts
- Tools requiring rich terminal output
- CLI apps with dependency injection

## Installation

```bash
dotnet add package Atc.Console.Spectre
```

## Target Framework

- .NET 9.0

## Key Features

- `CommandAppFactory` for creating Spectre.Console command applications
- `ServiceCollectionFactory` for dependency injection setup
- Console logger configuration and integration
- Support for Spectre.Console.Cli command pattern
- Built-in logging to console with structured output
- Configuration binding for console logger settings

## Requirements

- [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

## Key Dependencies

- Spectre.Console
- Spectre.Console.Cli
- Microsoft.Extensions.Logging
- Atc (foundation library)

## Main Components

### CommandAppFactory

Creates configured Spectre.Console command applications with dependency injection:
- `Create(IServiceCollection)`: Creates a command app with DI support

### ServiceCollectionFactory

Creates service collections with preconfigured logging:
- `Create(ConsoleLoggerConfiguration)`: Sets up services with console logging

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

## Contributing

Contributions are welcome! Please see the main [repository README](../../README.md) for contribution guidelines.
