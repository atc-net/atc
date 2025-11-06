// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Defines the type of placeholder item to display as the first option in a dropdown list.
/// </summary>
[SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue", Justification = "OK.")]
public enum DropDownFirstItemType
{
    /// <summary>
    /// No first item placeholder specified.
    /// </summary>
    [EnumGuid("48D811F1-B118-4D3E-A1ED-8B2D0D40FB50")]
    [LocalizedDescription(null, typeof(EnumResources))]
    None = -1,

    /// <summary>
    /// Display a blank/empty first item in the dropdown.
    /// </summary>
    [EnumGuid("2E296A8E-DE37-4DE6-ACE6-02C63E0251B8")]
    [LocalizedDescription("", typeof(EnumResources))]
    Blank = -2,

    /// <summary>
    /// Display "Please Select" as the first item prompting user to make a selection.
    /// </summary>
    [EnumGuid("B70DA7F5-600A-46B5-8FAC-4883E550C7EB")]
    [LocalizedDescription("DropDownFirstItemTypePleaseSelect", typeof(EnumResources))]
    PleaseSelect = -3,

    /// <summary>
    /// Display "Include All" as the first item to allow selecting all options.
    /// </summary>
    [EnumGuid("1FAFFE9E-4C72-44A3-A234-B71DCBE8BAF0")]
    [LocalizedDescription("DropDownFirstItemTypeIncludeAll", typeof(EnumResources))]
    IncludeAll = -4,
}