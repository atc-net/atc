namespace Atc.Rest.FluentAssertions.Tests.Assertions;

public abstract class ContentResultAssertionsBaseFixture
{
    protected static ContentResult CreateWithJsonContent<T>(T content)
        => new ContentResult
        {
            Content = TestJsonSerializer.Serialize(content),
            ContentType = MediaTypeNames.Application.Json,
        };
}