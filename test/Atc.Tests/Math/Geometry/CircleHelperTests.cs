using Atc.Math.Geometry;
using Xunit;

namespace Atc.Tests.Math.Geometry
{
    public class CircleHelperTests
    {
        [Fact]
        public void ArcLength()
        {
            double radius = 50;
            double angle = 50;
            Assert.Equal(43.633231299858238, CircleHelper.ArcLength(radius, angle));
        }

        [Fact]
        public void ArcLengthRound12()
        {
            double radius = 50;
            double angle = 50;
            Assert.Equal(43.633231299858, System.Math.Round(CircleHelper.ArcLength(radius, angle), 12));
        }

        [Fact]
        public void Area()
        {
            double radius = 50;
            Assert.Equal(7853.981633974483, CircleHelper.Area(radius));
        }

        [Fact]
        public void Circumference()
        {
            double radius = 50;
            Assert.Equal(314.15926535897933, CircleHelper.Circumference(radius));
        }

        [Fact]
        public void ChordLength()
        {
            double radius = 50;
            double angle = 50;
            Assert.Equal(42.26182617407, System.Math.Round(CircleHelper.ChordLength(radius, angle), 12));
        }
    }
}