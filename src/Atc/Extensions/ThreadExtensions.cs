using System.Globalization;

// ReSharper disable CheckNamespace
namespace System.Threading
{
    public static class ThreadExtensions
    {
        public static void SetCulture(this Thread thread, CultureInfo cultureInfo)
        {
            if (cultureInfo is null)
            {
                throw new ArgumentNullException(nameof(cultureInfo));
            }

            thread.CurrentCulture = cultureInfo;
            thread.CurrentUICulture = cultureInfo;
        }
    }
}