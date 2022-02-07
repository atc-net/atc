namespace Atc.CodeDocumentation;

internal static class XmlDocumentCommentParser
{
    internal static XmlDocumentComment?[] ParseXmlComment(XDocument xDocument, string? namespaceMatch)
    {
        return xDocument.Descendants("member")
            .Select(x =>
            {
                var attributeValue = x.Attribute("name")?.Value;
                if (attributeValue is null)
                {
                    return null;
                }

                var match = Regex.Match(attributeValue, @"(.):(.+)\.([^.()]+)?(\(.+\)|$)", RegexOptions.None, TimeSpan.FromSeconds(5));
                if (!match.Groups[1].Success)
                {
                    return null;
                }

                var memberType = (MemberType)match.Groups[1].Value[0];
                if (memberType == MemberType.None)
                {
                    return null;
                }

                var className = (memberType == MemberType.Type)
                    ? match.Groups[2].Value + "." + match.Groups[3].Value
                    : match.Groups[2].Value;

                var summary = x.ParseElementText("summary", namespaceMatch);
                var returns = x.ParseElementText("returns", namespaceMatch);
                var remarks = x.ParseElementText("remarks", namespaceMatch);

                var code = (string)x.Element("code") ?? string.Empty;
                if (code.Length > 0)
                {
                    code = TrimCode(code, trimEachLine: true);
                }

                var example = (string)x.Element("example") ?? string.Empty;
                if (example.Length > 0)
                {
                    example = TrimCode(example, trimEachLine: false);
                }

                var parameters = x.Elements("param")
                    .Select(e => Tuple.Create(e.Attribute("name")?.Value ?? "Unknown", e))
                    .Distinct(new TupleEqualityComparer<string, XElement>())
                    .ToDictionary(e => e.Item1, e => e.Item2.Value, StringComparer.Ordinal);

                return new XmlDocumentComment
                {
                    MemberType = memberType,
                    ClassName = className,
                    MemberName = match.Groups[3].Value,
                    Summary = summary,
                    Remarks = remarks,
                    Code = code,
                    Example = example,
                    Parameters = parameters,
                    Returns = returns,
                };
            })
            .Where(x => x is not null)
            .ToArray();
    }

    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    private static string TrimCode(string code, bool trimEachLine)
    {
        var sb = new StringBuilder();
        var sa = code.Split(new[] { '\n' }, StringSplitOptions.None);
        var ei = sa.Length - 1;
        const string lineStartOverheadSpaces = "            ";
        for (var i = 0; i < sa.Length; i++)
        {
            if (i == 0 && sa[i].Length == 0)
            {
                continue;
            }

            if (i == ei && sa[i].TrimExtended().Length == 0)
            {
                continue;
            }

            if (trimEachLine)
            {
                sb.AppendLine(sa[i].TrimExtended());
            }
            else
            {
                sb.AppendLine(sa[i].StartsWith(lineStartOverheadSpaces, StringComparison.Ordinal)
                    ? sa[i].Substring(lineStartOverheadSpaces.Length)
                    : sa[i]);
            }
        }

        var s = sb.ToString();
        var charsToRemove = 0;
        if (s.EndsWith(Environment.NewLine, StringComparison.Ordinal))
        {
            charsToRemove += 2;
        }

        if (s.EndsWith('.'))
        {
            charsToRemove++;
        }

        return charsToRemove > 0
            ? s.Substring(0, s.Length - charsToRemove)
            : s;
    }

    private static string ResolveSeeElement(Match m, string? ns)
    {
        var typeName = m.Groups[1].Value;
        if (string.IsNullOrWhiteSpace(ns))
        {
            return $"`{typeName}`";
        }

        return typeName.StartsWith(ns, StringComparison.Ordinal)
            ? $"[{typeName}]({Regex.Replace(typeName, "\\.(?:.(?!\\.))+$", me => me.Groups[0].Value.Replace(".", "#", StringComparison.Ordinal).ToLower(GlobalizationConstants.EnglishCultureInfo), RegexOptions.None, TimeSpan.FromSeconds(1))})"
            : $"`{typeName}`";
    }

    private static string ParseElementText(this XElement x, string name, string? @namespace)
    {
        var innerXml = x.Element(name)?.ToString();
        if (string.IsNullOrEmpty(innerXml))
        {
            return string.Empty;
        }

        innerXml = innerXml.Replace("<para>", string.Empty, StringComparison.Ordinal);
        innerXml = innerXml.Replace(Environment.NewLine, " ", StringComparison.Ordinal);
        innerXml = Regex.Replace(innerXml, @$"<\/?{name}>", string.Empty, RegexOptions.None, TimeSpan.FromSeconds(1)).Trim();
        innerXml = Regex.Replace(innerXml, @"<para\s*\/>|<\/para>", Environment.NewLine, RegexOptions.None, TimeSpan.FromSeconds(1));
        innerXml = Regex.Replace(innerXml, @"<see cref=""\w:([^\""]*)""\s*\/>", m => ResolveSeeElement(m, @namespace), RegexOptions.None, TimeSpan.FromSeconds(1));
        innerXml = Regex.Replace(innerXml, @"<(type)*paramref name=""([^\""]*)""\s*\/>", e => $"`{e.Groups[2].Value}`", RegexOptions.None, TimeSpan.FromSeconds(1));
        innerXml = Regex.Replace(innerXml, @"<c\b[^>]*>(.*?)<\/c>", e => $"`{e.Groups[1].Value}`", RegexOptions.None, TimeSpan.FromSeconds(1));
        innerXml = innerXml.TrimExtended();
        return string.Join("  ", innerXml.Split(new[] { "\r", "\n", "\t" }, StringSplitOptions.RemoveEmptyEntries).Select(y => y.Trim()));
    }
}