using System.Linq;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Xunit;

namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories
{
    public class SyntaxClassDeclarationFactoryTests
    {
        [Fact]
        public void Should_Generate_Partial_Class_Definition()
        {
            // Act
            var result = SyntaxClassDeclarationFactory.CreateAsPublicPartial("TestClass");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Modifiers.Count);
            Assert.Contains("partial", result.Modifiers.Select(item => item.ValueText));
            Assert.Contains("public", result.Modifiers.Select(item => item.ValueText));
        }
    }
}