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
            var values = Enum.GetNames(typeof(CasingStyle))
                .Where(enumValue => !string.Equals(enumValue, CasingStyle.None.ToString(), StringComparison.Ordinal))
                .Select(enumValue => enumValue.Equals(Default.ToString(), StringComparison.Ordinal)
                    ? $"{enumValue} (default)"
                    : enumValue)
                .ToList();

            return string.IsNullOrEmpty(Prefix)
                ? $"Valid values are: {string.Join(", ", values)}"
                : $"{Prefix}. Valid values are: {string.Join(", ", values)}".Replace("..", ".", StringComparison.Ordinal);
        }
    }
}