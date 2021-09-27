using System.Text;

// ReSharper disable once CheckNamespace
namespace System.IO
{
    /// <summary>
    /// Extensions for the <see cref="Stream"/> class.
    /// </summary>
    public static class MemoryStreamExtensions
    {
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="encoding">The encoding.</param>
        public static string ToString(this MemoryStream stream, Encoding? encoding = null)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            encoding ??= Encoding.Unicode;

            return encoding.GetString(stream.ToArray());
        }
    }
}