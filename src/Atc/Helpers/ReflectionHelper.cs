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
    /// <exception cref="ArgumentNullException">Thrown if the target or field name is null.</exception>
    /// <exception cref="ArgumentException">Thrown if the private field is not found in the object hierarchy.</exception>
    [SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "Reflection required for testing private fields.")]
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
    /// <exception cref="ArgumentNullException">Thrown if the target or field name is null.</exception>
    /// <exception cref="ArgumentException">Thrown if the private field is not found in the object hierarchy.</exception>
    [SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "Reflection required for testing private fields.")]
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

        return (T?)fieldInfo.GetValue(target);
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
            if (fieldInfo != null)
            {
                return fieldInfo;
            }

            type = type.BaseType;
        }

        return null;
    }
}