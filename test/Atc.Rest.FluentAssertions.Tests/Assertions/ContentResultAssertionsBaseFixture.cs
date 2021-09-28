using System.Net.Mime;
using Atc.Rest.FluentAssertions.Tests.XUnitTestData;
using Microsoft.AspNetCore.Mvc;

namespace Atc.Rest.FluentAssertions.Tests.Assertions
{
    public abstract class ContentResultAssertionsBaseFixture
    {
        protected static ContentResult CreateWithJsonContent<T>(T content)
            => new ContentResult
            {
                Content = TestJsonSerializer.Serialize(content),
                ContentType = MediaTypeNames.Application.Json,
            };
    }
}