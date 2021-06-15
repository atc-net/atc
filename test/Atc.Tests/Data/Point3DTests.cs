using Xunit;

namespace Atc.Tests.Data
{
    public class Point3DTests
    {
        [Theory]
        [InlineData(true, 0, 0, 0)]
        [InlineData(false, 1, 0, 0)]
        [InlineData(false, 0, 1, 0)]
        [InlineData(false, 1, 1, 0)]
        public void IsDefault(bool expected, int x, int y, int z)
        {
            // Arrange
            var input = new Point3D(x, y, z);

            // Act
            var actual = input.IsDefault;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}