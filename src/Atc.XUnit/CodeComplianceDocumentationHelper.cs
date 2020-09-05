using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Atc.CodeDocumentation;

namespace Atc.XUnit
{
    /// <summary>
    /// CodeComplianceDocumentationHelper.
    /// </summary>
    public static class CodeComplianceDocumentationHelper
    {
        /// <summary>
        /// Asserts the exported type with missing comments.
        /// </summary>
        /// <param name="type">The type.</param>
        public static void AssertExportedTypeWithMissingComments(Type type)
        {
            var typeComments = DocumentationHelper.CollectExportedTypeWithCommentsFromType(type);

            var testResults = new List<TestResult>();
            if (typeComments != null && !typeComments.HasComments)
            {
                testResults.Add(new TestResult(true, 0, $"Type: {typeComments.Type.BeautifyTypeName(true)}"));
            }

            TestResultHelper.AssertOnTestResults(testResults);
        }

        /// <summary>
        /// Asserts the exported types with missing comments.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="excludeTypes">The exclude types.</param>
        public static void AssertExportedTypesWithMissingComments(
            Assembly assembly,
            List<Type>? excludeTypes = null)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            var typesWithMissingCommentsGroups = DocumentationHelper.CollectExportedTypesWithMissingCommentsFromAssembly(
                assembly,
                excludeTypes)
                .OrderBy(x => x.Type.FullName)
                .GroupBy(x => x.Type.BeautifyName(true))
                .ToArray();

            var testResults = new List<TestResult>
            {
                new TestResult($"Assembly: {assembly.GetName()}"),
            };

            testResults.AddRange(typesWithMissingCommentsGroups.Select(item => new TestResult(false, 1, $"Type: {item.Key}")));

            TestResultHelper.AssertOnTestResults(testResults);
        }
    }
}