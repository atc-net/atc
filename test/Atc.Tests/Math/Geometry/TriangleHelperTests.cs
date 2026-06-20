// ReSharper disable JoinDeclarationAndInitializer

using TriangleHelper = Atc.Math.Geometry.TriangleHelper;

namespace Atc.Tests.Math.Geometry;

public class TriangleHelperTests
{
    [Fact]
    public void IsSumOfTheAnglesATriangle()
    {
        Assert.False(TriangleHelper.IsSumOfTheAnglesATriangle(45, 45, 91), "A:45, B:45, C:91");
        Assert.True(TriangleHelper.IsSumOfTheAnglesATriangle(45, 45, 90), "A:45, B:45, C:90");
    }

    [Fact]
    public void IsSumOfTheAnglesATriangleWithNulls()
    {
        double? angleA = null;
        double? angleB = 45;
        double? angleC = 90;

        Assert.Throws<ArgumentNullException>(() => TriangleHelper.IsSumOfTheAnglesATriangle(angleA, angleB, angleC));
        angleA = 20;
        Assert.False(TriangleHelper.IsSumOfTheAnglesATriangle(angleA, angleB, angleC), $"A:{angleA}, B:{angleB}, C:{angleC}");
        angleA = 45;
        Assert.True(TriangleHelper.IsSumOfTheAnglesATriangle(angleA, angleB, angleC), $"A:{angleA}, B:{angleB}, C:{angleC}");
    }

    [Fact]
    public void Pythagorean()
    {
        double? sideA = 10;
        double? sideB = 20;
        double? sideC;
        double? expected = 22.360679774997898;
        Assert.Equal(expected, TriangleHelper.Pythagorean(sideA, sideB, null));

        sideA = 15;
        sideC = 25;
        expected = 20;
        Assert.Equal(expected, TriangleHelper.Pythagorean(sideA, null, sideC));

        sideB = 5;
        sideC = 25;
        expected = 24.494897427831781;
        Assert.Equal(expected, TriangleHelper.Pythagorean(null, sideB, sideC));
    }

    [Theory]
    [InlineData(null, 10.0, 5.0)]
    [InlineData(10.0, null, 5.0)]
    public void Pythagorean_ImpossibleSides_ThrowsArithmeticException(
        double? sideA,
        double? sideB,
        double? sideC)
    {
        // When a leg is longer than the hypotenuse the radicand is negative.
        // Math.Sqrt(-x) returns NaN rather than throwing; we expect ArithmeticException.
        Assert.Throws<ArithmeticException>(() => TriangleHelper.Pythagorean(sideA, sideB, sideC));
    }

    [Fact]
    public void IsSumOfTheAnglesATriangle_AnglesWithSmallFloatingPointExcess_ReturnsTrue()
    {
        // Each angle is 60° + 1e-10, so their sum is 180° + 3e-10.
        // This is well within any sensible geometric tolerance (1e-9) but far exceeds
        // double.Epsilon (~4.9e-324), causing the current IsEqual check to incorrectly
        // reject a valid triangle.
        const double a = 60.0 + 1e-10;
        const double b = 60.0 + 1e-10;
        const double c = 60.0 + 1e-10;
        Assert.True(TriangleHelper.IsSumOfTheAnglesATriangle(a, b, c));
    }
}