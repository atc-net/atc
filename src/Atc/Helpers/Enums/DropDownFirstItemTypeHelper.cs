using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Atc.Resources;

// ReSharper disable once CheckNamespace
namespace Atc.Helpers
{
    /// <summary>
    /// Enumeration Helper: DropDownFirstItemTypeHelper.
    /// </summary>
    public static class DropDownFirstItemTypeHelper
    {
        /// <summary>
        /// Gets the enumeration GUID.
        /// </summary>
        /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
        /// <returns>
        /// The <see cref="Guid" />.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// Enumeration ' + dropDownFirstItemType + ' has no EnumGuid defined.
        /// </exception>
        public static Guid GetEnumGuid(DropDownFirstItemType dropDownFirstItemType)
        {
            var type = dropDownFirstItemType.GetType();
            var memberInfos = type.GetMember(dropDownFirstItemType.ToString());
            if (memberInfos.Length > 0)
            {
                var attrs = memberInfos[0].GetCustomAttributes(typeof(EnumGuidAttribute), false);
                if (attrs.Length > 0)
                {
                    return ((EnumGuidAttribute)attrs[0]).GlobalIdentifier;
                }
            }

            throw new UnexpectedTypeException("Enumeration '" + dropDownFirstItemType + "' has no EnumGuid defined.");
        }

        /// <summary>
        /// Gets the item from enumeration GUID.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="DropDownFirstItemType"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// The key ' + key + ' is not defined as a DropDownFirstItemType.
        /// </exception>
        [SuppressMessage("Major Bug", "S1751:Loops with at most one iteration should be refactored", Justification = "OK.")]
        public static DropDownFirstItemType GetItemFromEnumGuid(Guid key)
        {
            foreach (var item
                in Enum.GetValues(typeof(DropDownFirstItemType))
                    .Cast<DropDownFirstItemType>()
                    .Where(item => key == GetEnumGuid(item)))
            {
                return item;
            }

            throw new ArgumentException("The key '" + key + "' is not defined as a DropDownFirstItemType.", nameof(key));
        }

        /// <summary>
        /// Ensures the first type of the item.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
        [SuppressMessage("Microsoft.Performance", "CA1820:TestForEmptyStringsUsingStringLength", Justification = "OK.")]
        public static List<string> EnsureFirstItemType(List<string> list, DropDownFirstItemType dropDownFirstItemType)
        {
            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            var s = list.FirstOrDefault(x => x.Equals("None", StringComparison.Ordinal));
            if (s is not null)
            {
                list.Remove(s);
            }

            switch (dropDownFirstItemType)
            {
                case DropDownFirstItemType.None:
                    break;
                case DropDownFirstItemType.Blank:
                    s = list.FirstOrDefault(x => x == string.Empty);
                    if (s is not null)
                    {
                        list.Remove(s);
                    }

                    list.Insert(0, string.Empty);
                    break;
                case DropDownFirstItemType.PleaseSelect:
                    s = list.FirstOrDefault(x => string.Equals(x, EnumResources.DropDownFirstItemTypePleaseSelect, StringComparison.Ordinal));
                    if (s is not null)
                    {
                        list.Remove(s);
                    }

                    list.Insert(0, EnumResources.DropDownFirstItemTypePleaseSelect);
                    break;
                case DropDownFirstItemType.IncludeAll:
                    s = list.FirstOrDefault(x => string.Equals(x, EnumResources.DropDownFirstItemTypeIncludeAll, StringComparison.Ordinal));
                    if (s is not null)
                    {
                        list.Remove(s);
                    }

                    list.Insert(0, EnumResources.DropDownFirstItemTypeIncludeAll);
                    break;
                default:
                    throw new SwitchCaseDefaultException(dropDownFirstItemType);
            }

            return list;
        }
    }
}