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
    public SwitchCaseDefaultException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SwitchCaseDefaultException"/> class with an enum value.
    /// </summary>
    /// <param name="value">The unexpected enum value that was encountered.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
    public SwitchCaseDefaultException(Enum value)
        : base(BuildMessage(value))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SwitchCaseDefaultException"/> class with an enum value and a custom error message.
    /// </summary>
    /// <param name="value">The unexpected enum value that was encountered.</param>
    /// <param name="message">The custom error message that describes the error.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> or <paramref name="message"/> is null.</exception>
    public SwitchCaseDefaultException(
        Enum value,
        string message)
        : base(BuildMessage(value, message))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SwitchCaseDefaultException"/> class with any non-enum value.
    /// </summary>
    /// <param name="value">
    /// The unexpected value that was encountered. Accepts any type, including <see langword="null"/>.
    /// </param>
    public SwitchCaseDefaultException(object? value)
        : base(BuildMessageForObject(value))
    {
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
    /// Throws a <see cref="SwitchCaseDefaultException"/> for the given enum value.
    /// </summary>
    /// <param name="value">The unexpected enum value encountered in the switch default case.</param>
    [DoesNotReturn]
    public static void Throw(Enum value)
        => throw new SwitchCaseDefaultException(value);

    /// <summary>
    /// Throws a <see cref="SwitchCaseDefaultException"/> for the given value.
    /// </summary>
    /// <param name="value">The unexpected value encountered in the switch default case.</param>
    [DoesNotReturn]
    public static void Throw(object? value)
        => throw new SwitchCaseDefaultException(value);

    /// <summary>
    /// Initializes a new instance of the <see cref="SwitchCaseDefaultException"/> class with serialized data.
    /// </summary>
    /// <param name="serializationInfo">The serialization information.</param>
    /// <param name="streamingContext">The streaming context.</param>
    protected SwitchCaseDefaultException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
#if NETSTANDARD2_0
        : base(serializationInfo, streamingContext)
#else
        : base(ExceptionMessage)
#endif
    {
    }

    private static string BuildMessage(Enum value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return $"Unexpected value.{Environment.NewLine}Enum name: {value.GetType().FullName}{Environment.NewLine}Enum value: {value}";
    }

    private static string BuildMessage(
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

        return $"{message}{Environment.NewLine}Enum name: {value.GetType().FullName}{Environment.NewLine}Enum value: {value}";
    }

    private static string BuildMessageForObject(object? value)
        => value is null
            ? $"Unexpected value.{Environment.NewLine}Value: <null>"
            : $"Unexpected value.{Environment.NewLine}Type: {value.GetType().FullName}{Environment.NewLine}Value: {value}";
}