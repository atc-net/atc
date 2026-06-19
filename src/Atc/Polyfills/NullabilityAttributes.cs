#if NETSTANDARD2_0
#pragma warning disable MA0048 // File name must match type name
#pragma warning disable SA1649 // File name should match first type name
#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable ATC202 // Multi parameters should be broken down to separate lines
#pragma warning disable CA1019 // Add a public read-only property accessor for positional argument member of Attribute

namespace System.Diagnostics.CodeAnalysis;

/// <summary>
/// Specifies that the method or property will ensure that the listed field and property members have not-null values when returning with the specified return value condition.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
internal sealed class MemberNotNullWhenAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MemberNotNullWhenAttribute"/> class with the specified return value condition and a field or property member.
    /// </summary>
    /// <param name="returnValue">
    /// The return value condition. If the method returns this value, the associated parameter will not be null.
    /// </param>
    /// <param name="member">
    /// The field or property member that is promised to be not-null.
    /// </param>
    public MemberNotNullWhenAttribute(bool returnValue, string member)
    {
        ReturnValue = returnValue;
        Members = new[] { member };
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MemberNotNullWhenAttribute"/> class with the specified return value condition and list of field and property members.
    /// </summary>
    /// <param name="returnValue">
    /// The return value condition. If the method returns this value, the associated parameter will not be null.
    /// </param>
    /// <param name="members">
    /// The list of field and property members that are promised to be not-null.
    /// </param>
    public MemberNotNullWhenAttribute(bool returnValue, params string[] members)
    {
        ReturnValue = returnValue;
        Members = members;
    }

    /// <summary>
    /// Gets the return value condition.
    /// </summary>
    public bool ReturnValue { get; }

    /// <summary>
    /// Gets the field or property member names.
    /// </summary>
    public string[] Members { get; }
}

/// <summary>
/// Specifies that the output will be non-null if the named parameter is non-null.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
internal sealed class NotNullWhenAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotNullWhenAttribute"/> class with the specified return value condition.
    /// </summary>
    /// <param name="returnValue">
    /// The return value condition. If the method returns this value, the associated parameter will not be null.
    /// </param>
    public NotNullWhenAttribute(bool returnValue)
    {
        ReturnValue = returnValue;
    }

    /// <summary>
    /// Gets the return value condition.
    /// </summary>
    public bool ReturnValue { get; }
}
#endif