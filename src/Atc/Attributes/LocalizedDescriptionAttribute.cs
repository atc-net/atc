// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Localized Description Attribute.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate)]
public sealed class LocalizedDescriptionAttribute : DescriptionAttribute
{
    private readonly string? resourceKey;

    private readonly ResourceManager resource;

    /// <summary>
    /// Initializes a new instance of the <see cref="LocalizedDescriptionAttribute"/> class.
    /// </summary>
    /// <param name="resourceKey">The resource key.</param>
    /// <param name="resourceType">Type of the resource.</param>
    [SuppressMessage("Design", "CA1019:Define accessors for attribute arguments", Justification = "OK.")]
    public LocalizedDescriptionAttribute(string? resourceKey, Type resourceType)
    {
        if (resourceType is null)
        {
            throw new ArgumentNullException(nameof(resourceType));
        }

        resource = new ResourceManager(resourceType);
        this.resourceKey = resourceKey;
    }

    /// <summary>
    /// Gets the description stored in this attribute.
    /// </summary>
    /// <returns>The description stored in this attribute.</returns>
    public override string? Description
    {
        get
        {
            if (resourceKey is null)
            {
                return null;
            }

            if (resourceKey.Length == default)
            {
                return string.Empty;
            }

            var displayName = resource.GetString(resourceKey, CultureInfo.CurrentUICulture);
            return string.IsNullOrEmpty(displayName)
                ? null
                : displayName;
        }
    }
}