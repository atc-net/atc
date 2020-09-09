using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Atc.Tests.XUnitTestData
{
    internal static class TestMemberDataForExtensionsMethodInfo
    {
        public static IEnumerable<object[]> BeautifyNameData =>
            new List<object[]>
            {
                new object[] { "TestInInt(in int data)", typeof(TestMethods).GetMethod("TestInInt") },
                new object[] { "TestInNullInt(in int? data)", typeof(TestMethods).GetMethod("TestInNullInt") },
                new object[] { "TestOutInt(out int data)", typeof(TestMethods).GetMethod("TestOutInt") },
                new object[] { "TestInNullOut(out int? data)", typeof(TestMethods).GetMethod("TestInNullOut") },
                new object[] { "TestRefInt(ref int data)", typeof(TestMethods).GetMethod("TestRefInt") },
                new object[] { "TestRefNullInt(ref int? data)", typeof(TestMethods).GetMethod("TestRefNullInt") },
            };

        public static IEnumerable<object[]> BeautifyNameWithParametersData =>
            new List<object[]>
            {
                new object[] { "TestInInt(in int data)", typeof(TestMethods).GetMethod("TestInInt"), false, false, false },
                new object[] { "void TestInInt(in int data)", typeof(TestMethods).GetMethod("TestInInt"), false, false, true },
                new object[] { "TestInNullInt(in int? data)", typeof(TestMethods).GetMethod("TestInNullInt"), false, false, false },
                new object[] { "void TestInNullInt(in int? data)", typeof(TestMethods).GetMethod("TestInNullInt"), false, false, true },
                new object[] { "TestOutInt(out int data)", typeof(TestMethods).GetMethod("TestOutInt"), false, false, false },
                new object[] { "void TestOutInt(out int data)", typeof(TestMethods).GetMethod("TestOutInt"), false, false, true },
                new object[] { "TestInNullOut(out int? data)", typeof(TestMethods).GetMethod("TestInNullOut"), false, false, false },
                new object[] { "void TestInNullOut(out int? data)", typeof(TestMethods).GetMethod("TestInNullOut"), false, false, true },
                new object[] { "TestRefInt(ref int data)", typeof(TestMethods).GetMethod("TestRefInt"), false, false, false },
                new object[] { "void TestRefInt(ref int data)", typeof(TestMethods).GetMethod("TestRefInt"), false, false, true },
                new object[] { "TestRefNullInt(ref int? data)", typeof(TestMethods).GetMethod("TestRefNullInt"), false, false, false },
                new object[] { "void TestRefNullInt(ref int? data)", typeof(TestMethods).GetMethod("TestRefNullInt"), false, false, true },
            };
    }

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "OK.")]
    [SuppressMessage("Minor Code Smell", "S1481:Unused local variables should be removed", Justification = "OK, since this is a test.")]
    internal class TestMethods
    {
        public void TestInInt(in int data) { var x = data; }

        public void TestInNullInt(in int? data) { var x = data; }

        public void TestOutInt(out int data) { data = 0; }

        public void TestInNullOut(out int? data) { data = 0; }

        public void TestRefInt(ref int data) { var x = data; }

        public void TestRefNullInt(ref int? data) { var x = data; }
    }
}