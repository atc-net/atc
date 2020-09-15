using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Atc.Resources;

// ReSharper disable UnreachableSwitchCaseDueToIntegerAnalysis
// ReSharper disable once CheckNamespace
namespace Atc.Helpers
{
    /// <summary>
    /// Enumeration Helper: EnumHelper.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <param name="enumeration">The enumeration.</param>
        public static string GetName(Enum enumeration)
        {
            return enumeration.GetName();
        }

        /// <summary>
        /// Gets the enum value.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns>If parsed successfully and defined as a valid enum value, the enum value is returned. Otherwise the default value is returned.</returns>
        public static T GetEnumValue<T>(string value, bool ignoreCase = true) where T : Enum
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new UnexpectedTypeException($"Type {type.FullName} is not a enumerated type");
            }

            if (!Enum<T>.TryParse(value, ignoreCase, out var returnedValue))
            {
                return default!;
            }

            return (Enum.IsDefined(type, returnedValue)
                ? returnedValue
                : default)!;
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="enumeration">The enumeration.</param>
        public static string GetDescription(Enum enumeration)
        {
            return enumeration.GetDescription();
        }

        /// <summary>
        /// Gets the value from the description.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="description">The description.</param>
        /// <returns>The associated enumeration value.</returns>
        [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
        public static T GetValueFromDescription<T>(string description)
        {
            if (description == null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            if (description.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(description));
            }

            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new UnexpectedTypeException($"Type {type.FullName} is not a enumerated type");
            }

            foreach (var fieldInfo in type.GetFields())
            {
                if (fieldInfo.Name.Equals(description, StringComparison.OrdinalIgnoreCase))
                {
                    return (T)fieldInfo.GetValue(null);
                }

                var localizedDescriptionAttribute = Attribute.GetCustomAttribute(fieldInfo, typeof(LocalizedDescriptionAttribute)) as LocalizedDescriptionAttribute;
                if (localizedDescriptionAttribute?.Description != null &&
                    localizedDescriptionAttribute.Description.Equals(description, StringComparison.OrdinalIgnoreCase))
                {
                    return (T)fieldInfo.GetValue(null);
                }

                var descriptionAttributeOrg = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (descriptionAttributeOrg?.Description != null &&
                    descriptionAttributeOrg.Description.Equals(description, StringComparison.OrdinalIgnoreCase))
                {
                    return (T)fieldInfo.GetValue(null);
                }

                var displayNameAttribute = Attribute.GetCustomAttribute(fieldInfo, typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                if (displayNameAttribute?.DisplayName != null &&
                    displayNameAttribute.DisplayName.Equals(description, StringComparison.OrdinalIgnoreCase))
                {
                    return (T)fieldInfo.GetValue(null);
                }

                var displayAttribute = Attribute.GetCustomAttribute(fieldInfo, typeof(DisplayAttribute)) as DisplayAttribute;
                if (displayAttribute?.Description != null &&
                    displayAttribute.Description.Equals(description, StringComparison.OrdinalIgnoreCase))
                {
                    return (T)fieldInfo.GetValue(null);
                }
            }

            return default!;
        }

        /// <summary>
        /// Converts the enum to array.
        /// </summary>
        /// <param name="enumType">Type of the enum.</param>
        /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
        /// <param name="useDescriptionAttribute">if set to <c>true</c> [use description attribute].</param>
        /// <param name="includeDefault">if set to <c>true</c> [include default].</param>
        /// <param name="sortDirectionType">Type of the sort direction.</param>
        /// <param name="byFlagIncludeBase">if set to <c>true</c> [by flag include base].</param>
        /// <param name="byFlagIncludeCombined">if set to <c>true</c> [by flag include combined].</param>
        public static Array ConvertEnumToArray(
            Type enumType,
            DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None,
            bool useDescriptionAttribute = false,
            bool includeDefault = true,
            SortDirectionType sortDirectionType = SortDirectionType.None,
            bool byFlagIncludeBase = true,
            bool byFlagIncludeCombined = true)
        {
            var dictionary = ConvertEnumToDictionary(
                enumType,
                dropDownFirstItemType,
                useDescriptionAttribute,
                includeDefault,
                sortDirectionType,
                byFlagIncludeBase,
                byFlagIncludeCombined);

            return dictionary
                .Select(pair => pair.Value)
                .ToArray();
        }

        /// <summary>
        /// Converts the enum to dictionary.
        /// </summary>
        /// <param name="enumType">Type of the enum.</param>
        /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
        /// <param name="useDescriptionAttribute">if set to <c>true</c> [use description attribute].</param>
        /// <param name="includeDefault">if set to <c>true</c> [include default].</param>
        /// <param name="sortDirectionType">Type of the sort direction.</param>
        /// <param name="byFlagIncludeBase">if set to <c>true</c> [by flag include base].</param>
        /// <param name="byFlagIncludeCombined">if set to <c>true</c> [by flag include combined].</param>
        [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
        public static Dictionary<int, string> ConvertEnumToDictionary(
            Type enumType,
            DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None,
            bool useDescriptionAttribute = false,
            bool includeDefault = true,
            SortDirectionType sortDirectionType = SortDirectionType.None,
            bool byFlagIncludeBase = true,
            bool byFlagIncludeCombined = true)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException(nameof(enumType));
            }

            if (!enumType.IsEnum)
            {
                throw new UnexpectedTypeException($"Type {enumType.FullName} is not a enumerated type");
            }

            var list = new Dictionary<int, string>();
            var enums = Enum.GetValues(enumType);
            var hasFlagAttribute = enumType.IsDefined(typeof(FlagsAttribute), false);
            foreach (var e in enums)
            {
                var objEnumValue = e;
                if (ShouldEnumValueBeSkipped(objEnumValue, includeDefault, hasFlagAttribute, byFlagIncludeBase, byFlagIncludeCombined))
                {
                    continue;
                }

                var value = objEnumValue.ToString();
                if (useDescriptionAttribute)
                {
                    var description = ((objEnumValue as Enum)!).GetDescription();
                    if (!string.IsNullOrEmpty(description))
                    {
                        value = description;
                    }
                }

                if (dropDownFirstItemType == DropDownFirstItemType.None)
                {
                    if (!list.ContainsKey((int)objEnumValue))
                    {
                        list.Add((int)objEnumValue, value);
                    }
                }
                else if (!list.ContainsKey((int)objEnumValue))
                {
                    list.Add((int)objEnumValue, value);
                }
            }

            var orderList = sortDirectionType switch
            {
                SortDirectionType.None => list.ToList(),
                SortDirectionType.Ascending => list.OrderBy(x => x.Value).ToList(),
                SortDirectionType.Descending => list.OrderByDescending(x => x.Value).ToList(),
                _ => throw new SwitchCaseDefaultException(sortDirectionType)
            };

            if (dropDownFirstItemType == DropDownFirstItemType.None || enumType == typeof(DropDownFirstItemType))
            {
                return orderList.ToDictionary(x => x.Key, x => x.Value);
            }

            if (useDescriptionAttribute)
            {
                switch (dropDownFirstItemType)
                {
                    case DropDownFirstItemType.None:
                        break;
                    case DropDownFirstItemType.Blank:
                        orderList.Insert(0, new KeyValuePair<int, string>((int)DropDownFirstItemType.Blank, string.Empty));
                        break;
                    case DropDownFirstItemType.PleaseSelect:
                        orderList.Insert(0, new KeyValuePair<int, string>((int)DropDownFirstItemType.PleaseSelect, EnumResources.DropDownFirstItemTypePleaseSelect));
                        break;
                    case DropDownFirstItemType.IncludeAll:
                        orderList.Insert(0, new KeyValuePair<int, string>((int)DropDownFirstItemType.IncludeAll, EnumResources.DropDownFirstItemTypeIncludeAll));
                        break;
                    default:
                        throw new SwitchCaseDefaultException(dropDownFirstItemType);
                }
            }
            else
            {
                switch (dropDownFirstItemType)
                {
                    case DropDownFirstItemType.None:
                        break;
                    case DropDownFirstItemType.Blank:
                        orderList.Insert(0, new KeyValuePair<int, string>((int)DropDownFirstItemType.Blank, DropDownFirstItemType.Blank.ToString()));
                        break;
                    case DropDownFirstItemType.PleaseSelect:
                        orderList.Insert(0, new KeyValuePair<int, string>((int)DropDownFirstItemType.PleaseSelect, DropDownFirstItemType.PleaseSelect.ToString()));
                        break;
                    case DropDownFirstItemType.IncludeAll:
                        orderList.Insert(0, new KeyValuePair<int, string>((int)DropDownFirstItemType.IncludeAll, DropDownFirstItemType.IncludeAll.ToString()));
                        break;
                    default:
                        throw new SwitchCaseDefaultException(dropDownFirstItemType);
                }
            }

            return orderList.ToDictionary(x => x.Key, x => x.Value);
        }

        /// <summary>
        /// Converts the enum to dictionary with string key.
        /// </summary>
        /// <param name="enumType">Type of the enum.</param>
        /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
        /// <param name="useDescriptionAttribute">if set to <c>true</c> [use description attribute].</param>
        /// <param name="includeDefault">if set to <c>true</c> [include default].</param>
        /// <param name="sortDirectionType">Type of the sort direction.</param>
        /// <param name="byFlagIncludeBase">if set to <c>true</c> [by flag include base].</param>
        /// <param name="byFlagIncludeCombined">if set to <c>true</c> [by flag include combined].</param>
        [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
        public static Dictionary<string, string> ConvertEnumToDictionaryWithStringKey(
            Type enumType,
            DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None,
            bool useDescriptionAttribute = false,
            bool includeDefault = true,
            SortDirectionType sortDirectionType = SortDirectionType.None,
            bool byFlagIncludeBase = true,
            bool byFlagIncludeCombined = true)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException(nameof(enumType));
            }

            if (!enumType.IsEnum)
            {
                throw new UnexpectedTypeException($"Type {enumType.FullName} is not a enumerated type");
            }

            var list = new Dictionary<string, string>();
            var enums = Enum.GetValues(enumType);
            var hasFlagAttribute = enumType.IsDefined(typeof(FlagsAttribute), false);
            foreach (var e in enums)
            {
                var objEnumValue = e;
                if (ShouldEnumValueBeSkipped(objEnumValue, includeDefault, hasFlagAttribute, byFlagIncludeBase, byFlagIncludeCombined))
                {
                    continue;
                }

                var value = objEnumValue.ToString();
                if (useDescriptionAttribute)
                {
                    var description = ((objEnumValue as Enum)!).GetDescription();
                    if (!string.IsNullOrEmpty(description))
                    {
                        value = description;
                    }
                }

                if (dropDownFirstItemType == DropDownFirstItemType.None)
                {
                    if (!list.ContainsKey(objEnumValue.ToString()))
                    {
                        list.Add(objEnumValue.ToString(), value);
                    }
                }
                else if (!list.ContainsKey(objEnumValue.ToString()))
                {
                    list.Add(objEnumValue.ToString(), value);
                }
            }

            var orderList = sortDirectionType switch
            {
                SortDirectionType.None => list.ToList(),
                SortDirectionType.Ascending => list.OrderBy(x => x.Value).ToList(),
                SortDirectionType.Descending => list.OrderByDescending(x => x.Value).ToList(),
                _ => throw new SwitchCaseDefaultException(sortDirectionType)
            };

            if (dropDownFirstItemType == DropDownFirstItemType.None || enumType == typeof(DropDownFirstItemType))
            {
                return orderList.ToDictionary(x => x.Key, x => x.Value);
            }

            if (useDescriptionAttribute)
            {
                switch (dropDownFirstItemType)
                {
                    case DropDownFirstItemType.None:
                        break;
                    case DropDownFirstItemType.Blank:
                        orderList.Insert(0, new KeyValuePair<string, string>(DropDownFirstItemType.Blank.ToString(), string.Empty));
                        break;
                    case DropDownFirstItemType.PleaseSelect:
                        orderList.Insert(0, new KeyValuePair<string, string>(DropDownFirstItemType.PleaseSelect.ToString(), EnumResources.DropDownFirstItemTypePleaseSelect));
                        break;
                    case DropDownFirstItemType.IncludeAll:
                        orderList.Insert(0, new KeyValuePair<string, string>(DropDownFirstItemType.IncludeAll.ToString(), EnumResources.DropDownFirstItemTypeIncludeAll));
                        break;
                    default:
                        throw new SwitchCaseDefaultException(dropDownFirstItemType);
                }
            }
            else
            {
                switch (dropDownFirstItemType)
                {
                    case DropDownFirstItemType.None:
                        break;
                    case DropDownFirstItemType.Blank:
                        orderList.Insert(0, new KeyValuePair<string, string>(DropDownFirstItemType.Blank.ToString(), DropDownFirstItemType.Blank.ToString()));
                        break;
                    case DropDownFirstItemType.PleaseSelect:
                        orderList.Insert(0, new KeyValuePair<string, string>(DropDownFirstItemType.PleaseSelect.ToString(), DropDownFirstItemType.PleaseSelect.ToString()));
                        break;
                    case DropDownFirstItemType.IncludeAll:
                        orderList.Insert(0, new KeyValuePair<string, string>(DropDownFirstItemType.IncludeAll.ToString(), DropDownFirstItemType.IncludeAll.ToString()));
                        break;
                    default:
                        throw new SwitchCaseDefaultException(dropDownFirstItemType);
                }
            }

            return orderList.ToDictionary(x => x.Key, x => x.Value);
        }

        internal static bool ShouldEnumValueBeSkipped(
            object objEnumValue,
            bool includeDefault,
            bool hasFlagAttribute,
            bool byFlagIncludeBase,
            bool byFlagIncludeCombined)
        {
            if (!includeDefault && (int)objEnumValue == 0)
            {
                return true;
            }

            if (!hasFlagAttribute)
            {
                return false;
            }

            var n = (int)objEnumValue;
            if (!byFlagIncludeBase && n.IsBinarySequence())
            {
                return true;
            }

            if (byFlagIncludeCombined)
            {
                return false;
            }

            if (n.IsBinarySequence())
            {
                return false;
            }

            return !includeDefault || (int)objEnumValue != 0;
        }
    }
}