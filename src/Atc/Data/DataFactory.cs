using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using Atc.Helpers;
using Atc.Resources;

namespace Atc.Data
{
    /// <summary>
    /// Data Helper.
    /// </summary>
    public static class DataFactory
    {
        /// <summary>
        /// Create the key/value data table of integer and string.
        /// </summary>
        /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
        /// <returns>
        /// The <see cref="DataTable" />.
        /// </returns>
        public static DataTable CreateKeyValueDataTableOfIntString(DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None)
        {
            var dt = new DataTable
            {
                Locale = CultureInfo.InvariantCulture,
            };

            dt.Columns.Add("key", typeof(int));
            dt.Columns.Add("value", typeof(string));
            dt.PrimaryKey = new[] { dt.Columns["key"] };
            dt.AcceptChanges();

            DataRow dr;
            switch (dropDownFirstItemType)
            {
                case DropDownFirstItemType.None:
                    break;
                case DropDownFirstItemType.Blank:
                    dr = dt.NewRow();
                    dr["key"] = (int)DropDownFirstItemType.Blank;
                    dr["value"] = string.Empty;
                    dt.Rows.Add(dr);
                    break;
                case DropDownFirstItemType.PleaseSelect:
                    dr = dt.NewRow();
                    dr["key"] = (int)DropDownFirstItemType.PleaseSelect;
                    dr["value"] = EnumResources.DropDownFirstItemTypePleaseSelect;
                    dt.Rows.Add(dr);
                    break;
                case DropDownFirstItemType.IncludeAll:
                    dr = dt.NewRow();
                    dr["key"] = (int)DropDownFirstItemType.IncludeAll;
                    dr["value"] = EnumResources.DropDownFirstItemTypeIncludeAll;
                    dt.Rows.Add(dr);
                    break;
                default:
                    throw new SwitchCaseDefaultException(dropDownFirstItemType);
            }

            return dt;
        }

        /// <summary>
        /// Create the key/value data table of global identifier and string.
        /// </summary>
        /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
        /// <returns>
        /// The <see cref="DataTable" />.
        /// </returns>
        public static DataTable CreateKeyValueDataTableOfGuidString(DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None)
        {
            var dt = new DataTable
            {
                Locale = CultureInfo.InvariantCulture,
            };

            dt.Columns.Add("key", typeof(Guid));
            dt.Columns.Add("value", typeof(string));
            dt.PrimaryKey = new[] { dt.Columns["key"] };
            dt.AcceptChanges();

            DataRow dr;
            switch (dropDownFirstItemType)
            {
                case DropDownFirstItemType.None:
                    break;
                case DropDownFirstItemType.Blank:
                    dr = dt.NewRow();
                    dr["key"] = DropDownFirstItemTypeHelper.GetEnumGuid(DropDownFirstItemType.Blank);
                    dr["value"] = string.Empty;
                    dt.Rows.Add(dr);
                    break;
                case DropDownFirstItemType.PleaseSelect:
                    dr = dt.NewRow();
                    dr["key"] = DropDownFirstItemTypeHelper.GetEnumGuid(DropDownFirstItemType.PleaseSelect);
                    dr["value"] = EnumResources.DropDownFirstItemTypePleaseSelect;
                    dt.Rows.Add(dr);
                    break;
                case DropDownFirstItemType.IncludeAll:
                    dr = dt.NewRow();
                    dr["key"] = DropDownFirstItemTypeHelper.GetEnumGuid(DropDownFirstItemType.IncludeAll);
                    dr["value"] = EnumResources.DropDownFirstItemTypeIncludeAll;
                    dt.Rows.Add(dr);
                    break;
                default:
                    throw new SwitchCaseDefaultException(dropDownFirstItemType);
            }

            return dt;
        }

        /// <summary>
        /// Create the key/value dictionary of integer and string.
        /// </summary>
        /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
        /// <returns>
        /// The Dictionary.
        /// </returns>
        public static Dictionary<int, string> CreateKeyValueDictionaryOfIntString(DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None)
        {
            var dictionary = new Dictionary<int, string>();
            switch (dropDownFirstItemType)
            {
                case DropDownFirstItemType.None:
                    break;
                case DropDownFirstItemType.Blank:
                    dictionary.Add(
                        (int)DropDownFirstItemType.Blank,
                        string.Empty);
                    break;
                case DropDownFirstItemType.PleaseSelect:
                    dictionary.Add(
                        (int)DropDownFirstItemType.PleaseSelect,
                        EnumResources.DropDownFirstItemTypePleaseSelect);
                    break;
                case DropDownFirstItemType.IncludeAll:
                    dictionary.Add(
                        (int)DropDownFirstItemType.IncludeAll,
                        EnumResources.DropDownFirstItemTypeIncludeAll);
                    break;
                default:
                    throw new SwitchCaseDefaultException(dropDownFirstItemType);
            }

            return dictionary;
        }

        /// <summary>
        /// Create the key/value dictionary of global identifier and string.
        /// </summary>
        /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
        /// <returns>
        /// The Dictionary.
        /// </returns>
        public static Dictionary<Guid, string> CreateKeyValueDictionaryOfGuidString(DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None)
        {
            var dictionary = new Dictionary<Guid, string>();
            switch (dropDownFirstItemType)
            {
                case DropDownFirstItemType.None:
                    break;
                case DropDownFirstItemType.Blank:
                    dictionary.Add(
                        DropDownFirstItemTypeHelper.GetEnumGuid(DropDownFirstItemType.Blank),
                        string.Empty);
                    break;
                case DropDownFirstItemType.PleaseSelect:
                    dictionary.Add(
                        DropDownFirstItemTypeHelper.GetEnumGuid(DropDownFirstItemType.PleaseSelect),
                        EnumResources.DropDownFirstItemTypePleaseSelect);
                    break;
                case DropDownFirstItemType.IncludeAll:
                    dictionary.Add(
                        DropDownFirstItemTypeHelper.GetEnumGuid(DropDownFirstItemType.IncludeAll),
                        EnumResources.DropDownFirstItemTypeIncludeAll);
                    break;
                default:
                    throw new SwitchCaseDefaultException(dropDownFirstItemType);
            }

            return dictionary;
        }

        /// <summary>
        /// Creates the key value dictionary of string string.
        /// </summary>
        /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
        /// <returns>
        /// The Dictionary.
        /// </returns>
        public static Dictionary<string, string> CreateKeyValueDictionaryOfStringString(DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None)
        {
            var dictionary = new Dictionary<string, string>(StringComparer.Ordinal);
            switch (dropDownFirstItemType)
            {
                case DropDownFirstItemType.None:
                    break;
                case DropDownFirstItemType.Blank:
                    dictionary.Add(
                        DropDownFirstItemType.Blank.ToString(),
                        string.Empty);
                    break;
                case DropDownFirstItemType.PleaseSelect:
                    dictionary.Add(
                        DropDownFirstItemType.PleaseSelect.ToString(),
                        EnumResources.DropDownFirstItemTypePleaseSelect);
                    break;
                case DropDownFirstItemType.IncludeAll:
                    dictionary.Add(
                        DropDownFirstItemType.IncludeAll.ToString(),
                        EnumResources.DropDownFirstItemTypeIncludeAll);
                    break;
                default:
                    throw new SwitchCaseDefaultException(dropDownFirstItemType);
            }

            return dictionary;
        }
    }
}