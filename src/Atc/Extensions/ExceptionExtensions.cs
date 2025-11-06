// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extension methods for the <see cref="Exception"/> class.
/// </summary>
public static class ExceptionExtensions
{
    /// <summary>
    /// Gets a formatted message from the exception, optionally including inner exception messages and exception names.
    /// </summary>
    /// <param name="exception">The exception to extract the message from.</param>
    /// <param name="includeInnerMessage">If set to <see langword="true" />, recursively includes inner exception messages separated by " # ".</param>
    /// <param name="includeExceptionName">If set to <see langword="true" />, prefixes the message with the exception type name.</param>
    /// <returns>A formatted string containing the exception message(s).</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="exception"/> is <see langword="null"/>.</exception>
    public static string GetMessage(
        this Exception exception,
        bool includeInnerMessage = false,
        bool includeExceptionName = false)
    {
        if (exception is null)
        {
            throw new ArgumentNullException(nameof(exception));
        }

        if (includeInnerMessage && exception.InnerException is not null)
        {
            return $"{GetExceptionMessageLine(exception, includeExceptionName)} # {GetMessage(exception.InnerException, true, includeExceptionName)}";
        }

        return GetExceptionMessageLine(exception, includeExceptionName);
    }

    /// <summary>
    /// Recursively traverses the inner exception chain and returns the message from the deepest inner exception.
    /// </summary>
    /// <param name="exception">The exception to traverse.</param>
    /// <param name="includeExceptionName">If set to <see langword="true" />, prefixes the message with the exception type name.</param>
    /// <returns>The message from the deepest inner exception, or the current exception's message if no inner exceptions exist.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="exception"/> is <see langword="null"/>.</exception>
    public static string GetLastInnerMessage(
        this Exception exception,
        bool includeExceptionName = false)
    {
        if (exception is null)
        {
            throw new ArgumentNullException(nameof(exception));
        }

        if (exception.InnerException is not null && !string.IsNullOrEmpty(exception.InnerException.Message))
        {
            // ReSharper disable once TailRecursiveCall
            return GetLastInnerMessage(exception.InnerException, includeExceptionName);
        }

        return includeExceptionName
            ? GetExceptionShortName(exception)
            : exception.Message;
    }

    /// <summary>
    /// Flattens the specified exception and inner exception data.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="message">The message.</param>
    /// <param name="includeStackTrace">if set to <see langword="true" /> include stack trace.</param>
    /// <returns>The flatten message.</returns>
    public static string Flatten(
        this Exception exception,
        string message = "",
        bool includeStackTrace = false)
    {
        if (exception is null)
        {
            throw new ArgumentNullException(nameof(exception));
        }

        var sb = new StringBuilder();
        if (!string.IsNullOrEmpty(message))
        {
            sb.AppendLine(message);
        }

        var currentException = exception;
        while (currentException is not null)
        {
            sb.AppendLine(currentException.Message);
            if (includeStackTrace && exception.StackTrace is not null)
            {
                sb.Append(exception.StackTrace);
            }

            currentException = currentException.InnerException;
            if (includeStackTrace && exception.StackTrace is not null)
            {
                sb.AppendLine();
            }
        }

        return sb.ToString();
    }

    /// <summary>
    /// Converts the exception and all its inner exceptions to an XML document representation.
    /// </summary>
    /// <param name="exception">The exception to convert.</param>
    /// <returns>An <see cref="XDocument"/> containing the exception's message, stack trace, data, and inner exceptions in XML format.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="exception"/> is <see langword="null"/>.</exception>
    public static XDocument ToXml(this Exception exception)
    {
        if (exception is null)
        {
            throw new ArgumentNullException(nameof(exception));
        }

        var root = new XElement(exception.GetType().ToString());

        if (!string.IsNullOrEmpty(exception.Message))
        {
            root.Add(new XElement("Message", exception.Message));
        }

        if (exception.StackTrace is not null)
        {
            var xElements = from frame
                    in exception.StackTrace.Split('\n')
                let prettierFrame = frame.Substring(6).Trim()
                select new XElement("Frame", prettierFrame);
            root.Add(new XElement("StackTrace", xElements));
        }

        if (exception.Data.Count > 0)
        {
            var xElements = from entry
                    in exception.Data.Cast<DictionaryEntry>()
                let key = entry.Key.ToString()
                let value = entry.Value?.ToString() ?? "null"
                select new XElement(key, value);
            root.Add(new XElement("Data", xElements));
        }

        // ReSharper disable once InvertIf
        if (exception.InnerException is not null)
        {
            var xDocument = exception.InnerException.ToXml();
            root.Add(xDocument.Root);
        }

        return new XDocument(root);
    }

    private static string GetExceptionMessageLine(
        Exception exception,
        bool includeExceptionName)
    {
        var msg = exception.Message.Replace(Environment.NewLine, "; ", StringComparison.Ordinal);

        return includeExceptionName
            ? GetExceptionShortName(exception)
            : msg;
    }

    private static string GetExceptionShortName(Exception exception)
    {
        var exceptionName = exception.GetType().Name;
        return exceptionName.Equals("Exception", StringComparison.Ordinal)
            ? $"{exception.GetType().Name}: {exception.Message}"
            : $"{exception.GetType().Name.Replace("Exception", string.Empty, StringComparison.Ordinal)}: {exception.Message}";
    }
}