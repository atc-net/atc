using System.Collections.Generic;

namespace Atc.Tests.XUnitTestData
{
    internal static class TestMemberDataForExtensionsString
    {
        public static IEnumerable<object[]> IsCasingStyleValidData =>
            new List<object[]>
            {
                // CamelCase
                new object[] { true, string.Empty, CasingStyle.CamelCase },
                new object[] { true, "1", CasingStyle.CamelCase },
                new object[] { true, "h", CasingStyle.CamelCase },
                new object[] { false, "H", CasingStyle.CamelCase },
                new object[] { true, "hallo", CasingStyle.CamelCase },
                new object[] { false, "Hallo", CasingStyle.CamelCase },
                new object[] { false, "HALLO", CasingStyle.CamelCase },
                new object[] { false, "HAllo", CasingStyle.CamelCase },
                new object[] { false, "haLLO", CasingStyle.CamelCase },
                new object[] { false, "HaLlo", CasingStyle.CamelCase },
                new object[] { false, "Hallo world", CasingStyle.CamelCase },
                new object[] { false, "Hallo World", CasingStyle.CamelCase },
                new object[] { false, "hallo world", CasingStyle.CamelCase },
                new object[] { false, "hallo-world", CasingStyle.CamelCase },
                new object[] { false, "hallo-World", CasingStyle.CamelCase },
                new object[] { false, "hallo World", CasingStyle.CamelCase },
                new object[] { false, "HalloWorld", CasingStyle.CamelCase },
                new object[] { true, "halloWorld", CasingStyle.CamelCase },
                new object[] { false, "hallo_world", CasingStyle.CamelCase },
                new object[] { false, "hallo_World", CasingStyle.CamelCase },

                // KebabCase
                new object[] { true, string.Empty, CasingStyle.KebabCase },
                new object[] { true, "1", CasingStyle.KebabCase },
                new object[] { true, "h", CasingStyle.KebabCase },
                new object[] { false, "H", CasingStyle.KebabCase },
                new object[] { true, "hallo", CasingStyle.KebabCase },
                new object[] { false, "Hallo", CasingStyle.KebabCase },
                new object[] { false, "HALLO", CasingStyle.KebabCase },
                new object[] { false, "HAllo", CasingStyle.KebabCase },
                new object[] { false, "haLLO", CasingStyle.KebabCase },
                new object[] { false, "HaLlo", CasingStyle.KebabCase },
                new object[] { false, "Hallo world", CasingStyle.KebabCase },
                new object[] { false, "Hallo World", CasingStyle.KebabCase },
                new object[] { false, "hallo world", CasingStyle.KebabCase },
                new object[] { true, "hallo-world", CasingStyle.KebabCase },
                new object[] { false, "hallo-World", CasingStyle.KebabCase },
                new object[] { false, "hallo World", CasingStyle.KebabCase },
                new object[] { false, "HalloWorld", CasingStyle.KebabCase },
                new object[] { false, "halloWorld", CasingStyle.KebabCase },
                new object[] { false, "hallo_world", CasingStyle.KebabCase },
                new object[] { false, "hallo_World", CasingStyle.KebabCase },

                // PascalCase
                new object[] { true, string.Empty, CasingStyle.PascalCase },
                new object[] { true, "1", CasingStyle.PascalCase },
                new object[] { false, "h", CasingStyle.PascalCase },
                new object[] { true, "H", CasingStyle.PascalCase },
                new object[] { false, "hallo", CasingStyle.PascalCase },
                new object[] { true, "Hallo", CasingStyle.PascalCase },
                new object[] { false, "HALLO", CasingStyle.PascalCase },
                new object[] { false, "HAllo", CasingStyle.PascalCase },
                new object[] { false, "haLLO", CasingStyle.PascalCase },
                new object[] { true, "HaLlo", CasingStyle.PascalCase },
                new object[] { false, "Hallo world", CasingStyle.PascalCase },
                new object[] { false, "Hallo World", CasingStyle.PascalCase },
                new object[] { false, "hallo world", CasingStyle.PascalCase },
                new object[] { false, "hallo-world", CasingStyle.PascalCase },
                new object[] { false, "hallo-World", CasingStyle.PascalCase },
                new object[] { false, "hallo World", CasingStyle.PascalCase },
                new object[] { true, "HalloWorld", CasingStyle.PascalCase },
                new object[] { false, "halloWorld", CasingStyle.PascalCase },
                new object[] { false, "hallo_world", CasingStyle.PascalCase },
                new object[] { false, "hallo_World", CasingStyle.PascalCase },

                // SnakeCase
                new object[] { true, string.Empty, CasingStyle.SnakeCase },
                new object[] { true, "1", CasingStyle.SnakeCase },
                new object[] { true, "h", CasingStyle.SnakeCase },
                new object[] { false, "H", CasingStyle.SnakeCase },
                new object[] { true, "hallo", CasingStyle.SnakeCase },
                new object[] { false, "Hallo", CasingStyle.SnakeCase },
                new object[] { false, "HALLO", CasingStyle.SnakeCase },
                new object[] { false, "HAllo", CasingStyle.SnakeCase },
                new object[] { false, "haLLO", CasingStyle.SnakeCase },
                new object[] { false, "HaLlo", CasingStyle.SnakeCase },
                new object[] { false, "Hallo world", CasingStyle.SnakeCase },
                new object[] { false, "Hallo World", CasingStyle.SnakeCase },
                new object[] { false, "hallo world", CasingStyle.SnakeCase },
                new object[] { false, "hallo-world", CasingStyle.SnakeCase },
                new object[] { false, "hallo-World", CasingStyle.SnakeCase },
                new object[] { false, "hallo World", CasingStyle.SnakeCase },
                new object[] { false, "HalloWorld", CasingStyle.SnakeCase },
                new object[] { false, "halloWorld", CasingStyle.SnakeCase },
                new object[] { true, "hallo_world", CasingStyle.SnakeCase },
                new object[] { false, "hallo_World", CasingStyle.SnakeCase },
            };
    }
}