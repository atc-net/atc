<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Console.Spectre.Helpers

<br />

## CliUpdateCheckHelper
A start-up check that tells the user of a .NET tool when a newer stable version is on NuGet, with the `dotnet tool update` command to get it.
><b>Remarks:</b> The check is opt-in and best effort: it never throws and never delays the tool by more than its time budget. It is skipped for `-h`, `--help`, `-v` and `--version` (and when no arguments are given), on a CI system (`CI=true`), when a tool-specific opt-out environment variable is set, and for a development build (version 1.0.0.0).
<b>Code example:</b>
>```csharp
>await CliUpdateCheckHelper.CheckForUpdatesAsync(
>    args,
>    new CliUpdateCheckOptions("my-tool") { OptOutEnvironmentVariable = "MY_TOOL_NO_UPDATE_CHECK" });
>```

>```csharp
>public static class CliUpdateCheckHelper
>```

### Static Fields

#### ContinuousIntegrationEnvironmentVariable
>```csharp
>string ContinuousIntegrationEnvironmentVariable
>```
><b>Summary:</b> The environment variable that CI systems set to `true`; the check is skipped when it is set.
#### DefaultBudget
>```csharp
>TimeSpan DefaultBudget
>```
><b>Summary:</b> The default time the whole update check may take: 2 seconds.
### Static Methods

