namespace Atc.Helpers;

/// <summary>
/// Provides utility methods for working with <see cref="DirectoryInfo"/> objects.
/// </summary>
public static class DirectoryInfoHelper
{
    /// <summary>
    /// Gets a <see cref="DirectoryInfo"/> object representing the system's temporary folder.
    /// </summary>
    /// <returns>A <see cref="DirectoryInfo"/> for the temp path.</returns>
    public static DirectoryInfo GetTempPath()
        => new(Path.GetTempPath());

    /// <summary>
    /// Gets a <see cref="DirectoryInfo"/> object representing a subfolder within the system's temporary folder.
    /// </summary>
    /// <param name="folderName">The name of the subfolder within the temp directory.</param>
    /// <returns>A <see cref="DirectoryInfo"/> for the temp path with the specified subfolder.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="folderName"/> is <see langword="null"/>.</exception>
    public static DirectoryInfo GetTempPathWithSubFolder(string folderName)
    {
        if (folderName is null)
        {
            throw new ArgumentNullException(nameof(folderName));
        }

        return new DirectoryInfo(Path.Combine(Path.GetTempPath(), folderName));
    }
}