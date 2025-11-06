namespace Atc.CodeDocumentation;

/// <summary>
/// Represents the different types of members that can be documented in XML documentation comments.
/// Each value corresponds to the member type prefix used in XML documentation names.
/// </summary>
public enum MemberType
{
    /// <summary>
    /// Represents no member type.
    /// </summary>
    None = 0,

    /// <summary>
    /// Represents a field member (F: prefix in XML documentation).
    /// </summary>
    Field = 'F',

    /// <summary>
    /// Represents a property member (P: prefix in XML documentation).
    /// </summary>
    Property = 'P',

    /// <summary>
    /// Represents a type member such as a class, struct, interface, or enum (T: prefix in XML documentation).
    /// </summary>
    Type = 'T',

    /// <summary>
    /// Represents an event member (E: prefix in XML documentation).
    /// </summary>
    Event = 'E',

    /// <summary>
    /// Represents a method member (M: prefix in XML documentation).
    /// </summary>
    Method = 'M',
}