using System;

namespace Atc.Data.Models
{
    /// <summary>
    /// KeyValueItem.
    /// </summary>
    [Serializable]
    public class KeyValueItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyValueItem"/> class.
        /// </summary>
        public KeyValueItem()
        {
            this.Key = string.Empty;
            this.Value = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyValueItem"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public KeyValueItem(string key, string value)
        {
            this.Key = key ?? throw new ArgumentNullException(nameof(key));
            this.Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{nameof(this.Key)}: {this.Key}, {nameof(this.Value)}: {this.Value}";
        }
    }
}