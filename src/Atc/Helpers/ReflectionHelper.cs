// ReSharper disable ReturnTypeCanBeNotNullable
namespace Atc.Helpers;

/// <summary>
/// ReflectionHelper.
/// </summary>
public static class ReflectionHelper
{
    /// <summary>
    /// Sets the value of a private field on the specified target object.
    /// </summary>
    /// <param name="target">The target object containing the private field.</param>
    /// <param name="fieldName">The name of the private field to set.</param>
    /// <param name="value">The value to set on the private field.</param>
    [SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "OK.")]
    [ExcludeFromCodeCoverage]
    public static void SetPrivateField(object target, string fieldName, object value)
    {
        if (target is null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        if (string.IsNullOrEmpty(fieldName))
        {
            throw new ArgumentException("Field name cannot be null or empty", nameof(fieldName));
        }

        var fieldInfo = GetFieldInfo(target, fieldName);
        if (fieldInfo is null)
        {
            throw new ArgumentPropertyException($"Field '{fieldName}' not found in type '{target.GetType()}' or its base types.");
        }

        fieldInfo.SetValue(target, value);
    }

    /// <summary>
    /// Gets the value of a private field from the specified target object.
    /// </summary>
    /// <typeparam name="T">The type of the field value.</typeparam>
    /// <param name="target">The target object containing the private field.</param>
    /// <param name="fieldName">The name of the private field to retrieve.</param>
    /// <returns>The value of the private field, cast to the specified type.</returns>
    [SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "OK.")]
    [ExcludeFromCodeCoverage]
    public static T? GetPrivateField<T>(object target, string fieldName)
    {
        if (target is null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        if (string.IsNullOrEmpty(fieldName))
        {
            throw new ArgumentException("Field name cannot be null or empty", nameof(fieldName));
        }

        var fieldInfo = GetFieldInfo(target, fieldName);
        if (fieldInfo is null)
        {
            throw new ArgumentPropertyException($"Field '{fieldName}' not found in type '{target.GetType()}' or its base types.");
        }

        if (fieldInfo.GetValue(target) is not T fieldValue)
        {
            throw new InvalidCastException($"Field '{fieldName}' found in type '{target.GetType()}', but cannot be cast to type '{typeof(T)}'.");
        }

        return fieldValue;
    }

    /// <summary>
    /// Retrieves FieldInfo for a private field by name, traversing the inheritance hierarchy.
    /// </summary>
    /// <param name="target">The target object containing the private field.</param>
    /// <param name="fieldName">The name of the private field.</param>
    /// <returns>FieldInfo object representing the field, or null if not found.</returns>
    [SuppressMessage("Major Code Smell", "S3011:Make sure that this accessibility bypass is safe here", Justification = "OK.")]
    private static FieldInfo? GetFieldInfo(object target, string fieldName)
    {
        var type = target.GetType();
        while (type is not null)
        {
            var fieldInfo = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            if (fieldInfo is not null)
            {
                return fieldInfo;
            }

            type = type.BaseType;
        }

        return null;
    }
}