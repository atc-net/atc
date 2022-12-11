namespace Atc.Helpers;

public static class DirectoryInfoHelper
{
    public static DirectoryInfo GetTempPath()
        => new(Path.GetTempPath());

    public static DirectoryInfo GetTempPathWithSubFolder(
        string folderName)
    {
        if (folderName is null)
        {
            throw new ArgumentNullException(nameof(folderName));
        }

        return new DirectoryInfo(Path.Combine(Path.GetTempPath(), folderName));
    }
}