#### CheckForUpdatesAsync
>```csharp
>Task<Version> CheckForUpdatesAsync(string[] args, string packageId, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Runs the update check with default settings for the given tool package: nuget.org, a 2 second budget, the entry assembly version and `Spectre.Console.AnsiConsole.Console`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`args`&nbsp;&nbsp;-&nbsp;&nbsp;The command-line arguments of the tool.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`packageId`&nbsp;&nbsp;-&nbsp;&nbsp;The NuGet package id of the tool.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token that cancels the check.<br />
>
><b>Returns:</b> The newer version that was announced, or <see langword="null" /> when nothing was written.
#### CheckForUpdatesAsync
>```csharp
>Task<Version> CheckForUpdatesAsync(string[] args, CliUpdateCheckOptions options, CancellationToken cancellationToken = null)
>```
><b>Summary:</b> Runs the update check with default settings for the given tool package: nuget.org, a 2 second budget, the entry assembly version and `Spectre.Console.AnsiConsole.Console`.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`args`&nbsp;&nbsp;-&nbsp;&nbsp;The command-line arguments of the tool.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`packageId`&nbsp;&nbsp;-&nbsp;&nbsp;The NuGet package id of the tool.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token that cancels the check.<br />
>
><b>Returns:</b> The newer version that was announced, or <see langword="null" /> when nothing was written.
#### IsDevelopmentVersion
>```csharp
>bool IsDevelopmentVersion(Version version)
>```
><b>Summary:</b> Tells whether a version is the one a local development build gets (1.0.0.0, also written 1.0 or 1.0.0), for which the update check is skipped.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`version`&nbsp;&nbsp;-&nbsp;&nbsp;The version of the running tool.<br />
>
><b>Returns:</b> <see langword="true" /> for a development build; otherwise <see langword="false" />.
#### IsUpdateCheckDisabled
>```csharp
>bool IsUpdateCheckDisabled(Func<string, string> getEnvironmentVariable, string optOutEnvironmentVariable)
>```
><b>Summary:</b> Tells whether the environment turns the update check off: `CI` or the given opt-out variable is `1` or `true` (any casing).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`getEnvironmentVariable`&nbsp;&nbsp;-&nbsp;&nbsp;Reads an environment variable by name, normally .<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`optOutEnvironmentVariable`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the tool's own opt-out variable, or  for none.<br />
>
><b>Returns:</b> <see langword="true" /> when the check should be skipped; otherwise <see langword="false" />.
#### ShouldCheckForUpdates
>```csharp
>bool ShouldCheckForUpdates(string[] args)
>```
><b>Summary:</b> Tells whether the update check should run for the given command line. It is skipped when no arguments are given and for `-h`, `--help`, `-v` and `--version`, which must answer at once.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`args`&nbsp;&nbsp;-&nbsp;&nbsp;The command-line arguments.<br />
>
><b>Returns:</b> <see langword="true" /> when the check should run; otherwise <see langword="false" />.
#### TryGetNewerVersionAsync
>```csharp
>Task<Version> TryGetNewerVersionAsync(INugetFeedClient nugetFeedClient, string packageId, Version currentVersion, TimeSpan budget, CancellationToken cancellationToken)
>```
><b>Summary:</b> Gets the stable version on the feed that is newer than `currentVersion`, within the given time budget. Missing version parts count as 0, so 1.2.3 on the feed is not newer than a running 1.2.3.0.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`nugetFeedClient`&nbsp;&nbsp;-&nbsp;&nbsp;The client the latest version is looked up with.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`packageId`&nbsp;&nbsp;-&nbsp;&nbsp;The NuGet package id of the tool.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`currentVersion`&nbsp;&nbsp;-&nbsp;&nbsp;The version of the running tool.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`budget`&nbsp;&nbsp;-&nbsp;&nbsp;The time the lookup may take; when it runs out, the result is 
            even when the client does not honour cancellation.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`cancellationToken`&nbsp;&nbsp;-&nbsp;&nbsp;A token that cancels the lookup.<br />
>
><b>Returns:</b> The newer version, or <see langword="null" /> when the current version is the latest, the lookup fails or throws, the budget runs out, or the token is cancelled. Never throws for those cases.
#### WriteUpdateAvailable
>```csharp
>void WriteUpdateAvailable(IAnsiConsole console, string packageId, Version currentVersion, Version latestVersion)
>```
><b>Summary:</b> Writes the "Update available" panel with the current and the latest version and the `dotnet tool update -g &lt;package&gt;` command.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`console`&nbsp;&nbsp;-&nbsp;&nbsp;The console the panel is written to.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`packageId`&nbsp;&nbsp;-&nbsp;&nbsp;The NuGet package id of the tool.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`currentVersion`&nbsp;&nbsp;-&nbsp;&nbsp;The version of the running tool.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`latestVersion`&nbsp;&nbsp;-&nbsp;&nbsp;The newer version on the feed.<br />

<br />

## CliUpdateCheckOptions
Settings for the start-up update check of a CLI tool that is installed as a .NET tool, used by `Atc.Console.Spectre.Helpers.CliUpdateCheckHelper.CheckForUpdatesAsync(System.String[],Atc.Console.Spectre.Helpers.CliUpdateCheckOptions,System.Threading.CancellationToken)`.

>```csharp
>public class CliUpdateCheckOptions
>```

### Properties

#### Budget
>```csharp
>Budget
>```
><b>Summary:</b> Gets or sets the time the whole check may take before the tool goes on without it. Defaults to `Atc.Console.Spectre.Helpers.CliUpdateCheckHelper.DefaultBudget` (2 seconds).
#### Console
>```csharp
>Console
>```
><b>Summary:</b> Gets or sets the console the update notice is written to. When <see langword="null" /> (the default), `Spectre.Console.AnsiConsole.Console` is used.
#### CurrentVersion
>```csharp
>CurrentVersion
>```
><b>Summary:</b> Gets or sets the version of the running tool. When <see langword="null" /> (the default), the version of the entry assembly is used.
#### GetEnvironmentVariable
>```csharp
>GetEnvironmentVariable
>```
><b>Summary:</b> Gets or sets the function that reads an environment variable by name. Defaults to `System.Environment.GetEnvironmentVariable(System.String)`; replace it to control the environment in tests.
#### NugetFeedClient
>```csharp
>NugetFeedClient
>```
><b>Summary:</b> Gets or sets the client the latest version is looked up with. When <see langword="null" /> (the default), a `Atc.Nuget.NugetFeedClient` for nuget.org is used.
#### OptOutEnvironmentVariable
>```csharp
>OptOutEnvironmentVariable
>```
><b>Summary:</b> Gets or sets the name of an environment variable that turns the check off when it is `1` or `true`, for example `MY_TOOL_NO_UPDATE_CHECK`. The check is always off when `CI` is set the same way.
#### PackageId
>```csharp
>PackageId
>```
><b>Summary:</b> Gets the NuGet package id of the tool, which is looked up on the feed and shown in the update command.

<br />

## CommandAppHelper
Opt-in settings for a Spectre.Console `Spectre.Console.Cli.ICommandApp`, such as the one created by `Atc.Console.Spectre.Factories.CommandAppFactory`. Nothing here is applied unless it is called.

>```csharp
>public static class CommandAppHelper
>```

### Static Methods

#### UseSingleLineExceptionHandler
>```csharp
>void UseSingleLineExceptionHandler(ICommandApp app)
>```
><b>Summary:</b> Makes the application report a parse error, a validation error or an unhandled exception as a single red line on `Spectre.Console.AnsiConsole.Console` and exit with code 1, instead of printing a stack trace.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`app`&nbsp;&nbsp;-&nbsp;&nbsp;The command application to configure.<br />
#### UseSingleLineExceptionHandler
>```csharp
>void UseSingleLineExceptionHandler(ICommandApp app, IAnsiConsole console)
>```
><b>Summary:</b> Makes the application report a parse error, a validation error or an unhandled exception as a single red line on `Spectre.Console.AnsiConsole.Console` and exit with code 1, instead of printing a stack trace.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`app`&nbsp;&nbsp;-&nbsp;&nbsp;The command application to configure.<br />
#### UseStrictParsing
>```csharp
>void UseStrictParsing(ICommandApp app)
>```
><b>Summary:</b> Makes the application treat an argument or option that no command defines as an error, so a mistyped option fails instead of being silently ignored.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`app`&nbsp;&nbsp;-&nbsp;&nbsp;The command application to configure.<br />
#### WriteException
>```csharp
>int WriteException(IAnsiConsole console, Exception exception)
>```
><b>Summary:</b> Writes an exception as a single red `Error:` line and returns exit code 1. A Spectre.Console.Cli parse error that carries its own rendering (`Spectre.Console.Cli.CommandAppException.Pretty`) is written as that rendering. The exception message is never parsed as markup, so a message that holds a `[`, such as a path, is written as it is. Use it from `config.SetExceptionHandler` when the handler is set up in your own `Configure` call.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`console`&nbsp;&nbsp;-&nbsp;&nbsp;The console the error is written to.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`exception`&nbsp;&nbsp;-&nbsp;&nbsp;The exception to report.<br />
>
><b>Returns:</b> The exit code: always 1.

<br />

## ConsoleHelper
Helper methods for writing formatted output to the console using Spectre.Console.

>```csharp
>public static class ConsoleHelper
>```

### Static Methods

#### WriteHeader
>```csharp
>void WriteHeader(string text)
>```
><b>Summary:</b> Writes a header in ASCII art format with cornflower blue color.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`text`&nbsp;&nbsp;-&nbsp;&nbsp;The text to render as an ASCII header.<br />
#### WriteHeader
>```csharp
>void WriteHeader(string text, Color color)
>```
><b>Summary:</b> Writes a header in ASCII art format with cornflower blue color.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`text`&nbsp;&nbsp;-&nbsp;&nbsp;The text to render as an ASCII header.<br />
#### WriteLog
>```csharp
>void WriteLog(ILogger logger, LogKeyValueItem logItem, bool includeKey = True, bool includeDescription = True)
>```
><b>Summary:</b> Writes a single log key-value item through the logger.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`logger`&nbsp;&nbsp;-&nbsp;&nbsp;The logger to use for output.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`logItem`&nbsp;&nbsp;-&nbsp;&nbsp;The log key-value item to write.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeKey`&nbsp;&nbsp;-&nbsp;&nbsp;If true, includes the key in the output.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDescription`&nbsp;&nbsp;-&nbsp;&nbsp;If true, includes the description in the output.<br />
#### WriteLogs
>```csharp
>void WriteLogs(ILogger logger, List<LogKeyValueItem> logItems, bool includeKey = True, bool includeDescription = True)
>```
><b>Summary:</b> Writes multiple log key-value items through the logger.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`logger`&nbsp;&nbsp;-&nbsp;&nbsp;The logger to use for output.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`logItems`&nbsp;&nbsp;-&nbsp;&nbsp;The list of log key-value items to write.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeKey`&nbsp;&nbsp;-&nbsp;&nbsp;If true, includes the keys in the output.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeDescription`&nbsp;&nbsp;-&nbsp;&nbsp;If true, includes the descriptions in the output.<br />

<br />

## ConsoleOutputWidthHelper
Sets the width Spectre.Console writes in when the output is redirected (a pipe, a CI log, a file).
><b>Remarks:</b> A console without a window is reported as 80 columns wide, so redirected output is wrapped at 80 columns, which breaks long paths and messages over lines that a log reader or a script then cannot find. Applying the redirected width is opt-in: call `Atc.Console.Spectre.Helpers.ConsoleOutputWidthHelper.ApplyRedirectedOutputWidth` early in `Program.Main`.

>```csharp
>public static class ConsoleOutputWidthHelper
>```

### Static Fields

#### ColumnsEnvironmentVariable
>```csharp
>string ColumnsEnvironmentVariable
>```
><b>Summary:</b> The name of the environment variable that can give the width of redirected output: `COLUMNS`.
#### RedirectedOutputWidth
>```csharp
>int RedirectedOutputWidth
>```
><b>Summary:</b> The width, in columns, used for redirected output when the `COLUMNS` environment variable does not give one.
### Static Methods

#### ApplyRedirectedOutputWidth
>```csharp
>bool ApplyRedirectedOutputWidth()
>```
><b>Summary:</b> Sets the width of `Spectre.Console.AnsiConsole.Console` for redirected output when the standard output is redirected, using the `COLUMNS` environment variable or `Atc.Console.Spectre.Helpers.ConsoleOutputWidthHelper.RedirectedOutputWidth`. Nothing is changed when the output goes to a console window.
>
><b>Returns:</b> <see langword="true" /> when the output is redirected and the width was set; otherwise <see langword="false" />.
#### ApplyRedirectedOutputWidth
>```csharp
>bool ApplyRedirectedOutputWidth(IAnsiConsole console, bool isOutputRedirected, string columns)
>```
><b>Summary:</b> Sets the width of `Spectre.Console.AnsiConsole.Console` for redirected output when the standard output is redirected, using the `COLUMNS` environment variable or `Atc.Console.Spectre.Helpers.ConsoleOutputWidthHelper.RedirectedOutputWidth`. Nothing is changed when the output goes to a console window.
>
><b>Returns:</b> <see langword="true" /> when the output is redirected and the width was set; otherwise <see langword="false" />.
#### GetRedirectedOutputWidth
>```csharp
>int GetRedirectedOutputWidth(string columns)
>```
><b>Summary:</b> Gets the width for redirected output.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`columns`&nbsp;&nbsp;-&nbsp;&nbsp;The value of the COLUMNS environment variable, if any.<br />
>
><b>Returns:</b> The value of `columns` when it holds a positive whole number (surrounding white space is ignored); otherwise `Atc.Console.Spectre.Helpers.ConsoleOutputWidthHelper.RedirectedOutputWidth`.

<br />

## ProgramCsHelper
Helper methods for Program.cs setup in Spectre.Console CLI applications.

>```csharp
>public static class ProgramCsHelper
>```

### Static Methods

#### SetHelpArgumentIfNeeded
>```csharp
>string[] SetHelpArgumentIfNeeded(string[] args)
>```
><b>Summary:</b> Returns the command-line arguments with the help argument (`-h`) when none are given, so a tool started without arguments shows its help instead of an error.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`args`&nbsp;&nbsp;-&nbsp;&nbsp;The command-line arguments.<br />
>
><b>Returns:</b> An array holding only `Atc.Console.Spectre.CommandConstants.ArgumentShortHelp` when `args` is empty; otherwise `args` itself.
#### SetMinimumLogLevelIfNeeded
>```csharp
>void SetMinimumLogLevelIfNeeded(string[] args, ConsoleLoggerConfiguration consoleLoggerConfiguration)
>```
><b>Summary:</b> Sets the minimum log level to Trace if the verbose argument is present in the command-line arguments.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`args`&nbsp;&nbsp;-&nbsp;&nbsp;The command-line arguments to check.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`consoleLoggerConfiguration`&nbsp;&nbsp;-&nbsp;&nbsp;The console logger configuration to modify.<br />
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
