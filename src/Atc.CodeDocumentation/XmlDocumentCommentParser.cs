using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Atc.CodeDocumentation
{
    internal static class XmlDocumentCommentParser
    {
        internal static XmlDocumentComment?[] ParseXmlComment(XDocument xDocument, string? namespaceMatch)
        {
            return xDocument.Descendants("member")
                .Select(x =>
                {
                    var attributeValue = x.Attribute("name")?.Value;
                    if (attributeValue == null)
                    {
                        return null;
                    }

                    var match = Regex.Match(attributeValue, @"(.):(.+)\.([^.()]+)?(\(.+\)|$)");
                    if (!match.Groups[1].Success)
                    {
                        return null;
                    }

                    var memberType = (MemberType)match.Groups[1].Value[0];
                    if (memberType == MemberType.None)
                    {
                        return null;
                    }

                    var summaryXml = x.Elements("summary").FirstOrDefault()?.ToString()
                        ?? x.Element("summary")?.ToString()
                        ?? string.Empty;
                    summaryXml = Regex.Replace(summaryXml, @"<\/?summary>", string.Empty);
                    summaryXml = Regex.Replace(summaryXml, @"<para\s*/>", Environment.NewLine);
                    summaryXml = Regex.Replace(summaryXml, @"<see cref=""\w:([^\""]*)""\s*\/>", m => ResolveSeeElement(m, namespaceMatch));

                    var summary = Regex.Replace(summaryXml, @"<(type)*paramref name=""([^\""]*)""\s*\/>", e => $"`{e.Groups[1].Value}`");
                    if (summary.Length > 0)
                    {
                        summary = string.Join("  ", summary.Split(new[] { "\r", "\n", "\t" }, StringSplitOptions.RemoveEmptyEntries).Select(y => y.Trim()));
                    }

                    var returns = ((string)x.Element("returns")) ?? string.Empty;
                    var remarks = ((string)x.Element("remarks")) ?? string.Empty;
                    var code = (string)x.Element("code") ?? string.Empty;
                    if (code.Length > 0)
                    {
                        code = TrimCode(code, true);
                    }

                    var example = (string)x.Element("example") ?? string.Empty;
                    if (example.Length > 0)
                    {
                        example = TrimCode(example, false);
                    }

                    var parameters = x.Elements("param")
                        .Select(e => Tuple.Create(e.Attribute("name")?.Value ?? "Unknown", e))
                        .Distinct(new TupleEqualityComparer<string, XElement>())
                        .ToDictionary(e => e.Item1, e => e.Item2.Value);

                    var className = (memberType == MemberType.Type)
                        ? match.Groups[2].Value + "." + match.Groups[3].Value
                        : match.Groups[2].Value;

                    return new XmlDocumentComment
                    {
                        MemberType = memberType,
                        ClassName = className,
                        MemberName = match.Groups[3].Value,
                        Summary = summary.Trim(),
                        Remarks = remarks.Trim(),
                        Code = code,
                        Example = example,
                        Parameters = parameters,
                        Returns = returns.Trim(),
                    };
                })
                .Where(x => x != null)
                .ToArray();
        }

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

            if (s.EndsWith(".", StringComparison.Ordinal))
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
                ? $"[{typeName}]({Regex.Replace(typeName, "\\.(?:.(?!\\.))+$", me => me.Groups[0].Value.Replace(".", "#", StringComparison.Ordinal).ToLower(GlobalizationConstants.EnglishCultureInfo))})"
                : $"`{typeName}`";
        }
    }
}