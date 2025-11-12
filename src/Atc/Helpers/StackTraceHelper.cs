namespace Atc.Helpers;

/// <summary>
/// Provides utility methods for working with stack traces.
/// </summary>
public static class StackTraceHelper
{
    private const int DrillDownFrameDefaultMax = 250;
    private const int DrillDownFrameDefault = 25;

    /// <summary>
    /// Checks if the current stack trace contains a constructor call.
    /// </summary>
    /// <returns>True if a constructor call is found; otherwise, false.</returns>
    public static bool ContainsConstructor()
        => ContainsConstructor(DrillDownFrameDefault);

    /// <summary>
    /// Checks if the current stack trace contains a constructor call.
    /// </summary>
    /// <param name="drillDownFrameMax">The maximum number of frames to inspect.</param>
    /// <returns>True if a constructor call is found within the specified frames; otherwise, false.</returns>
    public static bool ContainsConstructor(int drillDownFrameMax)
        => ContainsNameWithinFrameCount(
            ".ctor",
            drillDownFrameMax);

    /// <summary>
    /// Checks if the current stack trace contains a property call for a specified property name.
    /// </summary>
    /// <param name="propertyName">The name of the property to check.</param>
    /// <returns>True if a call is found for the specified property; otherwise, false.</returns>
    public static bool ContainsPropertyName(string propertyName)
        => ContainsPropertyName(
            propertyName,
            DrillDownFrameDefault);

    /// <summary>
    /// Checks if the current stack trace contains a property call for a specified property name within a specified number of frames.
    /// </summary>
    /// <param name="propertyName">The name of the property to check.</param>
    /// <param name="drillDownFrameMax">The maximum number of frames to inspect.</param>
    /// <returns>True if a call is found for the specified property within the specified frames; otherwise, false.</returns>
    public static bool ContainsPropertyName(
        string propertyName,
        int drillDownFrameMax)
    {
        if (propertyName is null)
        {
            throw new ArgumentNullException(nameof(propertyName));
        }

        return ContainsNameWithinFrameCount(
            propertyName,
            drillDownFrameMax);
    }

    /// <summary>
    /// Checks if the current stack trace contains a property getter call for a specified property name.
    /// </summary>
    /// <param name="propertyName">The name of the property to check.</param>
    /// <returns>True if a getter call is found for the specified property; otherwise, false.</returns>
    public static bool ContainsPropertyGetterName(string propertyName)
        => ContainsPropertyGetterName(
            propertyName,
            DrillDownFrameDefault);

    /// <summary>
    /// Checks if the current stack trace contains a property getter call for a specified property name within a specified number of frames.
    /// </summary>
    /// <param name="propertyName">The name of the property to check.</param>
    /// <param name="drillDownFrameMax">The maximum number of frames to inspect.</param>
    /// <returns>True if a getter call is found for the specified property within the specified frames; otherwise, false.</returns>
    public static bool ContainsPropertyGetterName(
        string propertyName,
        int drillDownFrameMax)
        => ContainsNameWithinFrameCount(
            $"get_{propertyName}",
            drillDownFrameMax);

    /// <summary>
    /// Checks if the current stack trace contains a property setter call for a specified property name.
    /// </summary>
    /// <param name="propertyName">The name of the property to check.</param>
    /// <returns>True if a setter call is found for the specified property; otherwise, false.</returns>
    public static bool ContainsPropertySetterName(string propertyName)
        => ContainsPropertySetterName(
            propertyName,
            DrillDownFrameDefault);

    /// <summary>
    /// Checks if the current stack trace contains a property setter call for a specified property name within a specified number of frames.
    /// </summary>
    /// <param name="propertyName">The name of the property to check.</param>
    /// <param name="drillDownFrameMax">The maximum number of frames to inspect.</param>
    /// <returns>True if a setter call is found for the specified property within the specified frames; otherwise, false.</returns>
    public static bool ContainsPropertySetterName(
        string propertyName,
        int drillDownFrameMax)
        => ContainsNameWithinFrameCount(
            $"set_{propertyName}",
            drillDownFrameMax);

    /// <summary>
    /// Checks if the current stack trace contains a method with a specified name within a specified number of frames.
    /// </summary>
    /// <param name="name">The name of the method to check.</param>
    /// <param name="drillDownFrameMax">The maximum number of frames to inspect.</param>
    /// <returns>True if the method is found within the specified frames; otherwise, false.</returns>
    private static bool ContainsNameWithinFrameCount(
        string name,
        int drillDownFrameMax)
    {
        var stackFrames = new StackTrace()
            .GetFrames()?
            .Take(DrillDownFrameDefaultMax)
            .ToArray();

        if (stackFrames is null)
        {
            return false;
        }

        var stackFrameDepthMax = stackFrames.Length;
        if (stackFrameDepthMax > drillDownFrameMax)
        {
            stackFrameDepthMax = drillDownFrameMax;
        }

        for (var i = 0; i < stackFrameDepthMax; i++)
        {
            var methodName = stackFrames[i].GetMethod()?.Name;
            if (methodName is not null &&
                name.Equals(methodName, StringComparison.Ordinal))
            {
                return true;
            }
        }

        return false;
    }
}