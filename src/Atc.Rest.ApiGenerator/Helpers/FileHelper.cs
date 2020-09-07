using System;
using System.IO;
using System.Text;

namespace Atc.Rest.ApiGenerator.Helpers
{
    public static class FileHelper
    {
        public static void Save(string file, string text)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Save(new FileInfo(file), text);
        }

        public static void Save(FileInfo fileInfo, string text)
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

            File.WriteAllText(fileInfo.FullName, text, Encoding.UTF8);
        }
    }
}