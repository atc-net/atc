namespace Atc.XUnit;

internal class DebugLimitData
{
    public DebugLimitData(List<Tuple<string, List<string>>> classMethodNames)
    {
        ClassMethodNames = classMethodNames;
    }

    internal List<Tuple<string, List<string>>> ClassMethodNames { get; }

    internal bool HasClassNames => ClassMethodNames.Count != 0;
}