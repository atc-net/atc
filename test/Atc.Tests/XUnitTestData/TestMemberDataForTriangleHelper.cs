namespace Atc.Tests.XUnitTestData;

internal static class TestMemberDataForTriangleHelper
{
    public static TheoryData<string, TriangleData, double?, double?, double?, double?, double?, double?> GetSinesAndCosinesData
        => new()
        {
            {
                "A, B, a",
                new TriangleData
                {
                    A = 50,
                    B = 60,
                    C = 70,
                    a = 20,
                    b = 22.61031749694272,
                    c = 24.533631938113547,
                },
                50, 60, null, 20, null, null
            },
            {
                "B, C, a",
                new TriangleData
                {
                    A = 50,
                    B = 60,
                    C = 70,
                    a = 20,
                    b = 22.61031749694272,
                    c = 24.533631938113547,
                },
                null, 60, 70, 20, null, null
            },
            {
                "A, C, a",
                new TriangleData
                {
                    A = 50,
                    B = 60,
                    C = 70,
                    a = 20,
                    b = 22.61031749694272,
                    c = 24.533631938113547,
                },
                50, null, 70, 20, null, null
            },
            {
                "A, B, b",
                new TriangleData
                {
                    A = 50,
                    B = 60,
                    C = 70,
                    a = 22.113798272297949,
                    b = 25,
                    c = 27.12658937831246,
                },
                50, 60, null, null, 25, null
            },
            {
                "B, C, b",
                new TriangleData
                {
                    A = 50,
                    B = 60,
                    C = 70,
                    a = 22.113798272297949,
                    b = 25,
                    c = 27.12658937831246,
                },
                null, 60, 70, null, 25, null
            },
            {
                "A, C, b",
                new TriangleData
                {
                    A = 50,
                    B = 60,
                    C = 70,
                    a = 22.113798272297949,
                    b = 25,
                    c = 27.12658937831246,
                },
                50, null, 70, null, 25, null
            },
            {
                "A, B, c",
                new TriangleData
                {
                    A = 50,
                    B = 60,
                    C = 70,
                    a = 24.456224072877138,
                    b = 27.648149553206288,
                    c = 30,
                },
                50, 60, null, null, null, 30
            },
            {
                "B, C, b",
                new TriangleData
                {
                    A = 50,
                    B = 60,
                    C = 70,
                    a = 24.456224072877138,
                    b = 27.648149553206288,
                    c = 30,
                },
                null, 60, 70, null, null, 30
            },
            {
                "A, C, b",
                new TriangleData
                {
                    A = 50,
                    B = 60,
                    C = 70,
                    a = 24.456224072877138,
                    b = 27.648149553206288,
                    c = 30,
                },
                50, null, 70, null, null, 30
            },
            {
                "A, a, b",
                new TriangleData
                {
                    A = 50,
                    B = 73.246857743844259,
                    C = 56.753142256155741,
                    a = 20,
                    b = 25,
                    c = 21.8346659124577,
                },
                50, null, null, 20, 25, null
            },
            {
                "A, b, c",
                new TriangleData
                {
                    A = 50,
                    B = 53.9682652419093,
                    C = 76.031734758090693,
                    a = 23.681608591271644,
                    b = 25,
                    c = 30,
                },
                50, null, null, null, 25, 30
            },
            {
                "A, a, c",
                new TriangleData
                {
                    A = 50,
                    B = 80,
                    C = 50,
                    a = 30,
                    b = 38.56725658119236,
                    c = 30,
                },
                50, null, null, 30, null, 30
            },
            {
                "B, a, b",
                new TriangleData
                {
                    A = 37.79481562963835,
                    B = 50,
                    C = 92.20518437036165,
                    a = 20,
                    b = 25,
                    c = 32.611013884394723,
                },
                null, 50, null, 20, 25, null
            },
            {
                "B, b, c",
                new TriangleData
                {
                    A = 63.182832911813023,
                    B = 50,
                    C = 66.817167088186977,
                    a = 29.125290754320552,
                    b = 25,
                    c = 30,
                },
                null, 50, null, null, 25, 30
            },
            {
                "B, a, c",
                new TriangleData
                {
                    A = 65,
                    B = 50,
                    C = 65,
                    a = 30,
                    b = 25.357095704441967,
                    c = 30,
                },
                null, 50, null, 30, null, 30
            },
            {
                "C, a, b",
                new TriangleData
                {
                    A = 88.214560121034523,
                    B = 41.785439878965477,
                    C = 50,
                    a = 30,
                    b = 20,
                    c = 22.992495914453322,
                },
                null, null, 50, 30, 20, null
            },
            {
                "C, b, c",
                new TriangleData
                {
                    A = 90.329590902636426,
                    B = 39.67040909736356,
                    C = 50,
                    a = 39.161570730315248,
                    b = 25,
                    c = 30,
                },
                null, null, 50, null, 25, 30
            },
            {
                "C, a, c",
                new TriangleData
                {
                    A = 50,
                    B = 80,
                    C = 50,
                    a = 30,
                    b = 38.56725658119236,
                    c = 30,
                },
                null, null, 50, 30, null, 30
            },
        };
}