﻿using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Sdk;

namespace Atc.Rest.FluentAssertions.Tests.Assertions
{
    public class AcceptedResultAssertionsTests : ContentResultAssertionsBaseFixture
    {
        [Fact]
        public void Ctor_Sets_Subject_On_Subject_Property()
        {
            // Arrange
            var expected = new ContentResult();

            // Act
            var sut = new AcceptedResultAssertions(expected);

            // Assert
            sut.Subject.Should().Be(expected);
        }

        [Fact]
        public void WithContent_Throws_When_Content_Is_Not_Equivalent_To_Expected()
        {
            // Arrange
            var target = CreateWithJsonContent("FOO");

            var sut = new AcceptedResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("BAR"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected content of accepted result to be ""BAR"", but ""FOO"" differs near ""FOO"" (index 0).");
        }

        [Fact]
        public void WithContent_Throws_When_Content_Is_Not_Equivalent_To_Expected_WithBecauseMessage()
        {
            // Arrange
            var target = CreateWithJsonContent("FOO");

            var sut = new AcceptedResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("BAR", "Because of something"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected content of accepted result to be ""BAR"" Because of something, but ""FOO"" differs near ""FOO"" (index 0).");
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

            var sut = new AcceptedResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("FOO"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected content type of accepted result to be ""application/json"", but found ""BAZ"".");
        }

        [Fact]
        public void WithContent_Does_Not_Throw_When_Expected_Match()
        {
            // Arrange
            var target = CreateWithJsonContent("FOO");

            var sut = new AcceptedResultAssertions(target);

            // Act & Assert
            sut.Invoking(x => x.WithContent("FOO"))
                .Should()
                .NotThrow();
        }
    }
}