// ReSharper disable JoinDeclarationAndInitializer
namespace Atc.Tests.Math.Geometry;

public class TriangleHelperTests
{
    [Fact]
    public void IsSumOfTheAnglesATriangle()
    {
        Assert.False(Atc.Math.Geometry.TriangleHelper.IsSumOfTheAnglesATriangle(45, 45, 91), "A:45, B:45, C:91");
        Assert.True(Atc.Math.Geometry.TriangleHelper.IsSumOfTheAnglesATriangle(45, 45, 90), "A:45, B:45, C:90");
    }

    [Fact]
    public void IsSumOfTheAnglesATriangleWithNulls()
    {
        double? angleA = null;
        double? angleB = 45;
        double? angleC = 90;

        Assert.Throws<ArgumentNullException>(() => Atc.Math.Geometry.TriangleHelper.IsSumOfTheAnglesATriangle(angleA, angleB, angleC));
        angleA = 20;
        Assert.False(Atc.Math.Geometry.TriangleHelper.IsSumOfTheAnglesATriangle(angleA, angleB, angleC), $"A:{angleA}, B:{angleB}, C:{angleC}");
        angleA = 45;
        Assert.True(Atc.Math.Geometry.TriangleHelper.IsSumOfTheAnglesATriangle(angleA, angleB, angleC), $"A:{angleA}, B:{angleB}, C:{angleC}");
    }

    [Fact]
    public void Pythagorean()
    {
        double? sideA = 10;
        double? sideB = 20;
        double? sideC;
        double? expected = 22.360679774997898;
        Assert.Equal(expected, Atc.Math.Geometry.TriangleHelper.Pythagorean(sideA, sideB, null));

        sideA = 15;
        sideC = 25;
        expected = 20;
        Assert.Equal(expected, Atc.Math.Geometry.TriangleHelper.Pythagorean(sideA, null, sideC));

        sideB = 5;
        sideC = 25;
        expected = 24.494897427831781;
        Assert.Equal(expected, Atc.Math.Geometry.TriangleHelper.Pythagorean(null, sideB, sideC));
    }
}