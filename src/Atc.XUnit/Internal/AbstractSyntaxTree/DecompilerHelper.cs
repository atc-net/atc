// ReSharper disable InvertIf

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.Syntax;
using ICSharpCode.Decompiler.Metadata;
using ICSharpCode.Decompiler.TypeSystem;

namespace Atc.XUnit.Internal.AbstractSyntaxTree
{
    internal static class DecompilerHelper
    {
        internal static CSharpDecompiler GetDecompiler(Assembly assembly)
        {
            var assemblyFileName = new Uri(assembly.CodeBase).AbsolutePath;
            using var module = new PEFile(assemblyFileName);
            var resolver = new UniversalAssemblyResolver(assemblyFileName, false, module.Reader.DetectTargetFrameworkId());
            return new CSharpDecompiler(assemblyFileName, resolver, GetSettings());
        }

        internal static DecompilerSettings GetSettings()
        {
            return new DecompilerSettings
            {
                ThrowOnAssemblyResolveErrors = false
            };
        }

        internal static Tuple<MethodInfo, MethodDeclaration>[] GetTestMethodsWithDecompiled(CSharpDecompiler decompiler, Tuple<Type, MethodInfo[]>[] testTypeMethods)
        {
            var testMethods = new List<Tuple<MethodInfo, MethodDeclaration>>();
            foreach ((Type testType, MethodInfo[] testMethodInfos) in testTypeMethods)
            {
                var fullTypeName = new FullTypeName(testType.FullName);
                var syntaxTree = decompiler.DecompileType(fullTypeName);
                var astNodes = syntaxTree.Descendants.Where(x => x.NodeType == NodeType.Member).ToArray();
                foreach (var testMethodInfo in testMethodInfos)
                {
                    foreach (var astNode in astNodes)
                    {
                        if (!(astNode is MethodDeclaration methodDeclaration))
                        {
                            continue;
                        }

                        if (!methodDeclaration.Name.Equals(testMethodInfo.Name, StringComparison.Ordinal))
                        {
                            continue;
                        }

                        testMethods.Add(new Tuple<MethodInfo, MethodDeclaration>(testMethodInfo, methodDeclaration));
                    }
                }
            }

            return testMethods.ToArray();
        }
    }
}