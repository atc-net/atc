using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Atc.CodeDocumentation.Markdown
{
    internal static class MarkdownHelper
    {
        public static string Render(TypeComments typeComments)
        {
            var mb = new MarkdownBuilder();
            AppendHeaderForType(mb, typeComments);
            AppendTypeBox(mb, typeComments);

            if (typeComments.Type.IsEnum)
            {
                AppendBodyForEnum(mb, typeComments);
            }
            else
            {
                AppendBodyForClass(mb, typeComments);
            }

            return mb.ToString();
        }

        [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
        public static string? RenderSubList(TypeComments typeComments)
        {
            if (typeComments.Type.IsEnum)
            {
                return null;
            }

            var mb = new MarkdownBuilder();

            var staticFields = GetStaticFields(typeComments.Type);
            if (staticFields.Length > 0)
            {
                mb.Append("  -  Static Fields");
                mb.AppendLine();
                foreach (var item in staticFields)
                {
                    mb.Append($"     - {item.BeautifyName(false, true, true)}");
                    mb.AppendLine();
                }
            }

            var staticProperties = GetStaticProperties(typeComments.Type);
            if (staticProperties.Length > 0)
            {
                mb.Append("  -  Static Properties");
                mb.AppendLine();
                foreach (var item in staticProperties)
                {
                    mb.Append($"     - {item.Name}");
                    mb.AppendLine();
                }
            }

            var staticEvents = GetStaticEvents(typeComments.Type);
            if (staticEvents.Length > 0)
            {
                mb.Append("  -  Static Events");
                mb.AppendLine();
                foreach (var item in staticEvents)
                {
                    mb.Append($"     - {item.Name}");
                    mb.AppendLine();
                }
            }

            var staticMethods = GetStaticMethods(typeComments.Type);
            if (staticMethods.Length > 0)
            {
                mb.Append("  -  Static Methods");
                mb.AppendLine();
                foreach (var item in staticMethods)
                {
                    mb.Append($"     - {item.BeautifyName(false, true)}");
                    mb.AppendLine();
                }
            }

            var fields = GetFields(typeComments.Type);
            if (fields.Length > 0)
            {
                mb.Append("  -  Fields");
                mb.AppendLine();
                foreach (var item in fields)
                {
                    mb.Append($"     - {item.BeautifyName(false, true, true)}");
                    mb.AppendLine();
                }
            }

            var properties = GetProperties(typeComments.Type);
            if (properties.Length > 0)
            {
                mb.Append("  -  Properties");
                mb.AppendLine();
                foreach (var item in properties)
                {
                    mb.Append($"     - {item.Name}");
                    mb.AppendLine();
                }
            }

            var events = GetEvents(typeComments.Type);
            if (events.Length > 0)
            {
                mb.Append("  -  Events");
                mb.AppendLine();
                foreach (var item in events)
                {
                    mb.Append($"     - {item.Name}");
                    mb.AppendLine();
                }
            }

            var methods = GetMethods(typeComments.Type);
            if (methods.Length > 0)
            {
                mb.Append("  -  Methods");
                mb.AppendLine();
                foreach (var item in methods)
                {
                    mb.Append($"     - {item.BeautifyName(false, true)}");
                    mb.AppendLine();
                }
            }

            return mb.ToString();
        }

        private static MethodInfo[] GetMethods(Type type)
        {
            return type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.InvokeMethod)
                .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any() && !x.IsPrivate)
                .ToArray();
        }

        private static PropertyInfo[] GetProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.GetProperty | BindingFlags.SetProperty)
                .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any())
                .Where(y =>
                {
                    var get = y.GetGetMethod(true);
                    var set = y.GetSetMethod(true);
                    if (get != null && set != null)
                    {
                        return !(get.IsPrivate && set.IsPrivate);
                    }

                    if (get != null)
                    {
                        return !get.IsPrivate;
                    }

                    if (set != null)
                    {
                        return !set.IsPrivate;
                    }

                    return false;
                })
                .ToArray();
        }

        private static FieldInfo[] GetFields(Type type)
        {
            return type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.GetField | BindingFlags.SetField)
                .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any() && !x.IsPrivate)
                .ToArray();
        }

        private static EventInfo[] GetEvents(Type type)
        {
            return type.GetEvents(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any())
                .ToArray();
        }

        private static FieldInfo[] GetStaticFields(Type type)
        {
            return type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.GetField | BindingFlags.SetField)
                .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any() && !x.IsPrivate)
                .ToArray();
        }

        private static PropertyInfo[] GetStaticProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.GetProperty | BindingFlags.SetProperty)
                .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any())
                .Where(y =>
                {
                    var get = y.GetGetMethod(true);
                    var set = y.GetSetMethod(true);
                    if (get != null && set != null)
                    {
                        return !(get.IsPrivate && set.IsPrivate);
                    }

                    if (get != null)
                    {
                        return !get.IsPrivate;
                    }

                    if (set != null)
                    {
                        return !set.IsPrivate;
                    }

                    return false;
                })
                .ToArray();
        }

        private static MethodInfo[] GetStaticMethods(Type type)
        {
            return type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.InvokeMethod)
                .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any() && !x.IsPrivate)
                .ToArray();
        }

        private static EventInfo[] GetStaticEvents(Type type)
        {
            return type.GetEvents(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any())
                .ToArray();
        }

        private static void AppendHeaderForType(MarkdownBuilder mb, TypeComments typeComments)
        {
            mb.AppendLine();
            mb.AppendLine("<br />");
            mb.AppendLine();
            mb.Header(2, typeComments.Type.BeautifyName(false, true));

            var desc = typeComments.CommentLookup[typeComments.Type.FullName].FirstOrDefault(x => x.MemberType == MemberType.Type)?.Summary ?? string.Empty;
            if (desc.Length > 0)
            {
                mb.AppendLine(desc);
            }

            mb.AppendLine();
        }

        [SuppressMessage("Major Code Smell", "S3358:Ternary operators should not be nested", Justification = "OK.")]
        private static void AppendTypeBox(MarkdownBuilder mb, TypeComments typeComments)
        {
            var sb = new StringBuilder();
            var stat = typeComments.Type.IsAbstract && typeComments.Type.IsSealed
                ? "static "
                : string.Empty;
            var @abstract = typeComments.Type.IsAbstract && !typeComments.Type.IsInterface && !typeComments.Type.IsSealed
                ? "abstract "
                : string.Empty;
            var classOrStructOrEnumOrInterface = typeComments.Type.IsInterface
                ? "interface"
                : typeComments.Type.IsEnum
                    ? "enum"
                    : typeComments.Type.IsValueType
                        ? "struct"
                        : "class";

            var impl = string.Empty;
            if (!typeComments.Type.IsEnum)
            {
                impl = string.Join(
                    ", ",
                    new[] { typeComments.Type.BaseType }
                        .Concat(typeComments.Type.GetInterfaces())
                        .Where(x =>
                            x != null
                            && x != typeof(object)
                            && x != typeof(ValueType)
                            && !"System.Runtime.InteropServices".Equals(x.Namespace, StringComparison.Ordinal))
                        .Select(x => x!.BeautifyName(false, true)));
            }

            sb.AppendLine(impl.Length > 0
                ? $"public {stat}{@abstract}{classOrStructOrEnumOrInterface} {typeComments.Type.BeautifyName(false, true)} : {impl}"
                : $"public {stat}{@abstract}{classOrStructOrEnumOrInterface} {typeComments.Type.BeautifyName(false, true)}");

            mb.Code("csharp", sb.ToString());
            mb.AppendLine();
        }

        private static void AppendBodyForEnum(MarkdownBuilder mb, TypeComments typeComments)
        {
            var enums = Enum.GetNames(typeComments.Type)
                .Select(x => new
                {
                    Value = (int)Enum.Parse(typeComments.Type, x),
                    Name = x,
                    Description = (Enum.Parse(typeComments.Type, x) as Enum)!.GetDescription(),
                })
                .OrderBy(x => x.Value)
                .ToArray();

            BuildTable(mb, typeComments, null, enums, typeComments.CommentLookup[typeComments.Type.FullName], x => x.Value.ToString(GlobalizationConstants.EnglishCultureInfo), x => x.Name, x => x.Description!);
        }

        private static void AppendBodyForClass(MarkdownBuilder mb, TypeComments typeComments)
        {
            Build(mb, typeComments, "Static Fields", GetStaticFields(typeComments.Type), typeComments.CommentLookup[typeComments.Type.FullName], x => x.FieldType.BeautifyName(), x => x.Name, x => x.BeautifyName(false, false, true));
            Build(mb, typeComments, "Static Properties", GetStaticProperties(typeComments.Type), typeComments.CommentLookup[typeComments.Type.FullName], x => x.PropertyType.BeautifyName(), x => x.Name, x => x.Name);
            Build(mb, typeComments, "Static Events", GetStaticEvents(typeComments.Type), typeComments.CommentLookup[typeComments.Type.FullName], x => x.EventHandlerType.BeautifyName(), x => x.Name, x => x.Name);
            Build(mb, typeComments, "Static Methods", GetStaticMethods(typeComments.Type), typeComments.CommentLookup[typeComments.Type.FullName], x => x.ReturnType.BeautifyName(), x => x.Name, x => x.BeautifyName(false, false, true));

            Build(mb, typeComments, "Fields", GetFields(typeComments.Type), typeComments.CommentLookup[typeComments.Type.FullName], x => x.FieldType.BeautifyName(), x => x.Name, x => x.Name);
            Build(mb, typeComments, "Properties", GetProperties(typeComments.Type), typeComments.CommentLookup[typeComments.Type.FullName], x => x.PropertyType.BeautifyName(), x => x.Name, x => x.Name);
            Build(mb, typeComments, "Events", GetEvents(typeComments.Type), typeComments.CommentLookup[typeComments.Type.FullName], x => x.EventHandlerType.BeautifyName(), x => x.Name, x => x.Name);
            Build(mb, typeComments, "Methods", GetMethods(typeComments.Type), typeComments.CommentLookup[typeComments.Type.FullName], x => x.ReturnType.BeautifyName(), x => x.Name, x => x.BeautifyName(false, false, true));
        }

        [SuppressMessage("Major Code Smell", "S107:Methods should not have too many parameters", Justification = "OK.")]
        private static void BuildTable<T>(MarkdownBuilder mb, TypeComments typeComments, string? label, T[] array, IEnumerable<XmlDocumentComment> docs, Func<T, string> xType, Func<T, string> name, Func<T, string> finalName)
        {
            if (!array.Any())
            {
                return;
            }

            if (!string.IsNullOrEmpty(label))
            {
                mb.AppendLine("### " + label);
            }

            mb.AppendLine();
            IEnumerable<T> seq = array;
            if (typeComments.Type.IsEnum)
            {
                string[] head = { "Value", "Name", "Description", "Summary" };
                var data = seq.Select(item =>
                {
                    var summary = docs.FirstOrDefault(x => x.MemberName == name(item) || x.MemberName!.StartsWith(name(item) + "`", StringComparison.Ordinal))?.Summary ?? string.Empty;
                    return new[]
                    {
                        xType(item),
                        name(item),
                        finalName(item),
                        summary,
                    };
                }).ToList();

                mb.Table(head, data);
                mb.AppendLine();
            }
            else
            {
                seq = array.OrderBy(name);
                string[] head = { "Type", "Name", "Summary" };

                var data = seq.Select(item =>
                {
                    var summary = docs.FirstOrDefault(x => x.MemberName == name(item) || x.MemberName!.StartsWith(name(item) + "`", StringComparison.Ordinal))?.Summary ?? string.Empty;
                    return new[]
                    {
                        xType(item),
                        finalName(item),
                        summary,
                    };
                }).ToList();

                mb.Table(head, data);
                mb.AppendLine();
            }
        }

        [SuppressMessage("Major Code Smell", "S107:Methods should not have too many parameters", Justification = "OK.")]
        [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
        private static void Build<T>(MarkdownBuilder mb, TypeComments typeComments, string label, T[] array, IEnumerable<XmlDocumentComment> docs, Func<T, string> xType, Func<T, string> name, Func<T, string> finalName)
        {
            if (!array.Any())
            {
                return;
            }

            if (typeComments.Type.IsEnum)
            {
                BuildTable(mb, typeComments, label, array, docs, xType, name, finalName);
            }
            else
            {
                if (!string.IsNullOrEmpty(label))
                {
                    mb.AppendLine("### " + label);
                }

                mb.AppendLine();
                foreach (var item in array.OrderBy(name))
                {
                    mb.AppendLine($"#### {name(item)}");
                    mb.Code("csharp", finalName(item));

                    // ReSharper disable once PossibleMultipleEnumeration
                    var commentForMember = docs.FirstOrDefault(x =>
                        x.MemberName == name(item) ||
                        x.MemberName!.StartsWith(name(item) + "`", StringComparison.Ordinal));

                    if (commentForMember == null || string.IsNullOrEmpty(commentForMember.Summary))
                    {
                        continue;
                    }

                    if (commentForMember.Summary != name(item) + ".")
                    {
                        mb.AppendLine($"<p><b>Summary:</b> {commentForMember.Summary}</p>");
                    }

                    if (commentForMember.Parameters != null && commentForMember.Parameters.Count > 0)
                    {
                        mb.AppendLine("<b>Parameters</b>");
                        foreach (var parameter in commentForMember.Parameters)
                        {
                            mb.AppendLine(5, $"`{parameter.Key}`&nbsp;&nbsp;-&nbsp;&nbsp;{parameter.Value}<br />");
                        }
                    }

                    if (!string.IsNullOrEmpty(commentForMember.Returns))
                    {
                        mb.AppendLine($"<p><b>Returns:</b> {commentForMember.Returns}</p>");
                    }

                    if (!string.IsNullOrEmpty(commentForMember.Remarks))
                    {
                        mb.AppendLine($"<p><b>Remarks:</b> {commentForMember.Remarks}</p>");
                    }

                    if (!string.IsNullOrEmpty(commentForMember.Code))
                    {
                        mb.AppendLine("<b>Code usage:</b>");
                        mb.Code("csharp", commentForMember.Code);
                    }

                    if (!string.IsNullOrEmpty(commentForMember.Example))
                    {
                        mb.AppendLine("<b>Code example:</b>");
                        mb.Code("csharp", commentForMember.Example);
                    }
                }
            }
        }
    }
}