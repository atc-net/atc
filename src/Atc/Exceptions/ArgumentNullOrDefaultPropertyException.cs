using System.Diagnostics.CodeAnalysis;

// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    /// ArgumentNullOrDefaultPropertyException.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification = "Reviewed.")]
    [SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable", Justification = "Reviewed.")]
    [SuppressMessage("Microsoft.Usage", "CA2240:ImplementISerializableCorrectly", Justification = "Reviewed.")]
    public sealed class ArgumentNullOrDefaultPropertyException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentNullOrDefaultPropertyException"/> class.
        /// </summary>
        public ArgumentNullOrDefaultPropertyException()
            : base("Value cannot be null or default.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentNullOrDefaultPropertyException"/> class.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "param", Justification = "Reviewed.")]
        public ArgumentNullOrDefaultPropertyException(string paramName)
            : base("Value cannot be null or default.", paramName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentNullOrDefaultPropertyException"/> class.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">The message.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "param", Justification = "Reviewed.")]
        public ArgumentNullOrDefaultPropertyException(string paramName, string message)
            : base(message, paramName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentNullOrDefaultPropertyException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ArgumentNullOrDefaultPropertyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}