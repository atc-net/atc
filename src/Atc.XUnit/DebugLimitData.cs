namespace Atc.XUnit;

/// <summary>
/// Internal helper class for debugging and filtering test coverage analysis to specific classes and methods.
/// </summary>
internal sealed class DebugLimitData
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DebugLimitData"/> class.
    /// </summary>
    /// <param name="classMethodNames">List of tuples containing class names and their associated method names to filter.</param>
    public DebugLimitData(List<Tuple<string, List<string>>> classMethodNames)
    {
        ClassMethodNames = classMethodNames;
    }

    /// <summary>
    /// Gets the list of class and method name filters.
    /// </summary>
    internal List<Tuple<string, List<string>>> ClassMethodNames { get; }

    /// <summary>
    /// Gets a value indicating whether any class name filters are specified.
    /// </summary>
    internal bool HasClassNames => ClassMethodNames.Count != 0;
}