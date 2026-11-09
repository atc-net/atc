# Atc.Console.Spectre

**Target Framework:** `net10.0`

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

- .NET 10.0

## Key Features

- `CommandAppFactory` for creating Spectre.Console command applications
- `ServiceCollectionFactory` for dependency injection setup
- Console logger configuration and integration
- Support for Spectre.Console.Cli command pattern
- Built-in logging to console with structured output
- Configuration binding for console logger settings
- Opt-in Program.cs helpers: help when no arguments are given, redirected output width, single-line errors, strict parsing and a .NET tool update check

## Requirements

- [.NET 10](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)

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

## Program.cs helpers

All of these are opt-in: nothing changes until you call them.

### Show the help when no arguments are given

```csharp
args = ProgramCsHelper.SetHelpArgumentIfNeeded(args);
```

### Do not wrap redirected output at 80 columns

When the output is redirected (a pipe, a CI log), the console reports 80 columns and long lines are broken.
`ApplyRedirectedOutputWidth()` sets the width to the `COLUMNS` environment variable, or 240 when it is not set.

```csharp
ConsoleOutputWidthHelper.ApplyRedirectedOutputWidth();
```

### Report errors as one red line and reject unknown options

```csharp
var app = CommandAppFactory.Create(serviceCollection);

// A parse error or an unhandled exception is printed as "Error: <message>" and exits with 1.
// The message is never parsed as markup, so a path with '[' in it is printed as it is.
CommandAppHelper.UseSingleLineExceptionHandler(app);

// An option that no command defines is an error instead of being ignored.
CommandAppHelper.UseStrictParsing(app);
```

Inside your own `Configure` call, use `config.SetExceptionHandler((ex, _) => CommandAppHelper.WriteException(AnsiConsole.Console, ex))`.

### Tell the user about a newer version of a .NET tool

The check looks up the latest stable version of the tool package on nuget.org and, when it is newer than the running
version, writes an "Update available" panel with the `dotnet tool update -g <package>` command.
It is skipped for `-h`, `--help`, `-v`, `--version` and no arguments, when `CI` or the opt-out variable is `1`/`true`,
for a development build (1.0.0.0), and gives up after a time budget (2 seconds by default). It never throws.

```csharp
await CliUpdateCheckHelper.CheckForUpdatesAsync(
    args,
    new CliUpdateCheckOptions("my-tool")
    {
        OptOutEnvironmentVariable = "MY_TOOL_NO_UPDATE_CHECK",
    });
```

`CliUpdateCheckOptions` also takes the `INugetFeedClient`, the `IAnsiConsole`, the current version, the budget and the
environment reader, so the check can be tested without the network.

## Contributing

Contributions are welcome! Please see the main [repository README](../../README.md) for contribution guidelines.
