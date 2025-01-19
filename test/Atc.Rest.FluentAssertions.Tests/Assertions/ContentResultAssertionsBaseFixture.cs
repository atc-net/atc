namespace Atc.Rest.FluentAssertions.Tests.Assertions;

[SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "OK - false/positive")]
public abstract class ContentResultAssertionsBaseFixture
{
    protected static ContentResult CreateWithJsonContent<T>(T content)
        => new()
        {
            Content = TestJsonSerializer.Serialize(content),
            ContentType = MediaTypeNames.Application.Json,
        };
}