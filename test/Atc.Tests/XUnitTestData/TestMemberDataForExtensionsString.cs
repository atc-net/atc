using Xunit;

// ReSharper disable StringLiteralTypo
namespace Atc.Tests.XUnitTestData
{
    internal static class TestMemberDataForExtensionsString
    {
        public static TheoryData<bool, string, CasingStyle> IsCasingStyleValidData
            => new TheoryData<bool, string, CasingStyle>
            {
                // CamelCase
                { true, string.Empty, CasingStyle.CamelCase },
                { true, "1", CasingStyle.CamelCase },
                { true, "h", CasingStyle.CamelCase },
                { false, "H", CasingStyle.CamelCase },
                { true, "hallo", CasingStyle.CamelCase },
                { false, "Hallo", CasingStyle.CamelCase },
                { false, "HALLO", CasingStyle.CamelCase },
                { false, "HAllo", CasingStyle.CamelCase },
                { false, "haLLO", CasingStyle.CamelCase },
                { false, "HaLlo", CasingStyle.CamelCase },
                { false, "Hallo world", CasingStyle.CamelCase },
                { false, "Hallo World", CasingStyle.CamelCase },
                { false, "hallo world", CasingStyle.CamelCase },
                { false, "hallo-world", CasingStyle.CamelCase },
                { false, "hallo-World", CasingStyle.CamelCase },
                { false, "hallo World", CasingStyle.CamelCase },
                { false, "HalloWorld", CasingStyle.CamelCase },
                { true, "halloWorld", CasingStyle.CamelCase },
                { false, "hallo_world", CasingStyle.CamelCase },
                { false, "hallo_World", CasingStyle.CamelCase },

                // KebabCase
                { true, string.Empty, CasingStyle.KebabCase },
                { true, "1", CasingStyle.KebabCase },
                { true, "h", CasingStyle.KebabCase },
                { false, "H", CasingStyle.KebabCase },
                { true, "hallo", CasingStyle.KebabCase },
                { false, "Hallo", CasingStyle.KebabCase },
                { false, "HALLO", CasingStyle.KebabCase },
                { false, "HAllo", CasingStyle.KebabCase },
                { false, "haLLO", CasingStyle.KebabCase },
                { false, "HaLlo", CasingStyle.KebabCase },
                { false, "Hallo world", CasingStyle.KebabCase },
                { false, "Hallo World", CasingStyle.KebabCase },
                { false, "hallo world", CasingStyle.KebabCase },
                { true, "hallo-world", CasingStyle.KebabCase },
                { false, "hallo-World", CasingStyle.KebabCase },
                { false, "hallo World", CasingStyle.KebabCase },
                { false, "HalloWorld", CasingStyle.KebabCase },
                { false, "halloWorld", CasingStyle.KebabCase },
                { false, "hallo_world", CasingStyle.KebabCase },
                { false, "hallo_World", CasingStyle.KebabCase },

                // PascalCase
                { true, string.Empty, CasingStyle.PascalCase },
                { true, "1", CasingStyle.PascalCase },
                { false, "h", CasingStyle.PascalCase },
                { true, "H", CasingStyle.PascalCase },
                { false, "hallo", CasingStyle.PascalCase },
                { true, "Hallo", CasingStyle.PascalCase },
                { false, "HALLO", CasingStyle.PascalCase },
                { false, "HAllo", CasingStyle.PascalCase },
                { false, "haLLO", CasingStyle.PascalCase },
                { true, "HaLlo", CasingStyle.PascalCase },
                { false, "Hallo world", CasingStyle.PascalCase },
                { false, "Hallo World", CasingStyle.PascalCase },
                { false, "hallo world", CasingStyle.PascalCase },
                { false, "hallo-world", CasingStyle.PascalCase },
                { false, "hallo-World", CasingStyle.PascalCase },
                { false, "hallo World", CasingStyle.PascalCase },
                { true, "HalloWorld", CasingStyle.PascalCase },
                { false, "halloWorld", CasingStyle.PascalCase },
                { false, "hallo_world", CasingStyle.PascalCase },
                { false, "hallo_World", CasingStyle.PascalCase },

                // SnakeCase
                { true, string.Empty, CasingStyle.SnakeCase },
                { true, "1", CasingStyle.SnakeCase },
                { true, "h", CasingStyle.SnakeCase },
                { false, "H", CasingStyle.SnakeCase },
                { true, "hallo", CasingStyle.SnakeCase },
                { false, "Hallo", CasingStyle.SnakeCase },
                { false, "HALLO", CasingStyle.SnakeCase },
                { false, "HAllo", CasingStyle.SnakeCase },
                { false, "haLLO", CasingStyle.SnakeCase },
                { false, "HaLlo", CasingStyle.SnakeCase },
                { false, "Hallo world", CasingStyle.SnakeCase },
                { false, "Hallo World", CasingStyle.SnakeCase },
                { false, "hallo world", CasingStyle.SnakeCase },
                { false, "hallo-world", CasingStyle.SnakeCase },
                { false, "hallo-World", CasingStyle.SnakeCase },
                { false, "hallo World", CasingStyle.SnakeCase },
                { false, "HalloWorld", CasingStyle.SnakeCase },
                { false, "halloWorld", CasingStyle.SnakeCase },
                { true, "hallo_world", CasingStyle.SnakeCase },
                { false, "hallo_World", CasingStyle.SnakeCase },
            };
    }
}