using Atc.Helpers;
using Xunit;

namespace Atc.Tests.Helpers.Enums
{
    public class CardinalDirectionTypeHelperTests
    {
        [Theory]
        [InlineData(CardinalDirectionType.South, CardinalDirectionType.West, CardinalDirectionType.Simple)]
        [InlineData(CardinalDirectionType.SouthWest, CardinalDirectionType.West, CardinalDirectionType.Medium)]
        [InlineData(CardinalDirectionType.WestSouthWest, CardinalDirectionType.West, CardinalDirectionType.Advanced)]
        public void GetWhenRotateLeft(CardinalDirectionType expected, CardinalDirectionType input, CardinalDirectionType cardinalDirectionTypeToInclude)
            => Assert.Equal(expected, CardinalDirectionTypeHelper.GetWhenRotateLeft(cardinalDirectionTypeToInclude, input));

        [Theory]
        [InlineData(CardinalDirectionType.North, CardinalDirectionType.West, CardinalDirectionType.Simple, 3)]
        [InlineData(CardinalDirectionType.SouthEast, CardinalDirectionType.West, CardinalDirectionType.Medium, 3)]
        [InlineData(CardinalDirectionType.SouthSouthWest, CardinalDirectionType.West, CardinalDirectionType.Advanced, 3)]
        public void GetWhenRotateLeft_RotationNumber(CardinalDirectionType expected, CardinalDirectionType input, CardinalDirectionType cardinalDirectionTypeToInclude, int rotationNumber)
            => Assert.Equal(expected, CardinalDirectionTypeHelper.GetWhenRotateLeft(cardinalDirectionTypeToInclude, input, rotationNumber));

        [Theory]
        [InlineData(CardinalDirectionType.North, CardinalDirectionType.West, CardinalDirectionType.Simple)]
        [InlineData(CardinalDirectionType.NorthWest, CardinalDirectionType.West, CardinalDirectionType.Medium)]
        [InlineData(CardinalDirectionType.WestNorthWest, CardinalDirectionType.West, CardinalDirectionType.Advanced)]
        public void GetWhenRotateRight(CardinalDirectionType expected, CardinalDirectionType input, CardinalDirectionType cardinalDirectionTypeToInclude)
            => Assert.Equal(expected, CardinalDirectionTypeHelper.GetWhenRotateRight(cardinalDirectionTypeToInclude, input));

        [Theory]
        [InlineData(CardinalDirectionType.South, CardinalDirectionType.West, CardinalDirectionType.Simple, 3)]
        [InlineData(CardinalDirectionType.NorthEast, CardinalDirectionType.West, CardinalDirectionType.Medium, 3)]
        [InlineData(CardinalDirectionType.NorthNorthWest, CardinalDirectionType.West, CardinalDirectionType.Advanced, 3)]
        public void GetWhenRotateRight_RotationNumber(CardinalDirectionType expected, CardinalDirectionType input, CardinalDirectionType cardinalDirectionTypeToInclude, int rotationNumber)
            => Assert.Equal(expected, CardinalDirectionTypeHelper.GetWhenRotateRight(cardinalDirectionTypeToInclude, input, rotationNumber));

        [Theory]
        [InlineData(CardinalDirectionType.East, CardinalDirectionType.West, CardinalDirectionType.Simple)]
        [InlineData(CardinalDirectionType.East, CardinalDirectionType.West, CardinalDirectionType.Medium)]
        [InlineData(CardinalDirectionType.East, CardinalDirectionType.West, CardinalDirectionType.Advanced)]
        public void GetWhenRotate180(CardinalDirectionType expected, CardinalDirectionType input, CardinalDirectionType cardinalDirectionTypeToInclude)
            => Assert.Equal(expected, CardinalDirectionTypeHelper.GetWhenRotate180(cardinalDirectionTypeToInclude, input));

        [Theory]
        [InlineData(CardinalDirectionType.East, CardinalDirectionType.Simple, 0)]
        [InlineData(CardinalDirectionType.East, CardinalDirectionType.Simple, 10)]
        [InlineData(CardinalDirectionType.East, CardinalDirectionType.Simple, 40)]
        public void GetTheClosestByAngle(CardinalDirectionType expected, CardinalDirectionType input, double angle)
            => Assert.Equal(expected, CardinalDirectionTypeHelper.GetTheClosestByAngle(input, angle));

        [Theory]
        [InlineData(CardinalDirectionType.North, 0)]
        [InlineData(CardinalDirectionType.NorthEast, 1)]
        [InlineData(CardinalDirectionType.East, 2)]
        [InlineData(CardinalDirectionType.SouthEast, 3)]
        [InlineData(CardinalDirectionType.South, 4)]
        [InlineData(CardinalDirectionType.SouthWest, 5)]
        [InlineData(CardinalDirectionType.West, 6)]
        [InlineData(CardinalDirectionType.NorthWest, 7)]
        public void GetByRotationNumberClockwiseUsingMedium(CardinalDirectionType expected, int input)
            => Assert.Equal(expected, CardinalDirectionTypeHelper.GetByRotationNumberClockwiseUsingMedium(input));

        [Theory]
        [InlineData(CardinalDirectionType.None, 0, 0, 0, 0)]
        [InlineData(CardinalDirectionType.West, 1, 0, 0, 0)]
        [InlineData(CardinalDirectionType.North, 0, 1, 0, 0)]
        [InlineData(CardinalDirectionType.East, 0, 0, 1, 0)]
        [InlineData(CardinalDirectionType.South, 0, 0, 0, 1)]
        [InlineData(CardinalDirectionType.NorthWest, 1, 1, 0, 0)]
        [InlineData(CardinalDirectionType.SouthEast, 0, 0, 1, 1)]
        [InlineData(CardinalDirectionType.NorthEast, 0, 1, 1, 0)]
        [InlineData(CardinalDirectionType.SouthWest, 1, 0, 0, 1)]
        public void GetTargetCardinalDirectionByGridCells(CardinalDirectionType expected, int sourceX, int sourceY, int targetX, int targetY)
        {
            // Arrange
            var source = new GridCell(sourceX, sourceY);
            var target = new GridCell(targetX, targetY);

            // Act
            var actual = CardinalDirectionTypeHelper.GetTargetCardinalDirectionByGridCells(source, target);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(CardinalDirectionType.None, 0, 0, 0, 0)]
        [InlineData(CardinalDirectionType.West, 1, 0, 0, 0)]
        [InlineData(CardinalDirectionType.North, 0, 1, 0, 0)]
        [InlineData(CardinalDirectionType.East, 0, 0, 1, 0)]
        [InlineData(CardinalDirectionType.South, 0, 0, 0, 1)]
        [InlineData(CardinalDirectionType.NorthWest, 1, 1, 0, 0)]
        [InlineData(CardinalDirectionType.SouthEast, 0, 0, 1, 1)]
        [InlineData(CardinalDirectionType.NorthEast, 0, 1, 1, 0)]
        [InlineData(CardinalDirectionType.SouthWest, 1, 0, 0, 1)]
        public void GetTargetCardinalDirectionByPoint2Ds(CardinalDirectionType expected, int sourceX, int sourceY, int targetX, int targetY)
        {
            // Arrange
            var source = new Point2D(sourceX, sourceY);
            var target = new Point2D(targetX, targetY);

            // Act
            var actual = CardinalDirectionTypeHelper.GetTargetCardinalDirectionByPoint2Ds(source, target);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}