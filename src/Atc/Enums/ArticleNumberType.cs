// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents different types of product identification numbers and barcodes used in commerce.
/// </summary>
public enum ArticleNumberType
{
    /// <summary>
    /// Unknown or unspecified article number type.
    /// </summary>
    Unknown,

    /// <summary>
    /// Amazon Standard Identification Number - a 10-character alphanumeric unique identifier assigned by Amazon.
    /// </summary>
    ASIN,

    /// <summary>
    /// European Article Number - 8-digit barcode standard for product identification.
    /// </summary>
    EAN8,

    /// <summary>
    /// European Article Number - 13-digit barcode standard for product identification.
    /// </summary>
    EAN13,

    /// <summary>
    /// Global Trade Item Number - international product identification standard (formerly EAN/UPC).
    /// </summary>
    // ReSharper disable once IdentifierTypo
    GTIN,

    /// <summary>
    /// International Standard Book Number - 10-digit unique identifier for books (legacy format).
    /// </summary>
    ISBN10,

    /// <summary>
    /// International Standard Book Number - 13-digit unique identifier for books (current format).
    /// </summary>
    ISBN13,

    /// <summary>
    /// Stock Keeping Unit - internal product identification number used for inventory management.
    /// </summary>
    SKU,

    /// <summary>
    /// Universal Product Code - 12-digit barcode standard primarily used in North America.
    /// </summary>
    UPC,

    /// <summary>
    /// International Standard Serial Number - 8-digit identifier for periodical publications.
    /// </summary>
    ISSN,
}