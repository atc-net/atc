namespace Atc.CodeDocumentation.Markdown;

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

    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
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
            var list = staticFields
                .Select(x => x.BeautifyName(useFullName: false, useHtmlFormat: true, includeReturnType: true))
                .OrderBy(x => x)
                .ToList();
            AppendIndentedLines(mb, list);
        }

        var staticProperties = GetStaticProperties(typeComments.Type);
        if (staticProperties.Length > 0)
        {
            mb.Append("  -  Static Properties");
            mb.AppendLine();
            var list = staticProperties
                .Select(x => x.Name)
                .OrderBy(x => x)
                .ToList();
            AppendIndentedLines(mb, list);
        }

        var staticEvents = GetStaticEvents(typeComments.Type);
        if (staticEvents.Length > 0)
        {
            mb.Append("  -  Static Events");
            mb.AppendLine();
            var list = staticEvents
                .Select(x => x.Name)
                .OrderBy(x => x)
                .ToList();
            AppendIndentedLines(mb, list);
        }

        var staticMethods = GetStaticMethods(typeComments.Type);
        if (staticMethods.Length > 0)
        {
            mb.Append("  -  Static Methods");
            mb.AppendLine();
            var list = staticMethods
                .Select(x => x.BeautifyName(useFullName: false, useHtmlFormat: true))
                .OrderBy(x => x)
                .ToList();
            AppendIndentedLines(mb, list);
        }

        var fields = GetFields(typeComments.Type);
        if (fields.Length > 0)
        {
            mb.Append("  -  Fields");
            mb.AppendLine();
            var list = fields
                .Select(x => x.BeautifyName(useFullName: false, useHtmlFormat: true, includeReturnType: true))
                .OrderBy(x => x)
                .ToList();
            AppendIndentedLines(mb, list);
        }

        var properties = GetProperties(typeComments.Type);
        if (properties.Length > 0)
        {
            mb.Append("  -  Properties");
            mb.AppendLine();
            var list = properties
                .Select(x => x.Name)
                .OrderBy(x => x)
                .ToList();
            AppendIndentedLines(mb, list);
        }

        var events = GetEvents(typeComments.Type);
        if (events.Length > 0)
        {
            mb.Append("  -  Events");
            mb.AppendLine();
            var list = events
                .Select(x => x.Name)
                .OrderBy(x => x)
                .ToList();
            AppendIndentedLines(mb, list);
        }

        var methods = GetMethods(typeComments.Type);
        if (methods.Length > 0)
        {
            mb.Append("  -  Methods");
            mb.AppendLine();
            var list = methods
                .Select(x => x.BeautifyName(useFullName: false, useHtmlFormat: true))
                .OrderBy(x => x)
                .ToList();
            AppendIndentedLines(mb, list);
        }

        return mb.ToString();
    }

    private static void AppendIndentedLines(MarkdownBuilder mb, IEnumerable<string> list)
    {
        foreach (var item in list)
        {
            mb.Append($"     - {item}");
            mb.AppendLine();
        }
    }

    private static MethodInfo[] GetMethods(Type type)
    {
        return type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.InvokeMethod)
            .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any() && !x.IsPrivate)
            .ToArray();
    }

    private static PropertyInfo[] GetProperties(Type type)
    {
        return type
            .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.GetProperty | BindingFlags.SetProperty)
            .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any())
            .Where(y =>
            {
                var get = y.GetGetMethod(nonPublic: true);
                var set = y.GetSetMethod(nonPublic: true);
                if (get is not null && set is not null)
                {
                    return !(get.IsPrivate && set.IsPrivate);
                }

                if (get is not null)
                {
                    return !get.IsPrivate;
                }

                if (set is not null)
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
        return type
            .GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.GetProperty | BindingFlags.SetProperty)
            .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any())
            .Where(y =>
            {
                var get = y.GetGetMethod(nonPublic: true);
                var set = y.GetSetMethod(nonPublic: true);
                if (get is not null && set is not null)
                {
                    return !(get.IsPrivate && set.IsPrivate);
                }

                if (get is not null)
                {
                    return !get.IsPrivate;
                }

                if (set is not null)
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
        mb.Header(2, typeComments.Type.BeautifyName(useFullName: false, useHtmlFormat: true));

        var summary = typeComments.CommentLookup[typeComments.Type.FullName].FirstOrDefault(x => x.MemberType == MemberType.Type)?.Summary ?? string.Empty;
        if (summary.Length > 0)
        {
            mb.AppendLine(summary.Replace("  ", "<br>", StringComparison.Ordinal));

            var remarks = typeComments.CommentLookup[typeComments.Type.FullName].FirstOrDefault(x => x.MemberType == MemberType.Type)?.Remarks ?? string.Empty;
            if (!string.IsNullOrEmpty(remarks))
            {
                mb.AppendLine($"><b>Remarks:</b> {remarks.Replace("  ", "<br>", StringComparison.Ordinal)}");
            }

            var code = typeComments.CommentLookup[typeComments.Type.FullName].FirstOrDefault(x => x.MemberType == MemberType.Type)?.Code ?? string.Empty;
            if (!string.IsNullOrEmpty(code))
            {
                mb.AppendLine("><b>Code usage:</b>");
                mb.Code("csharp", code);
            }

            var example = typeComments.CommentLookup[typeComments.Type.FullName].FirstOrDefault(x => x.MemberType == MemberType.Type)?.Example ?? string.Empty;
            if (!string.IsNullOrEmpty(example))
            {
                mb.AppendLine("<b>Code example:</b>");
                mb.Code("csharp", example);
            }
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
                        x is not null
                        && x != typeof(object)
                        && x != typeof(ValueType)
                        && !"System.Runtime.InteropServices".Equals(x.Namespace, StringComparison.Ordinal))
                    .Select(x => x!.BeautifyName()));
        }

        sb.AppendLine(impl.Length > 0
            ? $"public {stat}{@abstract}{classOrStructOrEnumOrInterface} {typeComments.Type.BeautifyName(useFullName: false, useHtmlFormat: true)} : {impl}"
            : $"public {stat}{@abstract}{classOrStructOrEnumOrInterface} {typeComments.Type.BeautifyName(useFullName: false, useHtmlFormat: true)}");

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

        BuildTable(mb, typeComments, label: null, enums, typeComments.CommentLookup[typeComments.Type.FullName], x => x.Value.ToString(GlobalizationConstants.EnglishCultureInfo), x => x.Name, x => x.Description!);
    }

    private static void AppendBodyForClass(MarkdownBuilder mb, TypeComments typeComments)
    {
        Build(mb, typeComments, "Static Fields", GetStaticFields(typeComments.Type), typeComments.CommentLookup[typeComments.Type.FullName], x => x.FieldType.BeautifyName(), x => x.Name, x => x.BeautifyName(useFullName: false, useHtmlFormat: false, includeReturnType: true));
        Build(mb, typeComments, "Static Properties", GetStaticProperties(typeComments.Type), typeComments.CommentLookup[typeComments.Type.FullName], x => x.PropertyType.BeautifyName(), x => x.Name, x => x.Name);
        Build(mb, typeComments, "Static Events", GetStaticEvents(typeComments.Type), typeComments.CommentLookup[typeComments.Type.FullName], x => x.EventHandlerType.BeautifyName(), x => x.Name, x => x.Name);
        Build(mb, typeComments, "Static Methods", GetStaticMethods(typeComments.Type), typeComments.CommentLookup[typeComments.Type.FullName], x => x.ReturnType.BeautifyName(), x => x.Name, x => x.BeautifyName(useFullName: false, useHtmlFormat: false, includeReturnType: true));

        Build(mb, typeComments, "Fields", GetFields(typeComments.Type), typeComments.CommentLookup[typeComments.Type.FullName], x => x.FieldType.BeautifyName(), x => x.Name, x => x.Name);
        Build(mb, typeComments, "Properties", GetProperties(typeComments.Type), typeComments.CommentLookup[typeComments.Type.FullName], x => x.PropertyType.BeautifyName(), x => x.Name, x => x.Name);
        Build(mb, typeComments, "Events", GetEvents(typeComments.Type), typeComments.CommentLookup[typeComments.Type.FullName], x => x.EventHandlerType.BeautifyName(), x => x.Name, x => x.Name);
        Build(mb, typeComments, "Methods", GetMethods(typeComments.Type), typeComments.CommentLookup[typeComments.Type.FullName], x => x.ReturnType.BeautifyName(), x => x.Name, x => x.BeautifyName(useFullName: false, useHtmlFormat: false, includeReturnType: true));
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
                var summary = docs.FirstOrDefault(x => string.Equals(x.MemberName, name(item), StringComparison.Ordinal) || x.MemberName!.StartsWith(name(item) + "`", StringComparison.Ordinal))?.Summary ?? string.Empty;
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
                var summary = docs.FirstOrDefault(x => string.Equals(x.MemberName, name(item), StringComparison.Ordinal) || x.MemberName!.StartsWith(name(item) + "`", StringComparison.Ordinal))?.Summary ?? string.Empty;
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

    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
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
                    string.Equals(x.MemberName, name(item), StringComparison.Ordinal) ||
                    x.MemberName!.StartsWith(name(item) + "`", StringComparison.Ordinal));

                if (commentForMember is null || string.IsNullOrEmpty(commentForMember.Summary))
                {
                    continue;
                }

                if (!string.Equals(commentForMember.Summary, name(item) + ".", StringComparison.Ordinal))
                {
                    mb.AppendLine($"><b>Summary:</b> {commentForMember.Summary.Replace("  ", "<br>", StringComparison.Ordinal)}");
                }

                if (commentForMember.Parameters is not null && commentForMember.Parameters.Count > 0)
                {
                    mb.AppendLine(">");
                    mb.AppendLine("><b>Parameters:</b><br>");
                    foreach (var parameter in commentForMember.Parameters)
                    {
                        mb.Append(">");
                        mb.AppendLine(5, $"`{parameter.Key}`&nbsp;&nbsp;-&nbsp;&nbsp;{parameter.Value}<br />");
                    }
                }

                if (!string.IsNullOrEmpty(commentForMember.Returns))
                {
                    mb.AppendLine(">");
                    mb.AppendLine($"><b>Returns:</b> {commentForMember.Returns.Replace("  ", "<br>", StringComparison.Ordinal)}");
                }

                if (!string.IsNullOrEmpty(commentForMember.Remarks))
                {
                    mb.AppendLine(">");
                    mb.AppendLine($"><b>Remarks:</b> {commentForMember.Remarks.Replace("  ", "<br>", StringComparison.Ordinal)}");
                }

                if (!string.IsNullOrEmpty(commentForMember.Code))
                {
                    mb.AppendLine(">");
                    mb.AppendLine("><b>Code usage:</b>");
                    mb.Code("csharp", commentForMember.Code);
                }

                if (!string.IsNullOrEmpty(commentForMember.Example))
                {
                    mb.AppendLine(">");
                    mb.AppendLine("><b>Code example:</b>");
                    mb.Code("csharp", commentForMember.Example);
                }
            }
        }
    }
}