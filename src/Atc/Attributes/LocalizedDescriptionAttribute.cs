using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;

// ReSharper disable once CheckNamespace
namespace Atc
{
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
        public LocalizedDescriptionAttribute(string? resourceKey, Type resourceType)
        {
            if (resourceType == null)
            {
                throw new ArgumentNullException(nameof(resourceType));
            }

            this.resource = new ResourceManager(resourceType);
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
                if (this.resourceKey == null)
                {
                    return null;
                }

                if (this.resourceKey.Length == 0)
                {
                    return string.Empty;
                }

                string? displayName = this.resource.GetString(this.resourceKey, CultureInfo.CurrentUICulture);
                return string.IsNullOrEmpty(displayName)
                    ? null
                    : displayName;
            }
        }
    }
}