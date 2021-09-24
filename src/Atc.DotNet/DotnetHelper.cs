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

            while (directory.Parent is not null && !IsDefaultDotnetDirectoryName(directory.Name))
            {
                directory = directory.Parent;
            }

            if (directory.Exists && IsDefaultDotnetDirectoryName(directory.Name))
            {
                return directory;
            }

            if (TryGetDotnetDirectoryFromEnv("DOTNET_ROOT", out var result))
            {
                return result!;
            }

            throw new DirectoryNotFoundException("Could not determine location of system dotnet folder");
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

            var executableFile = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? "dotnet.exe"
                : "dotnet";

            var files = Directory.GetFiles(dotnetDirectory.FullName, executableFile);
            return files.Length switch
            {
                0 => throw new FileNotFoundException($"Could not find a dotnet file in path '{dotnetDirectory.FullName}'."),
                > 1 => throw new NotSupportedException($"Too many files matching dotnet* found in path '{dotnetDirectory.FullName}'."),
                _ => new FileInfo(files[0]),
            };
        }

        private static bool IsDefaultDotnetDirectoryName(string value)
        {
            return value.Equals("dotnet", StringComparison.Ordinal) ||
                   value.Equals(".dotnet", StringComparison.Ordinal);
        }

        private static bool TryGetDotnetDirectoryFromEnv(string envVariable, out DirectoryInfo? dotnetDirectory)
        {
            dotnetDirectory = null;
            var dotnetRootEnv = Environment.GetEnvironmentVariable(envVariable);
            if (!string.IsNullOrEmpty(dotnetRootEnv) && Directory.Exists(dotnetRootEnv))
            {
                dotnetDirectory = new DirectoryInfo(dotnetRootEnv);
                return true;
            }

            return false;
        }
    }
}
