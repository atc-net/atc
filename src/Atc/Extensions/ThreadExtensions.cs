// ReSharper disable CheckNamespace
namespace System.Threading;

/// <summary>
/// Extensions for the <see cref="Thread"/> class.
/// </summary>
public static class ThreadExtensions
{
    /// <summary>
    /// Sets both the current culture and current UI culture for the thread.
    /// </summary>
    /// <param name="thread">The thread to modify.</param>
    /// <param name="cultureInfo">The culture information to set.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="thread"/> or <paramref name="cultureInfo"/> is null.</exception>
    public static void SetCulture(this Thread thread, CultureInfo cultureInfo)
    {
        if (thread is null)
        {
            throw new ArgumentNullException(nameof(thread));
        }

        if (cultureInfo is null)
        {
            throw new ArgumentNullException(nameof(cultureInfo));
        }

        thread.CurrentCulture = cultureInfo;
        thread.CurrentUICulture = cultureInfo;
    }
}