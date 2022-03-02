# Atc

This library contains common extensions, helpers etc.

## Code documentation

[References](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc/Index.md)

[References extended](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc/IndexExtended.md)

## `ILogger` examples

### Using `logger.LogKeyValueItems(..)`

```csharp
    // Collect data
    var logItems = new List<LogKeyValueItem>
        {
            new LogKeyValueItem(LogCategoryType.Error, "Key1", "Error1"),
            new LogKeyValueItem(LogCategoryType.Warning, "Key2", "Warning1"),
            new LogKeyValueItem(LogCategoryType.Information, "Key3", "Information1"),
            LogItemFactory.CreateError("Key4", "Error2"),
            LogItemFactory.CreateWarning("Key5", "Warning2"),
            LogItemFactory.CreateInformation("Key6", "Information2"),
        };

    // Log data
    logger.LogKeyValueItems(logItems);
```

### Using `logger.LogKeyValueItem(..)`

```csharp
    // Collect data
    var logItem = LogItemFactory.CreateError("Key1", "Error1");

    // Log data
    logger.LogKeyValueItem(LogItemFactory.CreateError(logItem));
```

## `TimeSpanExtensions` examples

### Using `GetPrettyTime()` or `GetPrettyTime(decimalPrecision)`

The default value for `decimalPrecision` is 3.

```csharp
var stopwatch = Stopwatch.StartNew();

DoSomthingThatTakesLongTime();

stopwatch.Stop();

Console.WriteLine($"Running time: {stopwatch.Elapsed.GetPrettyTime()}");
```

Result format could look like:

```powershell
Running time: 14,015 sec
Running time: 13,234 min
Running time: 12,213 hours
```

## `NetworkInformationHelper` examples

### Using `HasConnection()`

This helper method ask a external internet service (GoogleDNS ping), to see it there is connection.

```csharp
bool hasConnection = NetworkInformationHelper.HasConnection()
```

### Using `GetPublicIpAddress()`

This helper method ask a external internet service (ipify.org), to get the external ip address.

```csharp
IPAddress? ipAddress = NetworkInformationHelper.GetPublicIpAddress()
```
