using Atc;

// ReSharper disable once CheckNamespace
namespace System.Text
{
    /// <summary>
    /// Extensions for the <see cref="StringBuilder"/> class.
    /// </summary>
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Appends a formatting options to the string builder.
        /// </summary>
        /// <param name="sb">The <see cref="StringBuilder"/>.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void Append(this StringBuilder sb, string format, params object[] args)
        {
            if (sb == null)
            {
                throw new ArgumentNullException(nameof(sb));
            }

            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            sb.Append(string.Format(GlobalizationConstants.EnglishCultureInfo, format, args));
        }

        /// <summary>
        /// Appends a new line with formatting options to the string builder.
        /// </summary>
        /// <param name="sb">The <see cref="StringBuilder"/>.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void AppendLine(this StringBuilder sb, string format, params object[] args)
        {
            if (sb == null)
            {
                throw new ArgumentNullException(nameof(sb));
            }

            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            sb.AppendLine(string.Format(GlobalizationConstants.EnglishCultureInfo, format, args));
        }
    }
}