# Atc

**Target Frameworks:** `netstandard2.0`, `net10.0`

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

## Target Frameworks

- .NET Standard 2.0
- .NET 10.0

The library multi-targets to provide broad compatibility with:
- .NET Framework 4.7.2+
- .NET Core 2.1+
- .NET 5+
- .NET 10.0

## Key Dependencies

- Microsoft.Extensions.Logging.Abstractions
- System.Text.Json
- System.ComponentModel.Annotations
- Meziantou.Polyfill (for backward compatibility)

## Main Components

### Extension Methods (Extensions/)

Organized by category:
- **BaseTypes**: String, Int, Double, Bool, Enum, DateTime, TimeSpan
- **Collections**: List, Dictionary, IEnumerable, Array
- **Reflection**: Type, Assembly, MethodInfo
- **Serialization**: JSON serialization helpers
- **Stream**: Stream and byte array operations

### Logging (Logging/)

- `ILogger` extensions for structured logging
- `LogKeyValueItem` for key-value pair logging
- `LogItemFactory` for creating log items

### Math & Geometry (Math/)

- `MathEx`: Extended math operations
- GeoSpatial calculations and coordinates
- Cartesian and geographic coordinate systems

### Helpers

- `NetworkInformationHelper`: Network connectivity and IP address utilities
- `JsonSerializerOptionsFactory`: Preconfigured JSON serialization options

### Data Structures

- Specialized collections
- Custom data structures for common scenarios

### Resources

Localized resources for:
- English (default)
- Danish (da-DK)
- German (de-DE)

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

### Using `TrimToNull()`

```csharp
string? a = "  Main Street  ".TrimToNull();  // "Main Street"
string? b = "   ".TrimToNull();              // null - nothing left, so treat it as not set
string? c = ((string?)null).TrimToNull();    // null
```

### Using `SplitIntoWords()` and `ToCasingStyle()`

```csharp
// Splits at separators, case changes and acronym ends - any input style works.
var words = "XMLParser.v2".SplitIntoWords();               // ["XML", "Parser", "v2"]

"getPetById".ToCasingStyle(CasingStyle.PascalCase);         // "GetPetById"
"XMLParser".ToCasingStyle(CasingStyle.CamelCase);           // "xmlParser"
"MyPetStore".ToCasingStyle(CasingStyle.KebabCase);          // "my-pet-store"
"my-pet-store".ToCasingStyle(CasingStyle.SnakeCase);        // "my_pet_store"
"myPetStore".ToCasingStyle(CasingStyle.UpperSnakeCase);     // "MY_PET_STORE"
```

## Code generation helpers

### Using `CSharpKeywordHelper` and `UniqueNameHelper`

```csharp
CSharpKeywordHelper.IsReservedKeyword("event");           // true
CSharpKeywordHelper.EscapeIfReservedKeyword("event");     // "@event"
CSharpKeywordHelper.IsValidIdentifier("2fa");             // false
CSharpKeywordHelper.EnsureIdentifierStart("2fa", "Header"); // "Header2fa"

var taken = new HashSet<string>(StringComparer.Ordinal);
UniqueNameHelper.Claim(taken, "id");                      // "id"
UniqueNameHelper.Claim(taken, "id");                      // "id2"
```

### Using `InvariantCasingHelper`

```csharp
// Invariant casing that keeps a letter as written when its cased form is no letter to this
// runtime (ICU can be newer than .NET's Unicode tables) - the same output on every platform.
string upper = InvariantCasingHelper.ToUpper("petStore");    // "PETSTORE"
string pascal = InvariantCasingHelper.ToUpperFirst("pet");   // "Pet"
```

### Using `HttpStatusCode.ToEnumName()`

```csharp
HttpStatusCode.NotFound.ToEnumName();    // "NotFound"
((HttpStatusCode)302).ToEnumName();      // "Found" (never the "Redirect" alias)
((HttpStatusCode)499).ToEnumName();      // "Status499"
```

## File and process helpers

### Using `FileSystemTransaction` to undo a half-done operation

```csharp
// Files written through the transaction are put back (and new files and folders removed)
// unless the operation returns 0.
var exitCode = FileSystemTransaction.Run(() =>
{
    FileSystemTransaction.CreateDirectory(projectFolder);
    FileSystemTransaction.WriteAllText(Path.Combine(projectFolder, "Program.cs"), content);
    return RunNextStep();
});
```

### Using `FileHelper.WriteAllTextIfChanged()`

```csharp
// Leaves the file (and its timestamp) alone when it already holds the content.
bool written = FileHelper.WriteAllTextIfChanged(new FileInfo("Generated.cs"), content, useLineFeedLineEndings: true);
```

### Using `GlobHelper`

```csharp
GlobHelper.IsMatch("/api/v1/users/42", "/api/**/users/*");   // true
GlobHelper.IsMatch("src/a/b/Program.cs", "src/**/*.cs");     // true
GlobHelper.IsMatchAny("/pets/1", new[] { "/pets/*", "/users" }); // true
```

