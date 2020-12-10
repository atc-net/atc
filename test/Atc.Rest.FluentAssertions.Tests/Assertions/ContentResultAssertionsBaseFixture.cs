using System.Net.Mime;
using Atc.Rest.FluentAssertions.Tests.XUnitTestData;
using Microsoft.AspNetCore.Mvc;

namespace Atc.Rest.FluentAssertions.Tests.Assertions
{
    public abstract class ContentResultAssertionsBaseFixture
    {
        protected ContentResult CreateWithJsonContent<T>(T content)
        {
            return new ContentResult
            {
                Content = TestJsonSerializer.Serialize(content),
                ContentType = MediaTypeNames.Application.Json,
            };
        }
    }
}