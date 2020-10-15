using System;
using System.IO;
using System.Text;
using Atc.Data.Models;

namespace Atc.Rest.ApiGenerator.Helpers
{
    public static class TextFileHelper
    {
        public static LogKeyValueItem Save(string file, string text, bool overrideIfExist = true)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            return Save(new FileInfo(file), text, overrideIfExist);
        }

        public static LogKeyValueItem Save(FileInfo fileInfo, string text, bool overrideIfExist = true)
        {
            if (fileInfo == null)
            {
                throw new ArgumentNullException(nameof(fileInfo));
            }

            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (fileInfo.Directory != null && !fileInfo.Directory.Exists)
            {
                Directory.CreateDirectory(fileInfo.Directory.FullName);
            }

            // Trim last NewLine in in *.cs files
            if (fileInfo.Extension.Equals(".cs", StringComparison.OrdinalIgnoreCase) &&
                text.EndsWith("}" + Environment.NewLine, StringComparison.Ordinal))
            {
                text = text.Substring(0, text.Length - 2);
            }

            if (File.Exists(fileInfo.FullName))
            {
                if (!overrideIfExist)
                {
                    return new LogKeyValueItem(LogCategoryType.Debug, "FileSkip", "#", fileInfo.FullName);
                }

                if (fileInfo.Extension.Equals(".cs", StringComparison.OrdinalIgnoreCase) ||
                    fileInfo.Extension.Equals(".csproj", StringComparison.OrdinalIgnoreCase) ||
                    fileInfo.Extension.Equals(".sln", StringComparison.OrdinalIgnoreCase))
                {
                    // If the content is the same - Note this don't take care of GIT-CRLF handling process.
                    string orgText = File.ReadAllText(fileInfo.FullName, Encoding.UTF8);
                    if (orgText == text)
                    {
                        return new LogKeyValueItem(LogCategoryType.Debug, "FileSkip", "#", fileInfo.FullName);
                    }
                }

                File.WriteAllText(fileInfo.FullName, text, Encoding.UTF8);
                return new LogKeyValueItem(LogCategoryType.Debug, "FileUpdate", "#", fileInfo.FullName);
            }

            File.WriteAllText(fileInfo.FullName, text, Encoding.UTF8);
            return new LogKeyValueItem(LogCategoryType.Debug, "FileCreate", "#", fileInfo.FullName);
        }
    }
}