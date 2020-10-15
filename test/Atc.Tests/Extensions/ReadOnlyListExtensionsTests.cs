using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Atc.Tests.Extensions
{
    public class ReadOnlyListExtensionsTests
    {
        [Theory]
        [InlineData(15, new[] { "a", "b", "c", "d" })]
        public void GetUniqueCombinations(int expected, string[] input)
        {
            // Act
            var actual = input.GetUniqueCombinations();

            // Assert
            actual.Should().NotBeNull().And.HaveCount(expected);
        }

        [Theory]
        [InlineData(15, new[] { "a", "b", "c", "d" })]
        public void GetUniqueCombinationsAsCommaSeparated(int expected, string[] input)
        {
            // Act
            var actual = input.GetUniqueCombinationsAsCommaSeparated();

            // Assert
            actual.Should().NotBeNull().And.HaveCount(expected);
        }

        [Theory]
        [InlineData(16, new[] { "a", "b", "c", "d" })]
        public void GetPowerSet(int expected, string[] input)
        {
            // Act
            var actual = input.GetPowerSet();

            // Assert
            actual.Should().NotBeNull().And.HaveCount(expected);
        }
    }
}