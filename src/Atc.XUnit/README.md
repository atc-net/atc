# Atc.XUnit

This library contains helpers classes which can help with improving code quality through unit test by unit testing.

## Code documentation

[References](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.XUnit/Index.md)

[References extended](https://github.com/atc-net/atc/blob/main/docs/CodeDoc/Atc.XUnit/IndexExtended.md)

## Usage

CodeComplianceTestHelper have some methods to collect public-methods and ensure that there is minimum one unit-test attached from a unit-test library.

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
