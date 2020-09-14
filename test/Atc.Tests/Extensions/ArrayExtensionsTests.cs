using System;
using FluentAssertions;
using Xunit;

namespace Atc.Tests.Extensions
{
    public class ArrayExtensionsTests
    {
        [Theory]
        [InlineData(new[] { "a", "b" }, new[] { "a", "b", "a" })]
        public void RemoveDuplicates(string[] expected, string[] input)
        {
            // Act
            var actual = input.RemoveDuplicates();

            // Assert
            actual.Should().NotBeNull().And.HaveCount(expected.Length);
            actual.Should()
                .NotBeNull()
                .And.HaveCount(expected.Length)
                .And.Contain(expected);
        }

        [Theory]
        [InlineData(new[] { "a", "b", "a" }, new[] { "a", "b", "a" }, SortDirectionType.None, false)]
        [InlineData(new[] { "a", "b" }, new[] { "a", "b", "a" }, SortDirectionType.None, true)]
        [InlineData(new[] { "a", "b" }, new[] { "a", "b", "a" }, SortDirectionType.Ascending, true)]
        [InlineData(new[] { "b", "a" }, new[] { "a", "b", "a" }, SortDirectionType.Descending, true)]
        public void ToArray(string[] expected, string[] input, SortDirectionType sortDirectionType, bool removeDuplicates)
        {
            // Act
            var actual = input.ToArray(sortDirectionType, removeDuplicates);

            // Assert
            actual.Should()
                .NotBeNull()
                .And.HaveCount(expected.Length)
                .And.Contain(expected);
        }

        [Theory]
        [InlineData(new[] { "a", "b", "a" }, new[] { "a", "b", "a" }, SortDirectionType.None, false)]
        [InlineData(new[] { "a", "b" }, new[] { "a", "b", "a" }, SortDirectionType.None, true)]
        [InlineData(new[] { "a", "b" }, new[] { "a", "b", "a" }, SortDirectionType.Ascending, true)]
        [InlineData(new[] { "b", "a" }, new[] { "a", "b", "a" }, SortDirectionType.Descending, true)]
        public void ToList(string[] expected, string[] input, SortDirectionType sortDirectionType, bool removeDuplicates)
        {
            // Act
            var actual = input.ToList(sortDirectionType, removeDuplicates);

            // Assert
            actual.Should()
                .NotBeNull()
                .And.HaveCount(expected.Length)
                .And.Contain(expected);
        }
    }
}