// ReSharper disable CheckNamespace
namespace System;

/// <summary>
/// The exception that is thrown when a method or constructor meant for design-time use only is invoked at runtime.
/// </summary>
/// <remarks>
/// This exception is typically used to prevent runtime execution of design-time-only constructors in ViewModels or other components
/// that are intended for use in visual designers (e.g., WPF/XAML designers, Blazor designers).
/// </remarks>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="DesignTimeUseOnlyException"/> class with serialized data.
    /// </summary>
    /// <param name="serializationInfo">The serialization information.</param>
    /// <param name="streamingContext">The streaming context.</param>
    protected DesignTimeUseOnlyException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
        : base(ExceptionMessage)
    {
    }
}