using System;
using System.IO;
using System.Reflection;
using Atc.CodeDocumentation.Markdown;
using Xunit;
using Xunit.Abstractions;

namespace Atc.Rest.Tests
{
    public class CodeDocumentationTests
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly ITestOutputHelper testOutputHelper;
        private readonly Assembly sourceAssembly = typeof(AtcRestAssemblyTypeInitializer).Assembly;

        public CodeDocumentationTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void RunMarkdownCodeDocGenerator()
        {
            // Arrange
            var assemblyName = typeof(CodeDocumentationTests).Assembly.GetName().Name;
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            int index = baseDirectory!.IndexOf(assemblyName!, StringComparison.Ordinal);
            var testProjectDirectory = new DirectoryInfo(baseDirectory.Substring(0, index + assemblyName.Length));
            var rootDirectory = testProjectDirectory!.Parent!.Parent;
            string codeDocPath =
                Path.Combine(
                    Path.Combine(
                        Path.Combine(rootDirectory!.FullName, "docs"), "CodeDoc"), sourceAssembly.GetName().Name!);
            var codeDocDirectory = new DirectoryInfo(codeDocPath);
            if (!codeDocDirectory.Exists)
            {
                codeDocDirectory.Create();
            }

            // Act & Assert
            MarkdownCodeDocGenerator.Run(sourceAssembly, codeDocDirectory);
        }
    }
}