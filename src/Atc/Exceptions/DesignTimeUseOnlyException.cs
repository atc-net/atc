// ReSharper disable CheckNamespace
namespace System;

/// <summary>
/// The exception that is thrown when an user is not found.
/// </summary>
/// <seealso cref="Exception" />
[Serializable]
public class DesignTimeUseOnlyException : Exception
{
    private const string ExceptionMessage = "This exception is raised if a method which is only meant to be used at design time is invoked at run-time. The reason can for example be if a constructor has been provided for a ViewModel and it only should be used for design time.";

    /// <summary>
    /// Initializes a new instance of the <see cref="DesignTimeUseOnlyException"/> class.
    /// </summary>
    public DesignTimeUseOnlyException()
        : base(ExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DesignTimeUseOnlyException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public DesignTimeUseOnlyException(
        string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DesignTimeUseOnlyException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public DesignTimeUseOnlyException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }

    protected DesignTimeUseOnlyException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
        : base(ExceptionMessage)
    {
    }
}