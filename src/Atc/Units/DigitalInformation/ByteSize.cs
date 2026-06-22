namespace Atc.Units.DigitalInformation;

/// <summary>
/// Represents a size in bytes.
/// </summary>
[Serializable]
[SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "OK.")]
public struct ByteSize : IEquatable<ByteSize>, IComparable<ByteSize>, IComparable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ByteSize"/> struct.
    /// </summary>
    /// <param name="value">The size in bytes.</param>
    public ByteSize(long value)
    {
        Value = value;
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
    public static bool operator ==(
        ByteSize byteSize1,
        ByteSize byteSize2)
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
    public static bool operator !=(
        ByteSize byteSize1,
        ByteSize byteSize2)
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
    /// Implements the less-than operator.
    /// </summary>
    /// <param name="a">Left operand.</param>
    /// <param name="b">Right operand.</param>
    /// <returns><see langword="true"/> if <paramref name="a"/> is less than <paramref name="b"/>.</returns>
    public static bool operator <(
        ByteSize a,
        ByteSize b)
        => a.Value < b.Value;

    /// <summary>
    /// Implements the less-than-or-equal operator.
    /// </summary>
    /// <param name="a">Left operand.</param>
    /// <param name="b">Right operand.</param>
    /// <returns><see langword="true"/> if <paramref name="a"/> is less than or equal to <paramref name="b"/>.</returns>
    public static bool operator <=(
        ByteSize a,
        ByteSize b)
        => a.Value <= b.Value;

    /// <summary>
    /// Implements the greater-than operator.
    /// </summary>
    /// <param name="a">Left operand.</param>
    /// <param name="b">Right operand.</param>
    /// <returns><see langword="true"/> if <paramref name="a"/> is greater than <paramref name="b"/>.</returns>
    public static bool operator >(
        ByteSize a,
        ByteSize b)
        => a.Value > b.Value;

    /// <summary>
    /// Implements the greater-than-or-equal operator.
    /// </summary>
    /// <param name="a">Left operand.</param>
    /// <param name="b">Right operand.</param>
    /// <returns><see langword="true"/> if <paramref name="a"/> is greater than or equal to <paramref name="b"/>.</returns>
    public static bool operator >=(
        ByteSize a,
        ByteSize b)
        => a.Value >= b.Value;

    /// <summary>
    /// Adds two <see cref="ByteSize"/> values.
    /// </summary>
    /// <param name="a">Left operand.</param>
    /// <param name="b">Right operand.</param>
    /// <returns>The sum of <paramref name="a"/> and <paramref name="b"/>.</returns>
    public static ByteSize operator +(
        ByteSize a,
        ByteSize b)
        => new(a.Value + b.Value);

    /// <summary>
    /// Subtracts one <see cref="ByteSize"/> value from another.
    /// </summary>
    /// <param name="a">Left operand.</param>
    /// <param name="b">Right operand.</param>
    /// <returns>The difference between <paramref name="a"/> and <paramref name="b"/>.</returns>
    public static ByteSize operator -(
        ByteSize a,
        ByteSize b)
        => new(a.Value - b.Value);

    /// <summary>
    /// Parses a string of digits into a <see cref="ByteSize"/>.
    /// </summary>
    /// <param name="value">The string to parse. Must represent a valid <see cref="long"/> value.</param>
    /// <returns>A <see cref="ByteSize"/> with the parsed byte count.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
    /// <exception cref="FormatException">Thrown when <paramref name="value"/> is not a valid integer.</exception>
    public static ByteSize Parse(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (long.TryParse(
                value.Trim(),
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out var longValue))
        {
            return new ByteSize(longValue);
        }

        throw new FormatException(
            $"The value '{value}' is not a valid byte size.");
    }

    /// <summary>
    /// Tries to parse a string into a <see cref="ByteSize"/>.
    /// </summary>
    /// <param name="value">The string to parse, or <see langword="null"/>.</param>
    /// <param name="result">
    /// When this method returns, contains the parsed <see cref="ByteSize"/>
    /// if parsing succeeded; otherwise, <see langword="default"/>.
    /// </param>
    /// <returns><see langword="true"/> if parsing succeeded; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse(
        string? value,
        out ByteSize result)
    {
        result = default;
        if (value is null)
        {
            return false;
        }

        if (long.TryParse(
                value.Trim(),
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out var longValue))
        {
            result = new ByteSize(longValue);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Equals the specified other.
    /// </summary>
    /// <param name="other">The other.</param>
    public readonly bool Equals(ByteSize other) => Value == other.Value;

    /// <inheritdoc />
    public override readonly bool Equals(object? obj)
        => obj is ByteSize x && Equals(x);

    /// <inheritdoc />
    public override readonly int GetHashCode() => Value.GetHashCode();

    /// <summary>
    /// Compares this instance to another <see cref="ByteSize"/> value.
    /// </summary>
    /// <param name="other">The other value to compare to.</param>
    /// <returns>
    /// A negative number if this instance is less than <paramref name="other"/>;
    /// zero if they are equal; a positive number if this instance is greater.
    /// </returns>
    public readonly int CompareTo(ByteSize other)
        => Value.CompareTo(other.Value);

    /// <summary>
    /// Compares this instance to another object.
    /// </summary>
    /// <param name="obj">An object to compare to, or <see langword="null"/>.</param>
    /// <returns>
    /// A negative number if this instance is less than <paramref name="obj"/>;
    /// zero if they are equal; a positive number if this instance is greater.
    /// </returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="obj"/> is not a <see cref="ByteSize"/>.</exception>
    public readonly int CompareTo(object? obj)
    {
        if (obj is null)
        {
            return 1;
        }

        if (obj is ByteSize other)
        {
            return CompareTo(other);
        }

        throw new ArgumentException(
            "Object must be of type ByteSize.",
            nameof(obj));
    }

    /// <summary>
    /// Returns a <see cref="string" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    /// <remarks>
    /// The size is formatted to a human readable format using the default formatter (<see cref="ByteSizeFormatter.Default"/>).
    /// </remarks>
    public override readonly string ToString()
        => ByteSizeFormatter.Default.Format(Value);

    /// <summary>
    /// Returns a <see cref="string" /> that represents this instance, using the specified formatter.
    /// </summary>
    /// <param name="formatter">The formatter to use.</param>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    /// <exception cref="System.ArgumentNullException"><c>formatter</c> is null.</exception>
    public readonly string ToString(ByteSizeFormatter formatter)
        => Format(formatter);

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