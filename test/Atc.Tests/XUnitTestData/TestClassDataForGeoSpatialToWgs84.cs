// ReSharper disable StringLiteralTypo
namespace Atc.Tests.XUnitTestData;

internal sealed class TestClassDataForGeoSpatialToWgs84 : IEnumerable<object[]>
{
    private readonly List<object[]> data = new()
    {
        new object[]
        {
            "Ågeruphøj 33 4000 Roskilde",
            new UniversalTransverseMercatorResult(32, "U", 698143.79986065126, 6176562.9507410871),
            8,
            new CartesianCoordinate(55.69430922, 12.15276437),
        },
        new object[]
        {
            "Åvej 18 4000 Roskilde",
            new UniversalTransverseMercatorResult(32, "U", 631759.74277469353, 6169762.696127858),
            8,
            new CartesianCoordinate(55.6558181, 11.0942214),
        },
        new object[]
        {
            "Rytterhusene 76 2620 Albertslund",
            new UniversalTransverseMercatorResult(32, "U", 711271.29002319183, 6174810.1109701814),
            8,
            new CartesianCoordinate(55.67305066, 12.35990214),
        },
    };

    public IEnumerator<object[]> GetEnumerator() => data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}