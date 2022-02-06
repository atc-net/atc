// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// ArticleNumberType.
/// </summary>
public enum ArticleNumberType
{
    /// <summary>
    /// Default Unknown.
    /// </summary>
    Unknown,

    /// <summary>
    /// Amazon Standard Identification Number
    /// </summary>
    ASIN,

    /// <summary>
    /// European Article Number
    /// </summary>
    EAN8,

    /// <summary>
    /// European Article Number
    /// </summary>
    EAN13,

    /// <summary>
    /// Global Trade Item Number (previously EAN - European Article Number)
    /// </summary>
    // ReSharper disable once IdentifierTypo
    GTIN,

    /// <summary>
    /// International Standard Book Number
    /// </summary>
    ISBN10,

    /// <summary>
    /// International Standard Book Number
    /// </summary>
    ISBN13,

    /// <summary>
    /// Stock keeping unit
    /// </summary>
    SKU,

    /// <summary>
    /// Universal Product Code
    /// </summary>
    UPC,

    /// <summary>
    /// International Standard Serial Number
    /// </summary>
    ISSN,
}