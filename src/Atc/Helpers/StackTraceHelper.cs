namespace Atc.Helpers;

/// <summary>
/// Provides utility methods for working with stack traces.
/// </summary>
public static class StackTraceHelper
{
    /// <summary>
    /// Determines whether any of the stack frames within the specified frame count contains a constructor.
    /// </summary>
    /// <param name="drillDownFrameMax">The maximum number of frames to inspect in the stack trace.</param>
    /// <returns>
    ///   <c>true</c> if a constructor is found within the specified number of frames; otherwise, <c>false</c>.
    /// </returns>
    public static bool ContainsConstructorWithinFrameCount(
        int drillDownFrameMax)
    {
        var stackFrames = new StackTrace().GetFrames();
        if (stackFrames is null)
        {
            return false;
        }

        var stackFrameLengthMax = stackFrames.Length;
        if (stackFrameLengthMax > drillDownFrameMax)
        {
            stackFrameLengthMax = drillDownFrameMax;
        }

        for (var i = 0; i < stackFrameLengthMax; i++)
        {
            var methodBase = stackFrames[i].GetMethod();
            if (methodBase is not null &&
                ".ctor".Equals(methodBase.Name, StringComparison.Ordinal))
            {
                return true;
            }
        }

        return false;
    }
}