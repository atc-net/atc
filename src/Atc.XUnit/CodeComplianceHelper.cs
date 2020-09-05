using System;
using System.Collections.Generic;
using System.Reflection;
using Atc.XUnit.Internal;

namespace Atc.XUnit
{
    /// <summary>
    /// CodeComplianceNamingHelper.
    /// </summary>
    public static class CodeComplianceHelper
    {
        /// <summary>
        /// Asserts the exported types with wrong definitions.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
        public static void AssertExportedTypesWithWrongDefinitions(
            Type type,
            bool useFullName = false)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Asserts the exported types with wrong definitions.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="excludeTypes">The exclude types.</param>
        /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
        public static void AssertExportedTypesWithWrongDefinitions(
            Assembly assembly,
            List<Type>? excludeTypes = null,
            bool useFullName = false)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            var methodsWithWrongNaming = AssemblyAnalyzerHelper.CollectExportedMethodsWithWrongNaming(
                assembly,
                excludeTypes);
            TestResultHelper.AssertOnTestResultsFromMethodsWithWrongDefinitions(
                assembly.GetName().Name,
                methodsWithWrongNaming,
                useFullName);
        }
    }
}