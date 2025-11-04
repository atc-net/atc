# Atc

**Target Frameworks:** `netstandard2.1`, `net9.0`

The foundation library for .NET development, providing a comprehensive collection of common utilities, extension methods, and helpers. Multi-targeting ensures compatibility with a wide range of .NET applications, from .NET Framework 4.7.2+ to the latest .NET versions.

## Why Use This Library?

Atc eliminates boilerplate code and provides battle-tested implementations for common tasks. Instead of writing the same utility code in every project, Atc provides:

- **Rich Extension Methods**: Extensions for all common .NET types (String, DateTime, Enum, Collections, etc.)
- **Logging Utilities**: Structured logging helpers for ILogger
- **Data Structures**: Specialized collections and data structures
- **Serialization Helpers**: JSON serialization utilities with sensible defaults
- **Math & Geometry**: Math operations, geospatial calculations, and coordinate systems
- **Networking Helpers**: Network information and IP address utilities

Perfect for:
- Reducing boilerplate in business applications
- Standardizing common operations across projects
- Improving code readability with expressive extension methods
- Building reusable libraries

## Installation

```bash
dotnet add package Atc
```

## Code Documentation

- [API References](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc/Index.md)
- [Extended References](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc/IndexExtended.md)

## Examples

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

## String Extension Examples

### Using `EnsureFirstCharacterToUpper()`

```csharp
string result = "hello world".EnsureFirstCharacterToUpper();
// Result: "Hello world"
```

### Using `IsDigit()`, `IsNumeric()`, and Validation Extensions

```csharp
bool isDigit = "12345".IsDigit();                    // true
bool isNumeric = "123.45".IsNumeric();                // true
bool isEmail = "user@example.com".IsEmailAddress();   // true
bool isGuid = "550e8400-e29b-41d4-a716-446655440000".IsGuid(); // true
```

### Using `Truncate()`

```csharp
string longText = "This is a very long text that needs truncation";
string short = longText.Truncate(20);
// Result: "This is a very lo..."
```

### Using `ToTitleCase()` and `ToPascalCase()`

```csharp
string title = "hello world".ToTitleCase();    // "Hello World"
string pascal = "hello world".ToPascalCase();  // "HelloWorld"
string camel = "HelloWorld".ToCamelCase();     // "helloWorld"
```

## Enum Extension Examples

### Using `GetName()` and `GetDescription()`

```csharp
public enum Status
{
    [Description("Currently Active")]
    Active,

    [Description("Temporarily Inactive")]
    Inactive
}

Status status = Status.Active;
string name = status.GetName();              // "Active"
string description = status.GetDescription(); // "Currently Active"
```

### Using `GetEnumValue<T>()`

```csharp
Status status = EnumExtensions.GetEnumValue<Status>("Active");
// Result: Status.Active

// With description
Status statusFromDescription = EnumExtensions.GetEnumValueFromDescription<Status>("Currently Active");
// Result: Status.Active
```

## Collection Extension Examples

### Using `AddIfNotContains()`

```csharp
var list = new List<string> { "apple", "banana" };
list.AddIfNotContains("orange");  // Adds "orange"
list.AddIfNotContains("apple");   // Does nothing, already exists
```

### Using `ForEach()`

```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };
numbers.ForEach(n => Console.WriteLine(n * 2));
```

### Using `IsNullOrEmpty()`

```csharp
List<string>? list = null;
bool isEmpty = list.IsNullOrEmpty();  // true

list = new List<string>();
isEmpty = list.IsNullOrEmpty();       // true

list.Add("item");
isEmpty = list.IsNullOrEmpty();       // false
```

## DateTime Extension Examples

### Using `GetAge()`

```csharp
DateTime birthDate = new DateTime(1990, 5, 15);
int age = birthDate.GetAge();  // Current age in years
```

### Using `GetPrettyTimeDiff()`

```csharp
DateTime past = DateTime.Now.AddMinutes(-45);
string diff = past.GetPrettyTimeDiff();
// Result: "45 minutes ago"
```

### Using `IsBetween()`

```csharp
DateTime now = DateTime.Now;
DateTime start = DateTime.Now.AddHours(-1);
DateTime end = DateTime.Now.AddHours(1);

bool isBetween = now.IsBetween(start, end);  // true
```

## JSON Serialization Examples

### Using `JsonSerializerOptionsFactory`

```csharp
using Atc.Serialization;

// Create default options
var options = JsonSerializerOptionsFactory.Create();

// Serialize with camelCase
var json = JsonSerializer.Serialize(myObject, options);

// Deserialize
var obj = JsonSerializer.Deserialize<MyType>(json, options);
```

## Math and Geometry Examples

### Using GeoSpatial Helpers

```csharp
using Atc.Math.GeoSpatial;

var coordinate1 = new CartesianCoordinate(55.6761, 12.5683); // Copenhagen
var coordinate2 = new CartesianCoordinate(51.5074, -0.1278); // London

// Calculate distance in kilometers
double distance = coordinate1.DistanceTo(coordinate2);
```

## Contributing

Contributions are welcome! Please see the main [repository README](../../README.md) for contribution guidelines.
