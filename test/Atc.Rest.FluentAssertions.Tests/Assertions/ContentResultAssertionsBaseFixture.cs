namespace Atc.Rest.FluentAssertions.Tests.Assertions;

public abstract class ContentResultAssertionsBaseFixture
{
    protected static ContentResult CreateWithJsonContent<T>(T content)
        => new()
        {
            Content = TestJsonSerializer.Serialize(content),
            ContentType = MediaTypeNames.Application.Json,
        };
}