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
        public void Ctor_Sets_Subject_On_Subject_Property()
        {
            var expected = new OkObjectResult("FOO");

            var sut = new OkResultAssertions(expected);

            sut.Subject.Should().Be(expected);
        }

        [Fact]
        public void WithContent_Throws_When_Content_Is_Not_Equivalent_To_Expected()
        {
            // Arrange
            var target = new OkObjectResult("FOO");
            target.ContentTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
            var sut = new OkResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("BAR"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected OK result value to be ""BAR"", but ""FOO"" differs near ""FOO"" (index 0).");
        }

        [Fact]
        public void WithContent_Throws_When_Content_Is_Not_Equivalent_To_Expected_WithBecauseMessage()
        {
            // Arrange
            var target = new OkObjectResult("FOO");
            target.ContentTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
            var sut = new OkResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("BAR", "Because of something"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected OK result value to be ""BAR"" Because of something, but ""FOO"" differs near ""FOO"" (index 0).");
        }

        [Fact]
        public void WithContentOfType_Throws_When_Content_Is_Not_Expected_Type_With_BecauseMessage()
        {
            // Arrange
            var target = new OkObjectResult("FOO");
            var sut = new OkResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContentOfType<int>("Because of something"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected type to be System.Int32 Because of something, but found System.String.");
        }

        [Fact]
        public void WithContent_Does_Not_Throw_When_Expected_Match()
        {
            // Arrange
            var target = new OkObjectResult("FOO");
            target.ContentTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
            var sut = new OkResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("FOO"))
                .Should()
                .NotThrow();
        }
    }
}