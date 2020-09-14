using Atc.Structs;
using Xunit;

namespace Atc.Tests.Structs
{
    public class CartesianCoordinateTests
    {
        [Theory]
        [InlineData(true, 0, 0)]
        [InlineData(false, 1, 0)]
        [InlineData(false, 0, 1)]
        [InlineData(false, 1, 1)]
        public void IsDefault(bool expected, int x, int y)
        {
            // Arrange
            var input = new CartesianCoordinate(x, y);

            // Act
            var actual = input.IsDefault;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}