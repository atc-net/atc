namespace Atc.Helpers;

/// <summary>
/// The AssemblyHelper module contains procedures used to preform assembly operations.
/// </summary>
public static class AssemblyHelper
{
    /// <summary>
    /// Load the specified assembly file, with a reference to memory and not the specified file.
    /// </summary>
    /// <remarks>
    /// The assembly is never directly loaded, to avoid
    /// holding a instance as "assembly = Assembly.Load(file)" do.
    /// </remarks>
    /// <param name="assemblyFile">The assembly file.</param>
    /// <returns>The Assembly that is loaded.</returns>
    public static Assembly Load(
        FileInfo assemblyFile)
    {
        if (assemblyFile is null)
        {
            throw new ArgumentNullException(nameof(assemblyFile));
        }

        if (!assemblyFile.Exists)
        {
            throw new IOException("File not found");
        }

        if (!assemblyFile.Extension.Equals(".dll", StringComparison.OrdinalIgnoreCase))
        {
            throw new IOException("File is not a dll");
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

        return Assembly.Load(bytes);
    }

    /// <summary>
    /// Read the specified assembly file into a byte array.
    /// </summary>
    /// <param name="assemblyFile">The assembly file.</param>
    /// <returns>The Assembly in a byte array.</returns>
    public static byte[] ReadAsBytes(
        FileInfo assemblyFile)
    {
        if (assemblyFile is null)
        {
            throw new ArgumentNullException(nameof(assemblyFile));
        }

        if (!assemblyFile.Exists)
        {
            throw new IOException("File not found");
        }

        if (!assemblyFile.Extension.Equals(".dll", StringComparison.OrdinalIgnoreCase))
        {
            throw new IOException("File is not a dll");
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