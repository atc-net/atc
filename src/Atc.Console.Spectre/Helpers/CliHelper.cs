namespace Atc.Console.Spectre.Helpers;

public static class CliHelper
{
    public static Version GetCurrentVersion()
        => Assembly.GetExecutingAssembly().GetFileVersion();
}