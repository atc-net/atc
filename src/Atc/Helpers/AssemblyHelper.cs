namespace Atc.Helpers;

/// <summary>
/// The AssemblyHelper module contains procedures used to preform assembly operations.
/// </summary>
public static class AssemblyHelper
{
    /// <summary>
    /// Retrieves the project root directory by searching upwards from the current assembly's base directory.
    /// The method looks for a directory containing a .csproj or .sln file, which is commonly found in the root of a C# project.
    /// </summary>
    /// <remarks>
    /// This method starts at the current assembly's base directory and moves up the directory tree until it finds a directory
    /// containing at least one .csproj or .sln file. This directory is considered the project root. If no such directory is found,
    /// the method defaults to returning the base directory of the application domain.
    /// This approach allows the method to be more adaptable to various project structures without relying on a fixed directory depth.
    /// However, it assumes that the project root will contain at least one .csproj or .sln file.
    /// </remarks>
    /// <returns>
    /// A <see cref="DirectoryInfo"/> object representing the project root directory,
    /// or the assembly's base directory if the project root cannot be determined.
    /// </returns>
    public static DirectoryInfo GetProjectRootDirectory()
    {
        var directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

        while (directory is not null &&
               directory.GetFiles("*.csproj").Length == 0 &&
               directory.GetFiles("*.sln").Length == 0)
        {
            directory = directory.Parent;
        }

        return directory ?? new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
    }

    /// <summary>
    /// Load the specified assembly file, with a reference to memory and not the specified file.
    /// </summary>
    /// <remarks>
    /// The assembly is never directly loaded, to avoid
    /// holding a instance as "assembly = Assembly.Load(file)" do.
    /// </remarks>
    /// <param name="assemblyFile">The assembly file.</param>
    /// <returns>The Assembly that is loaded.</returns>
    public static Assembly Load(FileInfo assemblyFile)
    {
        if (assemblyFile is null)
        {
            throw new ArgumentNullException(nameof(assemblyFile));
        }

        if (!assemblyFile.Exists)
        {
            throw new IOException("File not found");
        }

        if (!assemblyFile.Extension.Equals(".dll", StringComparison.OrdinalIgnoreCase) &&
            !assemblyFile.Extension.Equals(".exe", StringComparison.OrdinalIgnoreCase))
        {
            throw new IOException("File is not a dll or a executable file");
        }

        var bytes = ReadAsBytes(assemblyFile);
        if (bytes is null)
        {
            throw new IOException("Unknown problem with the file");
        }

        if (bytes.Length == 0)
        {
            throw new IOException("File has a 0 byte length");
        }

        try
        {
            return Assembly.Load(bytes);
        }
        catch (BadImageFormatException)
        {
            throw new IOException("File is not a valid Assembly");
        }
        catch (TypeLoadException)
        {
            throw new IOException("File is a unknown Assembly");
        }
    }

    /// <summary>
    /// Read the specified assembly file into a byte array.
    /// </summary>
    /// <param name="assemblyFile">The assembly file.</param>
    /// <returns>The Assembly in a byte array.</returns>
    public static byte[] ReadAsBytes(FileInfo assemblyFile)
    {
        if (assemblyFile is null)
        {
            throw new ArgumentNullException(nameof(assemblyFile));
        }

        if (!File.Exists(assemblyFile.FullName))
        {
            throw new IOException("File not found");
        }

        if (!assemblyFile.Extension.Equals(".dll", StringComparison.OrdinalIgnoreCase) &&
            !assemblyFile.Extension.Equals(".exe", StringComparison.OrdinalIgnoreCase) &&
            !(assemblyFile.Name.StartsWith('~') && assemblyFile.Name.EndsWith(".tmp", StringComparison.Ordinal)))
        {
            throw new IOException("File is not a dll or a executable file");
        }

        try
        {
            using var ms = new MemoryStream();
            using (var fs = File.Open(assemblyFile.FullName, FileMode.Open))
            {
                var buffer = new byte[1024];
                int read;
                while ((read = fs.Read(buffer, 0, 1024)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
            }

            return ms.ToArray();
        }
        catch (IOException)
        {
            var tmpFile = new FileInfo(Path.Combine(Path.GetTempPath(), "~" + Path.GetFileNameWithoutExtension(assemblyFile.Name) + ".tmp"));
            if (tmpFile.Exists)
            {
                File.Delete(tmpFile.FullName);
            }

            File.Copy(assemblyFile.FullName, tmpFile.FullName);
            var data = ReadAsBytes(tmpFile);
            File.Delete(tmpFile.FullName);
            return data;
        }
    }

    /// <summary>
    /// Gets the system name.</summary>
    /// <returns>System name.</returns>
    public static string GetSystemName()
    {
        var assembly = Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
        return assembly
            .GetName()
            .Name!;
    }

    /// <summary>
    /// Gets the system name as kebab casing.</summary>
    /// <returns>System name as kebab casing.</returns>
    public static string GetSystemNameAsKebabCasing()
        => GetSystemName()
            .Replace('.', '-')
            .ToLower(GlobalizationConstants.EnglishCultureInfo);

    /// <summary>
    /// Gets the system version.</summary>
    /// <returns>System version.</returns>
    public static Version GetSystemVersion()
    {
        var assembly = Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
        return assembly.GetFileVersion();
    }

    /// <summary>
    /// Gets the system location.</summary>
    /// <returns>System location.</returns>
    public static string GetSystemLocation()
    {
        var assembly = Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
        return assembly.Location;
    }

    /// <summary>
    /// Gets the system location path.</summary>
    /// <returns>System location path.</returns>
    public static string GetSystemLocationPath()
    {
        var uri = new UriBuilder(GetSystemLocation());
        return Path.GetDirectoryName(Uri.UnescapeDataString(uri.Path))!;
    }

    /// <summary>
    /// Gets the assembly informations.
    /// </summary>
    /// <returns>The array of <see cref="AssemblyInformation"/>.</returns>
    public static AssemblyInformation[] GetAssemblyInformations()
        => AppDomain.CurrentDomain.GetAssemblyInformations();

    /// <summary>
    /// Gets the assembly informations by system.
    /// </summary>
    /// <returns>The array of <see cref="AssemblyInformation"/>.</returns>
    public static AssemblyInformation[] GetAssemblyInformationsBySystem()
        => AppDomain.CurrentDomain.GetAssemblyInformationsBySystem();

    /// <summary>
    /// Gets the assembly informations by assembly fullname should start with value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The array of <see cref="AssemblyInformation"/>.</returns>
    public static AssemblyInformation[] GetAssemblyInformationsByStartsWith(
        string value)
        => AppDomain.CurrentDomain.GetAssemblyInformationsByStartsWith(value);
}