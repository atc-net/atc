using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Atc.DotNet
{
    public static class DotnetHelper
    {
        /// <summary>
        /// Get the directory of the .NET runtime.
        /// </summary>
        /// <remarks>
        /// This method is platform independent.
        /// </remarks>
        public static DirectoryInfo GetDotnetDirectory()
        {
            var directory = new DirectoryInfo(RuntimeEnvironment.GetRuntimeDirectory());

            while (directory.Parent is not null &&
                  !directory.Name.Equals("dotnet", StringComparison.OrdinalIgnoreCase))
            {
                directory = directory.Parent;
            }

            return directory;
        }

        /// <summary>
        /// Get the dotnet executable file from the OS.
        /// </summary>
        /// <remarks>
        /// This method is platform independent.
        /// </remarks>
        public static FileInfo GetDotnetExecutable()
        {
            var dotnetDirectory = GetDotnetDirectory();
            var files = Directory.GetFiles(dotnetDirectory.FullName, "dotnet*");
            return files.Length switch
            {
                0 => throw new FileNotFoundException($"Could not find a dotnet file in path '{dotnetDirectory.FullName}'."),
                > 1 => throw new NotSupportedException($"Too many files matching dotnet* found in path '{dotnetDirectory.FullName}'."),
                _ => new FileInfo(files[0]),
            };
        }
    }
}
