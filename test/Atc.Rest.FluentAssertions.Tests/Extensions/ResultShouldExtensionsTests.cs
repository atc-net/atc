﻿using Atc.Rest.Results;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Sdk;

namespace Atc.Rest.FluentAssertions.Tests.Extensions
{
    public class ResultShouldExtensionsTests
    {
        class DummyResult : ActionResult { }

        class AtcDummyResult : ResultBase
        {
            public AtcDummyResult() : base(new DummyResult())
            {
            }
        }

        [Fact]
        public void Should_Returns_ResultAssertion_With_Subject_Set_To_Subject()
        {
            // Arrange
            var target = new AtcDummyResult();

            // Act
            var actual = target.Should();

            // Assert
            actual.Invoking(x => x.BeOkResult())
                .Should()
                .Throw<XunitException>()
                .WithMessage($"*{typeof(DummyResult).FullName}*");
        }
    }
}