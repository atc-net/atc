// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    /// Extensions for the <see cref="bool"/> class.
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        /// Determines whether the specified a is equal.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        ///   <c>true</c> if the specified a is equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEqual(this bool? a, bool? b)
        {
            if (a == null || b == null)
            {
                return a == null && b == null;
            }

            return a == b;
        }

        /// <summary>
        /// Converts the string representation of a number to an integer.
        /// </summary>
        /// <param name="source">if set to <c>true</c> [source].</param>
        public static int ToInt(this bool source)
        {
            return source ? 1 : 0;
        }

        /// <summary>
        /// Converts the string representation of a number to an integer.
        /// </summary>
        /// <param name="source">The source.</param>
        public static int ToInt(this bool? source)
        {
            return source?.ToInt() ?? 0;
        }
    }
}