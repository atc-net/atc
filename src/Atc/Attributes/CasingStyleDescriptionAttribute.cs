// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Provides a description attribute that generates documentation text listing valid <see cref="CasingStyle"/> values.
/// This attribute is useful for documenting properties that accept casing style values, showing all valid options with the default highlighted.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate)]
public sealed class CasingStyleDescriptionAttribute : DescriptionAttribute
{
    /// <summary>
    /// Gets or sets the default casing style to be indicated in the generated description.
    /// The default value is <see cref="CasingStyle.CamelCase"/>.
    /// </summary>
    public new CasingStyle Default { get; set; } = CasingStyle.CamelCase;

    /// <summary>
    /// Gets or sets an optional prefix to prepend to the generated description text.
    /// </summary>
    public string? Prefix { get; set; }

    /// <summary>
    /// Gets the generated description listing all valid <see cref="CasingStyle"/> values (excluding None) with the default value marked.
    /// If a prefix is set, it will be prepended to the description.
    /// </summary>
    public override string Description
    {
        get
        {
#if NETSTANDARD2_0 || NETSTANDARD2_1
            var enumNames = Enum.GetNames(typeof(CasingStyle));
#else
            var enumNames = Enum.GetNames<CasingStyle>();
#endif

            var values = string.Join(
                ", ",
                enumNames
                    .Where(enumValue => !string.Equals(enumValue, nameof(CasingStyle.None), StringComparison.Ordinal))
                    .Select(enumValue => enumValue.Equals(Default.ToString(), StringComparison.Ordinal)
                        ? $"{enumValue} (default)"
                        : enumValue));

            if (string.IsNullOrEmpty(Prefix))
            {
                return $"Valid values are: {values}";
            }

            var sb = new StringBuilder(Prefix)
                .Append(". Valid values are: ")
                .Append(values);

            return sb
                .ToString()
                .Replace("..", ".", StringComparison.Ordinal);
        }
    }
}