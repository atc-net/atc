// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// CasingStyle Description Attribute.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate)]
public sealed class CasingStyleDescriptionAttribute : DescriptionAttribute
{
    /// <summary>Gets or sets the default.</summary>
    /// <value>The default.</value>
    public new CasingStyle Default { get; set; } = CasingStyle.CamelCase;

    /// <summary>Gets or sets the prefix.</summary>
    /// <value>The prefix.</value>
    public string? Prefix { get; set; }

    /// <summary>
    /// Gets the description stored in this attribute.
    /// </summary>
    /// <returns>The description stored in this attribute.</returns>
    public override string Description
    {
        get
        {
#if NETSTANDARD2_1
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