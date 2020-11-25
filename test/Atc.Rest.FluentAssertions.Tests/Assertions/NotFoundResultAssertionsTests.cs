using Atc.Rest.FluentAssertions.Tests.XUnitTestData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Sdk;

namespace Atc.Rest.FluentAssertions.Tests.Assertions
{
    public class NotFoundResultAssertionsTests
    {
        [Fact]
        public void Ctor_Sets_Subject_On_Subject_Property()
        {
            // Arrange
            var expected = new ContentResult();

            // Act
            var sut = new NotFoundResultAssertions(expected);

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
                ContentType = "application/json",
            };

            var sut = new NotFoundResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("BAR"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected not found result to be ""BAR"", but ""FOO"" differs near ""FOO"" (index 0).");
        }

        [Fact]
        public void WithContent_Throws_When_Content_Is_Not_Equivalent_To_Expected_WithBecauseMessage()
        {
            // Arrange
            var target = new ContentResult
            {
                Content = "FOO",
                ContentType = "application/json",
            };

            var sut = new NotFoundResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("BAR", "Because of something"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected not found result to be ""BAR"" Because of something, but ""FOO"" differs near ""FOO"" (index 0).");
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

            var sut = new NotFoundResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("FOO"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected not found result to be ""application/json"" with a length of 16, but ""BAZ"" has a length of 3, differs near ""BAZ"" (index 0).");
        }

        [Fact]
        public void WithContent_Does_Not_Throw_When_Expected_Match()
        {
            // Arrange
            var target = new ContentResult
            {
                Content = "FOO",
                ContentType = "application/json",
            };

            var sut = new NotFoundResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("FOO"))
                .Should()
                .NotThrow();
        }

        [Theory]
        [MemberData(nameof(TestDataAssertions.ErrorMessageContent), MemberType = typeof(TestDataAssertions))]
        public void WithErrorMessage_Throws_When_Content_Doenst_Match_Expected(string content)
        {
            // Arrange
            var target = new ContentResult { Content = content };
            var sut = new NotFoundResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithErrorMessage("BAR"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected error message of ""not found result"" to be ""BAR"", but ""FOO"" differs near ""FOO"" (index 0).");
        }

        [Theory]
        [MemberData(nameof(TestDataAssertions.ErrorMessageContent), MemberType = typeof(TestDataAssertions))]
        public void WithErrorMessage_Does_Not_Throw_When_Expected_Match(string content)
        {
            // Arrange
            var target = new ContentResult { Content = content };
            var sut = new NotFoundResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithErrorMessage("FOO"))
                .Should()
                .NotThrow();
        }
    }
}