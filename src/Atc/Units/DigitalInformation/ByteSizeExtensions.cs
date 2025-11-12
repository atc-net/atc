// ReSharper disable once CheckNamespace
namespace System;

public static class ByteSizeExtensions
{
    /// <summary>
    /// Returns an instance of <see cref="ByteSize"/> that represents the specified size.
    /// </summary>
    /// <param name="value">The size in bytes.</param>
    /// <returns>An instance of <see cref="ByteSize"/> that represents the specified size.</returns>
    public static ByteSize Bytes(this decimal value)
        => value;

    /// <summary>
    /// Returns an instance of <see cref="ByteSize"/> that represents the specified size.
    /// </summary>
    /// <param name="value">The size in bytes.</param>
    /// <returns>An instance of <see cref="ByteSize"/> that represents the specified size.</returns>
    public static ByteSize Bytes(this double value)
        => value;

    /// <summary>
    /// Returns an instance of <see cref="ByteSize"/> that represents the specified size.
    /// </summary>
    /// <param name="value">The size in bytes.</param>
    /// <returns>An instance of <see cref="ByteSize"/> that represents the specified size.</returns>
    public static ByteSize Bytes(this float value)
        => value;

    /// <summary>
    /// Returns an instance of <see cref="ByteSize"/> that represents the specified size.
    /// </summary>
    /// <param name="value">The size in bytes.</param>
    /// <returns>An instance of <see cref="ByteSize"/> that represents the specified size.</returns>
    public static ByteSize Bytes(this int value)
        => value;

    /// <summary>
    /// Returns an instance of <see cref="ByteSize"/> that represents the specified size.
    /// </summary>
    /// <param name="value">The size in bytes.</param>
    /// <returns>An instance of <see cref="ByteSize"/> that represents the specified size.</returns>
    public static ByteSize Bytes(this uint value)
        => value;

    /// <summary>
    /// Returns an instance of <see cref="ByteSize"/> that represents the specified size.
    /// </summary>
    /// <param name="value">The size in bytes.</param>
    /// <returns>An instance of <see cref="ByteSize"/> that represents the specified size.</returns>
    public static ByteSize Bytes(this long value)
        => value;

    /// <summary>
    /// Returns an instance of <see cref="ByteSize"/> that represents the specified size.
    /// </summary>
    /// <param name="value">The size in bytes.</param>
    /// <returns>An instance of <see cref="ByteSize"/> that represents the specified size.</returns>
    public static ByteSize Bytes(this ulong value)
        => value;
}