### Running a tool with `ProcessHelper`

```csharp
// Find "git" on PATH, close its stdin so it cannot wait for input, stop it after 30 seconds,
// and read stdout and stderr apart.
var git = ProcessHelper.FindExecutableInPath("git");
var result = await ProcessHelper.ExecuteAsync(
    new ProcessStartInfo(git!.FullName, "status --porcelain") { WorkingDirectory = repositoryPath },
    TimeSpan.FromSeconds(30));

if (result.IsSuccessful)
{
    Parse(result.StandardOutput); // warnings are in result.StandardError
}
```

## `NugetFeedClient` examples

### Using `GetLatestStableVersionAsync(..)` to find the latest stable version of a package

The client reads the flat container resource of nuget.org (or another NuGet v3 feed) and returns the highest
version that is not a prerelease. A version found is cached per instance; any failure (no network, an unknown
package, an unexpected answer, a cancellation) gives `null` instead of an exception.

```csharp
INugetFeedClient client = new NugetFeedClient();

Version? latest = await client.GetLatestStableVersionAsync("Atc", cancellationToken);
```

Pass your own `HttpClient` (for example from `IHttpClientFactory`, or one over a fake `HttpMessageHandler` in tests),
and optionally the flat container address of another feed:

```csharp
var client = new NugetFeedClient(
    httpClient,
    new Uri("https://pkgs.example.com/nuget/v3/flatcontainer/"));
```

## `SearchQueryHelper` examples

### Using `Parse()` to split a free-text search into terms

Words split on white space and commas, text in double quotes is one phrase (an unclosed quote
runs to the end), and a full GUID becomes an identifier term. The helper only parses; the caller
decides how each term matches, e.g. a word as a substring, a phrase as whole words and an
identifier as an exact id.

```csharp
var terms = SearchQueryHelper.Parse("\"Main Street 8\" Springfield 5b1eba26-8b25-f111-8341-7c1e52fbbe51");
// [ (Phrase, "Main Street 8"), (Word, "Springfield"), (Identifier, "5b1eba26-8b25-f111-8341-7c1e52fbbe51") ]

// Custom separators, or no GUID detection
var options = new SearchQueryOptions { WordSeparators = [';'], DetectGuids = false };
var custom = SearchQueryHelper.Parse("alpha;beta", options);
// [ (Word, "alpha"), (Word, "beta") ]
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

### Using `ToEnumOrDefault<T>()`

```csharp
DayOfWeek a = "monday".ToEnumOrDefault(DayOfWeek.Sunday);  // DayOfWeek.Monday
DayOfWeek b = "Funday".ToEnumOrDefault(DayOfWeek.Sunday);  // DayOfWeek.Sunday (unknown name)
DayOfWeek c = "42".ToEnumOrDefault(DayOfWeek.Sunday);      // DayOfWeek.Sunday (undefined number)
```

## Claims Extension Examples

### Using `GetDisplayName()`, `GetUsername()`, `GetEmail()` and `GetAppId()`

```csharp
string? objectId = User.GetIdentity();     // Microsoft Entra ID object id (oid)
string? name = User.GetDisplayName();      // "name" claim, e.g. "Jane Doe"
string? username = User.GetUsername();     // ClaimTypes.Name, else "preferred_username"
string? email = User.GetEmail();           // ClaimTypes.Email, else "email", else an email-shaped username
string? appId = User.GetAppId();           // "azp" (v2 tokens), else "appid" (v1 tokens)
```

## `GuidHelper` examples

### Using `CreateDeterministic()`

```csharp
// The same components always give the same Guid - a stable id derived from natural keys.
Guid id = GuidHelper.CreateDeterministic("device", "123");
// Always 9174bb27-8d27-375a-3046-9518b6264ddc
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

### Using `CopyTo()` to apply options you cannot replace

```csharp
// ASP.NET Core minimal APIs: copy every setting and converter, not just a few.
services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(
    o => JsonSerializerOptionsFactory.Create().CopyTo(o.SerializerOptions));
```

### Using `StringEnumMemberJsonConverterFactory` for strict and lenient enums

```csharp
// Names come from [JsonStringEnumMemberName], else [EnumMember], else the member name.
// Non-nullable enums are strict; a nullable enum reads an unknown value (e.g. one a
// third-party API added later) as null instead of failing the whole response.
var options = new JsonSerializerOptions();
options.Converters.Add(new StringEnumMemberJsonConverterFactory(
    onUnknownValue: (type, value) => logger.LogWarning("Unknown {Type} value {Value}", type.Name, value)));
```

### Using `AsyncEnumerableFactory.FromException<T>()`

```csharp
// A stream that fails when enumerated, e.g. to test error handling.
IAsyncEnumerable<Item> failing = AsyncEnumerableFactory.FromException<Item>(new HttpRequestException("Gone"));
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
