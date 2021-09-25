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
        /// <para>This method is platform independent.</para>
        /// <para>The default location on Windows is C:\Program Files\dotnet.</para>
        /// <para>The default location on Linux and macOS is /usr/share/dotnet.</para>
        /// <para>On Linux it varies from distribution to distribution and method of installation.</para>
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

            // The environment variable 'DOTNET_ROOT' specifies the location of the .NET runtimes,
            // if they are not installed in the default location.
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

            var dotnetFilename = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? "dotnet.exe"
                : "dotnet";

            var dotnetFullName = Path.Combine(dotnetDirectory.FullName, dotnetFilename);

            if (!File.Exists(dotnetFullName))
            {
                throw new FileNotFoundException($"No '{dotnetFilename}' file found in dotnet directory '{dotnetDirectory}'");
            }

            return new FileInfo(dotnetFullName);
        }

        /// <remarks>
        /// "dotnet" is the default name, but Github Actions installs to ".dotnet" ("/home/runner/.dotnet")
        /// </remarks>
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
