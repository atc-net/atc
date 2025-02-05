// ReSharper disable once CheckNamespace
namespace System.Reflection;

/// <summary>
/// Extensions for the <see cref="FieldInfo"/> class.
/// </summary>
public static class FieldInfoExtensions
{
    /// <summary>
    /// Beautifies the name.
    /// </summary>
    /// <param name="fieldInfo">The field information.</param>
    /// <param name="useFullName">if set to <see langword="true" /> [use full name].</param>
    /// <param name="useHtmlFormat">if set to <see langword="true" /> [use HTML format].</param>
    /// <param name="includeReturnType">if set to <see langword="true" /> [include return type].</param>
    public static string BeautifyName(this FieldInfo fieldInfo, bool useFullName = false, bool useHtmlFormat = false, bool includeReturnType = false)
    {
        if (fieldInfo is null)
        {
            throw new ArgumentNullException(nameof(fieldInfo));
        }

        return includeReturnType
            ? $"{fieldInfo.FieldType.BeautifyName(useFullName, useHtmlFormat)} {fieldInfo.Name}"
            : fieldInfo.Name;
    }
}