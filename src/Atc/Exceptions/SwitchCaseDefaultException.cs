// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// The exception that is thrown when an unexpected value is encountered in a switch statement's default case.
/// </summary>
/// <remarks>
/// This exception is typically used to handle unexpected enum values or cases that should not occur in a switch statement.
/// It provides specialized constructors for enum values that automatically format detailed error messages.
/// </remarks>
/// <seealso cref="Exception" />
[Serializable]
public class SwitchCaseDefaultException : Exception
{
    private const string ExceptionMessage = "Unexpected value.";

    /// <summary>
    /// Initializes a new instance of the <see cref="SwitchCaseDefaultException"/> class with a default error message.
    /// </summary>
    public SwitchCaseDefaultException()
        : base(ExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SwitchCaseDefaultException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public SwitchCaseDefaultException(
        string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SwitchCaseDefaultException"/> class with an enum value.
    /// </summary>
    /// <param name="value">The unexpected enum value that was encountered.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
    [SuppressMessage("Major Code Smell", "S5766:Deserializing objects without performing data validation is security-sensitive", Justification = "OK.")]
    public SwitchCaseDefaultException(
        Enum value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        ReflectionHelper.SetPrivateField(this, "_message", $"Unexpected value.{Environment.NewLine}Enum name: {value.GetType().FullName}{Environment.NewLine}Enum value: {value}");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SwitchCaseDefaultException"/> class with an enum value and a custom error message.
    /// </summary>
    /// <param name="value">The unexpected enum value that was encountered.</param>
    /// <param name="message">The custom error message that describes the error.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> or <paramref name="message"/> is null.</exception>
    [SuppressMessage("Major Code Smell", "S5766:Deserializing objects without performing data validation is security-sensitive", Justification = "OK.")]
    public SwitchCaseDefaultException(
        Enum value,
        string message)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (message is null)
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
    public SwitchCaseDefaultException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SwitchCaseDefaultException"/> class with serialized data.
    /// </summary>
    /// <param name="serializationInfo">The serialization information.</param>
    /// <param name="streamingContext">The streaming context.</param>
    protected SwitchCaseDefaultException(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(ExceptionMessage)
    {
    }
}