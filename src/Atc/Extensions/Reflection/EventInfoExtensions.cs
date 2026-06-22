// ReSharper disable once CheckNamespace
namespace System.Reflection;

/// <summary>
/// Extensions for the <see cref="EventInfo"/> class.
/// </summary>
public static class EventInfoExtensions
{
    /// <summary>
    /// Returns a human-readable representation of the event, optionally including the event handler type
    /// and using full type names or HTML formatting.
    /// </summary>
    /// <param name="eventInfo">The event information.</param>
    /// <param name="useFullName">If <see langword="true"/>, the event-handler type is rendered with its fully-qualified name.</param>
    /// <param name="useHtmlFormat">If <see langword="true"/>, the event-handler type name is wrapped in HTML tags.</param>
    /// <param name="includeEventHandlerType">If <see langword="true"/>, the event-handler type is prepended to the name.</param>
    /// <returns>A string such as <c>MyEvent</c> or <c>EventHandler MyEvent</c> when <paramref name="includeEventHandlerType"/> is <see langword="true"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="eventInfo"/> is null.</exception>
    public static string BeautifyName(
        this EventInfo eventInfo,
        bool useFullName = false,
        bool useHtmlFormat = false,
        bool includeEventHandlerType = false)
    {
        ArgumentNullException.ThrowIfNull(eventInfo);

        return includeEventHandlerType && eventInfo.EventHandlerType is not null
            ? $"{eventInfo.EventHandlerType.BeautifyName(useFullName, useHtmlFormat)} {eventInfo.Name}"
            : eventInfo.Name;
    }
}