using System;
using System.Collections.Generic;
using System.Reflection;
using Atc.Math;
using Atc.XUnit;
using Xunit;
using Xunit.Abstractions;

namespace Atc.Tests
{
    public class CodeComplianceTests
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly ITestOutputHelper testOutputHelper;
        private readonly Assembly sourceAssembly = typeof(AtcAssemblyTypeInitializer).Assembly;
        private readonly Assembly testAssembly = typeof(CodeComplianceTests).Assembly;

        private readonly List<Type> excludeTypes = new List<Type>
        {
            // TODO: Add UnitTest and remove from this list!!
            typeof(MathEx),
        };

        public CodeComplianceTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void AssertExportedMethodsWithMissingTests_AbstractSyntaxTree()
        {
            // Act & Assert
            CodeComplianceTestHelper.AssertExportedMethodsWithMissingTests(
                DecompilerType.AbstractSyntaxTree,
                sourceAssembly,
                testAssembly,
                excludeTypes);
        }

        [Fact]
        public void AssertExportedMethodsWithMissingTests_MonoReflection()
        {
            // Act & Assert
            CodeComplianceTestHelper.AssertExportedMethodsWithMissingTests(
                DecompilerType.MonoReflection,
                sourceAssembly,
                testAssembly,
                excludeTypes);
        }

        [Fact]
        public void AssertExportedTypesWithMissingComments()
        {
            // Act & Assert
            CodeComplianceDocumentationHelper.AssertExportedTypesWithMissingComments(
                sourceAssembly);
        }

        [Fact]
        public void AssertExportedTypesWithWrongNaming()
        {
            // Act & Assert
            CodeComplianceHelper.AssertExportedTypesWithWrongDefinitions(
                sourceAssembly);
        }
    }
}