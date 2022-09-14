using TriangleHelper = Atc.Math.Trigonometry.TriangleHelper;

namespace Atc.Tests.Math.Trigonometry;

public class TriangleHelperTests
{
    [Theory]
    [MemberData(nameof(TestMemberDataForTriangleHelper.GetSinesAndCosinesData), MemberType = typeof(TestMemberDataForTriangleHelper))]
    public void SinesAndCosines(string testName, TriangleData expected, double? angleA, double? angleB, double? angleC, double? sideA, double? sideB, double? sideC)
    {
        // Act
        var actual = TriangleHelper.SinesAndCosines(angleA, angleB, angleC, sideA, sideB, sideC);

        // Assert
        Assert.NotNull(testName);
        Assert.NotNull(actual);

        Assert.Equal(expected.A, actual.A);
        Assert.Equal(expected.B, actual.B);
        Assert.Equal(expected.C, actual.C);

        Assert.Equal(expected.a, actual.a);
        Assert.Equal(expected.b, actual.b);
        Assert.Equal(expected.c, actual.c);

        Assert.Equal(expected.ToString(), actual.ToString());
    }
}