<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Console.Spectre.Logging

<br />


## ConsoleLogger

```csharp
public class ConsoleLogger : ILogger
```

### Methods


#### BeginScope

```csharp
IDisposable BeginScope(TState state)
```
#### IsEnabled

```csharp
bool IsEnabled(LogLevel logLevel)
```
#### Log

```csharp
void Log(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
```

<br />


## ConsoleLoggerConfiguration

```csharp
public class ConsoleLoggerConfiguration
```

### Properties


#### ConsoleConfiguration

```csharp
ConsoleConfiguration
```
#### ConsoleRender

```csharp
ConsoleRender
```
#### ConsoleSettings

```csharp
ConsoleSettings
```
#### IncludeExceptionNameForException

```csharp
IncludeExceptionNameForException
```
#### IncludeInnerMessageForException

```csharp
IncludeInnerMessageForException
```
#### MinimumLogLevel

```csharp
MinimumLogLevel
```
#### UseFixedWidthSpacing

```csharp
UseFixedWidthSpacing
```
#### UseShortNameForLogLevel

```csharp
UseShortNameForLogLevel
```
### Methods


#### ToString

```csharp
string ToString()
```

<br />


## ConsoleLoggerHelper

```csharp
public static class ConsoleLoggerHelper
```

### Static Methods


#### Output

```csharp
void Output(ILogger logger, LogKeyValueItem logKeyValueItem, bool includeKey = True, bool includeDescription = True)
```
#### Output

```csharp
void Output(ILogger logger, List<LogKeyValueItem> logKeyValueItems, bool includeKey = True, bool includeDescription = True)
```

<br />


## ConsoleLoggerProvider

```csharp
public class ConsoleLoggerProvider : ILoggerProvider, IDisposable
```

### Methods


#### CreateLogger

```csharp
ILogger CreateLogger(string categoryName)
```
#### Dispose

```csharp
void Dispose()
```

<br />


## ConsoleRenderType

```csharp
public enum ConsoleRenderType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | Default | Default |  | 
| 1 | LogLevel | Log Level |  | 
| 2 | CategoryName | Category Name |  | 
| 3 | LogLevelAndCategoryName | Log Level And Category Name |  | 


<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>