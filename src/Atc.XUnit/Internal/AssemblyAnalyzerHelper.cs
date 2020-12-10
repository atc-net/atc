using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Atc.XUnit.Internal
{
    internal static class AssemblyAnalyzerHelper
    {
        private static readonly List<string> TypeNamesForExtensionsToSkip = new List<string>
        {
            "DynamicExtensions",
            "EventHandlerExtensions",
            "NullableExtensions",
            "ObjectExtensions",
            "TypeExtensions",
        };

        private static readonly List<string> AllowedNamesForCollectionExtensions = new List<string>
        {
            "IList",
            "IEnumerable",
            "IQueryable",
            "IOrderedQueryable",
            "ObservableCollection",
        };

        private static readonly List<string> AllowedNamesForEnumerableExtensions = new List<string>
        {
            "IEnumerable",
        };

        private static readonly List<string> AllowedNamesForQueryableExtensions = new List<string>
        {
            "IQueryable",
            "IOrderedQueryable",
        };

        internal static Dictionary<MethodInfo, string> CollectExportedMethodsWithWrongNaming(
            Assembly assembly,
            List<Type>? excludeTypes)
        {
            var types = CollectFilteredAssemblyTypes(assembly, excludeTypes);
            var listModuleScopeNamesToExclude = new List<string>
            {
                typeof(Exception).Module.ScopeName,
            };

            var list = new Dictionary<MethodInfo, string>();
            foreach (var type in types)
            {
                var methods = type.GetPublicDeclaredOnlyMethods();
                foreach (var method in methods)
                {
                    if (method.DeclaringType != null &&
                        listModuleScopeNamesToExclude.Contains(method.DeclaringType.Module.ScopeName))
                    {
                        continue;
                    }

                    if (method.Name.StartsWith("get_", StringComparison.Ordinal) ||
                        method.Name.StartsWith("set_", StringComparison.Ordinal) ||
                        method.Name.StartsWith("op_", StringComparison.Ordinal) ||
                        method.Name.StartsWith("add_", StringComparison.Ordinal) ||
                        method.Name.StartsWith("remove_", StringComparison.Ordinal))
                    {
                        continue;
                    }

                    if ("Equals".Equals(method.Name, StringComparison.Ordinal) ||
                        "GetHashCode".Equals(method.Name, StringComparison.Ordinal) ||
                        "GetType".Equals(method.Name, StringComparison.Ordinal) ||
                        "ToString".Equals(method.Name, StringComparison.Ordinal))
                    {
                        continue;
                    }

                    var error = ValidateMethod(method);
                    if (!string.IsNullOrEmpty(error))
                    {
                        list.Add(method, error);
                    }
                }
            }

            return list;
        }

        [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
        private static Type[] CollectFilteredAssemblyTypes(Assembly assembly, List<Type>? excludeTypes)
        {
            excludeTypes ??= new List<Type>();

            var types = new[] { assembly }
                .SelectMany(x =>
                {
                    try
                    {
                        return x.GetTypes();
                    }
                    catch (ReflectionTypeLoadException ex)
                    {
                        return ex.Types.Where(t => t != null);
                    }
                    catch
                    {
                        return Type.EmptyTypes;
                    }
                })
                .Where(x => x != null
                            && x.IsPublic
                            && !x.IsInterface
                            && !x.IsNested
                            && !(x.IsAbstract && !x.IsSealed)
                            && !x.IsDelegate()
                            && !x.GetCustomAttributes<ObsoleteAttribute>().Any()
                            && !x.GetCustomAttributes<CompilerGeneratedAttribute>().Any()
                            && !excludeTypes.Contains(x))
                .OrderBy(x => x.FullName)
                .ToArray();

            return types;
        }

        private static string? ValidateMethod(MethodInfo method)
        {
            if (method.DeclaringType == null)
            {
                return null;
            }

            var classType = method.DeclaringType;
            if (TypeNamesForExtensionsToSkip.Contains(classType.Name))
            {
                return null;
            }

            if (classType.Name.EndsWith("Extensions", StringComparison.Ordinal))
            {
                if (!method.IsDefined(typeof(ExtensionAttribute)))
                {
                    return "Method in not a extension method.";
                }

                var className = classType.Name.Replace("Extensions", string.Empty, StringComparison.Ordinal);
                var classNamePrefixSimplified = GetSimpleTypeName(className);
                var firstParameterType = method.GetParameters().First().ParameterType;
                var firstParameterNameSimplified = GetSimpleTypeName(firstParameterType);
                if (classNamePrefixSimplified.Equals(firstParameterNameSimplified, StringComparison.Ordinal) ||
                    ("I" + classNamePrefixSimplified).Equals(firstParameterNameSimplified, StringComparison.Ordinal))
                {
                    // Ok
                    return null;
                }

                if ((classNamePrefixSimplified.Equals("Collection", StringComparison.Ordinal) && AllowedNamesForCollectionExtensions.Contains(firstParameterNameSimplified)) ||
                    (classNamePrefixSimplified.Equals("Enumerable", StringComparison.Ordinal) && AllowedNamesForEnumerableExtensions.Contains(firstParameterNameSimplified)) ||
                    (classNamePrefixSimplified.Equals("Queryable", StringComparison.Ordinal) && AllowedNamesForQueryableExtensions.Contains(firstParameterNameSimplified)) ||
                    firstParameterType.Name.Equals("IApplicationBuilder", StringComparison.Ordinal) ||
                    firstParameterType.Name.Equals("IServiceCollection", StringComparison.Ordinal))
                {
                    // Ok
                    return null;
                }

                if (firstParameterType.IsGenericType &&
                    firstParameterType.GenericTypeArguments.Any(x => x.Name.Equals(className, StringComparison.Ordinal)))
                {
                    // Ok
                    return null;
                }

                var sa = className.Humanize().Split(' ');
                if (sa.Length <= 1)
                {
                    return "Extension parameter type should match the class name-prefix.";
                }

                if (GetSimpleTypeName(sa[0]).Equals(firstParameterNameSimplified, StringComparison.Ordinal) &&
                    sa.Any(x => x.Equals("Is", StringComparison.Ordinal) || x.Equals("Has", StringComparison.Ordinal)))
                {
                    return null;
                }

                return "Extension parameter type should match the class name-prefix.";
            }

            if (method.IsDefined(typeof(ExtensionAttribute)))
            {
                return "Class name-suffix is not Extensions.";
            }

            return null;
        }

        private static string GetSimpleTypeName(string name)
        {
            if (name.Equals("Boolean", StringComparison.Ordinal))
            {
                return "bool";
            }

            if (name.Equals("Double", StringComparison.Ordinal))
            {
                return "double";
            }

            if (name.Equals("Decimal", StringComparison.Ordinal))
            {
                return "decimal";
            }

            if (name.Equals("Integer", StringComparison.Ordinal))
            {
                return "int";
            }

            if (name.Equals("Long", StringComparison.Ordinal))
            {
                return "long";
            }

            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (name.Equals("String", StringComparison.Ordinal))
            {
                return "string";
            }

            return name;
        }

        private static string GetSimpleTypeName(Type type)
        {
            var beautifyName = type.BeautifyName();
            if (type.IsNullable())
            {
                beautifyName = beautifyName.Replace("?", string.Empty, StringComparison.Ordinal);
            }

            var i = beautifyName.IndexOf("<", StringComparison.Ordinal);
            if (i != -1)
            {
                beautifyName = beautifyName.Substring(0, i);
            }

            return beautifyName;
        }
    }
}