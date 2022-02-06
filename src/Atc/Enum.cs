namespace Atc;

/// <summary>
/// Extension methods for enums.
/// </summary>
/// <typeparam name="T">The generic enum type.</typeparam>
[SuppressMessage("Design", "MA0018:Do not declare static members on generic types", Justification = "OK.")]
[SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "OK.")]
[SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "OK.")]
public static class Enum<T>
    where T : Enum
{
    /// <summary>Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.</summary>
    /// <param name="value">A string containing the name or value to convert.</param>
    /// <param name="ignoreCase">true to ignore case; false to regard case.</param>
    /// <returns>If parsed successfully and defined as a valid enum value, the enum value is returned. Otherwise the default value is returned.</returns>
    /// <code><![CDATA[DayOfWeek day = Enum<DayOfWeek>.GetEnumValue(value);]]></code>
    /// <example><![CDATA[
    /// Assert.Equal(DayOfWeek.Monday, Enum<DayOfWeek>.GetEnumValue("Monday"));
    /// Assert.Equal(DayOfWeek.Monday, Enum<DayOfWeek>.GetEnumValue("MONDAY"));
    /// ]]></example>
    public static T GetEnumValue(string value, bool ignoreCase = true)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Length == default)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }

        if (!TryParse(value, ignoreCase, out var returnedValue))
        {
            return default!;
        }

        return (Enum.IsDefined(typeof(T), returnedValue)
            ? returnedValue
            : default)!;
    }

    /// <summary>Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.</summary>
    /// <param name="value">A string containing the name or value to convert.</param>
    /// <param name="ignoreCase">true to ignore case; false to regard case.</param>
    /// <param name="returnedValue">When this method returns, contains the enum value, if the conversion succeeded, or default enum if the conversion failed.</param>
    /// <returns>If parsed successfully and defined as a valid enum value, the enum value is returned. Otherwise the default value is returned.</returns>
    /// <code><![CDATA[bool isParsed = Enum<DayOfWeek>.TryGetEnumValue(value, ignoreCase, out var dayOfWeek);]]></code>
    /// <example><![CDATA[
    /// DayOfWeek expectedOut;
    /// bool isParsed = Enum<DayOfWeek>.TryGetEnumValue("Monday", true, out var dayOfWeek);
    /// Assert.True(isParsed);
    /// Assert.Equal(expectedOut, dayOfWeek);
    /// ]]></example>
    public static bool TryGetEnumValue(string value, bool ignoreCase, out T returnedValue)
    {
        if (!string.IsNullOrEmpty(value))
        {
            return TryParse(value, ignoreCase, out returnedValue);
        }

        returnedValue = default!;
        return false;
    }

    /// <summary>Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.</summary>
    /// <param name="value">A string containing the name or value to convert.</param>
    /// <param name="returnedValue">When this method returns, contains the enum value, if the conversion succeeded, or default enum if the conversion failed.</param>
    /// <returns>If parsed successfully and defined as a valid enum value, the enum value is returned. Otherwise the default value is returned.</returns>
    /// <code><![CDATA[bool isParsed = Enum<DayOfWeek>.TryGetEnumValue(value, out var dayOfWeek);]]></code>
    /// <example><![CDATA[
    /// DayOfWeek expectedOut;
    /// bool isParsed = Enum<DayOfWeek>.TryGetEnumValue("Monday", out var dayOfWeek);
    /// Assert.True(isParsed);
    /// Assert.Equal(expectedOut, dayOfWeek);
    /// ]]></example>
    public static bool TryGetEnumValue(Enum? value, out T returnedValue)
    {
        returnedValue = default!;
        return value is not null && TryGetEnumValue(value.ToString(), false, out returnedValue);
    }

    /// <summary>Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.</summary>
    /// <param name="value">A string containing the name or value to convert.</param>
    /// <param name="ignoreCase">true to ignore case; false to regard case.</param>
    /// <returns>An object of type enumType whose value is represented by value.</returns>
    /// <code><![CDATA[DayOfWeek day = Enum<DayOfWeek>.Parse(value);]]></code>
    /// <example><![CDATA[
    /// Assert.Equal(DayOfWeek.Monday, Enum<DayOfWeek>.Parse("Monday"));
    /// ]]></example>
    public static T Parse(string value, bool ignoreCase = true)
    {
        return (T)Enum.Parse(typeof(T), value, ignoreCase);
    }

    /// <summary>Converts the string representation of a enum. A return value indicates whether the conversion succeeded.</summary>
    /// <param name="value">A string containing a enum to convert.</param>
    /// <param name="returnedValue">When this method returns, contains the enum value, if the conversion succeeded, or default enum if the conversion failed.</param>
    /// <returns>true if the value was converted successfully; otherwise, false.</returns>
    /// <code><![CDATA[bool isParsed = Enum<DayOfWeek>.TryParse(value, out var dayOfWeek);]]></code>
    /// <example><![CDATA[
    /// DayOfWeek expectedOut;
    /// bool isParsed = Enum<DayOfWeek>.TryParse("Monday", out var dayOfWeek);
    /// Assert.True(isParsed);
    /// Assert.Equal(expectedOut, dayOfWeek);
    /// ]]></example>
    public static bool TryParse(string value, out T returnedValue)
    {
        return TryParse(value, true, out returnedValue);
    }

    /// <summary>Converts the string representation of a enum. A return value indicates whether the conversion succeeded.</summary>
    /// <param name="value">A string containing a enum to convert.</param>
    /// <param name="ignoreCase">true to ignore case; false to regard case.</param>
    /// <param name="returnedValue">When this method returns, contains the enum value, if the conversion succeeded, or default enum if the conversion failed.</param>
    /// <returns>true if the value was converted successfully; otherwise, false.</returns>
    /// <code><![CDATA[bool isParsed = Enum<DayOfWeek>.TryParse(value, ignoreCase, out var dayOfWeek);]]></code>
    /// <example><![CDATA[
    /// DayOfWeek expectedOut;
    /// bool isParsed = Enum<DayOfWeek>.TryParse("Monday", true, out var dayOfWeek);
    /// Assert.True(isParsed);
    /// Assert.Equal(expectedOut, dayOfWeek);
    /// ]]></example>
    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    public static bool TryParse(string value, bool ignoreCase, out T returnedValue)
    {
        try
        {
            returnedValue = (T)Enum.Parse(typeof(T), value, ignoreCase);
            return true;
        }
        catch
        {
            returnedValue = default!;
            return false;
        }
    }

    /// <summary>Converts the enum to array.</summary>
    /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
    /// <param name="useDescriptionAttribute">true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.</param>
    /// <param name="includeDefault">true to include the default enumeration value; false to skip it.</param>
    /// <param name="sortDirectionType">Type of the sort direction.</param>
    /// <param name="byFlagIncludeBase">if set to <c>true</c> [by flag include base].</param>
    /// <param name="byFlagIncludeCombined">if set to <c>true</c> [by flag include combined].</param>
    /// <returns>An array of names from the enum.</returns>
    /// <code><![CDATA[Array array = Enum<DayOfWeek>.ToArray();]]></code>
    /// <example><![CDATA[
    /// Array array = Enum<DayOfWeek>.ToArray();
    /// Assert.Equal(7, array.Length);
    /// ]]></example>
    public static Array ToArray(
        DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None,
        bool useDescriptionAttribute = true,
        bool includeDefault = true,
        SortDirectionType sortDirectionType = SortDirectionType.None,
        bool byFlagIncludeBase = true,
        bool byFlagIncludeCombined = true)
    {
        var dictionary = ToDictionary(
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

    /// <summary>Converts the enum to dictionary.</summary>
    /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
    /// <param name="useDescriptionAttribute">true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.</param>
    /// <param name="includeDefault">true to include the default enumeration value; false to skip it.</param>
    /// <param name="sortDirectionType">Type of the sort direction.</param>
    /// <param name="byFlagIncludeBase">if set to <c>true</c> [by flag include base].</param>
    /// <param name="byFlagIncludeCombined">if set to <c>true</c> [by flag include combined].</param>
    /// <returns>An dictionary of enum values as int and names from the enum.</returns>
    /// <code><![CDATA[Dictionary<int, string> dictionary = Enum<DayOfWeek>.ToDictionary();]]></code>
    /// <example><![CDATA[
    /// Dictionary<int, string> dictionary = Enum<DayOfWeek>.ToDictionary();
    /// Assert.Equal(7, dictionary.Count);
    /// ]]></example>
    public static Dictionary<int, string> ToDictionary(
        DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None,
        bool useDescriptionAttribute = true,
        bool includeDefault = true,
        SortDirectionType sortDirectionType = SortDirectionType.None,
        bool byFlagIncludeBase = true,
        bool byFlagIncludeCombined = true)
    {
        return EnumHelper.ConvertEnumToDictionary(
            typeof(T),
            dropDownFirstItemType,
            useDescriptionAttribute,
            includeDefault,
            sortDirectionType,
            byFlagIncludeBase,
            byFlagIncludeCombined);
    }

    /// <summary>Converts the enum to dictionary with key as string.</summary>
    /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
    /// <param name="useDescriptionAttribute">true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.</param>
    /// <param name="includeDefault">true to include the default enumeration value; false to skip it.</param>
    /// <param name="sortDirectionType">Type of the sort direction.</param>
    /// <param name="byFlagIncludeBase">if set to <c>true</c> [by flag include base].</param>
    /// <param name="byFlagIncludeCombined">if set to <c>true</c> [by flag include combined].</param>
    /// <returns>An dictionary of enum values as string and names from the enum.</returns>
    /// <code><![CDATA[Dictionary<string, string> dictionary = Enum<DayOfWeek>.ToDictionaryWithStringKey();]]></code>
    /// <example><![CDATA[
    /// Dictionary<string, string> dictionary = Enum<DayOfWeek>.ToDictionaryWithStringKey();
    /// Assert.Equal(7, dictionary.Count);
    /// ]]></example>
    public static Dictionary<string, string> ToDictionaryWithStringKey(
        DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None,
        bool useDescriptionAttribute = true,
        bool includeDefault = true,
        SortDirectionType sortDirectionType = SortDirectionType.None,
        bool byFlagIncludeBase = true,
        bool byFlagIncludeCombined = true)
    {
        return EnumHelper.ConvertEnumToDictionaryWithStringKey(
            typeof(T),
            dropDownFirstItemType,
            useDescriptionAttribute,
            includeDefault,
            sortDirectionType,
            byFlagIncludeBase,
            byFlagIncludeCombined);
    }

    /// <summary>Converts the enum to list of key value pairs.</summary>
    /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
    /// <param name="useDescriptionAttribute">true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.</param>
    /// <param name="includeDefault">true to include the default enumeration value; false to skip it.</param>
    /// <param name="sortDirectionType">Type of the sort direction.</param>
    /// <param name="byFlagIncludeBase">if set to <c>true</c> [by flag include base].</param>
    /// <param name="byFlagIncludeCombined">if set to <c>true</c> [by flag include combined].</param>
    /// <returns>An list of KeyValuePair of the enum with the key as int.</returns>
    /// <code><![CDATA[List<KeyValuePair<int, string>> list = Enum<DayOfWeek>.ToKeyValuePairs();]]></code>
    /// <example><![CDATA[
    /// List<KeyValuePair<int, string>> list = Enum<DayOfWeek>.ToKeyValuePairs();
    /// Assert.Equal(7, list.Count);
    /// ]]></example>
    public static List<KeyValuePair<int, string>> ToKeyValuePairs(
        DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None,
        bool useDescriptionAttribute = true,
        bool includeDefault = true,
        SortDirectionType sortDirectionType = SortDirectionType.None,
        bool byFlagIncludeBase = true,
        bool byFlagIncludeCombined = true)
    {
        var dictionary = ToDictionary(
            dropDownFirstItemType,
            useDescriptionAttribute,
            includeDefault,
            sortDirectionType,
            byFlagIncludeBase,
            byFlagIncludeCombined);

        return dictionary
            .Select(pair => new KeyValuePair<int, string>(pair.Key, pair.Value))
            .ToList();
    }

    /// <summary>Converts the enum to list of key value pairs with key as string.</summary>
    /// <param name="dropDownFirstItemType">Type of the drop down first item.</param>
    /// <param name="useDescriptionAttribute">true to use the display/description/localizeddescription attribute value if exist, default value is name; false to just use the name value.</param>
    /// <param name="includeDefault">true to include the default enumeration value; false to skip it.</param>
    /// <param name="sortDirectionType">Type of the sort direction.</param>
    /// <param name="byFlagIncludeBase">if set to <c>true</c> [by flag include base].</param>
    /// <param name="byFlagIncludeCombined">if set to <c>true</c> [by flag include combined].</param>
    /// <returns>An list of KeyValuePair of the enum with the key as string.</returns>
    /// <code><![CDATA[List<KeyValuePair<string, string>> list = Enum<DayOfWeek>.ToKeyValuePairsWithStringKey();]]></code>
    /// <example><![CDATA[
    /// List<KeyValuePair<int, string>> list = Enum<DayOfWeek>.ToKeyValuePairsWithStringKey();
    /// Assert.Equal(7, list.Count);
    /// ]]></example>
    public static List<KeyValuePair<string, string>> ToKeyValuePairsWithStringKey(
        DropDownFirstItemType dropDownFirstItemType = DropDownFirstItemType.None,
        bool useDescriptionAttribute = true,
        bool includeDefault = true,
        SortDirectionType sortDirectionType = SortDirectionType.None,
        bool byFlagIncludeBase = true,
        bool byFlagIncludeCombined = true)
    {
        var dictionary = ToDictionaryWithStringKey(
            dropDownFirstItemType,
            useDescriptionAttribute,
            includeDefault,
            sortDirectionType,
            byFlagIncludeBase,
            byFlagIncludeCombined);

        return dictionary
            .Select(pair => new KeyValuePair<string, string>(pair.Key, pair.Value))
            .ToList();
    }
}