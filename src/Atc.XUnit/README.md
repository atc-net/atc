# Atc.XUnit

**Target Framework:** `net9.0`

Testing utilities and code compliance helpers for xUnit v3 tests. This library helps ensure code quality by detecting missing tests, verifying documentation coverage, and providing custom test output helpers.

## Why Use This Library?

Maintaining high code quality requires comprehensive test coverage and documentation. Atc.XUnit automates the verification of:

- **Test Coverage**: Ensure all public methods have at least one test
- **Documentation Coverage**: Verify XML documentation exists for public APIs
- **Test Output**: Capture and display test output with xUnit's ITestOutputHelper integration
- **Code Compliance**: Enforce coding standards through automated tests

Perfect for:
- Enforcing test coverage policies
- Preventing undocumented public APIs
- Maintaining code quality standards
- Continuous integration validation

## Installation

```bash
dotnet add package Atc.XUnit
```

## Target Framework

- .NET 9.0

## Key Dependencies

- xUnit.v3 (assert, common, extensibility.core)
- ICSharpCode.Decompiler (for code analysis)
- EPPlus 7.5.3 (version-pinned for licensing)
- Mono.Reflection
- Atc.CodeDocumentation
- Atc (foundation library)

## Code Documentation

- [API References](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.XUnit/Index.md)
- [Extended References](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.XUnit/IndexExtended.md)

## Examples

### Assert public-methods with missing unit-tests

```csharp
public static class CodeComplianceTestHelper
{
    [Fact]
    public void AssertExportedMethodsWithMissingTests()
    {
        // Arrange
        var sourceAssembly = typeof(AtcAssemblyTypeInitializer).Assembly;
        var testAssembly = typeof(CodeComplianceTests).Assembly;

        // Act & Assert
        CodeComplianceTestHelper.AssertExportedMethodsWithMissingTests(
            DecompilerType.AbstractSyntaxTree,
            sourceAssembly,
            testAssembly);
    }
}
```

Output example from AssertExportedMethodsWithMissingTests where 13 methods over 2 classes don't have any unit-tests:
```
Xunit.Sdk.TrueException
Assembly: Atc (13)
   Type: Atc.Math.MathEx (11)
      Rect(int x, int width = 1, int height = 1)
      Hysteron(ref int state, int x, int width = 1, int height = 1)
      Ceiling(int x, int period)
      Floor(int x, int period)
      SawTooth(int x, int period)
      Multiply(Func<int, int> f, Func<int, int> g)
      Compose(Func<int, int> f, Func<int, int> g)
      Floor(Func<int, int> f, int period)
      Ceiling(Func<int, int> f, int period)
      Periodic(Func<int, int> f, int period)
      Modulate(Func<int, int> carrier, Func<int, int> cellFunction, int period)
   Type: Atc.Serialization.JsonConverters.JsonTypeDiscriminatorConverter<T> (2)
      Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
      Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
```

### Collect public-methods with missing unit-tests

```csharp
public MethodInfo[] CollectExportedTypesWithMissingTests(
    Assembly sourceAssembly,
    Assembly testAssembly,)
{
    return CodeComplianceTestHelper.CollectExportedMethodsWithMissingTestsFromAssembly(
        DecompilerType.AbstractSyntaxTree,
        sourceAssembly,
        testAssembly);
}
```

### Using XUnitLogger for Test Output

The `XUnitLogger` integrates with xUnit's `ITestOutputHelper` to capture logging during tests:

```csharp
public class MyTests
{
    private readonly ILogger logger;

    public MyTests(ITestOutputHelper output)
    {
        // Create a logger that writes to test output
        logger = XUnitLogger.Create(output);
    }

    [Fact]
    public void TestWithLogging()
    {
        // Logging will appear in test output
        logger.LogInformation("Starting test");

        // Your test code
        var result = PerformOperation();

        logger.LogInformation("Test completed with result: {Result}", result);

        Assert.NotNull(result);
    }
}
```

### Testing for Missing Documentation

Ensure all public types have XML documentation:

```csharp
[Fact]
public void AssertExportedTypesWithMissingDocumentation()
{
    // Arrange
    var sourceAssembly = typeof(MyLibraryType).Assembly;

    // Act & Assert
    CodeDocumentationTestHelper.AssertExportedTypesWithMissingComments(
        sourceAssembly);
}
```

### Testing for Missing Test Methods

Detect methods without corresponding tests:

```csharp
[Fact]
public void AssertExportedMethodsWithMissingTests()
{
    // Arrange
    var sourceAssembly = typeof(MyLibrary).Assembly;
    var testAssembly = typeof(MyLibraryTests).Assembly;

    var excludedTypes = new[]
    {
        typeof(InternalHelper),  // Exclude specific types
    };

    // Act & Assert
    CodeComplianceTestHelper.AssertExportedMethodsWithMissingTests(
        DecompilerType.AbstractSyntaxTree,
        sourceAssembly,
        testAssembly,
        excludedTypes);
}
```

### Serialization Testing Helper

Test JSON serialization/deserialization round-trips:

```csharp
[Fact]
public void TestSerializationRoundTrip()
{
    // Arrange
    var original = new MyDto
    {
        Id = 1,
        Name = "Test",
        CreatedAt = DateTime.UtcNow
    };

    // Act & Assert - verifies serialize -> deserialize yields equal object
    SerializeAndDeserializeHelper.Assert<MyDto>(original);
}
```

## Advanced Usage

### Custom Logger Provider

Create custom loggers for different test scenarios:

```csharp
public class MyTestClass
{
    private readonly ILogger logger;

    public MyTestClass(ITestOutputHelper output)
    {
        var provider = new XUnitLoggerProvider(output);
        var factory = new LoggerFactory();
        factory.AddProvider(provider);

        logger = factory.CreateLogger<MyTestClass>();
    }
}
```

### Filtering Test Coverage

Exclude internal types or implementation details from coverage checks:

```csharp
[Fact]
public void VerifyTestCoverage()
{
    var sourceAssembly = typeof(PublicApi).Assembly;
    var testAssembly = typeof(PublicApiTests).Assembly;

    var excludedTypes = new[]
    {
        typeof(InternalImplementation),
        typeof(GeneratedCode),
    };

    var excludedMethods = new[]
    {
        "ToString",  // Exclude standard object methods
        "GetHashCode",
        "Equals",
    };

    CodeComplianceTestHelper.AssertExportedMethodsWithMissingTests(
        DecompilerType.AbstractSyntaxTree,
        sourceAssembly,
        testAssembly,
        excludedTypes,
        excludedMethods);
}
```

## Best Practices

1. **Run Compliance Tests in CI**: Add code compliance tests to your build pipeline to catch issues early
2. **Exclude Generated Code**: Don't enforce coverage on auto-generated code
3. **Document Exclusions**: When excluding types, add comments explaining why
4. **Use Logger in Tests**: Capture diagnostic information to help debug test failures
5. **Regular Updates**: Run documentation compliance regularly to ensure new APIs are documented

## Contributing

Contributions are welcome! Please see the main [repository README](../../README.md) for contribution guidelines.
