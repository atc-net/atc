// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Provides a description attribute that retrieves localized text from resource files based on the current UI culture.
/// This attribute extends <see cref="DescriptionAttribute"/> to support internationalization.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate)]
public sealed class LocalizedDescriptionAttribute : DescriptionAttribute
{
    private readonly string? resourceKey;

    private readonly ResourceManager resource;

    /// <summary>
    /// Initializes a new instance of the <see cref="LocalizedDescriptionAttribute"/> class.
    /// </summary>
    /// <param name="resourceKey">The resource key used to retrieve the localized description text.</param>
    /// <param name="resourceType">The type containing the resource file with localized strings.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="resourceType"/> is null.</exception>
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
    /// Gets the localized description text based on the current UI culture.
    /// Returns an empty string if the resource key is null, empty, or the localized text cannot be found.
    /// </summary>
    public override string Description
    {
        get
        {
            if (resourceKey is null)
            {
                return string.Empty;
            }

            if (resourceKey.Length == 0)
            {
                return string.Empty;
            }

            var displayName = resource.GetString(resourceKey, CultureInfo.CurrentUICulture);
            return string.IsNullOrEmpty(displayName)
                ? string.Empty
                : displayName;
        }
    }
}