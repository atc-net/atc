namespace Atc.Tests.Serialization.XUnitTestTypes;

public class ComplexData
{
    public CultureInfo? MyCulture { get; set; }

    public DirectoryInfo? MyDirectory { get; set; }

    public FileInfo? MyFile { get; set; }

    public TimeSpan? MyTimeSpan { get; set; }

    public DateTimeOffset? MyDateTimeOffset { get; set; }

    public Uri? MyUri { get; set; }

    public Version? MyVersion { get; set; }

    public ChargePointState? State { get; set; }

    public override string ToString()
        => $"{nameof(MyCulture)}: {MyCulture}, {nameof(MyDirectory)}: {MyDirectory}, {nameof(MyFile)}: {MyFile}, {nameof(MyTimeSpan)}: {MyTimeSpan}, {nameof(MyDateTimeOffset)}: {MyDateTimeOffset}, {nameof(MyUri)}: {MyUri}, {nameof(MyVersion)}: {MyVersion}";
}