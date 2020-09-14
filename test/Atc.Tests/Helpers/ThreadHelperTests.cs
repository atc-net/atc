using System;
using Atc.Helpers;
using FluentAssertions;
using Xunit;

namespace Atc.Tests.Helpers
{
    public class ThreadHelperTests
    {
        [Fact]
        public void GetParallelOptions()
        {
            // Act
            var actual = ThreadHelper.GetParallelOptions();

            // Assert
            actual.Should().NotBeNull();
            if (Environment.ProcessorCount > 0)
            {
                actual.MaxDegreeOfParallelism.Should().Be(Environment.ProcessorCount - 2);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetParallelOptions_ExemptProcessorCount(int exemptProcessorCount)
        {
            // Act
            var actual = ThreadHelper.GetParallelOptions(exemptProcessorCount);

            // Assert
            actual.Should().NotBeNull();
            if (Environment.ProcessorCount > 0)
            {
                actual.MaxDegreeOfParallelism.Should().Be(Environment.ProcessorCount - exemptProcessorCount);
            }
        }
    }
}