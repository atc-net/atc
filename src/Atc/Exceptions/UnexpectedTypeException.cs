// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// The exception that is thrown when actual type differs from expected type.
/// </summary>
/// <seealso cref="Exception" />
[Serializable]
public class UnexpectedTypeException : Exception
{
    private const string ExceptionMessage = "Unexpected type.";

    /// <summary>
    /// Initializes a new instance of the <see cref="UnexpectedTypeException"/> class.
    /// </summary>
    public UnexpectedTypeException()
        : base(ExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnexpectedTypeException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public UnexpectedTypeException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnexpectedTypeException"/> class.
    /// </summary>
    /// <param name="actualType">The actual type.</param>
    /// <param name="expectedType">The expected type.</param>
    [SuppressMessage("Major Code Smell", "S5766:Deserializing objects without performing data validation is security-sensitive", Justification = "OK.")]
    public UnexpectedTypeException(
        Type actualType,
        Type expectedType)
    {
        if (actualType is null)
        {
            throw new ArgumentNullException(nameof(actualType));
        }

        if (expectedType is null)
        {
            throw new ArgumentNullException(nameof(expectedType));
        }

        var actualTypeName = actualType.FullName!;
        if (actualType.IsSimple())
        {
            actualTypeName = actualType.BeautifyTypeName();
        }

        var expectedTypeName = expectedType.FullName!;
        if (actualType.IsSimple())
        {
            expectedTypeName = expectedType.BeautifyTypeName();
        }

        ReflectionHelper.SetPrivateField(this, "_message", $"Unexpected type.{Environment.NewLine}ActualType name: {actualTypeName}{Environment.NewLine}ExpectedType name: {expectedTypeName}");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnexpectedTypeException"/> class.
    /// </summary>
    /// <param name="actualType">The actual type.</param>
    /// <param name="expectedType">The expected type.</param>
    /// <param name="message">The message.</param>
    [SuppressMessage("Major Code Smell", "S5766:Deserializing objects without performing data validation is security-sensitive", Justification = "OK.")]
    public UnexpectedTypeException(
        Type actualType,
        Type expectedType,
        string message)
    {
        if (actualType is null)
        {
            throw new ArgumentNullException(nameof(actualType));
        }

        if (expectedType is null)
        {
            throw new ArgumentNullException(nameof(expectedType));
        }

        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        var actualTypeName = actualType.FullName!;
        if (actualType.IsSimple())
        {
            actualTypeName = actualType.BeautifyTypeName();
        }

        var expectedTypeName = expectedType.FullName!;
        if (actualType.IsSimple())
        {
            expectedTypeName = expectedType.BeautifyTypeName();
        }

        ReflectionHelper.SetPrivateField(this, "_message", $"{message}{Environment.NewLine}ActualType name: {actualTypeName}{Environment.NewLine}ExpectedType name: {expectedTypeName}");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnexpectedTypeException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public UnexpectedTypeException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }

    protected UnexpectedTypeException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
        : base(ExceptionMessage)
    {
    }
}