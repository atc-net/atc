using System;
using System.Collections.Generic;
using System.Reflection;
using Atc.XUnit;
using Xunit;
using Xunit.Abstractions;

namespace Atc.Rest.Extended.Tests
{
    public class CodeComplianceTests
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly ITestOutputHelper testOutputHelper;
        private readonly Assembly sourceAssembly = typeof(AtcRestExtendedAssemblyTypeInitializer).Assembly;
        private readonly Assembly testAssembly = typeof(CodeComplianceTests).Assembly;

        private readonly List<Type> excludeTypes = new List<Type>
        {
            // TODO: Add UnitTest and remove from this list!!
            typeof(Filters.ApiVersionDocumentFilter),
            typeof(Filters.ApiVersionOperationFilter),
            typeof(Filters.AuthorizeResponseOperationFilter),
            typeof(Filters.DefaultResponseOperationFilter),
            typeof(Filters.SecurityRequirementsOperationFilter),
            typeof(Filters.SwaggerEnumDescriptionsDocumentFilter),
            typeof(Options.ConfigureApiVersioningOptions),
            typeof(Versioning.VersionErrorResponseProvider),
            typeof(Microsoft.AspNetCore.Builder.OpenApiBuilderExtensions),
            typeof(Microsoft.AspNetCore.Builder.RestApiExtendedBuilderExtensions),
            typeof(Microsoft.Extensions.DependencyInjection.FluentValidationExtensions),
            typeof(Microsoft.Extensions.DependencyInjection.OpenApiExtensions),
            typeof(Microsoft.Extensions.DependencyInjection.RestApiExtendedExtensions),
            typeof(Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptionsExtensions),
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