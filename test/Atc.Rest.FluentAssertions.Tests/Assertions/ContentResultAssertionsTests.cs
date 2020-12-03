using System.Net;
using System.Net.Mime;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Sdk;

namespace Atc.Rest.FluentAssertions.Tests.Assertions
{
    public class ContentResultAssertionsTests
    {
        [Fact]
        public void Ctor_Sets_Subject_On_Subject_Property()
        {
            // Arrange
            var expected = new ContentResult();

            // Act
            var sut = new ContentResultAssertions(expected);

            // Assert
            sut.Subject.Should().Be(expected);
        }

        [Fact]
        public void WithContent_Throws_When_Content_Is_Not_Equivalent_To_Expected()
        {
            // Arrange
            var target = new ContentResult
            {
                Content = "FOO",
                ContentType = MediaTypeNames.Application.Json,
            };

            var sut = new ContentResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("BAR"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected content result to be ""BAR"", but ""FOO"" differs near ""FOO"" (index 0).");
        }

        [Fact]
        public void WithContent_Throws_When_Content_Is_Not_Equivalent_To_Expected_WithBecauseMessage()
        {
            // Arrange
            var target = new ContentResult
            {
                Content = "FOO",
                ContentType = MediaTypeNames.Application.Json,
            };

            var sut = new ContentResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("BAR", "Because of something"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected content result to be ""BAR"" Because of something, but ""FOO"" differs near ""FOO"" (index 0).");
        }

        [Fact]
        public void WithContent_Throws_When_ContentTypes_Isnt_Json()
        {
            // Arrange
            var target = new ContentResult
            {
                Content = "FOO",
                ContentType = "BAZ",
            };

            var sut = new ContentResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("FOO"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected content result to be ""application/json"" with a length of 16, but ""BAZ"" has a length of 3, differs near ""BAZ"" (index 0).");
        }

        [Fact]
        public void WithContent_Does_Not_Throw_When_Expected_Match()
        {
            // Arrange
            var target = new ContentResult
            {
                Content = "FOO",
                ContentType = MediaTypeNames.Application.Json,
            };

            var sut = new ContentResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("FOO"))
                .Should()
                .NotThrow();
        }

        [Fact]
        public void WithStatusCode_Throws_When_StatusCode_Is_Not_As_Expected()
        {
            // Arrange
            var target = new ContentResult
            {
                StatusCode = 100,
            };

            var sut = new ContentResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithStatusCode(StatusCodes.Status200OK, "FOO {0}", "BAR"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected status code to be 200 because FOO BAR, but found 100.");

            sut.Invoking(x => x.WithStatusCode(HttpStatusCode.OK, "FOO {0}", "BAR"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected status code to be 200 because FOO BAR, but found 100.");
        }

        [Fact]
        public void WithStatusCode_Does_Not_Throws_When_StatusCode_Is_As_Expected()
        {
            // Arrange
            var target = new ContentResult
            {
                StatusCode = StatusCodes.Status200OK,
            };

            var sut = new ContentResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithStatusCode(StatusCodes.Status200OK, "FOO", "BAR"))
                .Should()
                .NotThrow();

            sut.Invoking(x => x.WithStatusCode(HttpStatusCode.OK, "FOO", "BAR"))
                .Should()
                .NotThrow();
        }
    }
}