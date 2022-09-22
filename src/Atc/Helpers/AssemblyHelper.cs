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
}