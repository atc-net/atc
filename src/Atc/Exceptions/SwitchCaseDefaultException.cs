using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Atc.Helpers;

// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    /// The exception.
    /// </summary>
    [Serializable]
    public class SwitchCaseDefaultException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchCaseDefaultException"/> class.
        /// </summary>
        public SwitchCaseDefaultException()
            : base("Unexpected value.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchCaseDefaultException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public SwitchCaseDefaultException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchCaseDefaultException"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        [SuppressMessage("Major Code Smell", "S5766:Deserializing objects without performing data validation is security-sensitive", Justification = "OK.")]
        public SwitchCaseDefaultException(Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            ReflectionHelper.SetPrivateField(this, "_message", $"Unexpected value.{Environment.NewLine}Enum name: {value.GetType().FullName}{Environment.NewLine}Enum value: {value}");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchCaseDefaultException"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="message">The message.</param>
        [SuppressMessage("Major Code Smell", "S5766:Deserializing objects without performing data validation is security-sensitive", Justification = "OK.")]
        public SwitchCaseDefaultException(Enum value, string message)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            ReflectionHelper.SetPrivateField(this, "_message", $"{message}{Environment.NewLine}Enum name: {value.GetType().FullName}{Environment.NewLine}Enum value: {value}");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchCaseDefaultException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public SwitchCaseDefaultException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected SwitchCaseDefaultException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base("Unexpected value.")
        {
        }
    }
}