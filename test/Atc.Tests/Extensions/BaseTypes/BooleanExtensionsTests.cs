using System;
using Xunit;

namespace Atc.Tests.Extensions.BaseTypes
{
    public class BooleanExtensionsTests
    {
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        [InlineData(true, false, false)]
        public void IsEqual(bool expected, bool? a, bool? b)
        {
            // Act
            var actual = a.IsEqual(b);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(1, true)]
        public void ToInt(int expected, bool input)
        {
            // Act
            var actual = input.ToInt();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, null)]
        [InlineData(0, false)]
        [InlineData(1, true)]
        public void ToInt_Nullable(int expected, bool? input)
        {
            // Act
            var actual = input.ToInt();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}