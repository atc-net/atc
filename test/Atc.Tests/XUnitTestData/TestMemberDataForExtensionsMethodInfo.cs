// ReSharper disable UnusedVariable
namespace Atc.Tests.XUnitTestData;

internal static class TestMemberDataForExtensionsMethodInfo
{
    public static TheoryData<string, MethodInfo?> BeautifyNameData
        => new TheoryData<string, MethodInfo?>
        {
            { "TestInInt(in int data)", typeof(TestMethods).GetMethod("TestInInt") },
            { "TestInNullInt(in int? data)", typeof(TestMethods).GetMethod("TestInNullInt") },
            { "TestOutInt(out int data)", typeof(TestMethods).GetMethod("TestOutInt") },
            { "TestInNullOut(out int? data)", typeof(TestMethods).GetMethod("TestInNullOut") },
            { "TestRefInt(ref int data)", typeof(TestMethods).GetMethod("TestRefInt") },
            { "TestRefNullInt(ref int? data)", typeof(TestMethods).GetMethod("TestRefNullInt") },
        };

    public static TheoryData<string, MethodInfo?, bool, bool, bool> BeautifyNameWithParametersData
        => new TheoryData<string, MethodInfo?, bool, bool, bool>
        {
            { "TestInInt(in int data)", typeof(TestMethods).GetMethod("TestInInt"), false, false, false },
            { "void TestInInt(in int data)", typeof(TestMethods).GetMethod("TestInInt"), false, false, true },
            { "TestInNullInt(in int? data)", typeof(TestMethods).GetMethod("TestInNullInt"), false, false, false },
            { "void TestInNullInt(in int? data)", typeof(TestMethods).GetMethod("TestInNullInt"), false, false, true },
            { "TestOutInt(out int data)", typeof(TestMethods).GetMethod("TestOutInt"), false, false, false },
            { "void TestOutInt(out int data)", typeof(TestMethods).GetMethod("TestOutInt"), false, false, true },
            { "TestInNullOut(out int? data)", typeof(TestMethods).GetMethod("TestInNullOut"), false, false, false },
            { "void TestInNullOut(out int? data)", typeof(TestMethods).GetMethod("TestInNullOut"), false, false, true },
            { "TestRefInt(ref int data)", typeof(TestMethods).GetMethod("TestRefInt"), false, false, false },
            { "void TestRefInt(ref int data)", typeof(TestMethods).GetMethod("TestRefInt"), false, false, true },
            { "TestRefNullInt(ref int? data)", typeof(TestMethods).GetMethod("TestRefNullInt"), false, false, false },
            { "void TestRefNullInt(ref int? data)", typeof(TestMethods).GetMethod("TestRefNullInt"), false, false, true },
        };
}

[SuppressMessage("Minor Code Smell", "S1481:Unused local variables should be removed", Justification = "OK, since this is a test.")]
[SuppressMessage("Design", "MA0048:File name must match type name", Justification = "OK.")]
internal class TestMethods
{
    public void TestInInt(in int data)
    {
        var x = data;
    }

    public void TestInNullInt(in int? data)
    {
        var x = data;
    }

    public void TestOutInt(out int data)
    {
        data = 0;
    }

    public void TestInNullOut(out int? data)
    {
        data = 0;
    }

    public void TestRefInt(ref int data)
    {
        var x = data;
    }

    public void TestRefNullInt(ref int? data)
    {
        var x = data;
    }
}