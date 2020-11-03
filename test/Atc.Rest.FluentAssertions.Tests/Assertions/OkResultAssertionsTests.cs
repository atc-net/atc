using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Xunit;
using Xunit.Sdk;

namespace Atc.Rest.FluentAssertions.Tests.Assertions
{
    public class OkResultAssertionsTests
    {
        [Fact]
        public void WithContent_Throws_When_Content_Is_Not_Equivalent_To_Expected()
        {
            var target = new OkObjectResult("FOO");
            target.ContentTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
            var sut = new OkResultAssertions(target);

            sut.Invoking(x => x.WithContent("BAR"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected OK result to be ""BAR"", but ""FOO"" differs near ""FOO"" (index 0).");
        }

        [Fact(Skip = "Skipped until issue #18 is fixed.")]
        public void WithContent_Throws_When_ContentTypes_Isnt_Json()
        {
            var target = new OkObjectResult("FOO");
            var sut = new OkResultAssertions(target);

            sut.Invoking(x => x.WithContent("FOO"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected OK result to contain only items matching (x == ""application/json""), but the collection is empty.");
        }

        [Fact]
        public void WithContent_Does_Not_Throw_When_Expected_Match()
        {
            var target = new OkObjectResult("FOO");
            target.ContentTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
            var sut = new OkResultAssertions(target);

            sut.Invoking(x => x.WithContent("FOO"))
                .Should()
                .NotThrow();
        }
    }
}