using System;
using System.Collections.Generic;
using System.Reflection;
using Atc.XUnit;
using Xunit;
using Xunit.Abstractions;

namespace Atc.Rest.Tests
{
    public class CodeComplianceTests
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly ITestOutputHelper testOutputHelper;
        private readonly Assembly sourceAssembly = typeof(AtcRestAssemblyTypeInitializer).Assembly;
        private readonly Assembly testAssembly = typeof(CodeComplianceTests).Assembly;

        private readonly List<Type> excludeTypes = new List<Type>
        {
            // TODO: Add UnitTest and remove from this list!!
            typeof(Rest.Extensions.EndpointRouteBuilderExtensions),
            typeof(Rest.Middleware.ExceptionTelemetryMiddleware),
            typeof(Rest.Middleware.KeepAliveMiddleware),
            typeof(Rest.Middleware.RequestCorrelationMiddleware),
            typeof(Options.AllowAnonymousAccessForDevelopmentHandler),
            typeof(Options.ConfigureApiBehaviorOptions),
            typeof(Options.RestApiOptions),
            typeof(Microsoft.ApplicationInsights.Extensibility.Accept4xxResponseAsSuccessInitializer),
            typeof(Microsoft.ApplicationInsights.Extensibility.CallingIdentityTelemetryInitializer),
            typeof(Microsoft.AspNetCore.Builder.RestApiBuilderExtensions),
            typeof(Microsoft.AspNetCore.Http.AnonymousAccessExtensions),
            typeof(Microsoft.AspNetCore.Http.HttpContextExtensions),
            typeof(Microsoft.AspNetCore.Mvc.Filters.ErrorHandlingExceptionFilterAttribute),
            typeof(Microsoft.Extensions.DependencyInjection.RestApiExtensions),
            typeof(Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions),
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