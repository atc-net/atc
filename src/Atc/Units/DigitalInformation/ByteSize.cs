namespace Atc.Units.DigitalInformation;

/// <summary>
/// Represents a size in bytes.
/// </summary>
[Serializable]
[SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "OK.")]
public struct ByteSize : IEquatable<ByteSize>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ByteSize"/> struct.
    /// </summary>
    /// <param name="value">The size in bytes.</param>
    public ByteSize(long value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Gets the size in bytes.
    /// </summary>
    /// <value>
    /// The size in bytes.
    /// </value>
    public long Value { get; }

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="byteSize1">The byteSize1.</param>
    /// <param name="byteSize2">The byteSize2.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator ==(ByteSize byteSize1, ByteSize byteSize2)
    {
        return byteSize1.Equals(byteSize2);
    }

    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="byteSize1">The byteSize1.</param>
    /// <param name="byteSize2">The byteSize2.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator !=(ByteSize byteSize1, ByteSize byteSize2)
    {
        return !(byteSize1 == byteSize2);
    }

    /// <summary>
    /// Performs an implicit conversion from <see cref="byte"/> to <see cref="ByteSize"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator ByteSize(byte value) => new(value);

    /// <summary>
    /// Performs an implicit conversion from <see cref="sbyte"/> to <see cref="ByteSize"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator ByteSize(sbyte value) => new(value);

    /// <summary>
    /// Performs an implicit conversion from <see cref="decimal"/> to <see cref="ByteSize"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator ByteSize(decimal value) => new((long)value);

    /// <summary>
    /// Performs an implicit conversion from <see cref="double"/> to <see cref="ByteSize"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator ByteSize(double value) => new(checked((long)value));

    /// <summary>
    /// Performs an implicit conversion from <see cref="float"/> to <see cref="ByteSize"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator ByteSize(float value) => new(checked((long)value));

    /// <summary>
    /// Performs an implicit conversion from <see cref="int"/> to <see cref="ByteSize"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator ByteSize(int value) => new(value);

    /// <summary>
    /// Performs an implicit conversion from <see cref="uint"/> to <see cref="ByteSize"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator ByteSize(uint value) => new(value);

    /// <summary>
    /// Performs an implicit conversion from <see cref="long"/> to <see cref="ByteSize"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator ByteSize(long value) => new(value);

    /// <summary>
    /// Performs an implicit conversion from <see cref="ulong"/> to <see cref="ByteSize"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator ByteSize(ulong value) => new(checked((long)value));

    /// <summary>
    /// Performs an implicit conversion from <see cref="short"/> to <see cref="ByteSize"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator ByteSize(short value) => new(value);

    /// <summary>
    /// Performs an implicit conversion from <see cref="ushort"/> to <see cref="ByteSize"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator ByteSize(ushort value) => new(value);

    /// <summary>
    /// Equals the specified other.
    /// </summary>
    /// <param name="other">The other.</param>
    public readonly bool Equals(ByteSize other) => this.Value == other.Value;

    /// <inheritdoc />
    public override readonly bool Equals(object obj) => obj is ByteSize x && this.Equals(x);

    /// <inheritdoc />
    public override readonly int GetHashCode() => base.GetHashCode();

    /// <summary>
    /// Returns a <see cref="string" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    /// <remarks>
    /// The size is formatted to a human readable format using the default formatter (<see cref="ByteSizeFormatter.Default"/>).
    /// </remarks>
    public override readonly string ToString() => ByteSizeFormatter.Default.Format(Value);

    /// <summary>
    /// Returns a <see cref="string" /> that represents this instance, using the specified formatter.
    /// </summary>
    /// <param name="formatter">The formatter to use.</param>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    /// <exception cref="System.ArgumentNullException"><c>formatter</c> is null.</exception>
    public readonly string ToString(ByteSizeFormatter formatter) => Format(formatter);

    /// <summary>
    /// Returns a <see cref="string" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    /// <remarks>
    /// The size is formatted to a human readable format using the default formatter (<see cref="ByteSizeFormatter.Default"/>).
    /// </remarks>
    public readonly string Format() => ByteSizeFormatter.Default.Format(Value);

    /// <summary>
    /// Returns a <see cref="string" /> that represents this instance, using the specified formatter.
    /// </summary>
    /// <param name="formatter">The formatter to use.</param>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    /// <exception cref="System.ArgumentNullException"><c>formatter</c> is null.</exception>
    public readonly string Format(ByteSizeFormatter formatter)
    {
        if (formatter is null)
        {
            throw new ArgumentNullException(nameof(formatter));
        }

        return formatter.Format(Value);
    }
}